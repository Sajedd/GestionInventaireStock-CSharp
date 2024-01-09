using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading;

namespace GestionInventaireStock_CSharp
{
    public class HttpServer
    {
        static HttpListener httpListener = new HttpListener();

        public static void Start(string port)
        {
            // fichier html

            string html = File.ReadAllText("index.html");
            byte[] bytesHtml = Encoding.UTF8.GetBytes(html); // Conversion en byte


            // Lancement du serveur

            Console.WriteLine("Starting server...");
            httpListener.Prefixes.Add(string.Format("http://localhost:{0}/", port)); // Ajout de l'URI du serveur local
            httpListener.Start();
            Console.WriteLine(string.Format("Running at http://localhost:{0}/", port));

            // Gestion des requêtes
            while (true)
            {
                HttpListenerContext context = httpListener.GetContext(); // get a context
                                                                         // Now, you'll find the request URL in context.Request.Url
                context.Response.OutputStream.Write(bytesHtml, 0, bytesHtml.Length); // "Dépot" du fichier HTML sur le server
                context.Response.Close(); // Fin de transmission
            }
        }
    }
}