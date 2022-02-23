using System.IO;
using System.Collections.Generic;

public class Huffmanencoder
{
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

    private Treenode BuildHuffmanTree(Dictionary<char, int> dict)
    {
        var queue = new PriorityQueue<Treenode, int>();
        foreach (var pair in dict)
        {
            queue.Enqueue(new Treenode()
            {
                Value = pair.Key.ToString(),
                Priority = pair.Value
                
            }, pair.Value);
        }

        while (queue.Count > 1)
        {
            var children = new[] {queue.Dequeue(), queue.Dequeue()};
            var newNode  = new Treenode()
            {
                Value = children[0].Value + children[1].Value,
                Priority = children[0].Priority + children[1].Priority,
                Children = children,
            };
            queue.Enqueue(newNode, newNode.Priority);
        }

        return queue.Dequeue();
    }

    public Dictionary<char, string>  GetEncodingTable(string str)
    {
        var tree = BuildHuffmanTree(GetCharactersCountInString(str));
        var table = new Dictionary<char, string>();
        TraverseTreeForCodes(tree, "", table);
        return table;
    }

    private void TraverseTreeForCodes(Treenode node, string code, Dictionary<char, string> codeTable)
    {
        if (node.Children == null)
        {
            codeTable[node.Value[0]] = code;
            return;
        }

        TraverseTreeForCodes(node.Children[0], code + "0", codeTable);
        TraverseTreeForCodes(node.Children[1], code + "1", codeTable);
    }
}
