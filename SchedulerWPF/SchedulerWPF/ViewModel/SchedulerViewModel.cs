using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace WpfScheduler
{
    public class SchedulerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Meeting> meetings;
        public event PropertyChangedEventHandler PropertyChanged;
        public SchedulerViewModel()
        {
            this.Meetings = new ObservableCollection<Meeting>();
            this.AddAppointments();

        }
        public ObservableCollection<Meeting> Meetings
        {
            get
            {
                return this.meetings;
            }
            set
            {
                this.meetings = value;
                this.RaiseOnPropertyChanged("Meetings");
            }
        }
        private void AddAppointments()
        {
            var meeting = new Meeting();
            meeting.EventName = "Meeting";
            meeting.From = new DateTime(2020, 12, 15, 10, 0, 0);
            meeting.To = meeting.From.AddDays(2).AddHours(1);
            meeting.BackgroundColor = new SolidColorBrush(Colors.SlateBlue);
            meeting.ForegroundColor = new SolidColorBrush(Colors.White);
            this.Meetings.Add(meeting);
        }
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
    

