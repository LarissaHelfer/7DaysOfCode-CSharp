using System;
using PokemonC.View;
using PokemonC.Service;
using PokemonC.Model;

namespace PokemonC.Controllers;

public class TamagotchiController
{
    private string nomeJogador { get; set; }
    private List<Pokemon> MascoteAdotado { get; set; }
    private TamagotchiView Mensagens { get; set; }


    public TamagotchiController()
    {
        this.MascoteAdotado = new List<Pokemon>();
        this.Mensagens = new TamagotchiView();
    }

    public void Jogar()
    {
        string opcaoUsuario;
        int jogar = 1;

        while (jogar == 1)
        {
            Mensagens.PrimeiroMenu();
            opcaoUsuario = Console.ReadLine();

            switch (opcaoUsuario)
            {
                case "1":
                    Console.Clear();
                    MenuAdocao();
                    break;
                case "2":
                    Console.Clear();
                    MenuInteracao();
                    break;
                case "3":
                    Console.Clear();
                    jogar = 0;
                    break;
                default:
                    Console.WriteLine("Opção Inválida! Informe uma opção entre 1 a 3. ");
                    break;
            }
        }
    }
    private void MenuAdocao()
    {
        string opcaoUsuario = "1", refPokemon;
        Pokemon pokemon = new();

        refPokemon = Mensagens.MenuAdotarMascote();

        while (opcaoUsuario != "3")
        {
            opcaoUsuario = Mensagens.InformacoesPokemon(refPokemon);

            switch (opcaoUsuario)
            {
                case "1":
                    Console.Clear();
                    pokemon = PokemonService.BuscaPokemon(refPokemon);
                    Mensagens.DetalhesPokemon(pokemon);
                    break;

                case "2":
                    Console.Clear();
                    pokemon = PokemonService.BuscaPokemon(refPokemon);
                    this.MascoteAdotado.Add(pokemon);
                    Mensagens.SucessoAdotado(nomeJogador, pokemon);
                    return;

                case "3":
                    Console.Clear();
                    return;

                default:
                    Console.WriteLine("Opção Inválida! Tente novamente: ");
                    break;
            }
        }
    }

    private void MenuInteracao()
    {
        string opcaoUsuario = "0";
        int idPokemon;

        idPokemon = Mensagens.MenuVerPokemons(MascoteAdotado);
        while (opcaoUsuario != "5")
        {
            opcaoUsuario = Mensagens.InteragirComMascotes(MascoteAdotado[idPokemon]);

            switch (opcaoUsuario)
            {
                case "1":
                    Console.Clear();
                    Mensagens.DetalharMascote(MascoteAdotado[idPokemon]);
                    break;
                case "2":
                    Console.Clear();
                    MascoteAdotado[idPokemon].Alimentar();
                    Mensagens.AlimentarPokemon();

                    if (!MascoteAdotado[idPokemon].Saude())
                        Mensagens.GameOver(MascoteAdotado[idPokemon]);

                    break;
                case "3":
                    Console.Clear();
                    MascoteAdotado[idPokemon].BrincarMascote();
                    Mensagens.BrincarComPokemon(MascoteAdotado[idPokemon]);
                    if (!MascoteAdotado[idPokemon].Saude())
                    {
                        Mensagens.GameOver(MascoteAdotado[idPokemon]);
                    }
                    break;
                case "4":
                    Console.Clear();
                    MascoteAdotado[idPokemon].Dormir();
                    Mensagens.ColocarParaDormir();
                    if (!MascoteAdotado[idPokemon].Saude())
                    {
                        Mensagens.GameOver(MascoteAdotado[idPokemon]);
                    }
                    break;
                case "5":
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Opção inválida, informe um valor entre 1 e 5.");
                    break;
            }
        }

    }
}
