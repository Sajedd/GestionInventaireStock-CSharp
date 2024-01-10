using System;
using System.Net;
using System.Threading;
using System.Text;
using System.IO;
using GestionInventaireStock_CSharp.API;
using GestionInventaireStock_CSharp.Server;
namespace GestionInventaireStock_CSharp
{
    public class Program
    {
        
        static async Task Main(string[] args)
        {
            await HttpServer.StartAsync();

        }
    }

}


