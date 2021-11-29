using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Function
{
    public interface ILdapValidator
    {        
        bool Valid(string userId, string password);
    }
    public class LdapManagement
    {
        public readonly string DomainName;
      
        public readonly int PortNumber;

        public LdapManagement(string domainName, int port = 389)
        {
            DomainName = domainName;
            PortNumber = port;
        }

        public bool Valid(string userId, string password)
        {
            try
            {
                string path = LdapPath();
                string username = UserFullId(userId);
                DirectoryEntry de = new DirectoryEntry(path, username, password, AuthenticationTypes.Secure);
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.FindOne();
                return true;
            }
            catch (DirectoryServicesCOMException ex)
            {
                return false;
            }
        }

        public string UserFullId(string userId)
        {
            string value = string.Format(@"{0}@{1}", userId, DomainName);
            return value;
        }

        public string LdapPath()
        {
            string value = string.Format(@"LDAP://{0}:{1}", DomainName, PortNumber);
            return value;
        }
    }
}