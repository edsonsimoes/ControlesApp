using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ControlesAppCross
{
    public class DataServices
    {
        HttpClient client = new HttpClient();

        public async Task<List<Tarefas>> GetTarefasAsync(string Tipo, string Usuario)
        {
            try
            {
                string url = "http://vm01.bulgart.com:5000/Api/Tarefas?tipo=" + Tipo + "&usuario=" + Usuario + "&senha=123";

                var response = await client.GetStringAsync(url);
                var Tarefass = JsonConvert.DeserializeObject<List<Tarefas>>(response);
                return Tarefass;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<Usuario>> GetUsuario(string Nome, string Senha)
        {
            try
            {
                string url = "http://vm01.bulgart.com:5000/Api/Usuarios?usuario=" + Nome + "&senha=" + Senha;
                var response = await client.GetStringAsync(url);
                var UsuarioLogado = JsonConvert.DeserializeObject<List<Usuario>>(response);
                return UsuarioLogado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public async Task AddTarefasAsync(Tarefas Tarefas)
        //{
        //    try
        //    {
        //        string url = "http://www.webapi.somee.com/api/Tarefass/{0}";

        //        var uri = new Uri(string.Format(url, Tarefas.CodPro));

        //        var data = JsonConvert.SerializeObject(Tarefas);
        //        var content = new StringContent(data, Encoding.UTF8, "application/json");

        //        HttpResponseMessage response = null;

        //        response = await client.PostAsync(uri, content);
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            throw new Exception("Erro ao incluir Tarefas");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task UpdateTarefasAsync(Tarefas Tarefas)
        //{
        //    string url = "http://www.webapi.somee.com/api/Tarefass/{0}";
        //    var uri = new Uri(string.Format(url, Tarefas.CodPro));

        //    var data = JsonConvert.SerializeObject(Tarefas);
        //    var content = new StringContent(data, Encoding.UTF8, "application/json");

        //    HttpResponseMessage response = null;
        //    response = await client.PutAsync(uri, content);
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new Exception("Erro ao atualizar Tarefas");
        //    }

        //}

        //public async Task DeletaTarefasPorIndiceAsync(int indice)
        //{
        //    string url = "http://www.webapi.somee.com/api/Tarefass/{0}";
        //    await client.DeleteAsync(string.Concat(url, indice));
        //}

        //public async Task DeletaTarefasAsync(Tarefas Tarefas)
        //{
        //    string url = "http://www.webapi.somee.com/api/Tarefass/{0}";
        //    var uri = new Uri(string.Format(url, Tarefas.CodPro));
        //    await client.DeleteAsync(uri);
        //}

    }
}
