using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DataGenerator.BL
{
    public class ScriptGenerator : IScriptGenerator
    {
        private readonly IRepository _repository;
        private readonly Random _random = new Random();

        public ScriptGenerator(IRepository repository)
        {
            _repository = repository;
        }

        public UserEntity GenerateUser()
        {
            UserEntity user = new UserEntity();

            user.Login = _repository.GetRandomLogin();

            user.Name = _repository.GetRandomName();
            user.Surname = _repository.GetRandomSurname();

            bool isPatronymicExist = _random.Next(100) != 0;
            if (isPatronymicExist)
                user.Patronymic = _repository.GetRandomPatronymic();


            user.Password = _random.Next(1000, 10000).ToString();
            user.Email = string.Format(@"{0}@{1}", user.Login, _repository.GetRandomMailDomain());

            int year = _random.Next(2010, 2017);
            int month = _random.Next(1, 13);
            int day = _random.Next(1, 29);
            if (year == 2016 && month > 2) month = 2;
            user.RegistrationDate = new DateTime(year, month, day);

            return user;
        }

        public string GetValueLine(UserEntity entity)
        {
            string registrationDate = entity.RegistrationDate.ToString("yyyyMMdd");
            string result = string.Format("VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", entity.Name,
                entity.Surname, entity.Patronymic, entity.Email, entity.Login, entity.Password, registrationDate);

            return result;
        }

        public string GetInsertLine()
        {
            string result =
                @"INSERT INTO BlogUser (Name, Surname, Patronymic, Email, UserLogin, Password, RegistrationDate)";

            return result;
        }

        public string CreateScript(int entityCount)
        {
            StringBuilder builder = new StringBuilder();

            string insertLine = GetInsertLine();
            builder.AppendLine(insertLine);

            for (int i = 1; i <= entityCount; i++)
            {
                UserEntity user = GenerateUser();
                string valueLine = GetValueLine(user);
                builder.Append(valueLine);
            }

            return builder.ToString();
        }

    }
}
