using Microsoft.Maui.Controls;

namespace SportSyncSuggestions
{
    public partial class MainPage : ContentPage
    {
        double startX = 0;

        public MainPage()
        {
            InitializeComponent();
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            TileStackLayout.GestureRecognizers.Add(panGesture);
        }

        private void OnPanUpdated(object? sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    startX = e.TotalX;
                    break;
                case GestureStatus.Running:
                    double deltaX = startX - e.TotalX;
                    TileScrollView.ScrollToAsync(TileScrollView.ScrollX + deltaX, 0, false);
                    startX = e.TotalX;
                    break;
            }
        }
    }
}
