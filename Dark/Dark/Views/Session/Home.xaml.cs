using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dark.Views.Session
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            Maison.Source = ImageSource.FromResource("Dark.Image.Maison.png");
            Securite.Source = ImageSource.FromResource("Dark.Image.Securite.jpg");
            Jardin.Source = ImageSource.FromResource("Dark.Image.Jardin.jpg");
            Piscine.Source = ImageSource.FromResource("Dark.Image.Piscine.png");
            Tobogan.Source = ImageSource.FromResource("Dark.Image.Tobogan.jpg");

        }
    }
   
}