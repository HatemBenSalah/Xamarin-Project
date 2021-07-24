using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Dark.Model;
using Dark.Helpers;
using Dark.Views.Session;

namespace Dark.Views.welcome
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public LoginPage ()
		{ 
			InitializeComponent ();
            LogoSignIn.Source = ImageSource.FromResource("Dark.Image.ProfilePicture.png");
            Mail.Text = Settings.Mail;
        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();

        }

        private async void Btn_SignIN(object sender, EventArgs e)
        {
            var User = await firebaseHelper.Authentification(Mail.Text, Password.Text);

            if (User != null)
            {
                Settings.Mail = Mail.Text;
                Settings.Password = Password.Text;
                
                if(Settings.Mail=="admin@isetma.com")
                    {
                    await Navigation.PushAsync(new Home());
                }
                else
                    if(Settings.Mail=="moufida.jguirim@mahdia.r-iset.tn")


                await Navigation.PushAsync(new Prof());
                else
                    await Navigation.PushAsync(new Etudiant());


            }
            else
            {
                await DisplayAlert("Email or Password is incorrect ", "Please try again ", "OK");
            }

        }

    }
}