using ASP.NETProject.DbModels.Entities;
using DbModels.Entities;
using BusinessLogics;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfContracts;
using WcfContracts.DataContracts;

namespace MainProjectWcfApp
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "UserService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы UserService.svc или UserService.svc.cs в обозревателе решений и начните отладку.
    public class UserService : IUserService
    {
        IdentityUnitOfWork Database = new IdentityUnitOfWork("Identity");

        public OperationDetails Create(UserData userDto)
        {
            ApplicationUser user;
            if (Database.UserManager.FindByEmail(userDto.Email) == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = Database.UserManager.Create(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                Database.UserManager.AddToRole(user.Id, userDto.Role);
                // создаем профиль клиента

               /* var CustomerId = Database.ClientManager.GetAll().OrderByDescending(x => x.CustomerId).First().CustomerId + 1;*/
                ClientProfile clientProfile = new ClientProfile() { Id = user.Id, Address = userDto.Address, Name = userDto.Name};

                Database.ClientManager.Create(clientProfile);
                Database.Save();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public ClaimsIdentityContract Authenticate(UserData userDto)
        {
            ClaimsIdentityContract claim = null;
            // находим пользователя
            ApplicationUser user = Database.UserManager.Find(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = new ClaimsIdentityContract(Database.UserManager.CreateIdentity(user,
                                            DefaultAuthenticationTypes.ApplicationCookie));
            return claim;
        }

        // начальная инициализация бд
        public void SetInitialData(UserData adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = Database.RoleManager.FindByName(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    Database.RoleManager.Create(role);
                }
            }
            Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

