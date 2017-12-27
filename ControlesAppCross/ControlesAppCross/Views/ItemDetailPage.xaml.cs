using ControlesAppCross.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using ControlesAppCross.Helpers;


namespace ControlesAppCross.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		ItemDetailViewModel viewModel;
        DataServices dataService;
        List<Tarefas> _tarefas_dados;
        public Command LoadItemsCommand { get; set; }
        string tipoL, usuarioL;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public ItemDetailPage(ItemDetailViewModel viewModel, string tipo, string usuario)
		{
			InitializeComponent();
            dataService = new DataServices();
            AtualizaDados(tipo, usuario, false);
            this.dropTipos.SelectedItem = "Tipo Minhas";
            BindingContext = this.viewModel = viewModel;
            this.DtInicio.Date = DateTime.Now.AddDays(-30);
            tipoL = tipo;
            usuarioL = usuario;

        }
        public void OnPesquisarButtonClicked(object Sender, EventArgs e)
        {
            AtualizaDados(tipoL, usuarioL, true);
        }
        async void AtualizaDados(string tipo, string usuario, bool AplicFiltro)
        {
            _tarefas_dados = await dataService.GetTarefasAsync(tipo, usuario);
            if (AplicFiltro)
            {
                List<Tarefas> _tarefas_dadosF = new List<Tarefas>();

                _tarefas_dadosF.Clear();
                foreach (var item in _tarefas_dados)
                {
                    if (item.DATA_PROGR >= this.DtInicio.Date && item.DATA_PROGR <= this.DtFinal.Date)
                    {
                        _tarefas_dadosF.Add(item);
                    }
                }
                _tarefas_dados.Clear();
                _tarefas_dados = _tarefas_dadosF;

            }
            lvTarefas.ItemsSource = _tarefas_dados.OrderBy(item => item.DATA_PROGR).ToList();
            this.nrpesq.Text = "Filtradas: " + _tarefas_dados.Count();
        }


        //async Task AtualizaDados1()
        //{
        //    if (IsBusy)
        //        return;

        //    IsBusy = true;

        //    try
        //    {

        //        var dados_d = await dataService.GetTarefasAsync("NaoLidas", Constants.UserCod.ToString());
        //        foreach (var item in dados_d)
        //        {
        //            var _dados = new Tarefas();
        //            _dados = item;
        //            _tarefas_dados.Add(item);
        //        }

        //        lvTarefas.ItemsSource = _tarefas_dados;

        //    }

        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //        MessagingCenter.Send(new MessagingCenterAlert
        //        {
        //            Title = "Error",
        //            Message = "Unable to load items.",
        //            Cancel = "OK"
        //        }, "message");
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        private void lvClientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
