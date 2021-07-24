using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Dark.Model;

namespace Dark.Model
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://isetma-73602.firebaseio.com/");

        public async Task<List<Person>> GetAllPersons()
        {

            return (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Select(item => new Person
              {
                  Name = item.Object.Name,
                  LastName=item.Object.LastName,
                  CIN = item.Object.CIN,
                  Phone=item.Object.Phone,
                  Mail=item.Object.Mail,
                  Adress=item.Object.Adress,
                  Coupon=item.Object.Coupon,
                  Password=item.Object.Password
                 
              }).ToList();
        }

        public async Task AddPerson(string cin, string name, string lastname,string phone,string mail,string adress,string coupon,string password)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new Person() { CIN = cin, Name = name ,LastName=lastname,Phone=phone,Mail=mail,Adress=adress,Coupon=coupon,Password=password});
        }


        public async Task<Person> GetMail(string mail)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();
           
            return allPersons.Where(a => (a.Mail ==mail)).FirstOrDefault();

        }

        public async Task<Person> GetPassword(string password)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();

            return allPersons.Where(p => (p.Password == password)).FirstOrDefault();

        }
        public async Task<Person> Authentification(string mail , string Password)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();

            return allPersons.Where(a => (a.Mail == mail) && (a.Password==Password)).FirstOrDefault();

        }

    }
}
