using MDD4All.QVT.TransformationStarter.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MDD4All.QVT.TransformationStarter.Views
{
    public partial class ObjectDeserializationView
    {
        [Parameter]
        public ObjectDeserializationViewModel DataContext { get; set; }

        private string RadioButtonGroupGUID { get; set; } = Guid.NewGuid().ToString();

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