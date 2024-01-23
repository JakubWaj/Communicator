namespace JsonAppReading;

public class Look
{

    public string Color { get; private set; }
    public string Size { get; private set; }

    public Look(string color, string size)
    {
        Color = color;
        Size = size;
    }
}