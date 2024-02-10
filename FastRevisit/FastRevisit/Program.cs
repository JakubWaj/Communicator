// See https://aka.ms/new-console-template for more information

using FastRevisit.Sorting;

Console.WriteLine("Hello, World!");

int seed = 30;

var ints = Numbers.getData(15,321321);

var intsresult = InsertionSort.Sort(ints);
Console.WriteLine(string.Join(", ", intsresult));