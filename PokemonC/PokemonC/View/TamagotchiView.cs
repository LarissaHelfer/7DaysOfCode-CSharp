using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonC.Model;
using PokemonC;
namespace PokemonC.View;

internal class TamagotchiView
{
    private string jogador { get; set; }

    public TamagotchiView()
    {
        BoasVindas();
    }
    public void BoasVindas()
    {
        Console.WriteLine(@" 
                                                                         
                          ######   ##    #      #    ##     ####      ###   ######  ######  #    #   # 
                            #    #    #  ##    ##  #    #   #  #    #    #    #    #        #    #   #
                            #    #    #  #  ##  #  #    #  #        #    #    #    #        ######   # 
                            #    ######  #      #  ######  #  ###   #    #    #    #        #    #   # 
                            #    #    #  #      #  #    #  ######    ####     #    #######  #    #   # 
");
        Console.WriteLine("\n                                        ============================================");
        Console.WriteLine("                                             Bem vindo ao berçario de Pokemons!    ");
        Console.WriteLine("                                        ============================================\n");
        Console.Write("      Qual seu nome: ");
        jogador = Console.ReadLine();
    }

    public void PrimeiroMenu()
    {
        Console.WriteLine("\n\n=================== MENU ===================");
        Console.WriteLine($"{char.ToUpper(jogador[0]) + jogador.Substring(1)}, você deseja:\n");
        Console.WriteLine("1 - Adotar um mascote virtual");
        Console.WriteLine("2 - Ver meus macotes");
        Console.WriteLine("3 - Sair do programa");
        Console.Write($"\nDigite o número da opção desejada: ");
    }

    public string MenuAdotarMascote()
    {
        Console.WriteLine("\n============== ADOTAR UM MASCOTE ==============");
        Console.WriteLine($"{char.ToUpper(jogador[0]) + jogador.Substring(1)}, veja as opções de pokemons disponíveis para adoção:\n");
        Console.WriteLine("Bulbasaur");
        Console.WriteLine("Charmander");
        Console.WriteLine("Squirtle");
        Console.WriteLine("Caterpie");
        Console.WriteLine("Pikachu");
        Console.Write("\nDigite o nome do Pokemon que quer adotar: ");
        return Console.ReadLine();
    }

    public string InformacoesPokemon(string refPokemon)
    {
        Console.WriteLine("\n\n=================== MENU ===================");
        Console.WriteLine($"{char.ToUpper(jogador[0]) + jogador.Substring(1)}, você deseja:\n");
        Console.WriteLine($"1 - Saber mais sobre o {refPokemon}");
        Console.WriteLine($"2 - Adotar o {refPokemon}");
        Console.WriteLine($"3 - Retornar ao menu principal\n");
        Console.Write($"Digite a opção desejada: ");

        return Console.ReadLine();
    }

    public void DetalhesPokemon(Pokemon pokemon)
    {
        Console.WriteLine("\n================ INFORMAÇÕES ================");
        Console.WriteLine($"Nome: {char.ToUpper(pokemon.name[0]) + pokemon.name.Substring(1)}");
        Console.WriteLine($"ID: {pokemon.id}");
        Console.WriteLine($"Altura: {pokemon.height / 10} m");
        Console.WriteLine($"Peso:  {pokemon.weight / 10} kg");
        Console.Write("Tipo: ");
        foreach(Types tipoP in pokemon.types)
        {
            string tipoType = char.ToUpper(tipoP.type.name[0]) + tipoP.type.name.Substring(1);
            Console.Write($"{tipoType}  ");
        }
        Console.WriteLine();
        Console.Write("Habilidades: ");
        foreach (Abilities habilidade in pokemon.abilities)
        {
            string tipoHabilidade = char.ToUpper(habilidade.ability.name[0]) + habilidade.ability.name.Substring(1);
            Console.Write($"{tipoHabilidade}  ");
        }
        Console.WriteLine();
    }

    public void DetalharMascote(Pokemon pokemon)
    {
        Console.WriteLine("\n================ INFORMAÇÕES ================");

        Console.WriteLine($"Nome: {pokemon.name}");
        Console.WriteLine($"ID: {pokemon.id}");
        Console.WriteLine($"Altura: {pokemon.height/10} m");
        Console.WriteLine($"Peso:  {pokemon.weight/10} kg");

        TimeSpan idade = DateTime.Now.Subtract(pokemon.DataNascimento);

        Console.WriteLine($"Idade: {idade.Minutes} anos");

        if (pokemon.Fome())
            Console.WriteLine($"{char.ToUpper(pokemon.name[0]) + pokemon.name.Substring(1)} está com fome!");
        else
            Console.WriteLine($"{char.ToUpper(pokemon.name[0]) + pokemon.name.Substring(1)} está alimentado!");

        if (pokemon.Humor > 5)
            Console.WriteLine($"{char.ToUpper(pokemon.name[0]) + pokemon.name.Substring(1)} está feliz!");
        else
            Console.WriteLine($"{char.ToUpper(pokemon.name[0]) + pokemon.name.Substring(1)} está triste!");
        if (pokemon.Sono())
            Console.WriteLine($"{char.ToUpper(pokemon.name[0]) + pokemon.name.Substring(1)} está cansado!");
        else
            Console.WriteLine($"{char.ToUpper(pokemon.name[0]) + pokemon.name.Substring(1)} está descansado!");
    }

    public void SucessoAdotado(string especie, Pokemon pokemon)
    {
        Console.WriteLine($"{char.ToUpper(jogador[0]) + jogador.Substring(1)} seu Pokemon foi adotado com sucesso, o ovo de {pokemon.name} está chocando: ");

        Console.WriteLine(@"
               ███╗
             ███████╗
            █████████╗
            █████████║
            █████████║
            ╚███████╔╝
             ╚═════╝");
    }

    public int MenuVerPokemons(List<Pokemon> Pokemons)
    {
        Console.WriteLine("===============================================\n\n");
        Console.WriteLine($"Você possui {Pokemons.Count} Pokemon adotados.");
        for (int indicePokemon = 0; indicePokemon < Pokemons.Count; indicePokemon++)
        {
            Console.WriteLine($"{indicePokemon} - {Pokemons[indicePokemon].name}");
        }

        Console.Write($"Com qual Pokemon você deseja interagir? ");
        return Convert.ToInt32(Console.ReadLine());
    }

    public string InteragirComMascotes(Pokemon pokemon)
    {
        Console.WriteLine("===============================================\n\n");
        Console.WriteLine($"{char.ToUpper(jogador[0]) + jogador.Substring(1)}, você deseja:");
        Console.WriteLine($"1 - Saber como {pokemon.name} está");
        Console.WriteLine($"2 - Alimentar o {pokemon.name}");
        Console.WriteLine($"3 - Brincar com {pokemon.name} ");
        Console.WriteLine($"4 - Colocar {pokemon.name} para dormir");
        Console.WriteLine($"5 - Retornar ao menu principal");

        return Console.ReadLine().ToUpper();
    }

    public void AlimentarPokemon()
    {
        Console.WriteLine("===============================================\n\n");
        Console.WriteLine($"* ◡ *");
        Console.WriteLine($"Pokemon de barriga cheia");
        
    }

    public void BrincarComPokemon(Pokemon pokemon)
    {
        Console.WriteLine("===============================================\n\n");
        Console.WriteLine($"( * ◡ * )");
        Console.WriteLine($"O {pokemon.name} ficou mais feliz");
    }

    public void ColocarParaDormir()
    {
        Console.WriteLine("===============================================\n\n");
        Console.WriteLine($"(∪ ◡ ∪)");
        Console.WriteLine($"Pokemon está descansado");
    }
    public void GameOver(Pokemon pokemon)
    {
        Console.WriteLine("===============================================\n\n");
        Console.WriteLine("Seu mascote morreu de " + (pokemon.Humor > 0 ? "fome" : "tristeza", "cansaço"));

        Console.WriteLine(@"
              █████      █     █     █  ███████      ███████  █     █  ███████  ██████  
             █     █    █ █    ██   ██  █            █     █  █     █  █        █     █ 
             █         █   █   █ █ █ █  █            █     █  █     █  █        █     █ 
             █  ████  █     █  █  █  █  █████        █     █  █     █  █████    ██████  
             █     █  ███████  █     █  █            █     █   █   █   █        █   █   
             █     █  █     █  █     █  █            █     █    █ █    █        █    █  
              █████   █     █  █     █  ███████      ███████     █     ███████  █     █ ");
    }

}