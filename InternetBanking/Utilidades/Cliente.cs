using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
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

        public static Cliente GetClienteByUsuario(string usuario)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    Cliente c1 = new Cliente();
                    var response = httpClient.GetStringAsync(new Uri($"https://bank-integration.azurewebsites.net/api/Netbankings/GetClientDetails/{ usuario}")).Result;
                    c1 = JsonConvert.DeserializeObject<Cliente>(response);
                    return c1;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }


    }

    public class Cuentas
    {
        public int id { get; set; }
        public string propietario { get; set; }
        public string cedula { get; set; }
        public string tipo { get; set; }
        public string moneda { get; set; }
        public double balance { get; set; }
        public string estado { get; set; }
        public DateTime ultimaVisita { get; set; }

        public static object ListarCuentas()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = httpClient.GetStringAsync(new Uri($"https://corebankapis.azurewebsites.net/api/TblCuentas")).Result;

                    List<Cuentas> c1 = JsonConvert.DeserializeObject<List<Cuentas>>(response);
                    var query = from i in c1
                                select new
                                {
                                    Numero_De_Cuenta = i.id,
                                    Balance = i.balance,
            
                                    Moneda = i.moneda,
                                    Estado = i.estado,
                                    Tipo = i.tipo,

                                };
                    return query;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

    }

    public class Transacciones
    {
        public int id { get; set; }
        public string cedula { get; set; }
        public string tipoTransaccion { get; set; }
        public string nombreProducto { get; set; }
        public int precioProducto { get; set; }
        public string idCuentaEmisora { get; set; }
        public string idCuentaReceptora { get; set; }
        public DateTime fechaTransaccion { get; set; }

        public static object GetTransacciones(int NumeroCuenta)
        {
            List<Transacciones> t1 = new List<Transacciones>();
            List<Transacciones> t2 = new List<Transacciones>();
            using (var httpClient = new HttpClient())
            {
                //lista de transacciones que envia
                try
                {
                    var response = httpClient.GetStringAsync(new Uri($"")).Result;
                    t1 = JsonConvert.DeserializeObject<List<Transacciones>>(response);                                      
                }
                catch (Exception)
                {
                    t1 = null;
                }
                //Lista de transacciones que recibe
                try
                {
                    var response = httpClient.GetStringAsync(new Uri($"")).Result;
                    t2 = JsonConvert.DeserializeObject<List<Transacciones>>(response);
                }
                catch (Exception)
                {
                    t2 = null;
                }
                t1.AddRange(t2);
                if(t1 != null)
                {
                    var query = from i in t1
                                select new
                                {
                                  Fecha = i.fechaTransaccion,
                                  Cuenta_Remitente = i.idCuentaEmisora,
                                  Cuenta_Receptora = i.idCuentaReceptora,
                                  Monto = i.precioProducto,
                                  Concepto = i.nombreProducto,
                                  Tipo = i.tipoTransaccion,
                                };
                    return query.OrderByDescending(x => x.Fecha);
                }
                return t1;
            }
        }

    }
    public class usuario
    {
        public string username { get; set; }
        public string clave { get; set; }

        public static async Task<bool> ValidarUsuarioAsync(string usuario, string clave)
        {
            using (var Client = new HttpClient())
            {
                var response = await Client.GetAsync(new Uri($"https://bank-integration.azurewebsites.net/api/Netbankings/IsValidUser/Username={ usuario}&Clave={ clave}"));
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return true;
                return false;              
            }
        }   
    }
   
}
