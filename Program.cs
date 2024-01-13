using System;
using System.Net;
using System.Threading;
using System.Text;
using System.IO;
using GestionInventaireStock_CSharp.API;
using GestionInventaireStock_CSharp.Server;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Reflection.Emit;
namespace GestionInventaireStock_CSharp
{
    public class Program
    {
        
        static async Task Main(string[] args)
        {
            // Hébergement de l'api
            await HttpServer.Start();

        }
    }

}


