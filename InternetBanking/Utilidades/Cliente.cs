using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class Cliente
    {
        private int id;
        private string nombre;
        private string apellido;
        private string cedula;
        private string correoElectronico;
        private string telefono;
        private string usuario;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Usuario { get => usuario; set => usuario = value; }

        public static Cliente BuscarCliente(string cedula)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    Cliente c1 = new Cliente();
                    var response = httpClient.GetStringAsync(new Uri($"https://bank-integration.azurewebsites.net/api/Netbankings/GetClientDetails/{ cedula}")).Result;
                    c1= JsonConvert.DeserializeObject<Cliente>(response);
                    return c1;
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }
    }
}
