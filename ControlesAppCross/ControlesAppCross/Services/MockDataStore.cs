using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ControlesAppCross.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(ControlesAppCross.Services.MockDataStore))]
namespace ControlesAppCross.Services
{
	public class MockDataStore : IDataStore<Item>
	{
		bool isInitialized;
		List<Item> items;

		public async Task<bool> AddItemAsync(Item item)
		{

/* Unmerged change from project 'ControlesAppCross.iOS'
Before:
			await InitializeAsync();
After:
			await Initialize();
*/
			Initialize();

			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{

/* Unmerged change from project 'ControlesAppCross.iOS'
Before:
			await InitializeAsync();
After:
			await Initialize();
*/
			Initialize();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(Item item)
		{

/* Unmerged change from project 'ControlesAppCross.iOS'
Before:
			await InitializeAsync();
After:
			await Initialize();
*/
			Initialize();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{

/* Unmerged change from project 'ControlesAppCross.iOS'
Before:
			await InitializeAsync();
After:
			await Initialize();
*/
			Initialize();

			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{

/* Unmerged change from project 'ControlesAppCross.iOS'
Before:
			await InitializeAsync();
After:
			await Initialize();
*/
			Initialize();

			return await Task.FromResult(items);
		}

		public Task<bool> PullLatestAsync()
		{
			return Task.FromResult(true);
		}


		public Task<bool> SyncAsync()
		{
			return Task.FromResult(true);
		}


/* Unmerged change from project 'ControlesAppCross.iOS'
Before:
		public async Task InitializeAsync()
After:
		public async Task Initialize()
*/
        public void Initialize()
        {
            if (isInitialized)
                return;

            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), pathImage = "../drawable/icone_naolidas.png", Text = "Tarefas não Lidas", Description="Total "},
                new Item { Id = Guid.NewGuid().ToString(), pathImage = "../drawable/icone_fazerhoje_laranja.png", Text = "Fazer Hoje", Description="Total "},
                new Item { Id = Guid.NewGuid().ToString(), pathImage = "../drawable/icone_validar_azul.png", Text = "Validar", Description="Total "},
                new Item { Id = Guid.NewGuid().ToString(), pathImage = "../drawable/icone_anotacoes_verde.png", Text = "Anotações", Description="Total "},
                new Item { Id = Guid.NewGuid().ToString(), pathImage = "../drawable/icone_atrasos_vermelho.png", Text = "Tarefas em Atraso", Description="Total "},
                new Item { Id = Guid.NewGuid().ToString(), pathImage = "../drawable/Icone_NovaTarefa.png", Text = "Adicionar Tarefa", Description=""},
            };

            foreach (Item item in _items)
            {
                items.Add(item);
            }

            isInitialized = true;
        }

        Task IDataStore<Item>.Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
