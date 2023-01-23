using Models;
using System.Net.Http.Json;
using System.Text.Json;


namespace Services;

public class MovieDBSearchService
{
    private readonly HttpClient _HttpClient;

    public MovieDBSearchService(
        HttpClient httpClient
    ) => (httpClient) = (_HttpClient);

    // public async Task<ICollection<IMediaModel>> SearchFor(SearchModel partial)
    // {
    //     var content = await _HttpClient.GetFromJsonAsync<JsonElement>(
    //         $"https://api.themoviedb.org/3/movie/{id}?api_key=1422303e78dc4243889e6e549813ff6d"
    //         );

    //     ret.releaseDate = content.GetProperty("release_date").ToString();
    //     ret.title = content.GetProperty("original_title").ToString();

    // }


    public async Task<ICollection<MovieModel>> SearchMovie(SearchModel partial)
    {
        var content = await _HttpClient.GetFromJsonAsync<JsonElement>(
            "https://api.themoviedb.org/3/search/movie?"
                + "api_key=" + "1422303e78dc4243889e6e549813ff6d" 
                + "&query=" + partial.Title 
                + "&page=1"
            );
        
        return new List<MovieModel>{
            new MovieModel{Title=content.GetString()}
        };
    }
}
