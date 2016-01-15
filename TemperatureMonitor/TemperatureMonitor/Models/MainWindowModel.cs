using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Catel.Data;
using Catel.MVVM;
using TemperatureMonitor.Data;
using TemperatureMonitor.Models;
using TemperatureMonitor.ViewModels;
using System.Runtime.Serialization;

namespace TemperatureMonitor.Models
{
    [Serializable]
    public class MainWindowModel : ModelBase
    {
        #region Constructor & destructor

        /// <summary>
        /// Initializes a new instance of the MainWindowModel class.
        /// </summary>
        public MainWindowModel()
            : base()
        {
            GetData();
        }

        protected MainWindowModel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the States collection.
        /// </summary>
        public ObservableCollection<State> States
        {
            get { return GetValue<ObservableCollection<State>>(StatesProperty); }
            set { SetValue(StatesProperty, value); }
        }

        /// <summary>
        /// Register the States property so it is known in the class.
        /// </summary>
        public static readonly PropertyData StatesProperty = RegisterProperty("States", typeof(ObservableCollection<State>));

        /// <summary>
        /// Gets or sets the selected state value.
        /// </summary>
        public State SelectedState
        {
            get { return GetValue<State>(SelectedStateProperty); }
            set { SetValue(SelectedStateProperty, value); }
        }

        /// <summary>
        /// Register the SelectedState property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedStateProperty = RegisterProperty("SelectedState", typeof(State), null, (sender, e) => ((MainWindowModel)sender).OnSelectedStatePropertyChanged());

        private void OnSelectedStatePropertyChanged()
        {
            if (SelectedState != null)
                SelectedCity = SelectedState.Cities[0];
        }

        /// <summary>
        /// Gets or sets the SelectedCity property value.
        /// </summary>
        public City SelectedCity
        {
            get { return GetValue<City>(SelectedCityProperty); }
            set { SetValue(SelectedCityProperty, value); }
        }

        /// <summary>
        /// Register the SelectedCity property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedCityProperty = RegisterProperty("SelectedCity", typeof(City), null, (sender, e) => ((MainWindowModel)sender).OnSelectedCityPropertyChanged());

        private void OnSelectedCityPropertyChanged()
        {
            if (SelectedCity != null)
                UpdatePredictedTemperature();
        }

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        public DateTime SelectedDate
        {
            get { return GetValue<DateTime>(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        /// <summary>
        /// Register the SelectedDate property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedDateProperty = RegisterProperty("SelectedDate", typeof(DateTime), null, (sender, e) => ((MainWindowModel)sender).OnSelectedDatePropertyChanged());

        private void OnSelectedDatePropertyChanged()
        {
            if (SelectedDate != null)
                UpdatePredictedTemperature();
        }

        /// <summary>
        /// Gets or sets the ActualTemperature property value.
        /// </summary>
        public string ActualTemperature
        {
            get { return GetValue<string>(ActualTemperatureProperty); }
            set { SetValue(ActualTemperatureProperty, value); }
        }

        /// <summary>
        /// Register the ActualTemperature property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ActualTemperatureProperty = RegisterProperty("ActualTemperature", typeof(string), "0");

        /// <summary>
        /// Gets or sets the PredictedTemperature property value.
        /// </summary>
        public string PredictedTemperature
        {
            get { return GetValue<string>(PredictedTemperatureProperty); }
            set { SetValue(PredictedTemperatureProperty, value); }
        }

        /// <summary>
        /// Register the PredictedTemperature property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PredictedTemperatureProperty = RegisterProperty("PredictedTemperature", typeof(string));

        /// <summary>
        /// Gets or sets the Variance property value.
        /// </summary>
        public string Variance
        {
            get { return GetValue<string>(VarianceProperty); }
            set { SetValue(VarianceProperty, value); }
        }

        /// <summary>
        /// Register the Variance property so it is known in the class.
        /// </summary>
        public static readonly PropertyData VarianceProperty = RegisterProperty("Variance", typeof(string), "0");

        #endregion

        #region Methods
        // TODO: Create your methods here

        public void GetData()
        {
            SuspendValidation = true;

            States = new ObservableCollection<State>();
            foreach (var state in ListOfStates.States)
            {
                States.Add(state);
            }

            Reset();

            SuspendValidation = false;
        }

        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            bool isActualTemperatureValid = true;
            double tempActualTemperature;

            if (string.IsNullOrWhiteSpace(ActualTemperature))
                isActualTemperatureValid = false;
            else if (double.TryParse(ActualTemperature, out tempActualTemperature) == false)
                isActualTemperatureValid = false;

            if (isActualTemperatureValid == false)
                validationResults.Add(FieldValidationResult.CreateError(ActualTemperatureProperty, "Actual Temperature value is not valid."));

            if (SelectedCity != null && SelectedDate != null)
            {
                var currentPredictedTemperatureQuery =
                    from t in SelectedCity.TemperatureCollection
                    where SelectedDate.Date.CompareTo(t.DateOfTemperature) == 0
                    select t;
                if (currentPredictedTemperatureQuery.Count() == 0)
                    validationResults.Add(FieldValidationResult.CreateError(PredictedTemperatureProperty, "Temperature data not available for the selected city in the selected date.\nPlease enter value for selected date between " + SelectedCity.TemperatureCollection.First().DateOfTemperature.ToShortDateString() + " and " + SelectedCity.TemperatureCollection.Last().DateOfTemperature.ToShortDateString() + "."));
            }
        }

        public void UpdatePredictedTemperature()
        {
            var currentPredictedTemperatureQuery =
                from t in SelectedCity.TemperatureCollection
                where SelectedDate.Date.CompareTo(t.DateOfTemperature) == 0
                select t;
            if (currentPredictedTemperatureQuery.Count() > 0)
                PredictedTemperature = currentPredictedTemperatureQuery.First().Temperature.ToString();
        }

        public void CalculateVariance()
        {
            double temp = double.Parse(ActualTemperature) - double.Parse(PredictedTemperature);

            if (temp >= 0)
                Variance = temp.ToString();
            else
                Variance = "(" + (-temp).ToString() + ")";
        }

        public void Reset()
        {
            SelectedState = States[0];
            SelectedCity = SelectedState.Cities[0];
            SelectedDate = SelectedCity.TemperatureCollection.First().DateOfTemperature;
            ActualTemperature = "0";
        }

        #endregion
    }
}
