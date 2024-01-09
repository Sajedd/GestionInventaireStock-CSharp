using System;
using System.Net;
using System.Threading;
using System.Text;
using System.IO;
namespace GestionInventaireStock_CSharp
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            HttpServer.Start("3000");
        }
    }
}


