using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ProyectoFinal1
{
    public class AIService
    {
        private readonly string apiKey;
        public AIService(string apiKey) => this.apiKey = apiKey;

        public async Task<string> ConsultarIAAsync(string prompt)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                // Instrucción para respuesta directa en español SIN introducción
                var promptFinal = $"Responde a la siguiente consulta de forma directa, clara y en español, sin introducciones ni frases iniciales como 'En qué puedo ayudarte'. Consulta: {prompt}";

                var json = "{ \"model\": \"gpt-3.5-turbo\", \"messages\": [ { \"role\": \"user\", \"content\": \"" + promptFinal.Replace("\"", "\\\"") + "\" } ] }";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

                if (!response.IsSuccessStatusCode)
                {
                    string errorDetails = await response.Content.ReadAsStringAsync();
                    return $"Error {response.StatusCode}: {errorDetails}";
                }

                var result = await response.Content.ReadAsStringAsync();
                JObject obj = JObject.Parse(result);
                return obj["choices"][0]["message"]["content"].ToString().Trim();
            }
        }
    }
}