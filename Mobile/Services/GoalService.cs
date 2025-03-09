using Mobile.Models;
using System.Collections.ObjectModel;

namespace Mobile.Services
{
    public class GoalService
    {
        private ObservableCollection<Goal> _goals;
        public ObservableCollection<Goal> Goals => _goals;

        public GoalService()
        {
            _goals = new ObservableCollection<Goal>();
        }

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public void UpdateGoal(Goal goal)
        {
            var existingGoal = _goals.FirstOrDefault(g => g.Id == goal.Id);
            if (existingGoal != null)
            {
                var index = _goals.IndexOf(existingGoal);
                _goals[index] = goal;
            }
        }

        public void DeleteGoal(string id)
        {
            var goal = _goals.FirstOrDefault(g => g.Id == id);
            if (goal != null)
            {
                _goals.Remove(goal);
            }
        }

        public void UpdateProgress(string id, int progress)
        {
            var goal = _goals.FirstOrDefault(g => g.Id == id);
            if (goal != null)
            {
                goal.Progress = progress;
                if (progress >= 100)
                {
                    goal.IsCompleted = true;
                }
            }
        }
    }
} 