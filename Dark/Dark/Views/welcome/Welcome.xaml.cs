using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dark.Views.welcome
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Welcome : ContentPage
	{
		public Welcome ()
		{
			InitializeComponent ();

		}

        async private void login_Clicked(object sender, EventArgs e)
        {
          await  Navigation.PushAsync(new LoginPage());

        }
       async private void Register_clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new RegisterPage());
        }
      
    }
}