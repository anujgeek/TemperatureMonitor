using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemperatureMonitor.Models;

namespace UnitTestProject
{
    [TestClass]
    public class MainWindowModelTest
    {
        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        /// <summary>
        ///A test for GetData
        ///</summary>
        [TestMethod()]
        public void GetDataTest()
        {
            MainWindowModel target = new MainWindowModel(); // TODO: Initialize to an appropriate value
            target.GetData();
            Assert.AreEqual(44, target.States.Count, "Data not loaded properly.");
        }

        /// <summary>
        ///A test for SelectedState
        ///</summary>
        [TestMethod()]
        public void SelectedStateTest()
        {
            MainWindowModel target = new MainWindowModel(); // TODO: Initialize to an appropriate value
            State expected = target.States[4]; // TODO: Initialize to an appropriate value
            State actual;
            target.SelectedState = expected;
            actual = target.SelectedState;
            Assert.AreEqual(expected, actual, "State object verification fail.");
        }

        /// <summary>
        ///A test for SelectedCity
        ///</summary>
        [TestMethod()]
        public void SelectedCityTest()
        {
            MainWindowModel target = new MainWindowModel(); // TODO: Initialize to an appropriate value
            City expected = target.SelectedState.Cities[0]; // TODO: Initialize to an appropriate value
            City actual;
            target.SelectedCity = expected;
            actual = target.SelectedCity;
            Assert.AreEqual(expected, actual, "City object verification fail.");
        }

        /// <summary>
        ///A test for SelectedDate
        ///</summary>
        [TestMethod()]
        public void SelectedDateTest()
        {
            MainWindowModel target = new MainWindowModel(); // TODO: Initialize to an appropriate value
            DateTime expected = target.SelectedDate; // TODO: Initialize to an appropriate value
            DateTime actual;
            target.SelectedDate = expected;
            actual = target.SelectedDate;
            Assert.AreEqual(expected, actual, "Selected Date verification failed.");
        }

        /// <summary>
        ///A test for PredictedTemperature
        ///</summary>
        [TestMethod()]
        public void PredictedTemperatureTest()
        {
            MainWindowModel target = new MainWindowModel(); // TODO: Initialize to an appropriate value
            string expected = "28"; // TODO: Initialize to an appropriate value
            string actual;
            target.PredictedTemperature = expected;
            actual = target.PredictedTemperature;
            Assert.AreEqual(expected, actual, "PredictedTemperature verification failed.");
        }

        /// <summary>
        ///A test for ActualTemperature
        ///</summary>
        [TestMethod()]
        public void ActualTemperatureTest()
        {
            MainWindowModel target = new MainWindowModel(); // TODO: Initialize to an appropriate value
            string expected = "0"; // TODO: Initialize to an appropriate value
            string actual;
            target.ActualTemperature = expected;
            actual = target.ActualTemperature;
            Assert.AreEqual(expected, actual, "ActualTemperature verification failed.");
        }

        /// <summary>
        ///A test for OnCalculateVarianceExecute
        ///</summary>
        [TestMethod()]
        public void CalculateVarianceTest()
        {
            MainWindowModel target = new MainWindowModel(); // TODO: Initialize to an appropriate value
            target.CalculateVariance();
            Assert.AreEqual("(28)", target.Variance, "Variance verification failed.");
        }

        /// <summary>
        ///A test for OnResetCommandExecute
        ///</summary>
        [TestMethod()]
        public void OnResetCommandExecuteTest()
        {
            MainWindowModel target = new MainWindowModel(); // TODO: Initialize to an appropriate value
            target.Reset();
            Assert.AreEqual("Alabama", target.SelectedState.Name, "Reset verification failed.");
        }
    }
}
