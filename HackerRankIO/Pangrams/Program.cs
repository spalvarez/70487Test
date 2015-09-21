﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangrams
{
    class Program
    {
        static void Main(String[] args)
        {
            List<char> ALPHABET = new List<char>()
        {
            'a','b','c','d','e','f','g','h'
            ,'i','j','k','l','m','n','o','p'
            ,'q','r','s','t','u','v','w','x'
            ,'y','z'
        };

            char[] input = Console.ReadLine().ToLower().ToCharArray();
            List<char> inputChars = new List<char>();
            inputChars.AddRange(input);

            for (int i = 0; i < ALPHABET.Count; i++)
            {
                if (!inputChars.Contains(ALPHABET[i]))
                {
                    Console.WriteLine("not pangram");
                    return;
                }
            }
            Console.WriteLine("pangram");
        }
    }
}
