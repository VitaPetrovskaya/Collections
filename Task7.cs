using System;
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

        // TODO mplement GetSequence method using yield.
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
    }

    public struct FirstLastKey
    {
        private readonly string _firstName;
        private readonly string _lastName;

        public FirstLastKey(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public override bool Equals(object obj)
        {
            // TODO #1 Implement Equals method.
            if (obj == null)
            {
                return false;
            }

            FirstLastKey entity = (FirstLastKey)obj;
            if (entity._firstName == _firstName && entity._lastName == _lastName)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            // TODO #1 Implement GetHashCode method.
            return (_firstName + _lastName).GetHashCode();
        }
    }

    public struct AgeKey
    {
        private readonly int _age;

        public AgeKey(int age)
        {
            _age = age;
        }

        public override bool Equals(object obj)
        {
            // TODO #1 Implement Equals method.
            if (obj == null)
            {
                return false;
            }

            AgeKey entity = (AgeKey)obj;
            if (entity._age == _age)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            // TODO #1 Implement GetHashCode method.
            return _age.GetHashCode();
        }
    }

    public class Database
    {
        private readonly List<DbEntity> _entities = new List<DbEntity>();
        private readonly Dictionary<FirstLastKey, List<DbEntity>> _fnDict = new Dictionary<FirstLastKey, List<DbEntity>>();
        private readonly Dictionary<AgeKey, List<DbEntity>> _ageDict = new Dictionary<AgeKey, List<DbEntity>>();

        public void AddRange(IEnumerable<DbEntity> entities)
        {
            _entities.AddRange(entities);

            // TODO #1 Set dictionary with key-value pairs.
            
            foreach(DbEntity entity in entities)
            {
                FirstLastKey firstLastKey = new FirstLastKey(entity.FirstName, entity.LastName);
                if(_fnDict.ContainsKey(firstLastKey))
                {
                    _fnDict[firstLastKey].Add(entity);
                }
                else
                {
                    List<DbEntity> list = new List<DbEntity>();
                    list.Add(entity);
                    _fnDict.Add(firstLastKey, list);
                }
            }

            foreach(DbEntity entity in entities)
            {
                AgeKey ageKey = new AgeKey(entity.Age);
                if (_ageDict.ContainsKey(ageKey))
                {
                    _ageDict[ageKey].Add(entity);
                }
                else
                {
                    List<DbEntity> list = new List<DbEntity>();
                    list.Add(entity);
                    _ageDict.Add(ageKey, list);
                }
            }
        }

        public IList<DbEntity> FindBy(string firstName, string lastName)
        {
            // TODO #1 Implement FinbBy method.
            List<DbEntity> result = new List<DbEntity>();
            if(_fnDict.TryGetValue(new FirstLastKey(firstName, lastName), out result))
            {
                return result;
            }

            return new DbEntity[] { };
        }

        public IList<DbEntity> FindBy(int age)
        {
            // TODO #2 Add AgeKey struct, dictionary and implement FinbBy method.
            List<DbEntity> result = new List<DbEntity>();
            if (_ageDict.TryGetValue(new AgeKey(age), out result))
            {
                return result;
            }

            return new DbEntity[] { };
        }
    }

    public static void Main()
    {
        var dbGenerator = new DbGenerator();
        var db = new Database();
        db.AddRange(dbGenerator.GetSequence(10000));

        var items = db.FindBy("Jack", "Jones");
        Console.WriteLine(items.Count);

        var items2 = db.FindBy(30);
        Console.WriteLine(items2.Count);

        Console.ReadLine();
    }
}