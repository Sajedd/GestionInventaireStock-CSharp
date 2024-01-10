using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading;
using GestionInventaireStock_CSharp.API;
using System.Net.Cache;

namespace GestionInventaireStock_CSharp.Server
{
    public class HttpServer
    {
        static HttpListener httpListener = new HttpListener();
        private static HttpClient client = new HttpClient();

        public static async Task StartAsync()
        {
            // fichier html

            string html = File.ReadAllText("C:\\Users\\dell\\B2\\GestionInventaireStock-CSharp\\index.html");



            // Lancement du serveur

            Console.WriteLine("Starting server...");
            httpListener.Prefixes.Add("http://localhost:3000/"); // Ajout de l'URI du serveur local
            httpListener.Start();
            Console.WriteLine("Running at http://localhost:3000/");

            // Gestion des requêtes
            while (true)
            {
                HttpListenerContext context = httpListener.GetContext(); // get a context
                HttpListenerRequest request = context.Request;
                if (request.HttpMethod == "GET")
                {
                    Console.WriteLine(await Api.GET(request.Url.LocalPath));

                    byte[] bytesHtml = Encoding.UTF8.GetBytes(await Api.GET(request.Url.LocalPath)); // Conversion en byte
                    context.Response.OutputStream.Write(bytesHtml, 0, bytesHtml.Length); // "Dépot" du fichier HTML sur le server
                    context.Response.Close(); // Fin de transmission
                }
                
                Console.WriteLine("REQUEST : " + context.Request.HttpMethod);
                Console.WriteLine("RESPONSE : " + context.Response);



            }
        }
    }
}