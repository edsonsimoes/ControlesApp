using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlesAppCross.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UsuarioLogado : ContentPage
	{
		public UsuarioLogado ()
		{
			InitializeComponent ();
            UsuarioConectado.Text = "Usuário Conectado: " + Constants.Username;
		}

        public void OnDesconectarButtonClicked(object Sender, EventArgs e)
        {
            Constants.UserCod = 0;
            Constants.Username = string.Empty;
            Constants.Password = string.Empty;
            App.IsUserLoggedIn = false;

            Application.Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Menu",
                        //Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new LoginPage())
                    {
                        Title = "Usuário",
                        
                        //Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                }
            };


        }

    }
}