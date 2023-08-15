using PokemonC.Controllers;

namespace PokemonC;
class Program
{
    static void Main(string[] args)
    {
        TamagotchiController Jogo = new TamagotchiController();
        Jogo.Jogar();
    }
}