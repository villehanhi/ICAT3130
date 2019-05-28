using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase;

namespace Himaan
{
    public interface IFirebaseAuthenticator
    {
        Task<string> LoginWithEmailPassword(string email, string password);
    }
}
