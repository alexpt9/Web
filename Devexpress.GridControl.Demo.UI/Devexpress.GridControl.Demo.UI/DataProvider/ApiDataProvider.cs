using Devexpress.GridControl.Demo.UI.Interfaces;
using Devexpress.GridControl.Demo.UI.Model;
using System;
using System.Collections.Generic;

namespace Devexpress.GridControl.Demo.UI.DataProvider
{
    public class ApiDataProvider : IApiDataProvider
    {
        public IReadOnlyList<Person> GetPersonsList()
        {
            Random rn = new Random();
            int count = rn.Next(100000, 120000);
            return GeneratePersonData(count); 
        }

        public  List<Person> GeneratePersonData(int count)
        {
            List<Person> people = new List<Person>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                string nickName = GenerateRandomNickName();
                int age = random.Next(18, 80); // Generate random age between 18 and 80
                string address = GenerateRandomAddress();
                string nationality = GenerateRandomNationality();
                DateTime dob = GenerateRandomDOB();
                string gender = GenerateRandomGender();
                string city = GenerateRandomCity();
                string occupation = GenerateRandomOccupation();
                string fName = GenerateRandomFirstName();
                string lName = GenerateRandomLastName();
                string org = GenerateRandomOorganisation();
                string fullName = fName + lName;

                Person person = new Person 
                { 
                    NickName = GenerateRandomNickName(), 
                    FirstName = GenerateRandomFirstName(), 
                    LastName = GenerateRandomLastName(), 
                    Age = random.Next(18, 80),
                    Address = GenerateRandomAddress(), 
                    DateOfBirth = GenerateRandomDOB(), 
                    Gender = GenerateRandomGender(), 
                    City = GenerateRandomCity(), 
                    Nationality = GenerateRandomNationality(), 
                    Occupation = GenerateRandomOccupation(), 
                    CurrentOrganisation = GenerateRandomOorganisation(),
                    IncomePerYear = GenerateIncomePerYear(),
                };
                people.Add(person);
            }

            return people;
        }

        private string GenerateRandomNickName()
        {
            // Generate random names (you can customize this as per your requirements)
            string[] names = { "John", "Al", "Mich", "Emi", "Dav", "Sop", "Dan", "Oli", "Jam", "Em" };
            Random random = new Random();
            int index = random.Next(0, names.Length);
            return names[index];
        }

        private string GenerateRandomFirstName()
        {
            // Generate random names (you can customize this as per your requirements)
            string[] names = { "John", "Alice", "Michael", "Emily", "David", "Sophia", "Daniel", "Olivia", "James", "Emma" };
            Random random = new Random();
            int index = random.Next(0, names.Length);
            return names[index];
        }

        private string GenerateRandomLastName()
        {
            // Generate random names (you can customize this as per your requirements)
            string[] names = { "sergio", "Thomson", "Jackson", "butler", "hussey", "woakes", "peter", "Beckham", "Willis", "Watson" };
            Random random = new Random();
            int index = random.Next(0, names.Length);
            return names[index];
        }

        private string GenerateRandomAddress()
        {
            // Generate random addresses (you can customize this as per your requirements)
            string[] addresses = { "123 Main St", "456 Elm St", "789 Oak Ave", "987 Pine St", "654 Maple Ave" };
            Random random = new Random();
            int index = random.Next(0, addresses.Length);
            return addresses[index];
        }

        private string GenerateRandomCity()
        {
            // Generate random addresses (you can customize this as per your requirements)
            string[] country = { "Mumbai", "Shangai", "Jerusalem", "New York", "Tokoyo" };
            Random random = new Random();
            int index = random.Next(0, country.Length);
            return country[index];
        }

        private string GenerateRandomNationality()
        {
            // Generate random addresses (you can customize this as per your requirements)
            string[] country = { "Indial", "China", "Israelis", "USA", "Japan" };
            Random random = new Random();
            int index = random.Next(0, country.Length);
            return country[index];
        }

        private DateTime GenerateRandomDOB()
        {
            int minAge = 18;
            int maxAge = 80;
            Random random = new Random();
            int randomAge = random.Next(minAge, maxAge);

            // Subtract the random age from the current date to get the date of birth
            DateTime currentDate = DateTime.Now;
            return currentDate.AddYears(-randomAge);
        }

        private string GenerateRandomGender()
        {
            // Generate random addresses (you can customize this as per your requirements)
            string[] country = { "Male", "Female", "Other" };
            Random random = new Random();
            int index = random.Next(0, country.Length);
            return country[index];
        }

        private string GenerateRandomOccupation()
        {
            // Generate random addresses (you can customize this as per your requirements)
            string[] country = { "Doctor", "Engineer", "Constrictor", "Nurse", "Teacher" };
            Random random = new Random();
            int index = random.Next(0, country.Length);
            return country[index];
        }

        private  string GenerateRandomOorganisation()
        {
            // Generate random addresses (you can customize this as per your requirements)
            string[] country = { "Apple", "Microsoft", "Facebook", "Netflix", "Appolo" };
            Random random = new Random();
            int index = random.Next(0, country.Length);
            return country[index];
        }

        private long  GenerateIncomePerYear()
        {
            Random rn = new Random();
            return rn.Next(1000000, 2000000);
        }
    }
}
