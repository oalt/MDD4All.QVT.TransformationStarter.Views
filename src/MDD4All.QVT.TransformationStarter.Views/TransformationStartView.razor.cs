using MDD4All.QVT.TransformationStarter.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MDD4All.QVT.TransformationStarter.Views
{
    public partial class TransformationStartView
    {
        [Parameter]
        public MainViewModel DataContext { get; set; }

        public TransformationViewModel TransformationViewModel { get; set; }

        protected override void OnInitialized()
        {
            TransformationViewModel = DataContext.TransformationViewModel;

            TransformationViewModel.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "ReadyToRunTransformation")
            {
                StateHasChanged();
            }
        }
    }
}