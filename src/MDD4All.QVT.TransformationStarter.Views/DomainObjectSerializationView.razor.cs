using MDD4All.QVT.TransformationStarter.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MDD4All.QVT.TransformationStarter.Views
{
    public partial class DomainObjectSerializationView
    {
        [Inject]
        public IStringLocalizer<DomainAssignmentView> L { get; set; }

        [Parameter]
        public ObjectSerializationViewModel DataContext { get; set; }

        private string RadioButtonGroupGUID { get; set; } = Guid.NewGuid().ToString();

        protected override void OnInitialized()
        {
            DataContext.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "FileSelectionResult")
            {
                if(DataContext.FileSelectionResult)
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

        private void OnSelectFileToSave()
        {
            SynchronizationContext.Current?.Post((_) =>
            {
                DataContext.SelectFileToSaveCommand.Execute("Select destination file...");
                StateHasChanged();
            }, null);
            
        }
    }
}