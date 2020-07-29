using CopaMundoFilmes.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CopaMundoFilmes.Api.Services
{
    public class FilmeService
    {
        private readonly HttpClient _httpClient;

        public FilmeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Filme>> ObterFilmes()
        {
            var resultado = await _httpClient.GetAsync("http://copafilmes.azurewebsites.net/api/filmes");
            var str = await resultado.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Filme>>(str);
        }
    }
}
