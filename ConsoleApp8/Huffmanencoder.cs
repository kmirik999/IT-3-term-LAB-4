using System.IO;
using System.Collections.Generic;
public class Huffmanencoder
{
    private class CharacterCount
    {
        public char Character;
        public int Count;
    }

    private Dictionary<char, int> GetCharactersCountInString(string str)
    {
        var dictionary = new Dictionary<char, int>();
        for (int i = 0; i < str.Length; i++)
        {
            var currentChar = str[i];
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