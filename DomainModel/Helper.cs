using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public static class Helper
    {
        
        public static Func<string, int, int, bool> validate_LongText = (
           texto, min, max
           ) => texto.Length >= min && texto.Length <= max;
        public static String generateRandomCode()
        {
            Random rdm = new Random();
            return rdm.Next(1000, 9000).ToString();
        }
        
    }
}
