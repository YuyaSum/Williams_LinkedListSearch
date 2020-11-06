using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace Williams_LinkedListSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading file, please wait...\n");

            LinkedList list = LoadFile.FileLoad();

            string choice = "";

            while (choice != "7")
            {
                Console.WriteLine("What would you like to do?: \n");
                Console.WriteLine("1: Search by name");
                Console.WriteLine("2: Show count of nodes");
                Console.WriteLine("3: Show count of all female nodes");
                Console.WriteLine("4: Show count of all male nodes");
                Console.WriteLine("5: Add a name to the list");
                Console.WriteLine("6: View top popular names");
                Console.WriteLine("7: Exit");
                choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("What we looking for?: ");
                        string name = Console.ReadLine();
                        Stopwatch sw = new Stopwatch();

                        sw.Start();
                        Node result = list.SameTimeSearch(name.ToLower());
                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;
                        Console.WriteLine("It takes " + string.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10) + " to search the list.");

                        if (result != null)
                        {
                            Console.WriteLine(name + " is in the list!");
                        }
                        else
                        {
                            Console.WriteLine(name + " is not in the list...");
                        }

                        break;
                    case "2":
                        Console.WriteLine("Number of Total Nodes: " + list.Head.Data.NodeCount + "\n");
                        break;
                    case "3":
                        Console.WriteLine("Number of Female Nodes: " + list.Head.Data.FemaleCount + "\n");
                        break;
                    case "4":
                        Console.WriteLine("Number of Male Nodes: " + list.Head.Data.MaleCount + "\n");
                        break;
                    case "5":
                        bool match = false;
                        int rankInt = -1;
                        Console.WriteLine("What is the gender? (M/F)");
                        //wile statement to check to see if its capital M or F
                        string gender = Console.ReadLine().ToUpper();
                        while (gender != "M" && gender != "F") {
                            Console.WriteLine("Please make sure its M or F");
                            gender = Console.ReadLine().ToUpper();
                        }
                        char genderChar = Convert.ToChar(gender);

                        Console.WriteLine("What is the name?");
                        name = Console.ReadLine();

                        //Check to see if its a number
                        Console.WriteLine("What is the rank?");
                        string rank = Console.ReadLine();
                        while (!Int32.TryParse(rank, out rankInt)) {
                            Console.WriteLine("Make sure rank is a number.");
                            rank = Console.ReadLine();
                        }

                        Node searchNode = list.SameTimeSearch(name.ToLower());

                        //this checks to see if either of the nodes are null and if not checks to see if gender and name are equal to input.
                        if (searchNode != null)
                        {
                            if (searchNode.Data.Name.ToLower() == name.ToLower() && searchNode.Data.Gender.Equals(genderChar))
                            {
                                match = true;
                            }
                            if (searchNode.Next != null)
                            {
                                if (searchNode.Next.Data.Name.ToLower() == name.ToLower() && searchNode.Next.Data.Gender.Equals(genderChar))
                                {
                                    match = true;
                                }
                            }
                            if (searchNode.Previous != null)
                            {
                                if (searchNode.Previous.Data.Name.ToLower() == name.ToLower() && searchNode.Previous.Data.Gender.Equals(genderChar))
                                {
                                    match = true;
                                }
                            }
                        }
                        if (match) {
                            Console.WriteLine("There is a match. Would you like to add \"_1\"? (y/n)");
                            choice = Console.ReadLine().ToLower();
                            while (choice != "y" && choice != "n") {
                                Console.WriteLine("Please type either y or n.");
                                choice = Console.ReadLine();
                            }
                            if (choice == "y") 
                            {
                                name += "_1";
                                match = false;
                            }
                        }
                        if (!match) { 
                            MetaData add = new MetaData(genderChar, name, rankInt);
                            list.Add(add);
                        }
                        break;
                    case "6":
                        Console.WriteLine("What gender would you like to view? (M/F)");
                        gender = Console.ReadLine().ToUpper();
                        while (gender != "M" && gender != "F")
                        {
                            Console.WriteLine("Please make sure its M or F");
                            gender = Console.ReadLine().ToUpper();
                        }

                        if (gender == "F")
                        {
                            Console.WriteLine("Most Popular Name and Rank: " + list.Popular()[0].Data.Name + ", " + list.Popular()[0].Data.Rank + "\n");
                        }
                        else { 
                            Console.WriteLine("Most Popular Name and Rank: " + list.Popular()[1].Data.Name + ", " + list.Popular()[1].Data.Rank + "\n");
                        }
                        break;
                    case "7":
                        break;
                    case "debug":
                        Console.WriteLine(list.Print());
                        break;
                    default:
                        Console.WriteLine("Invalid Option: Try Again.");
                        break;
                }
            }
        }
    }
}