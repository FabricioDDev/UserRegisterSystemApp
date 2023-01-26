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

    }
}
