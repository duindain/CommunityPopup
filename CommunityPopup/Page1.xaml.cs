using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityPopup
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Task.Delay(1000).Wait();

            MessageService.HideProgressIndicator();
        }
    }
}