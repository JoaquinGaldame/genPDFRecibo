using genComandera;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataSet dataset = new DataSet();
            genComandera.genCOMAMD pdf = new genComandera.genCOMAMD();

            byte[] datosPDF = new byte[] { };
            var stringWriter = new StringWriter();
            //System.Web.HttpResponse test = new System.Web.HttpResponse(stringWriter);

            pdf.GenerandoTicket();
        }
    }
}
