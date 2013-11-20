using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Xaml;

namespace ConsoleApplication1
{

    class Program
    {
        static void Main(string[] args)
        {

            /*SW.PruebaSoapClient cliente = new SW.PruebaSoapClient();
            int x = cliente.Sumar(2,4);
            */

            string apikey = "AIzaSyDPrJ6scmDKqUeJQfAGLn9u53f09UX0o1c";
            string cx = "000577246389018380999:1hm1tkgeht8";
            string query = "groupware";
            string url = string.Format("https://www.googleapis.com/customsearch/v1?key={0}&cx={1}&q={2}", apikey, cx, query);
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream outputStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(outputStream, Encoding.ASCII);
            string output = reader.ReadToEnd();
            response.Close();
            outputStream.Close();
            reader.Close();
            JavaScriptSerializer oJS = new JavaScriptSerializer();
            var tmp = oJS.DeserializeObject(output);
            Console.WriteLine(output);
            

            WebClient wc = new WebClient();
            wc.Encoding = ASCIIEncoding.UTF8;
            String  download = wc.DownloadString("http://localhost:26626/SrvSROSI.svc/GetEstudiantes");
            var result = oJS.Deserialize<Estudiante[]>(download);

        }
    }
}
