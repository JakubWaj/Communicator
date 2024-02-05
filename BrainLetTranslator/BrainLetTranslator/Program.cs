// See https://aka.ms/new-console-template for more information

using System.Text;

string input = "";
input = Console.ReadLine();

input = input.ToLower();
StringBuilder sb = new StringBuilder();
int i = 0;
foreach (var letter in input)
{
    if (i % 2 == 1)
    {
       sb.Append(letter.ToString().ToUpper());
    }
    else
    {
        sb.Append(letter.ToString().ToLower());
    }
    i++;
}
Console.WriteLine(sb.ToString());