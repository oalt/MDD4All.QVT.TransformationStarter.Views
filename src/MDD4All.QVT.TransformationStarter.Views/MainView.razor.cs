using LL.MDE.Components.Qvt.Common.Services;
using MDD4All.FileAccess.Contracts;
using MDD4All.QVT.TransformationStarter.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MDD4All.QVT.TransformationStarter.Views
{
    public partial class MainView
    {
        [Inject]
        public TransformationDescriptorProvider DescriptorProvider { get; set; }

        [Inject]
        public IFileLoader FileLoader { get; set; }

        [Inject]
        public IFileSaver FileSaver { get; set; }

        private MainViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext = new MainViewModel(DescriptorProvider.TransformationDescriptor, FileLoader, FileSaver);
            DataContext.PropertyChanged += OnDataContextPropertyChanged;
        }

        private void OnDataContextPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "ActiveViewState")
            {
                StateHasChanged();
            }
        }

        
    }
}