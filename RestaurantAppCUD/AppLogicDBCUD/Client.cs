using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogicDBCUD
{
    public class Client
    {
        public string requestAllRecipes()
        {
            return @"SELECT * FROM Recipe";
        }
    }
}
