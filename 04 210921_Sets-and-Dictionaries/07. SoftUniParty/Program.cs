using System;
using System.Collections.Generic;

namespace _07._SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guestList = new HashSet<string>();
            HashSet<string> vipList = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vipList.Add(input);
                }
                else
                {
                    guestList.Add(input);
                }

                input = Console.ReadLine();
            }

            string output = Console.ReadLine();

            while (output != "END")
            {

                if (char.IsDigit(output[0]))
                {
                    vipList.Remove(output);
                }
                else
                {
                    guestList.Remove(output);
                }

                output = Console.ReadLine();
            }

            Console.WriteLine(guestList.Count + vipList.Count);
            PrintGuests(vipList);
            PrintGuests(guestList);
        }

            static void PrintGuests(HashSet<string> guests)
            {
                foreach (var member in guests)
                {
                    Console.WriteLine(member);
                }
            }
        }
    }