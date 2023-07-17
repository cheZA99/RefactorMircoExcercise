namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm : IAlarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private readonly ISensor _sensor;
        private bool _alarmOn = false;

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        public Alarm()
        {
            //Personally, I wouldn't do this in real-world apps since we are relying on concrete type.
            //But this is only because we can't change client classes.
            //Otherwise I would inject ISensor like I did in other constructor. 
            _sensor = new Sensor();
        }

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();
            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
            else
            {
                _alarmOn = false;
            }
        }

        public bool AlarmOn => _alarmOn;
    }
}
