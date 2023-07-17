using NUnit.Framework;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests

{
    [TestFixture]
    public class SensorTests
    {
        private ISensor _sensor;

        [SetUp]
        public void SetUp()
        {
            _sensor = new Sensor();
        }

        [TestCase(16, 22, true)]
        [TestCase(9, 15.9, false)]
        [TestCase(22.1, 30, false)]
        public void Test_Pressure_In_Range(double min, double max, bool isValid)
        {
            var value = _sensor.PopNextPressurePsiValue();
            Assert.That(value >= min && value <= max, Is.EqualTo(isValid));
        }
    }
}
