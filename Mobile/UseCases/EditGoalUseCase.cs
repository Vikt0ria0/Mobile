using Mobile.Models;
using Mobile.Repository;

namespace Mobile.UseCases
{
    public class EditGoalUseCase
    {
        private readonly IGoalRepository _repository;

        public EditGoalUseCase(IGoalRepository repository)
        {
            _repository = repository;
        }

        public async Task<EditGoalModel> GetGoalAsync(string id)
        {
            return await _repository.GetGoalAsync(id);
        }

        public async Task<(bool success, string error)> UpdateGoalAsync(string id, EditGoalModel goal)
        {
            // Валидация данных
            if (!await _repository.ValidateGoalAsync(goal))
            {
                return (false, "Проверьте правильность заполнения полей");
            }

            // Дополнительные бизнес-правила
            if (goal.Deadline < DateTime.Now)
            {
                return (false, "Дедлайн не может быть в прошлом");
            }

            if (goal.IsCompleted && goal.Progress != 100)
            {
                goal.Progress = 100;
            }

            // Сохранение данных
            var success = await _repository.UpdateGoalAsync(id, goal);
            return success ? 
                (true, string.Empty) : 
                (false, "Не удалось сохранить изменения");
        }
    }
} 