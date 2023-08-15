namespace PokemonC.Model;

public class Pokemon
{
    public List<Abilities> abilities { get; set; }
    public List<Types> types { get; set; }
    public int id { get;set; }
    public double? height { get; set; }
    public double? weight { get; set; }
    public string? name { get; set; }
    public int Alimentacao { get; set; }
    public int Humor { get; set; }
    public int Descanso { get; set; }   
    public DateTime DataNascimento { get; set; }

    public Pokemon()
    {
        Random valorAleatorio = new();
        Alimentacao = valorAleatorio.Next(2, 10);
        Humor = valorAleatorio.Next(2, 10);
        Descanso = valorAleatorio.Next(2, 10);
        DataNascimento = DateTime.Now;
    }

    public bool Fome()
    {
        return this.Alimentacao < 5;
    }

    public void Alimentar()
    {
        this.Alimentacao++;
    }
    public bool Sono()
    {
        return this.Descanso < 5;
    }

    public void Dormir()
    {
        this.Descanso++;
        this.Alimentacao--;
    }

    public void BrincarMascote()
    {
        this.Humor++;
        this.Alimentacao--;
        this.Descanso--;
    }

    public bool Saude()
    {
        return (this.Alimentacao > 0 && this.Humor > 0 && this.Descanso > 0);
    }
}
