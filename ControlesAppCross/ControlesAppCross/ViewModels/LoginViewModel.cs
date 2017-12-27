using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ControlesAppCross.Views;

namespace ControlesAppCross
{
    class LoginViewModel 
    {
        private string _usuario;
        public string Usuario
        {
            get { return _usuario; }
            set
            {
                if (_usuario != value)
                {
                    _usuario = value;
                }
            }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set
            {
                if(_senha != value)
                {
                    _senha = value;
                }
            }
        }

        //public ICommand IncluirUsuario
        //{
        //    get
        //    {
        //        var clienteDAL = new ClienteDAL();
        //        return new Command(() =>
        //        {
        //            Usuario cli = new Usuario();
        //            cli.Nome = "mac";
        //            cli.Senha = "numsey";
        //            clienteDAL.Add(cli);
        //            App.Current.MainPage.DisplayAlert("Novo Usuario", "Inclusão realizada com sucesso", "OK");
        //        });
        //    }
        //}

        private INavigation _navigation;

        public LoginViewModel(INavigation navigation, string nome)
        {
            VerificarLoginAsync(nome);
            _navigation = navigation;
        }

        private void VerificarLoginAsync(string Nome)
        {
            List<Usuario> usuario = new List<Usuario>();
            var dataservice = new DataServices();
            //usuario = await dataservice.GetUsuarioAsync(Nome);

            if (usuario!=null)
            {
                _navigation.PushAsync(new ItemsPage());
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Não foi possível logar","Dados inválidos...", "Ok");
            }
        }
    }}
