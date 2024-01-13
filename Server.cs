using System.Text;
using System.Net;
using GestionInventaireStock_CSharp.API;

namespace GestionInventaireStock_CSharp.Server
{
    public class HttpServer
    {
        static HttpListener httpListener = new HttpListener();

        public static async Task Start()
        {
            // Lancement du serveur
            string API_URL = "http://localhost:3000/";
            Console.WriteLine("Starting server...");
            httpListener.Prefixes.Add(API_URL); // Ajout de l'URI du serveur local
            httpListener.Start();
            Console.WriteLine("Running at "+API_URL);

            // Gestion des requêtes http
            while (true)
            {
                HttpListenerContext context = httpListener.GetContext(); // Obtention des informations sur la page (dites "context")
                HttpListenerRequest request = context.Request;
                if (request.HttpMethod == "GET")
                {
                    Console.WriteLine(await Api.GET(request.Url.LocalPath));

                    byte[] bytesHtml = Encoding.UTF8.GetBytes(await Api.GET(request.Url.LocalPath)); // Conversion en byte
                    context.Response.OutputStream.Write(bytesHtml, 0, bytesHtml.Length); // "Dépot" du fichier HTML sur le server
                }
                else if (request.HttpMethod == "POST") 
                {

                    string body = new StreamReader(request.InputStream, request.ContentEncoding).ReadToEnd();

                    Console.WriteLine(body);
                    HttpResponseMessage rep = await Api.POST(request.Url.LocalPath, body);
                    Console.WriteLine(rep.StatusCode.ToString());
                }
                else if (request.HttpMethod == "PUT")
                {
                    string body = new StreamReader(request.InputStream, request.ContentEncoding).ReadToEnd();

                    Console.WriteLine(body);
                    await Api.PUT(request.Url.LocalPath, body);
                }
                else if(request.HttpMethod == "DELETE")
                {
                    await Api.DELETE(request.Url.LocalPath);

                }

                Console.WriteLine("REQUEST : " + context.Request.HttpMethod);
                Console.WriteLine("RESPONSE : " + context.Response.StatusCode);
                context.Response.Close(); // Fin de transmission
                Console.WriteLine("DONE");




            }
        }
    }
}