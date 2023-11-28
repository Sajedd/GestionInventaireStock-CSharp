using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GestionInventaireStock_CSharp.Models;

namespace GestionInventaireStock_CSharp.API
{
    public class Api
    {
        public static async Task GET(HttpClient client)
        {
            var json = await client.GetStringAsync(
                 "http://localhost:3000/ceolcyne/");

            Console.Write(json);
        }

        public static async Task POST(HttpClient client, string json)
        {
            await client.PostAsJsonAsync(
            "http://localhost:3000/ceolcyne/", json);
        }
    }
}