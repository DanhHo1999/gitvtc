using System.Net;
using System.Text;

namespace _15_PTPOST
{
    class TestServer
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("http://icanhazip.com");
            request.Method = "POST";
            string postData = "This is a test that posts this string to a WebServer";
            byte[] bytes=Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;

            Stream dataStream=request.GetRequestStream();

            dataStream.Write(bytes, 0, bytes.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using (dataStream = response.GetResponseStream()) { 
                StreamReader reader =new StreamReader(dataStream);
                string responseFromServer=reader.ReadToEnd();

                Console.WriteLine(responseFromServer);
            }
            response.Close();
        }
    }
}