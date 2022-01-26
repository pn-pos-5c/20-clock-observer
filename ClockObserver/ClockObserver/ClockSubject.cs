namespace ClockObserver
{
    public class ClockSubject : Subject
    {
        private string? time;
        public string Time
        {
            get => time ?? "** unknown **";
            set
            {
                time = value;
                Notify();
            }
        }
    }
}
