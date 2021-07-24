using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dark.Model;
using Dark.Helpers;

namespace Dark.Views.welcome
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public RegisterPage()
        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();

        }
        async protected void btn_Register(object sender, EventArgs e)
        {
            if (verfyAllEntry() == false)

              {
                  await allEntryNoteEmplty();
              }
            
            
            
          if ( verfyAllEntry() == true & verifPassword() == false)
          {
            await  AlertPassword();
          } 
          else if(verfyAllEntry() == true & verifPassword() == true)
            {
                await firebaseHelper.AddPerson(CIN.Text, FirstName.Text, LastName.Text, Phone.Text, Mail.Text, Adress.Text, Coupon.Text, Password.Text);
                Settings.Mail = Mail.Text;
                Settings.Password = Password.Text;
                await DisplayAlert("Success", "you are registred", "OK");
                await Navigation.PushAsync(new LoginPage());
            }

                
          

        }
        async protected Task AlertPassword()
        {
           
                await DisplayAlert("Password doesn't match  ", "Please verify", "OK"); ;
               
                Password.Text = null;
            ConfirmPassword.Text = null;
            


        }
        async protected Task allEntryNoteEmplty()
        {

            await DisplayAlert("Emplty fields", "please complete all required fields", "OK");

        }
        protected Boolean verfyAllEntry()
        {
            Boolean isEmplty = true;
            if (Password.Text == null
                || ConfirmPassword.Text == null
                || Adress.Text == null
                || Mail.Text == null
                || CIN.Text == null
                || Phone.Text == null)

            {
                isEmplty= false;
            }
            return isEmplty;
        }
        protected Boolean verifPassword()
        {
            if (
                  (Password.Text != ConfirmPassword.Text) ||(Password.Text==null)
                )
            {
                return false;
            }
            else
                return true;
        }
    }
}

