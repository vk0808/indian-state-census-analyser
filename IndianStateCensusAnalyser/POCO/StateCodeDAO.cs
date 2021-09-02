using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class StateCodeDAO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        public StateCodeDAO(string number, string name, string tin, string code)
        {
            this.serialNumber = Convert.ToInt32(number);
            this.stateName = name;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = code;
        }
    }
}