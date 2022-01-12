using plz.Services;
using plz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            LoginService services = new LoginService();

            var getLoginDetails = await services.CheckLoginIfExists(EntryEmail.Text, EntryPassword.Text);

            if (getLoginDetails)
            {
                await DisplayAlert("Login success", "You are login", "Okay", "Cancel");
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            else
            {
                await DisplayAlert("Login failed", "Username or Password is incorrect or not exists", "Okay", "Cancel");
            }
        }
    }
}