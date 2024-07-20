using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.RegisterAndLoginPage.EmployeeSetting
{
    class EmployeeSaveAndGet
    {

        EmployeeModel employeeModel = new EmployeeModel();
        SaveEmailOnTxt saveEmailOnTxt = new SaveEmailOnTxt();
        public EmployeeSaveAndGet()
        {
        }
        public async void SaveEmployee()
        {
            employeeModel.Email = saveEmailOnTxt.GetEmail();
            employeeModel.Name = PlayerData.Name;
            employeeModel.RecordMathGameMinus = PlayerData.RecordMathGameMinus;
            employeeModel.RecordMathGame = PlayerData.RecordMathGame;
            employeeModel.RecordMemoryGame = PlayerData.RecordPuzzleGame;
            employeeModel.RecordPuzzleGame = PlayerData.RecordMemoryGame;

            await firebase.Child(nameof(EmployeeModel)).Child(employeeModel.Email).PutAsync(employeeModel);
        }
        public async void GetEmployee()
        {
            foreach (var employee in await GetAllEmployee())
            {
                if (employee.Email == saveEmailOnTxt.GetEmail())
                {
                    employeeModel.Email = employee.Email;
                    employeeModel.Name = employee.Name;
                    employeeModel.RecordMathGameMinus = employee.RecordMathGameMinus;
                    employeeModel.RecordMathGame = employee.RecordMathGame;
                    employeeModel.RecordPuzzleGame = employee.RecordPuzzleGame;
                    employeeModel.RecordMemoryGame = employee.RecordMemoryGame;
                    break;
                }
            }
            PlayerData.Name = employeeModel.Name;
            PlayerData.RecordMathGameMinus = employeeModel.RecordMathGameMinus;
            PlayerData.RecordMathGame = employeeModel.RecordMathGame;
            PlayerData.RecordPuzzleGame = employeeModel.RecordPuzzleGame;
            PlayerData.RecordMemoryGame = employeeModel.RecordMemoryGame;
        }



        FirebaseClient firebase = new FirebaseClient(Setting.FireBaseDatabaseUrl, new FirebaseOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult(Setting.FireBaseDatabaseUrl)
        });
        public async Task<List<EmployeeModel>> GetAllEmployee()
        {
            return (await firebase.Child(nameof(EmployeeModel)).OnceAsync<EmployeeModel>()).Select(f => new EmployeeModel
            {
                Name = f.Object.Name,
                RecordMathGameMinus = f.Object.RecordMathGameMinus,
                RecordMathGame = f.Object.RecordMathGame,
                RecordPuzzleGame = f.Object.RecordPuzzleGame,
                RecordMemoryGame = f.Object.RecordMemoryGame,
                Email = f.Object.Email,
            }).ToList();
        }
        public async Task<bool> AddOrUpdateEmployee(EmployeeModel employeeModel)
        {
            if (!string.IsNullOrWhiteSpace(employeeModel.Email))
            {
                try
                {
                    await firebase.Child(nameof(EmployeeModel)).Child(employeeModel.Email).PutAsync(employeeModel);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                var response = await firebase.Child(nameof(EmployeeModel)).PostAsync(employeeModel);
                if (response.Key != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
