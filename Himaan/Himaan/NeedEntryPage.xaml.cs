using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Himaan.Helper;
using Himaan.Models;

namespace Himaan
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NeedEntryPage : ContentPage
	{
        FirebaseHelper firebaseHelper = new FirebaseHelper();
		public NeedEntryPage ()
		{
			InitializeComponent ();
		}

        private async void OnAskButtonClicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddNeed(txtTo.Text, txtFrom.Text, dtNeedDate.Date, Convert.ToInt32(txtNeededSeats.Text), txtDescription.Text);
            txtTo.Text = string.Empty;
            txtFrom.Text = string.Empty;
            txtNeededSeats.Text = string.Empty;
            txtDescription.Text = string.Empty;
            dtNeedDate.Date = DateTime.Now;
            await DisplayAlert("Success", "Successfully added.", "OK");
        }
    }
}