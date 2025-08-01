using Microsoft.AspNetCore.Components;

namespace MDD4All.QVT.TransformationStarter.Views
{
    public partial class StatusIcon
    {
        [Parameter]
        public bool Status {  get; set; } = false;
    }
}