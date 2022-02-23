using System.IO;
using System.Collections.Generic;
public class Huffmanencoder
{
    private Dictionary<char, int> GetCharactersCountInFile(string path)
    {
        var fileContent = File.ReadAllText(path);
        var dictionary = new Dictionary<char, int>();
        for (int i = 0; i < fileContent.Length; i++)
        {
            var currentChar = fileContent[i];
            if (dictionary.ContainsKey(currentChar))
            {
                dictionary[currentChar]++;
            }
            else
            {
                dictionary[currentChar] = 1;
            }
        }
        return dictionary;
    }



}