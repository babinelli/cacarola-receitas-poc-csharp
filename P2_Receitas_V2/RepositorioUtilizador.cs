using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Receitas_V2
{

    class RepositorioUtilizador
    {
        // Dados internos de cada utilizador ("banco de dados")
        // private por é interno ao repositório
        private ArrayList Utilizadores = new ArrayList()
        {
            // Cada instância, ou seja, cada utilizador, é um elemento da lista
            new Utilizador("bfc", "1234", "0000"),
            new Utilizador("bafantinelli", "4321", "0001")
        };

        #region Methods

        // Polimorfismo na classe Consultar()
        // Verifica se existe o usuário na base de dados e retorna seus dados, caso exista, ou nulo, caso não exista
        public Utilizador Consultar(string username, string password)
        {
            // item = uma instância de Utilizador, ou seja, utilizador 01, utilizador 02, etc...
            foreach (Utilizador item in Utilizadores)
            {
                if (item.Username == username && item.Password == password)
                {
                    return item;
                }
            }
            return null;
        }
        public Utilizador Consultar(string pin)
        {
            foreach (Utilizador item in Utilizadores)
            {
                if (item.Pin == pin)
                {
                    return item;
                }
            }
            return null;
        }
        #endregion
    }
}
