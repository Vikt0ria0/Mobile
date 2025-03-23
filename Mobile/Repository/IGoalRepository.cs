using Mobile.Models;

namespace Mobile.Repository
{
    public interface IGoalRepository
    {
        Task<EditGoalModel> GetGoalAsync(string id);
        Task<bool> UpdateGoalAsync(string id, EditGoalModel goal);
        Task<bool> ValidateGoalAsync(EditGoalModel goal);
    }
} 