using MDD4All.FileAccess.Contracts;
using MDD4All.QVT.TransformationStarter.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading;

namespace MDD4All.QVT.TransformationStarter.Views
{
    public partial class EaObjectSelectionView
    {
        [Inject]
        public IFileLoader FileLoader { get; set; }

        [Parameter]
        public EaObjectSelectionViewModel DataContext { get; set; }

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
                    DataContext.ConnectionString = DataContext.SelectedFilename;
                }
            }
            else if (e.PropertyName == "RepositoryTreeViewModel" && DataContext.ShowEaElementSelectionDialog)
            {
                InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            }

        }

        private void OnSelectFile()
        {
            SynchronizationContext.Current?.Post((_) =>
            {
                DataContext.SelectFileToLoadCommand.Execute("Choose EA model file...");
                StateHasChanged();
            }, null);
        }

        private void OnSelectEaElementClick()
        {
            DataContext.ShowSelectionDialogCommand.Execute(null);
        }

        private void OnSelctionDialogClose(bool args)
        {
            DataContext.CloseSelectionDialogCommand.Execute(null);
            StateHasChanged();
        }
    }
}