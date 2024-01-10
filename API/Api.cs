using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using GestionInventaireStock_CSharp.Models;

namespace GestionInventaireStock_CSharp.API
{
    public class Api
    {
        public static HttpClient client = new HttpClient();
        

        public static async Task<string> GET(string endpoint)
        {
            var json = await client.GetStringAsync(
                 Environment.GetEnvironmentVariable("DATABASE_URL")+"e-commerce/" +endpoint); //Variable d'environnement � d�finir dans Projet > Propri�t�s > D�boguer > G�n�ral
            return json;
        }

        public static async Task<string> GET_ONE(string endpoint, string id)
        {
            var json = await client.GetStringAsync(
                 Environment.GetEnvironmentVariable("DATABASE_URL") + "e-commerce/" + endpoint + "/"+id); //Variable d'environnement � d�finir dans Projet > Propri�t�s > D�boguer > G�n�ral
            return json;
        }

        public static async Task<HttpResponseMessage> POST(string endpoint, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var err = await client.PostAsync(
            Environment.GetEnvironmentVariable("DATABASE_URL") + "e-commerce/" + endpoint, content);

            return err;
        }

        public static async Task<HttpResponseMessage> PATCH(string endpoint, string id, string json)
        {
            var err = await client.PatchAsJsonAsync(
            Environment.GetEnvironmentVariable("DATABASE_URL") + "e-commerce/" + endpoint + ".php?q={\"id\":\""+id+"\"}", json);

            return err;
        }

        public static async Task<HttpResponseMessage> DELETE(string endpoint, string id)
        {
            var err = await client.DeleteAsync(
            Environment.GetEnvironmentVariable("DATABASE_URL") + "e-commerce/" + endpoint + ".php?q={\"id\":\"" + id + "\"}");

            return err;
        }
    }
}