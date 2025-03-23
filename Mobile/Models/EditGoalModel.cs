using System.ComponentModel.DataAnnotations;

namespace Mobile.Models
{
    public class EditGoalModel
    {
        [Required(ErrorMessage = "Название цели обязательно")]
        [MinLength(3, ErrorMessage = "Название должно содержать минимум 3 символа")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Описание цели обязательно")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Категория обязательна")]
        public string Category { get; set; }

        public DateTime Deadline { get; set; }

        [Range(0, 100, ErrorMessage = "Прогресс должен быть от 0 до 100")]
        public int Progress { get; set; }

        public bool IsCompleted { get; set; }

        [Range(0, 100, ErrorMessage = "Срочность должна быть от 0 до 100")]
        public int Urgency { get; set; }
    }
} 