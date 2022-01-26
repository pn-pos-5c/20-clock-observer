using System.ComponentModel;
using System.Windows;

namespace ClockObserver
{
    public partial class ClockObserverWindow : Window, INotifyPropertyChanged, IObserver
    {
        private string time = string.Empty;
        private readonly ClockSubject clockSubject;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged(nameof(time));
            }
        }

        public ClockObserverWindow(ClockSubject clockSubject)
        {
            InitializeComponent();
            DataContext = this;
            this.clockSubject = clockSubject;
            this.clockSubject.Attach(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Update()
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(Update);
            }
            Time = clockSubject.Time;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            clockSubject.Detach(this);
        }
    }
}
