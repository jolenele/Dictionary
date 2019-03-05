using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.SqlServer.Server;

namespace Assignment1
{
    public class Dictionary
    {
        private int numWord;
        public readonly int maxWord;
        private WordInfo[] dictList;

        public Dictionary()
        {
            numWord = 0;
            maxWord = 10000;
            dictList = new WordInfo[maxWord];
        }

        public int BinarySearch(string word)
        {
            int low = 0, mid = 0, high = numWord - 1;
            while (low <= high)
            {
                mid = (low + high) / 2;
                //compare str1 > str2 = 1, str1 == str2 = 0, str1 <str2 = -1
                if (dictList[mid].word == word) return mid;
                if (string.Compare(dictList[mid].word, word) == 1)
                    high = mid - 1;
                if (string.Compare(dictList[mid].word, word) == -1)
                    low = mid + 1;
            }
            return -1;
        }

        public void ModifiedInsertionSort(int index)
        {
            for (int i = index + 1; i < numWord; i++)
            {
                WordInfo temp = dictList[i];
                int j = i - 1;
                while (j >= 0 && string.Compare(dictList[j].word, temp.word) == 1)
                {
                    dictList[j + 1] = dictList[j];
                    j--;
                }
                dictList[j + 1] = temp;
            }
        }

        public bool WordExist(string word)
        {
            int loc = BinarySearch(word);
            if (loc == -1) return false;
            return true;
        }

        public bool Add(string word, string meaning)
        {
            if (numWord == maxWord || BinarySearch(word) != -1) return false;
            WordInfo newWord = new WordInfo(word,meaning);
            dictList[numWord] = newWord;
            numWord++;
            int temp = 0;
            for (; temp < numWord; temp++)
            {
                if (string.Compare(dictList[temp].word, word) == 1)
                    break;
            }
            ModifiedInsertionSort(temp);
            return true;
        }
        
        public bool Delete(string word)
        {
            int loc = BinarySearch(word);
            if (loc == -1) return false;
            dictList[loc] = dictList[numWord - 1];
            numWord--;
            return true;
        }

        public int GetCount()
        {
            int count = 0;
            for (int i = 0; i < numWord; i++)
            {
                count++;
            }

            return count;
        }

        public string GetMeaning(string word)
        {
            return word + "\t-\t" + dictList[BinarySearch(word)].meaning;
        }

        public string PrintWordList()
        {
            string s = "Dictionary List: ";
            
            for (int i = 0; i < numWord; i++)
            {
                s += "\n" + dictList[i].word;
            }

            return s;
        }

        public void PrintDictionary()
        {
            Console.WriteLine("Word" + "\t-\t" + "Meaning");
            for (int i = 0; i < numWord; i++)
            {
                Console.WriteLine(dictList[i].word + "\t-\t" + dictList[i].meaning);
            }

        }
    }
}