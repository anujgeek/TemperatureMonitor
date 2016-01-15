namespace TemperatureMonitor.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Catel.Data;
    using Catel.MVVM;
    using Models;
    using System.ComponentModel;
    public class MainWindowViewModel : ViewModelBase
    {

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
            : base()
        {
            MainWindowModel = new MainWindowModel();

            CalculateVarianceCommand = new Command(OnCalculateVarianceCommandExecute, OnCalculateVarianceCommandCanExecute);
            ResetCommand = new Command(OnResetCommandExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "US National Weather Service - Temperature Monitor - By Anuj Agrawal"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets

        /// <summary>
        /// Gets or sets the MainWindowModel value.
        /// </summary>
        [Model]
        public MainWindowModel MainWindowModel
        {
            get { return GetValue<MainWindowModel>(MainWindowModelProperty); }
            private set { SetValue(MainWindowModelProperty, value); }
        }

        /// <summary>
        /// Register the MainWindowModel property so it is known in the class.
        /// </summary>
        public static readonly PropertyData MainWindowModelProperty = RegisterProperty("MainWindowModel", typeof(MainWindowModel));

        #region View Model Properties

        /// <summary>
        /// Gets or sets the States collection.
        /// </summary>
        [ViewModelToModel("MainWindowModel")]
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
        [ViewModelToModel("MainWindowModel")]
        public State SelectedState
        {
            get { return GetValue<State>(SelectedStateProperty); }
            set { SetValue(SelectedStateProperty, value); }
        }

        /// <summary>
        /// Register the SelectedState property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedStateProperty = RegisterProperty("SelectedState", typeof(State));

        /// <summary>
        /// Gets or sets the SelectedCity property value.
        /// </summary>
        [ViewModelToModel("MainWindowModel")]
        public City SelectedCity
        {
            get { return GetValue<City>(SelectedCityProperty); }
            set { SetValue(SelectedCityProperty, value); }
        }

        /// <summary>
        /// Register the SelectedCity property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedCityProperty = RegisterProperty("SelectedCity", typeof(City));

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        [ViewModelToModel("MainWindowModel")]
        public DateTime SelectedDate
        {
            get { return GetValue<DateTime>(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        /// <summary>
        /// Register the SelectedDate property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedDateProperty = RegisterProperty("SelectedDate", typeof(DateTime));

        /// <summary>
        /// Gets or sets the ActualTemperature property value.
        /// </summary>
        [ViewModelToModel("MainWindowModel")]
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
        [ViewModelToModel("MainWindowModel")]
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
        [ViewModelToModel("MainWindowModel")]
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

        #endregion

        #region Commands
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        /// <summary>
        /// Gets the CalculateVarianceCommand command.
        /// </summary>
        public Command CalculateVarianceCommand { get; private set; }

        /// <summary>
        /// Method to check whether the CalculateVarianceCommand command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnCalculateVarianceCommandCanExecute()
        {
            if ((MainWindowModel as INotifyDataErrorInfo).HasErrors)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Method to invoke when the CalculateVarianceCommand command is executed.
        /// </summary>
        private void OnCalculateVarianceCommandExecute()
        {
            MainWindowModel.CalculateVariance();
        }

        /// <summary>
        /// Gets the ResetCommand command.
        /// </summary>
        public Command ResetCommand { get; private set; }


        /// <summary>
        /// Method to invoke when the ResetCommand command is executed.
        /// </summary>
        private void OnResetCommandExecute()
        {
            MainWindowModel.Reset();
        }

        #endregion

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
