using System.ComponentModel;

namespace Mobile.Models
{
    public class MainGoal : Goal
    {
        private string _color;
        public string Color
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        private int _urgency;
        public int Urgency
        {
            get => _urgency;
            set
            {
                _urgency = value;
                OnPropertyChanged(nameof(Urgency));
            }
        }

        private string _image;
        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public string DeadlineFormatted => $"Дедлайн: {Deadline:dd.MM.yyyy}";
        public string CategoryFormatted => $"Категория: {Category}";
    }
} 