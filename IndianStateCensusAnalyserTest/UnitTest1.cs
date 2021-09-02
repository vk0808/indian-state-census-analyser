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
        static string indianStateCodeHeaders = @"SrNo,State Name,TIN,StateCode";

        // Files - 1.x
        static string indianStateCensusFilePath = @"../../../CsvFiles/IndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"../../../CsvFiles/Utility/WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"../../../CsvFiles/IndiaStateCensusData.txt";
        static string IndianStateCensusFilePathWithWrongDelimeter = @"../../../CsvFiles/DelimiterIndiaStateCensusData.csv";
        static string IndianStateCensusFilePathWithWrongHeader = @"../../../CsvFiles/WrongIndiaStateCensusData.csv";

        // Files - 2.x
        static string indianStateCodePath = @"../../../CsvFiles/IndiaStateCode.csv";
        static string WrongIndianStateCodeFilePath = @"../../../CsvFiles/Utility/WrongIndiaStateCode.csv";
        static string WrongIndianStateCodeFileTypePath = @"../../../CsvFiles/IndiaStateCode.txt";
        static string IndianStateCodeFilePathWrongDelimeter = @"../../../CsvFiles/DelimiterIndiaStateCode.csv";
        static string IndianStateCodeFilePathWrongHeader = @"../../../CsvFiles/WrongIndiaStateCode.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecords;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();
        }

        // Test case - 1.1
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(3, totalRecord.Count);
        }

        // Test case - 1.2
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        // Test case - 1.3
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        // Test case - 1.4
        [Test]
        public void GivenIndianCensusDataFile_WhenDelimeterNotProper_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCensusFilePathWithWrongDelimeter, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        // Test case - 1.5
        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCensusFilePathWithWrongHeader, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }


        // Test case - 2.1
        [Test]
        public void GivenIndianStateCodeFile_WhenRead_ShouldReturnCensusDataCount()
        {
            stateRecords = censusAnalyser.LoadCensusData(indianStateCodePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(3, stateRecords.Count);
        }

        // Test case - 2.2
        [Test]
        public void GivenWrongStateCodeFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        // Test case - 2.3
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongIndianStateCodeFileTypePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }

        // Test case - 2.4
        [Test]
        public void GivenIndianStateCodeFile_WhenDelimeterNotProper_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCodeFilePathWrongDelimeter, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }

        // Test case - 2.5
        [Test]
        public void GivenIndianStateCodeFile_WhenHeaderNotProper_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCodeFilePathWrongHeader, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}