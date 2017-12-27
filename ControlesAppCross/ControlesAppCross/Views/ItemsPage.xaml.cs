using System;
using System.Windows.Input;
using ControlesAppCross.Models;
using ControlesAppCross.ViewModels;

using Xamarin.Forms;


namespace ControlesAppCross.Views
{
	public partial class ItemsPage : ContentPage
	{
		ItemsViewModel viewModel;
        
        public ItemsPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new ItemsViewModel();
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
            string tipo;
            tipo = "NaoLidas";

			if (item == null)
				return;
            if (item.Text.Contains("Tarefas não Lidas"))
            {
                tipo = "NaoLidas";
            }
            if (item.Text.Contains("Fazer Hoje"))
            {
                tipo = "FazerHoje";
            }
            if (item.Text.Contains("Validar"))
            {
                tipo = "Validar";
            }
            if (item.Text.Contains("Anotações"))
            {
                tipo = "Anotar";
            }
            if (item.Text.Contains("Atraso"))
            {
                tipo = "Atraso";
            }
            if (item.Text.Contains("Adicionar"))
            {
                tipo = "Adicionar";
                var url = "http://www.controlesonline.com.br";
                Device.OpenUri(new Uri(url));
            }
            
            if (tipo != "Adicionar")
            {
                await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item), tipo, Constants.UserCod.ToString()));

                // Manually deselect item
                ItemsListView.SelectedItem = null;
            }
        }

        async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewItemPage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);
		}
	}
}
