using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.BL
{
    public interface IRepository
    {
        string GetRandomName();
        string GetRandomSurname();
        string GetRandomPatronymic();
        string GetRandomLogin();
        string GetRandomMailDomain();
    }
}
