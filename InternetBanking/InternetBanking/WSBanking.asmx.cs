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
        public string HelloWorld()
        {
            return "Hello World";
        }
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
            
    }
}
