using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Receitas_V2
{

    class Utilizador 
    {

        #region Properties
        public string Username { get; set; }
        public string Password { get; set; }
        public string Pin { get; set; }
        #endregion

        #region Constructor
        public Utilizador(string username, string password, string pin)
        {
            Username = username;
            Password = password;
            Pin = pin;
        }
        #endregion

    }
}
