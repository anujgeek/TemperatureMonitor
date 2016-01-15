using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Catel.Data;

namespace TemperatureMonitor.Models
{
    [Serializable]
    public class State
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of State.
        /// </summary>
        public State()
        {
            Name = "";
            Cities = new ObservableCollection<City>();
        }

        /// <summary>
        /// Initializes a new instance of State.
        /// </summary>
        /// <param name="name">Name of the state.</param>
        /// <param name="cities">List of cities.</param>
        public State(string name, ObservableCollection<City> cities)
        {
            Name = name;
            Cities = cities;
        }

        #endregion

        #region Properties

        private string _name;

        /// <summary>
        /// Gets or sets the name of the state.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private ObservableCollection<City> _cities;

        /// <summary>
        /// Gets or sets the collection of cities.
        /// </summary>
        public ObservableCollection<City> Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }

        #endregion
    }
}
