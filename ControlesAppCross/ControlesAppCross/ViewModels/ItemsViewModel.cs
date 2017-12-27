using System;
using System.Diagnostics;
using System.Threading.Tasks;

using ControlesAppCross.Helpers;
using ControlesAppCross.Models;
using ControlesAppCross.Views;

using Xamarin.Forms;

using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.Linq;


namespace ControlesAppCross.ViewModels
{
	public class ItemsViewModel : BaseViewModel
	{
		public ObservableRangeCollection<Item> Items { get; set; }
		public Command LoadItemsCommand { get; set; }
        DataServices dataService = new DataServices();
        List<Tarefas> _tarefas_tot = new List<Tarefas>();


        public ItemsViewModel()
		{
			Title = "Controles On-Line App";
			Items = new ObservableRangeCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
			{
				var _item = item as Item;
				Items.Add(_item);
				await DataStore.AddItemAsync(_item);
			});


            //AtualizaDados();

        }

        //async Task GetDados()
        //{
        //    if (IsBusy)
        //        return;

        //    IsBusy = true;

        //    try

        //    {
        //        DataServices dataService = new DataServices();
        //        List<Tarefas> _tarefas = new List<Tarefas>();

        //        var dados = await dataService.GetTarefasAsync("Eresumo");
        //        foreach (var item in dados)
        //        {
        //            var _dados = new Tarefas();
        //            _tarefas.Add(item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Debug.WriteLine(ex);
        //        MessagingCenter.Send(new MessagingCenterAlert
        //        {
        //            Title = "Error",
        //            Message = "Unable to load dados.",
        //            Cancel = "OK"
        //        }, "message");
        //    }
        //}

        async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
                Items.Clear();
				var items = await DataStore.GetItemsAsync(true);
				Items.ReplaceRange(items);
                List<Tarefas> dados = new List<Tarefas>();
                if (!App.IsUserLoggedIn)
                {
                    Tarefas tarefa = new Tarefas();
                    tarefa.AtrTotal = 0;
                    tarefa.NLTotal = 0;
                    tarefa.FhjTotal = 0;
                    tarefa.VldTotal = 0;
                    tarefa.AnotTotal = 0;
                    dados.Add(tarefa);
                }
                else
                {
                    dados = await dataService.GetTarefasAsync("Eresumo", Constants.UserCod.ToString());
                }

                foreach (var item in dados)
                {
                    var _dados = new Tarefas();
                    _tarefas_tot.Clear();
                    _tarefas_tot.Add(item);
                }

                foreach (var item in Items)
                {
                    if (item.Text.Contains("Tarefas em Atraso"))
                    {
                        item.Text = "Tarefas em Atraso ( " + _tarefas_tot.First().AtrTotal + " )";
                    }
                    if (item.Text.Contains("Tarefas não Lidas"))
                    {
                        item.Text = "Tarefas não Lidas ( " + _tarefas_tot.First().NLTotal + " )";
                    }
                    if (item.Text.Contains("Fazer Hoje"))
                    {
                        item.Text = "Fazer Hoje ( " + _tarefas_tot.First().FhjTotal + " )";
                    }
                    if (item.Text.Contains("Validar"))
                    {
                        item.Text = "Validar ( " + _tarefas_tot.First().VldTotal + " )";
                    }
                    if (item.Text.Contains("Anotações"))
                    {
                        item.Text = "Anotações ( " + _tarefas_tot.First().AnotTotal + " )";
                    }


                }

            }

            catch (Exception ex)
			{
				Debug.WriteLine(ex);
				MessagingCenter.Send(new MessagingCenterAlert
				{
					Title = "Error",
					Message = "Unable to load items.",
					Cancel = "OK"
				}, "message");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}