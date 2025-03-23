using System.ComponentModel;
using System.Windows.Input;
using Mobile.Models;
using Mobile.UseCases;

namespace Mobile.ViewModels
{
    public class EditGoalViewModel : INotifyPropertyChanged
    {
        private readonly EditGoalUseCase _useCase;
        private string _goalId;
        private EditGoalModel _goal;
        private bool _isLoading;
        private string _errorMessage;
        private bool _hasError;

        public EditGoalModel Goal
        {
            get => _goal;
            set
            {
                _goal = value;
                OnPropertyChanged(nameof(Goal));
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                HasError = !string.IsNullOrEmpty(value);
            }
        }

        public bool HasError
        {
            get => _hasError;
            set
            {
                _hasError = value;
                OnPropertyChanged(nameof(HasError));
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EditGoalViewModel(EditGoalUseCase useCase)
        {
            _useCase = useCase;
            SaveCommand = new Command(async () => await SaveGoal(), () => !IsLoading);
            CancelCommand = new Command(async () => await Cancel(), () => !IsLoading);
        }

        public async Task InitializeAsync(string goalId)
        {
            try
            {
                _goalId = goalId;
                IsLoading = true;
                ErrorMessage = string.Empty;
                Goal = await _useCase.GetGoalAsync(goalId);
            }
            catch (Exception ex)
            {
                ErrorMessage = "Не удалось загрузить данные";
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task SaveGoal()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;

                var (success, error) = await _useCase.UpdateGoalAsync(_goalId, Goal);
                if (!success)
                {
                    ErrorMessage = error;
                    return;
                }

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                ErrorMessage = "Произошла ошибка при сохранении";
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 