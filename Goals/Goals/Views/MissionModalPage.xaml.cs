using Goals.Localization;
using Goals.ViewModels;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Goals.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MissionModalPage : PopupPage
    {
        public MissionModalPage()
        {
            BindingContext = new MissionCreateViewModel();
            InitializeComponent();
        }      
    }
}