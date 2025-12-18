using MDD4All.QVT.TransformationStarter.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MDD4All.QVT.TransformationStarter.Views
{
    public partial class TransformationFinishedView
    {
        [Inject]
        public IStringLocalizer<TransformationFinishedView> L { get; set; }

        [Parameter]
        public MainViewModel DataContext { get; set; } = null!;
    }
}