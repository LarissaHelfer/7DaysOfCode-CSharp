using RestSharp;
using System;
using System.Text.Json;
namespace PokemonC.Service;

public static class PokemonService
{
    public static Model.Pokemon BuscaPokemon(string refPokemon)
    {
        var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{refPokemon.ToLower()}");
        var request = new RestRequest("", Method.Get);
        var response = client.Execute(request);
        return JsonSerializer.Deserialize<Model.Pokemon>(response.Content);
    }
}