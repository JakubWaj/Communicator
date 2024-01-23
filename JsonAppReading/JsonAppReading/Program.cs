// See https://aka.ms/new-console-template for more information
using JsonAppReading;
using System.Text.Json;
var dog = new Dog("Azor", "Owczarek", 5, 25.5m, new Look(Color.Red, "Big"));
var dog2 = new Dog("Burek", "Kundel", 3, 15.5m, new Look(Color.Blue, "Small"));
var dog3 = new Dog("Reksio", "Jamnik", 2, 5.5m,new Look(Color.Green, "Medium"));
List<Dog> dogs = new List<Dog>()
{
    dog,
    dog2,
    dog3
};
var serialized = JsonSerializer.Serialize(dogs); 

FileManager.WriteFile("karcewicz.txt", serialized);

var deserialized = JsonSerializer.Deserialize<List<Dog>>(FileManager.ReadFile("karcewicz.txt"));



foreach (var item in deserialized)
{
    Console.WriteLine(item);
}
