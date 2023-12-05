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
        public static async Task<string> GET(HttpClient client)
        {
            var json = await client.GetStringAsync(
                 Environment.GetEnvironmentVariable("API_URL")); //Variable d'environnement à définir dans Projet > Propriétés > Déboguer > Général

            return json;
        }

        public static async Task<string> GET_ONE(HttpClient client, string id)
        {
            var json = await client.GetStringAsync(
                 Environment.GetEnvironmentVariable("API_URL") + id);

            return json;
        }

        public static async Task<HttpResponseMessage> POST(HttpClient client, string json)
        {
            var err = await client.PostAsJsonAsync(
            Environment.GetEnvironmentVariable("API_URL"), json);

            return err;
        }

        public static async Task<HttpResponseMessage> PATCH(HttpClient client, string id, string json)
        {
            var err = await client.PatchAsJsonAsync(
            Environment.GetEnvironmentVariable("API_URL") + id, json);

            return err;
        }

        public static async Task<HttpResponseMessage> DELETE(HttpClient client, string id)
        {
            var err = await client.DeleteAsync(
            Environment.GetEnvironmentVariable("API_URL") + id);

            return err;
        }
    }
}