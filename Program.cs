using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Assignment1
{
    class Program
    {
        private static int option;
        private static Dictionary dictionary;
        public static void Main(string[] args)
        {
            Console.WriteLine("Dictionary of you");
            dictionary = new Dictionary();
            runProgram();
        }
        private static void showMenu()
        {
            Console.Clear();
            Console.WriteLine("-- Welcome to the Build-your-own Dictionary --");
            Console.WriteLine("Please select one option from the menu below");
            Console.WriteLine("1. Add New Word");
            Console.WriteLine("2. Delete Word");
            Console.WriteLine("3. Get Meaning");
            Console.WriteLine("4. Dictionary List");
            Console.WriteLine("5. Print Dictionary");
            Console.WriteLine("6. Exit");
        }
        
        private static void runProgram()
        {
            do
            {
                showMenu();
                int.TryParse(Console.ReadLine(), out option);
                if (option == 1) AddWord();
                if (option == 2) DeleteWord();
                if (option == 3) GetMeaning();
                if (option == 4) DictionaryList();
                if (option == 5) PrintDictionary();
            } while (option != 6);
        }

        private static void AddWord()
        {
            Console.Clear();
            Console.WriteLine("Enter new word: ");
            string word = Console.ReadLine();
            Console.WriteLine("Enter its meaning: ");
            string meaning = Console.ReadLine();
            if(dictionary.WordExist(word))
                Console.WriteLine("This word has already exist in your dictionary..");
            Console.WriteLine(dictionary.Add(word.ToLower(),meaning.ToLower())
                ?"New word added successfully.."
                :"New word was not added..");
            if(dictionary.GetCount() == dictionary.maxWord)
                Console.WriteLine("Adding word failed! You have exceeded the maximum word..");
            Console.WriteLine("Press any key to return main menu..");
            Console.ReadKey();
        }

        private static void DeleteWord()
        {
            Console.Clear();
            Console.WriteLine(dictionary.PrintWordList());
            Console.WriteLine("Enter the word you want to delete: ");
            string word = Console.ReadLine();
            Console.WriteLine(dictionary.Delete(word.ToLower())
                ? "The word has been deleted successfully"
                : "The word '{0}' is not in the dictionary. Delete failed..", word);
            Console.WriteLine("Press any key to return main menu..");
            Console.ReadKey();
        }

        private static void GetMeaning()
        {
            Console.Clear();
            Console.WriteLine("Enter the word you are searching: ");
            string word = Console.ReadLine();
            Console.WriteLine(dictionary.WordExist(word.ToLower())
                ?dictionary.GetMeaning(word)
                :"There is no word '{0}' found in dictionary.", word);
            Console.WriteLine("Press any key to return main menu..");
            Console.ReadKey();
        }

        private static void DictionaryList()
        {
            Console.Clear();
            Console.WriteLine(dictionary.PrintWordList());
            Console.WriteLine("Press any key to return main menu..");
            Console.ReadKey();
        }

        private static void PrintDictionary()
        {
            Console.Clear();
            dictionary.PrintDictionary();
            Console.WriteLine("Press any key to return main menu..");
            Console.ReadKey();
        }
    }
}