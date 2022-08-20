using System.Net;

namespace _14_PTGET
{
    class TestServer
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("http://icanhazip.com");
            request.Method = "GET";
            //Get response
            WebResponse response = request.GetResponse();
            //display status
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            //get the stream containing content returned by the server
            //the using block ensures the stream is automatically closed.
            Stream dataStream = response.GetResponseStream();
                //Open the stream using a StreamReader for easy access
                StreamReader reader = new StreamReader(dataStream);
                //Read the content
                string responseFromServer=reader.ReadToEnd();

                Console.WriteLine(responseFromServer);
            
            response.Close();
        }
    }
}