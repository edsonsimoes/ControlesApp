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
	public partial class LoginPage : ContentPage
	{
        DataServices dataService = new DataServices();
        List<Usuario> _usuarios = new List<Usuario>();

        public LoginPage ()
		{
			InitializeComponent ();
		}

        async Task AtualizaDados(string usuario, string senha)
        {
            _usuarios = await dataService.GetUsuario(usuario, senha);
        }


        async Task OnLoginButtonClickedAsync(object sender, EventArgs e)
        {

            await AtualizaDados(usernameEntry.Text, passwordEntry.Text);
            //AtualizaDados(usernameEntry.Text, passwordEntry.Text);

            if (_usuarios.Count != 0)
            {
                Constants.Username = _usuarios.First().Usw_Nome;
                Constants.UserCod = _usuarios.First().Usw_cod;
                Constants.Password = _usuarios.First().Usw_Senha;
                App.IsUserLoggedIn = true;
                
            }
            else
            {
                _usuarios.Add(new Usuario());
                Constants.UserCod = 0;
                Constants.Username = string.Empty;
                Constants.Password = string.Empty;
                App.IsUserLoggedIn = false;
            }

            var isValid = AreCredentialsCorrect(_usuarios.First());
            if (isValid)
            {
                Application.Current.MainPage = new TabbedPage
                {
                    Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Menu",
                        //Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new UsuarioLogado())
                    {
                        Title = "Usuário",
                        
                        //Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                }
                };

                //Navigation.InsertPageBefore(new MainPage(), this);
                //await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Usuário e/ou Senha não conferem";
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(Usuario user)
        {
            return user.Usw_Nome == Constants.Username && user.Usw_Senha == Constants.Password;
        }
    }
}