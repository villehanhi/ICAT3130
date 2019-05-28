using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Himaan.Models;

namespace Himaan
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnOfferButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OfferEntryPage());
        }

        private void OnNeedButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NeedEntryPage());
        }

        private void OnSearchButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());
        }
        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}
