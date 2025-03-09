using System.ComponentModel;

namespace Mobile.Models
{
    public class CalendarDay : INotifyPropertyChanged
    {
        private int _dayNumber;
        public int DayNumber
        {
            get => _dayNumber;
            set
            {
                _dayNumber = value;
                OnPropertyChanged(nameof(DayNumber));
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private bool _isToday;
        public bool IsToday
        {
            get => _isToday;
            set
            {
                _isToday = value;
                OnPropertyChanged(nameof(IsToday));
            }
        }

        private int _goalsCount;
        public int GoalsCount
        {
            get => _goalsCount;
            set
            {
                _goalsCount = value;
                OnPropertyChanged(nameof(GoalsCount));
                OnPropertyChanged(nameof(HasGoals));
            }
        }

        public bool HasGoals => GoalsCount > 0;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 