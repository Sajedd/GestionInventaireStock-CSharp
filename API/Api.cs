using System.Text;

namespace GestionInventaireStock_CSharp.API
{
    public class Api
    {
        public static HttpClient client = new HttpClient();

        public Api() { 
            client.Timeout = TimeSpan.FromSeconds(5);
        }    

        
        // Create : méthode nous permettant d'enregistrer de nouvelles données
        public static async Task<HttpResponseMessage> POST(string endpoint, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var err = await client.PostAsync(
            Environment.GetEnvironmentVariable("DATABASE_URL") + endpoint, content);

            return err;
        }

        // Read : méthode nous permettant d'obtenir les informations désirés (utilisateurs, produits)
        public static async Task<string> GET(string endpoint)
        {
            var json = await client.GetStringAsync(
                 Environment.GetEnvironmentVariable("DATABASE_URL") +endpoint); //Variable d'environnement � d�finir dans Projet > Propri�t�s > D�boguer > G�n�ral
            return json;
        }

        // Update : méthode nous permettant de modifier des informations sur les données déja présentes
        public static async Task<HttpResponseMessage> PUT(string endpoint, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var err = await client.PutAsync(
            Environment.GetEnvironmentVariable("DATABASE_URL") + endpoint, content);

            return err;
        }

        // Delete : méthode nous permettant de supprimer un élément de la base de données
        public static async Task<HttpResponseMessage> DELETE(string endpoint)
        {
            var err = await client.DeleteAsync(
            Environment.GetEnvironmentVariable("DATABASE_URL") + endpoint);

            return err;
        }
    }
}