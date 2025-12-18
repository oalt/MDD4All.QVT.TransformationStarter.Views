using MDD4All.QVT.TransformationStarter.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MDD4All.QVT.TransformationStarter.Views
{
    public partial class TransformationStartView
    {
        [Inject]
        public IStringLocalizer<TransformationStartView> L { get; set; }

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