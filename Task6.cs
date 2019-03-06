﻿using System;
using System.Collections.Generic;

public class Program
{
    public class DbEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}, age {2}", FirstName, LastName, Age);
        }
    }

    public class DbGenerator
    {
        private static Random _random = new Random((int)DateTime.Now.Ticks);

        private static string[] _firstNames = new string[]
        {
            "Oliver",
            "Harry",
            "Jack",
            "George",
            "Noah",
            "Charlie",
            "Jacob",
            "Alfie",
            "Freddie"
        };

        private static string[] _lastNames = new string[]
        {
            "Smith",
            "Johnson",
            "Williams",
            "Jones",
            "Brown",
            "Davis",
            "Miller"
        };

        // TODO Implement GetSequence method using yield.
        public IEnumerable<DbEntity> GetSequence(int count)
        {
            var list = new List<DbEntity>(count);
            for (int i = 0; i < count; i++)
            {
                list.Add(new DbEntity
                {
                    FirstName = _firstNames[_random.Next(_firstNames.Length - 1)],
                    LastName = _lastNames[_random.Next(_lastNames.Length - 1)],
                    Age = _random.Next(18, 60)
                });

                yield return list[i];
            }
        }

        // TODO Implement GetSequence method using yield.
        public IEnumerable<DbEntity> GetSequence()
        {
            var list = new List<DbEntity>();
            for (int i = 0; ; i++)
            {
                list.Add(new DbEntity
                {
                    FirstName = _firstNames[_random.Next(_firstNames.Length - 1)],
                    LastName = _lastNames[_random.Next(_lastNames.Length - 1)],
                    Age = _random.Next(18, 60)
                });

                yield return list[i];
            }
        }
    }

    public static void Main()
    {
        var dbGenerator = new DbGenerator();
        foreach (var item in dbGenerator.GetSequence(100))
        {
            Console.WriteLine(item);
        }

        Console.ReadLine();
    }
}