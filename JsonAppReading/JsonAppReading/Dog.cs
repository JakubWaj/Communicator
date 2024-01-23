namespace JsonAppReading;

public class Dog
{
    public string Name { get;private set; }
    public string Race { get; private set; }
    public int Age { get; private set; }
    public decimal Weight { get; private set; }
    public Look Look { get; private set; }

    public Dog(string name, string race, int age, decimal weight,Look look)
    {
        Name = name;
        Race = race;
        Age = age;
        Weight = weight;
        Look = look;
    }

    public void ChangeAge(int age)
    {
        if(age<0)
        {
            Console.WriteLine("Jestes gupi");
            return;
        }
        Age = age;
    }
    
    public override string ToString()
    {
        return $"Name: {Name} Race: {Race } Age: {Age} Weight: {Weight} Look: {Look.Color} {Look.Size}";
    }
}