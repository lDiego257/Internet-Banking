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

        public static object ListarCuentas(string username)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    Cliente c1 = Cliente.GetClienteByUsuario(username);
                    var response = httpClient.GetStringAsync(new Uri($"https://bank-integration.azurewebsites.net/api/Netbankings/GetClientAccounts/{ c1.Cedula}")).Result;

                    List<Cuentas> ListaCuentas = JsonConvert.DeserializeObject<List<Cuentas>>(response);
                    var query = from i in ListaCuentas
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

        public static List<Cuentas> ListarCuentasInicio(string username)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    Cliente c1 = Cliente.GetClienteByUsuario(username);
                    var response = httpClient.GetStringAsync(new Uri($"https://bank-integration.azurewebsites.net/api/Netbankings/GetClientAccounts/{ c1.Cedula}")).Result;

                    List<Cuentas> ListaCuentas = JsonConvert.DeserializeObject<List<Cuentas>>(response);
                    return ListaCuentas;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public static object ListarCuentasDrop(string username)
        {

            using (var httpClient = new HttpClient())
            {
                try
                {
                    Cliente c1 = Cliente.GetClienteByUsuario(username);
                    var response = httpClient.GetStringAsync(new Uri($"https://bank-integration.azurewebsites.net/api/Netbankings/GetClientAccounts/{ c1.Cedula}")).Result;

                    List<Cuentas> ListaCuentas = JsonConvert.DeserializeObject<List<Cuentas>>(response);
                    var query = ListaCuentas.Select(p => new { p.id, DisplayText = p.id.ToString() + "| Moneda: " + p.moneda + " | Balance: " + p.balance.ToString() });
                    return query;

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public static Cuentas GetCuentasByID(int id)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    Cuentas c1 = new Cuentas();
                    var response = httpClient.GetStringAsync(new Uri($"https://bank-integration.azurewebsites.net/api/Netbankings/GetUserAccountDetails/{ id}")).Result;
                    c1 = JsonConvert.DeserializeObject<Cuentas>(response);
                    return c1;
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
        public double precioProducto { get; set; }
        public int idCuentaEmisora { get; set; }
        public int idCuentaReceptora { get; set; }
        public DateTime fechaTransaccion { get; set; }

        public static object GetTransacciones(string NumeroCuenta)
        {
            List<Transacciones> t1 = new List<Transacciones>();
            using (var httpClient = new HttpClient())
            {
                //lista de transacciones que envia
                try
                {
                    var response = httpClient.GetStringAsync(new Uri($"https://bank-integration.azurewebsites.net/api/Netbankings/GetAccountMovementsByReceiverUser/{ NumeroCuenta}")).Result;
                    t1.AddRange(JsonConvert.DeserializeObject<List<Transacciones>>(response));
                }
                catch (Exception)
                {
                }
                //Lista de transacciones que recibe
                try
                {
                    var response = httpClient.GetStringAsync(new Uri($"https://bank-integration.azurewebsites.net/api/Netbankings/GetAccountMovementsBySenderUser/{ NumeroCuenta}")).Result;
                    t1.AddRange(JsonConvert.DeserializeObject<List<Transacciones>>(response));
                }
                catch (Exception)
                {
                }
                if (t1.Count() > 0)
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

        public static bool PostTransaction(string cedula, string concepto, double monto, int Emisor, int Receptor)
        {
            Transacciones t1 = new Transacciones();
            t1.cedula = cedula;
            t1.nombreProducto = concepto;
            t1.idCuentaEmisora = Emisor;
            t1.idCuentaReceptora = Receptor;
            t1.precioProducto = monto;
            t1.tipoTransaccion = "D";

            var json = JsonConvert.SerializeObject(t1);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync(new Uri("https://bank-integration.azurewebsites.net/api/Netbankings/TransferMoney"), data).Result;
                    if (response.IsSuccessStatusCode)
                        return true;
                    return false;
                }
        }
            catch (Exception)
            {
                return false;
            }

}


    }
    public class usuario
    {
        public string username { get; set; }
        public string clave { get; set; }

        public static bool ValidaUsuario(string vUsuario, string vClave)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = httpClient.GetStringAsync(new Uri($"https://bank-integration.azurewebsites.net/api/Netbankings/IsValidUser/Username={ vUsuario}&Clave={ vClave}")).Result;
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }

    public class CuentasShow
    {
        public int Numero_De_Cuenta { get; set; }
        public double Balance { get; set; }
        public string Moneda { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
    }

    public class Beneficiario
    {
        int idDueño { get; set; }
        int idCuentaBeneficiario { get; set; }

        public static bool RegistrarBeneficiario(string idDueño, string idCuentaBeneficiario, string alias)
        {
            try
            {
                BDBankingEntities entities = new BDBankingEntities();
                tblBeneficiario b1 = new tblBeneficiario();
                b1.Alias = alias;
                b1.idCliente = idDueño;
                b1.CuentaBeneficiario = idCuentaBeneficiario;
                entities.tblBeneficiarios.Add(b1);
                entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static List<tblBeneficiario> GetBeneficiarios(string id)
        {
            BDBankingEntities entities = new BDBankingEntities();
            List<tblBeneficiario> beneficiarios = new List<tblBeneficiario>();
            beneficiarios = entities.tblBeneficiarios.Where(x => x.idCliente == id).ToList();
            return beneficiarios;
        }
        public static object ListarBeneficariosDrop(string id)
        {

            
                //try
                //{
                    BDBankingEntities entities = new BDBankingEntities();
                    List<tblBeneficiario> beneficiarios = new List<tblBeneficiario>();
                    beneficiarios = entities.tblBeneficiarios.Where(x => x.idCliente == id).ToList();  
                    var query = beneficiarios.Select(p => new { p.CuentaBeneficiario, DisplayText = p.CuentaBeneficiario.ToString() + "| Alias: " + p.Alias });
                    return query;

                //}
                //catch (Exception)
                //{
                //    return null;
                //}
            
        }
    }
}
