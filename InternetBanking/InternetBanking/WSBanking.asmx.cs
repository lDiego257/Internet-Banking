using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Services;

namespace InternetBanking
{
    /// <summary>
    /// Summary description for WSBanking
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSBanking : System.Web.Services.WebService
    {
        CNBanking entities = new CNBanking();
        
        [WebMethod]
        public int login(string usuario, string clave)
        {
            int id = 0;
            var query = entities.tblClientes.Where(x => x.Usuario == usuario & x.Clave == clave).Select(x => x);
            if (query.Count() > 0)
            {
                id = query.First().Id;
                return id;
            }
            else
            {
                return id;
            }         
        }
        [WebMethod]
        public tblCliente BuscarClientePorId(int id)
        {
            tblCliente Cliente = new tblCliente();
            Cliente = entities.tblClientes.Where(x => x.Id == id).FirstOrDefault();
            return Cliente;
        }
        [WebMethod]
        public tblCuenta BuscarCuentaPorNumero(int numero)
        {
            tblCuenta Cuenta = new tblCuenta();
            Cuenta = entities.tblCuentas.Where(x => x.Id == numero).FirstOrDefault();
            return Cuenta;
        }
        [WebMethod]
        public object ListarCuentas(string cedula)
        {
           return entities.tblCuentas.Where(x => x.Propietario == cedula).Select(x => x).ToList();
        }
        [WebMethod]
        public bool Transaccion(string origen, string destino, int monto, string concepto)
        {
            tblCuenta c1 = BuscarCuentaPorNumero(int.Parse(origen));
            tblCuenta c2 = BuscarCuentaPorNumero(int.Parse(destino));
            if (BuscarCuentaPorNumero(int.Parse(destino)) != null)
            {
                tblTransaccione transaccion = new tblTransaccione();
                transaccion.Concepto = concepto;
                transaccion.Destino = destino;
                transaccion.Monto = monto.ToString();
                transaccion.Origen = origen;
                entities.tblTransacciones.Add(transaccion);
               
          
                c1.Balance = c1.Balance - monto;
                c2.Balance = c2.Balance + monto;
                entities.Entry(c1).State = System.Data.Entity.EntityState.Modified;
                entities.Entry(c2).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
