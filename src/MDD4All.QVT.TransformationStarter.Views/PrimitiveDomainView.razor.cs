using MDD4All.QVT.TransformationStarter.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MDD4All.QVT.TransformationStarter.Views
{
    public partial class PrimitiveDomainView
    {
        [Parameter]
        public PrimitiveDomainObjectViewModel DataContext { get; set; }
    }
}