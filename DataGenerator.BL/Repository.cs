using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataGenerator.BL
{
    public class Repository : IRepository
    {
        private readonly List<string> _names;
        private readonly List<string> _surnames;
        private readonly List<string> _patronymics;
        private readonly List<string> _logins;
        private readonly List<string> _mailDomains;
        private readonly int[] _randomUniqNumbers;
        private int _currentLoginIndex = 0;
        private readonly Random _random = new Random();

        public Repository()
        {
            _randomUniqNumbers = Enumerable.Range(0, _logins.Count).OrderBy(x => _random.NextDouble()).ToArray();
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

        public string GetRandomName()
        {
            return _names[_random.Next(_names.Count)];
        }

        public string GetRandomSurname()
        {
            return _surnames[_random.Next(_surnames.Count)];
        }

        public string GetRandomPatronymic()
        {
            return _patronymics[_random.Next(_patronymics.Count)];
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
