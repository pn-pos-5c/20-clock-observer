using System;
using System.Threading;
using System.Windows;

namespace ClockObserver
{
    public partial class MainWindow : Window
    {
        private ClockSubject subject = new();
        private bool running = true;

        public MainWindow()
        {
            InitializeComponent();
            new Thread(() =>
            {
                while (running)
                {
                    subject.Time = TimeOnly.FromDateTime(DateTime.Now).ToString("r");
                    Thread.Sleep(1000);
                }
            }).Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var windows = new ClockObserverWindow(subject);
            windows.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            running = false;
        }
    }
}
