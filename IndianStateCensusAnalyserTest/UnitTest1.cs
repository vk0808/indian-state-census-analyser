using NUnit.Framework;
using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";

        // Files - 1.x
        static string indianStateCensusFilePath = @"../../../CsvFiles/IndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"../../../CsvFiles/Utility/WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"../../../CsvFiles/IndiaStateCensusData.txt";
        static string IndianStateCensusFilePathWithWrongDelimeter = @"../../../CsvFiles/DelimiterIndiaStateCensusData.csv";
        static string IndianStateCensusFilePathWithWrongHeader = @"../../../CsvFiles/WrongIndiaStateCensusData.csv";
        
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(3, totalRecord.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenDelimeterNotProper_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCensusFilePathWithWrongDelimeter, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
    }
}