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
    public partial class ProgrammationDetailPage : ContentPage
    {
        public ProgrammationDetailPage()
        {
            InitializeComponent();
            BindingContext = new ProgrammationDetailViewModel();
        }
    }
}