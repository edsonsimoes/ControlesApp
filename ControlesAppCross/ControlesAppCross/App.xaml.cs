using System;
using ControlesAppCross.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ControlesAppCross
{
	public partial class App : Application
	{
        public static bool IsUserLoggedIn { get; set; }

        public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
		{
            Current.MainPage = new TabbedPage
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

        internal static object GetMainPage(object container)
        {
            throw new NotImplementedException();
        }
    }
}
