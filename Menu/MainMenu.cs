using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Org.BouncyCastle.Tls;
using VOTING_APP2.Implementation.Repositories;
using VOTING_APP2.Implementations;
using VOTING_APP2.Implementations.Services;

namespace VOTING_APP2.Menu
{
    public class MainMenu
    {
        UserRepository user = new UserRepository();
        
        public static void Main()
        {
            MainMenu mainMenu = new MainMenu();
            System.Console.WriteLine("Press 1 to Login\nPress 2 to sign up");
            int response = int.Parse(Console.ReadLine()!);
            if (response == 1)
            {
                mainMenu.Login();
            }
             if (response == 2)
            {
                mainMenu.SignUp();
                Main();
            }

        }
        public void Login()
        {
            System.Console.WriteLine("Enter your Email Address");
            string email = Console.ReadLine()!;
            System.Console.WriteLine("Enter your password");
            string password = Console.ReadLine()!;
            var credentials = user.Login(email, password);

            if (credentials.Role == "SuperAdmin")
            {
                AdminMenu adminMenu = new AdminMenu();
                adminMenu.SuperAdmin();
            }
             if (credentials.Role == "Contestant")
            {
                System.Console.WriteLine(credentials.Role);
            }
             if (credentials.Role == "Voter")
            {
                VotersMenu votersMenu = new VotersMenu();
                votersMenu.VoterMenu("Votes");
            }
             if (credentials.Role == null)
            {
                System.Console.WriteLine("No credentials available");
            }
        }

         public  void SignUp()
        {
           VoterService voterService = new VoterService();
            System.Console.WriteLine("Enter the FirstName of the contestant");
            string name = Console.ReadLine()!;
            System.Console.WriteLine("Enter the LastName of the contestant");
            string LastName = Console.ReadLine()!;
            System.Console.WriteLine("Enter the age of the contestant");
            int age = int.Parse(Console.ReadLine()!);
            System.Console.WriteLine("Enter phonenumber of the contestant");
            string phonenumber=Console.ReadLine()!;
            System.Console.WriteLine("Enter the email of the contestants");
            string userEmail = Console.ReadLine()!;
            System.Console.WriteLine("Enter the password of the contestant");;
            string password = Console.ReadLine()!;
            var model = new Dtos.VoterRequestModel()
            {
                FirstName = name,
                LastName = LastName,
                Age = age,
                Password = password,
                Phonenumber = phonenumber,
                 UserEmail = userEmail,
                 
            };
             voterService.Create(model);      
        }
    }
}