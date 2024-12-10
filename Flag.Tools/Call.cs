// using System.Text.Json;
using System.Globalization;

namespace Foot.Tools
{
    public class Call
    {
        /// <summary>
        /// Récupère des données d'une API et désérialise la réponse en un objet de type générique.
        /// </summary>
        /// <typeparam name="T">Le type de l'objet attendu après désérialisation.</typeparam>
        /// <param name="url">L'URL de l'API pour récupérer les données.</param>
        /// <returns>Un objet de type T contenant les données désérialisées.</returns>
        public T GetFromApi<T>(string url)
        {
            // Appel de la méthode GetDataFromApi pour obtenir la réponse JSON de l'API
            var jsonResult = GetDataFromApi(url);
            // Désérialisation de la réponse JSON en un type générique T
            T result = JsonSerializer.Deserialize<T>(jsonResult);
            return result;
        }

        public string GetDataFromApi(string url)
        {
            // Initialisation d'une variable pour stocker le résultat
            string result = "";
            // Création d'une instance de HttpClient pour effectuer la requête
            HttpClient client = new HttpClient();
            // Appel de l'api récupération de la réponse 
            result = client.GetStringAsync(url).Result;
            return result;
        }
    }
}
