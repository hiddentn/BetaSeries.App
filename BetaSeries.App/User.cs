using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace BetaSeries.App
{
    class AppUser
    {
        static string VAULT_RESOURCE = "AppCreds" ; 
        static PasswordVault Vault = new PasswordVault();
        public string Token;
        public string Id;
        public AppUser()
        {
            try
            {
                var creds = Vault.FindAllByResource(VAULT_RESOURCE).FirstOrDefault();
                if (creds != null)
                {
                    Id = creds.UserName;
                    Token = Vault.Retrieve(VAULT_RESOURCE, Id).Password;
                }
            }
            catch (COMException)
            {
                // this exception likely means that no credentials have been stored
            }
        }
        public bool IsAuthenticated { get { return Token != null; } }

        public bool UpdateCredentials(string _id,string _token)
        {
            Id = _id;
            Token = _token;
            try
            {
                Vault.Add(new PasswordCredential(VAULT_RESOURCE, Id, Token));
                return true;
            }
            catch (Exception)
            {
                return false; 
            }
           
        }
        public bool RemoveCredentials()
        {
            try
            {
                Vault.Remove(Vault.Retrieve(VAULT_RESOURCE,Id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
