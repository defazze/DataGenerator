using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.BL
{
    public interface IScriptGenerator
    {
        UserEntity GenerateUser();
        string GetValueLine(UserEntity entity);
        string GetInsertLine();
        string CreateScript(int entityCount);
    }
}
