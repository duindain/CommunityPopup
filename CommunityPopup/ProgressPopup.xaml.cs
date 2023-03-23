using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityPopup
{
    public partial class ProgressPopup : Popup
    {
        public ProgressIndicatorVM VM => BindingContext as ProgressIndicatorVM;

        public ProgressPopup()
        {
            InitializeComponent();
        }
    }
}