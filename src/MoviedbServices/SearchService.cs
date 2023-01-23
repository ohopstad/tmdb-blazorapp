using MediaModels;
using System.Net.Http.Json;
using System.Text.Json;

namespace MoviedbServices;

public class SearchService
{
    private readonly HttpClient _HttpClient;

    public SearchService(
        HttpClient httpClient
    ) => (_HttpClient) = (httpClient);


    public async Task<ICollection<MovieModel>> SearchMovie(SearchModel partial)
    {
        List<MovieModel> ret = new();

        var content = await _HttpClient.GetFromJsonAsync<JsonElement>(
            "https://api.themoviedb.org/3/search/movie?"
                + "api_key=" + "1422303e78dc4243889e6e549813ff6d" 
                + "&query=" + partial.Title 
                + "&page=1"
            );
        
        
        var results = content.GetProperty("results");

        var arr = results.EnumerateArray();

        foreach (var m in arr)
        {
            ret.Add(new MovieModel{
                Title=m.GetProperty("title").ToString()
            });
        }

        return ret;
    }
}
