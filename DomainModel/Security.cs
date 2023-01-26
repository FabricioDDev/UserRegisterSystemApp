using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public static class Security
    {
        public static bool activeSession(object session)
        {
            User user = session != null ? (User)session : null;
            if (user != null && user.idProp != 0) return true;
            else return false;
        }
        public static bool isAdmin(object session)
        {
            User user = session != null ? (User)session : null;
            if (user != null && user.RoleType.Id == 2)
                return true;
            else return false;
        }
        public static bool isErrorSessionActive(object session)
        {
            if (session != null) return true;
            else return false;
        }
    }
}
