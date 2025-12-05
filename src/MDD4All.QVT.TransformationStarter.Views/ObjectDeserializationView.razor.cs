using MDD4All.QVT.TransformationStarter.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MDD4All.QVT.TransformationStarter.Views
{
    public partial class ObjectDeserializationView
    {
        [Parameter]
        public ObjectDeserializationViewModel DataContext { get; set; }

        private string RadioButtonGroupGUID { get; set; } = Guid.NewGuid().ToString();

        protected override void OnInitialized()
        {
            DataContext.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "FileSelectionResult")
            {
                if (DataContext.FileSelectionResult)
                {
                    DataContext.Filename = DataContext.SelectedFilename;

                }
                DataContext.RaisePropertyChanged("ReadyToRunTransformation");
            }
        }

        private void OnFormatSelection(ChangeEventArgs changeEventArgs, string format)
        {

            DataContext.Format = changeEventArgs.Value?.ToString();

        }

        private void OnSelectFileToOpen()
        {
            SynchronizationContext.Current?.Post((_) =>
            {
                DataContext.SelectFileToLoadCommand.Execute("Select data file...");
                StateHasChanged();
            }, null);

        }
    }
}