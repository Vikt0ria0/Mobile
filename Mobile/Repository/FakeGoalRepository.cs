using Mobile.Models;
using System.ComponentModel.DataAnnotations;

namespace Mobile.Repository
{
    public class FakeGoalRepository : IGoalRepository
    {
        private readonly Dictionary<string, EditGoalModel> _goals;

        public FakeGoalRepository()
        {
            _goals = new Dictionary<string, EditGoalModel>
            {
                {
                    "1", new EditGoalModel
                    {
                        Title = "Тестовая цель",
                        Description = "Описание тестовой цели",
                        Category = "Работа",
                        Deadline = DateTime.Now.AddDays(7),
                        Progress = 0,
                        IsCompleted = false,
                        Urgency = 50
                    }
                }
            };
        }

        public async Task<EditGoalModel> GetGoalAsync(string id)
        {
            await Task.Delay(500); // Имитация задержки сети
            return _goals.ContainsKey(id) ? _goals[id] : null;
        }

        public async Task<bool> UpdateGoalAsync(string id, EditGoalModel goal)
        {
            await Task.Delay(500); // Имитация задержки сети
            if (!_goals.ContainsKey(id)) return false;
            
            _goals[id] = goal;
            return true;
        }

        public async Task<bool> ValidateGoalAsync(EditGoalModel goal)
        {
            var validationContext = new ValidationContext(goal);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(goal, validationContext, validationResults, true);
            
            await Task.Delay(200); // Имитация проверки
            return isValid;
        }
    }
} 