using MyApp.RegisterAndLoginPage.EmployeeSetting;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.RegisterAndLoginPage
{
    internal class Authorization
    {

        public  LoginedUser User { get; private set; }
        public static EmployeeModel EmployeeModel { get; set; }
        private static Authorization _auth;
        private  UserRepository _repository;
        private Authorization(UserRepository repository) {
            _repository = repository;
            
        }

        public static Authorization GetInstance(UserRepository repository)
        {
            if (_auth == null)
            {
                _auth = new Authorization(repository);
            }

            return _auth;
        }

        public async Task InitUser() {
            User = await _repository.InitUser();
        }

        public async Task SignIn(string username, string password)
        {
            User = await _repository.SignIn(username, password);

        }

        public bool IsLogin() {

            return User!= null;
        }
        public class LoginedUser
        {
            public string UserName { get; set; }
            public string Token { get; set; }
        }

        
    }
}
