using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WinFormHotel.Logica
{
    public class GestionCliente
    {
        public string url { get; set; }

        public GestionCliente()
        {
            url = "http://localhost:19346/api/Clientes/";
        }

        public List<Cliente> ListaClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                var json = webClient.DownloadString(url);
                if (json == "false")
                    lista = null;
                else
                    lista = JsonConvert.DeserializeObject<List<Cliente>>(json);
            }
            return lista;
        }

        public Cliente ClientexId(int IdCliente)
        {
            Cliente cliente = new Cliente();
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                var json = webClient.DownloadString(url + IdCliente);
                if (json == "false")
                    cliente = null;
                else
                    cliente = JsonConvert.DeserializeObject<Cliente>(json);
            }
            return cliente;
        }

        internal async void EliminarCliente(string idCliente)
        {
            using (var client = new HttpClient())
            {
                var result = await client.DeleteAsync(String.Format("{0}/{1}", url, idCliente));
            }
        }

        internal async void InsertarCliente(Cliente cliente)
        {
            using (var client = new HttpClient())
            {
                var serializedProduct = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, content);
            }
        }

        internal async void ModificarCliente(Cliente cliente)
        {
            using (var client = new HttpClient())
            {
                var serializedProduct = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(String.Format("{0}/{1}", url, cliente.Id), content);
            }
        }
    }
}
