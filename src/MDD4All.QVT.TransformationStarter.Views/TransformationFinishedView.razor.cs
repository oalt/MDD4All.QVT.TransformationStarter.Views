using MDD4All.QVT.TransformationStarter.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MDD4All.QVT.TransformationStarter.Views
{
    public partial class TransformationFinishedView
    {
        [Parameter]
        public MainViewModel DataContext { get; set; } = null!;
    }
}