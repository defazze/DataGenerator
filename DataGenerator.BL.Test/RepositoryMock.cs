using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.BL.Test
{
    public class RepositoryMock : IRepository
    {
        public string GetRandomName()
        {
            return "Иван";
        }

        public string GetRandomSurname()
        {
            return "Иванов";
        }

        public string GetRandomPatronymic()
        {
            return "Иванович";
        }

        public string GetRandomLogin()
        {
            return "ivan";
        }

        public string GetRandomMailDomain()
        {
            return "gmail.com";
        }
    }
}
