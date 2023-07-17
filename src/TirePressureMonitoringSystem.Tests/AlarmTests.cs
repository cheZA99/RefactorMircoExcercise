using Moq;
using NUnit.Framework;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests
{
    [TestFixture]
    public class AlarmTests
    {
        private IAlarm _alarm;
        private Mock<ISensor> _sensorMock;

        [SetUp]
        public void SetUp()
        {
            _sensorMock = new Mock<ISensor>();
            _alarm = new Alarm(_sensorMock.Object);
        }

        [TestCase(16.5, true)]
        [TestCase(2, true)]
        [TestCase(520, true)]
        [TestCase(17.5, false)]
        [TestCase(20.2, false)]
        [TestCase(19.888888, false)]
        public void Check_Alarm_Should_Be_On_Or_Off(double pressure, bool state)
        {
            _sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(pressure);
            _alarm.Check();
            Assert.That(state, Is.EqualTo(_alarm.AlarmOn));
        }

        [TearDown]
        public void TearDown()
        {
            //no need for disposing anything
        }
    }
}
