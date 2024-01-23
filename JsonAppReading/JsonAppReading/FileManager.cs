using System.IO;
namespace JsonAppReading;

public static class FileManager
{
    public static void WriteFile(string path, string cont)
    {
        StreamWriter streamWriter = new StreamWriter(path);
        streamWriter.Write(cont);
        streamWriter.Close();
    }

    public static string ReadFile(string path)
    {
        StreamReader streamReader = new StreamReader(path);
        if (streamReader.EndOfStream)
        {
            streamReader.Close();
            return "";
        }
        string cont = streamReader.ReadToEnd();
        streamReader.Close();
        return cont;
    }
}