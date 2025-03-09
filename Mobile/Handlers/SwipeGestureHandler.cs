using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace Mobile.Handlers
{
    public class SwipeGestureHandler
    {
        private readonly Grid _contentGrid;
        private readonly string _nextRoute;
        private readonly string _previousRoute;

        public SwipeGestureHandler(Grid contentGrid, string nextRoute = null, string previousRoute = null)
        {
            _contentGrid = contentGrid;
            _nextRoute = nextRoute;
            _previousRoute = previousRoute;
            AddSwipeGestures();
        }

        private void AddSwipeGestures()
        {
            var swipeLeft = new SwipeGestureRecognizer { Direction = SwipeDirection.Left };
            var swipeRight = new SwipeGestureRecognizer { Direction = SwipeDirection.Right };

            if (!string.IsNullOrEmpty(_nextRoute))
            {
                swipeLeft.Swiped += async (s, e) =>
                {
                    await Shell.Current.GoToAsync(_nextRoute);
                };
                _contentGrid.GestureRecognizers.Add(swipeLeft);
            }

            if (!string.IsNullOrEmpty(_previousRoute))
            {
                swipeRight.Swiped += async (s, e) =>
                {
                    await Shell.Current.GoToAsync(_previousRoute);
                };
                _contentGrid.GestureRecognizers.Add(swipeRight);
            }
        }
    }
} 