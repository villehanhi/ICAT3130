using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Himaan.Models;
using Himaan.Helper;

namespace Himaan
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
	{
        FirebaseHelper firebaseHelper = new FirebaseHelper();
		public RegistrationPage()
		{
			InitializeComponent ();
		}
        
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allUsers = await firebaseHelper.GetAllUsers();
            lstPersons.ItemsSource = allUsers;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddUser(Convert.ToInt32(txtId.Text), txtFirstName.Text, txtLastName.Text, txtEmail.Text, dtDateOfBirth.Date, txtPhone.Text);
            txtId.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            dtDateOfBirth.Date = DateTime.Now;
            await DisplayAlert("Success", "Person Added Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllUsers();
            lstPersons.ItemsSource = allPersons;
        }

        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            var user = await firebaseHelper.GetUser(Convert.ToInt32(txtId.Text));
            if (user != null)
            {
                txtId.Text = user.userId.ToString();
                txtFirstName.Text = user.userFirstname;
                await DisplayAlert("Success", "Person Retrive Successfully", "OK");

            }
            else
            {
                await DisplayAlert("Success", "No Person Available", "OK");
            }

        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.UpdateUser(Convert.ToInt32(txtId.Text), txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPhone.Text);
            txtId.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            await DisplayAlert("Success", "User Updated Successfully", "OK");
            var allUsers = await firebaseHelper.GetAllUsers();
            lstPersons.ItemsSource = allUsers;
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.DeleteUser(Convert.ToInt32(txtId.Text));
            await DisplayAlert("Success", "User Deleted Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllUsers();
            lstPersons.ItemsSource = allPersons;
        }
    }
}