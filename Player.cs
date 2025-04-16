public abstract class Player
{
    public string Name { get; set; }
    public char Symbol { get; set; }

    protected Player(string name, char symbol)
    {
        Name = name;
        Symbol = symbol;
    }

    public abstract int GetMove(Board board);
}