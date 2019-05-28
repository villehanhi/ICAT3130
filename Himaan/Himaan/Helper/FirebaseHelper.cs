using System;
using System.Collections.Generic;
using System.Text;
using Himaan.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Himaan.Helper
{

    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://himaandatabase.firebaseio.com/");

        public async Task<List<User>> GetAllUsers()
        {

            return (await firebase
              .Child("Users")
              .OnceAsync<User>()).Select(item => new User
              {
                  userId = item.Object.userId,
                  userFirstname = item.Object.userFirstname,
                  userLastname = item.Object.userLastname,
                  userEmail = item.Object.userEmail,
                  userDateOfBirth = item.Object.userDateOfBirth,
                  userPhone = item.Object.userPhone
              }).ToList();
        }

        public async Task AddUser(int userId, string firstName, string lastName, string email, DateTime dateOfBirth, string phone)
        {

            await firebase
              .Child("Users")
              .PostAsync(new User() { userId = userId, userFirstname = firstName, userLastname = lastName, userEmail = email, userDateOfBirth = dateOfBirth, userPhone = phone});
        }

        public async Task<User> GetUser(int userId)
        {
            var allUsers = await GetAllUsers();
            await firebase
              .Child("Users")
              .OnceAsync<User>();
            return allUsers.Where(a => a.userId == userId).FirstOrDefault();
        }

        public async Task UpdateUser(int userId, string firstName, string lastname, string email, string phone)
        {
            var toUpdatePerson = (await firebase
              .Child("Users")
              .OnceAsync<User>()).Where(a => a.Object.userId == userId).FirstOrDefault();

            await firebase
              .Child("Users")
              .Child(toUpdatePerson.Key)
              .PutAsync(new User() { userId = userId, userFirstname = firstName, userLastname = lastname, userEmail = email, userPhone = phone });
        }

        public async Task DeleteUser(int userId)
        {
            var toDeletePerson = (await firebase
              .Child("Users")
              .OnceAsync<User>()).Where(a => a.Object.userId == userId).FirstOrDefault();
            await firebase.Child("Users").Child(toDeletePerson.Key).DeleteAsync();

        }

        public async Task AddOffer(string offerTo, string offerFrom, DateTime offerDate, int offerFreeSeats, string offerDescription)
        {
            await firebase
              .Child("Offers")
              .PostAsync(new Offer() { offerTo = offerTo, offerFrom = offerFrom, offerDate = offerDate, offerFreeSeats = offerFreeSeats, offerDescription = offerDescription });
        }

        public async Task AddNeed(string needTo, string needFrom, DateTime needDate, int NeededSeats, string needDescription)
        {
            await firebase
              .Child("Needs")
              .PostAsync(new Need() { needTo = needTo, needFrom = needFrom, needDate = needDate,
                  needFreeSeats = NeededSeats, needDescription = needDescription });
        }
    }

}