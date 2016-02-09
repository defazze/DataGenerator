using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataGenerator.Data
{
    public class Repository : IRepository
    {
        private readonly List<IdentityInfo> _names = new List<IdentityInfo>();
        private readonly List<IdentityInfo> _surnames = new List<IdentityInfo>();
        private readonly List<IdentityInfo> _patronymics = new List<IdentityInfo>();
        private readonly List<string> _logins = new List<string>();
        private readonly List<string> _mailDomains = new List<string>();
        
        private readonly int[] _randomUniqNumbers;
        private int _currentLoginIndex = 0;
        private readonly Random _random = new Random();

        private const string MALE_NAMES_PATH = @"Data\MaleNames.txt";
        private const string FEMALE_NAMES_PATH = @"Data\FemaleNames.txt";
        private const string SURNAMES_PATH = @"Data\surnames.txt";
        private const string PATRONYMIC_PATH = @"Data\patronymic.txt";
        public const string ENGLISH_WORD_PATH = @"EnglishWord.txt";

        public Repository()
        {
            _randomUniqNumbers = Enumerable.Range(0, _logins.Count).OrderBy(x => _random.NextDouble()).ToArray();
        }

        public void Init()
        {
            Action<string, Gender> addNames = (a, b) =>
            {
                using (TextReader reader = new StreamReader(a))
                {
                    while (true)
                    {
                        string name = reader.ReadLine();
                        if (name == null) break;

                        _names.Add(new IdentityInfo() {Gender = b, Identity = name});
                    }
                }
            };

            addNames(MALE_NAMES_PATH, Gender.Male);
            addNames(FEMALE_NAMES_PATH, Gender.Female);
        }

        internal string GetLogin(string line)
        {
            Regex regex = new Regex(@"\d+\s{2}(?<word>[a-z]+).+?n-");
            if (regex.IsMatch(line))
            {
                return regex.Match(line).Groups["word"].ToString();
            }

            return null;
        }

        public IdentityInfo GetRandomName()
        {
            return _names[_random.Next(_names.Count)];
        }

        public string GetRandomSurname(Gender gender)
        {
            return _surnames[_random.Next(_surnames.Count)].Identity;
        }

        public string GetRandomPatronymic(Gender gender)
        {
            return _patronymics[_random.Next(_patronymics.Count)].Identity;
        }

        public string GetRandomLogin()
        {
            if (_currentLoginIndex >= _logins.Count)
                throw new Exception("Из источника данных невозможно выбрать уникальный логин.");

            string login = _logins[_randomUniqNumbers[_currentLoginIndex]];
            _currentLoginIndex++;

            return login;
        }

        public string GetRandomMailDomain()
        {
            return _mailDomains[_random.Next(_mailDomains.Count)];
        }
    }
}
