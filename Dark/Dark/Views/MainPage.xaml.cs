
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Dark.Model;

namespace Dark
{
    public partial class MainPage : ContentPage
    {


        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public MainPage()
        {
            InitializeComponent();


        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();

        }



        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddPerson(CIN.Text, Name.Text,LastName.Text, Phone.Text,  Mail.Text, Adress.Text, Coupon.Text,Password.Text);
            CIN.Text = string.Empty;
            Name.Text = string.Empty;
            LastName.Text = string.Empty;

            Phone.Text = string.Empty;
            Mail.Text = string.Empty;
            Adress.Text = string.Empty;
            Coupon.Text = string.Empty;
            Password.Text = string.Empty;
            await DisplayAlert("Success", "Person Added Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();

        }

       async private void Button_Clicked_getMail(object sender, EventArgs e)
        {
            var mailperson = await firebaseHelper.Authentification(Mail.Text,Password.Text);
           
            if (mailperson != null)
            {
               
             
               
                await DisplayAlert("Success", "account existe dans la base de donneés", "OK");

            }
            else
            {
                await DisplayAlert("Success", "No account Available", "OK");
            }
        }
    }
}

