using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        private string dateOne;
        private string dateTwo;

        public string DateOne { get; set; }
        public string DateTwo { get; set; }

        public DateModifier()
        {

        }

        public DateModifier(string dateOne,string dateTwo)
        {
            this.DateOne = dateOne;
            this.DateTwo = dateTwo;
        }

        public double CalculateDayDifference()
        {
            var dateO = DateTime.Parse(this.DateOne);
            var dateT = DateTime.Parse(this.DateTwo);

            return Math.Abs((dateO - dateT).TotalDays);
        }
    }
}
