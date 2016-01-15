using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Catel.Data;

namespace TemperatureMonitor.Models
{
    [Serializable]
    public class DateAndTemperature
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of DateAndTemperature class.
        /// </summary>
        public DateAndTemperature()
        {
            DateOfTemperature = new DateTime(2012, 2, 1);
            Temperature = 20;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateOfTemperature">The date for average temperature.</param>
        /// <param name="temperature">The temperature on a particular date.</param>
        public DateAndTemperature(DateTime dateOfTemperature, double temperature)
        {
            DateOfTemperature = dateOfTemperature;
            Temperature = temperature;
        }

        #endregion

        #region Properties

        private DateTime _dateOfTemperature;

        /// <summary>
        /// Gets or sets the date for average temperature.
        /// </summary>
        public DateTime DateOfTemperature
        {
            get { return _dateOfTemperature; }
            set { _dateOfTemperature = value; }
        }

        private double _temperature;

        /// <summary>
        /// Gets or sets the temperature on a particular date.
        /// </summary>
        public double Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        #endregion
    }
}
