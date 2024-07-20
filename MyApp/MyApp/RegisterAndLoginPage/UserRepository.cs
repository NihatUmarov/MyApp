using Firebase.Auth;
using MyApp.RegisterAndLoginPage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static MyApp.RegisterAndLoginPage.Authorization;

namespace MyApp
{
    internal class UserRepository
    {
        static string webAPIKey = "AIzaSyAA6p4CsQ82FvYrPdAMmW8q43J3s7GLWK8";
        FirebaseAuthProvider authProvider;

        public UserRepository()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIKey));
        }
        public async Task<bool> Register(string email,string name,string password)
        {
            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(email,password,name);
            return !string.IsNullOrEmpty(token.FirebaseToken);
     
        }
        public async Task<LoginedUser>SignIn(string email,string password)
        {
            var token = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                TokenUtils.Save(token.FirebaseToken);
                
                return new LoginedUser()
                {

                    UserName = token.User.DisplayName,
                    Token = token.FirebaseToken,
                };
            }
            return null;
        }

        public async Task<LoginedUser> InitUser()
        {
            var token = TokenUtils.GetToken();
            if (token != null)
            {
                var result = await authProvider.GetUserAsync(token);
                return new LoginedUser()
                {
                    UserName = result.DisplayName,
                    Token = token
                };
            }

            return null;
           
        }
        public async Task<bool>ResetPassword(string email)
        {
            await authProvider.SendPasswordResetEmailAsync(email);
            return true;
        }     
        
    }
    
}
