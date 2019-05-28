using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himaan.Helper;
using Himaan.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Himaan
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OfferEntryPage : ContentPage
	{
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public OfferEntryPage ()
		{
			InitializeComponent ();
		}

        private async void OnOfferButtonClicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddOffer(txtTo.Text,txtFrom.Text, dtOfferDate.Date, Convert.ToInt32(txtFreeSeats.Text), txtDescription.Text);
            txtTo.Text = string.Empty;
            txtFrom.Text = string.Empty;
            txtFreeSeats.Text = string.Empty;
            txtDescription.Text = string.Empty;
            dtOfferDate.Date = DateTime.Now;
            await DisplayAlert("Success", "Offer Added Successfully", "OK");
        }
    }
}