using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.BL
{
    public interface IRepository
    {
        void Init();
        IdentityInfo GetRandomName();
        string GetRandomSurname(Gender gender);
        string GetRandomPatronymic(Gender gender);
        string GetRandomLogin();
        string GetRandomMailDomain();
    }
}
