using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Catel.Data;
using System.Collections.ObjectModel;

namespace TemperatureMonitor.Models
{
    [Serializable]
    public class City
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of City.
        /// </summary>
        public City()
        {
            Name = "";
            Id = "";
            TemperatureCollection = new ObservableCollection<DateAndTemperature>();
        }

        /// <summary>
        /// Initializes a new instance of City.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <param name="stationId">The weather station id of the city.</param>
        public City(string cityName, string stationId, ObservableCollection<DateAndTemperature> temperatureCollection)
        {
            Name = cityName;
            Id = stationId;
            TemperatureCollection = temperatureCollection;
        }

        #endregion

        #region Properties

        private string _name;

        /// <summary>
        /// Name of the city.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _id;

        /// <summary>
        /// The weather station id of the city.
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private ObservableCollection<DateAndTemperature> _temperatureCollection;

        /// <summary>
        /// Gets or sets the collection of DateAndTemperature objects.
        /// </summary>
        public ObservableCollection<DateAndTemperature> TemperatureCollection
        {
            get { return _temperatureCollection; }
            set { _temperatureCollection = value; }
        }

        #endregion
    }
}
