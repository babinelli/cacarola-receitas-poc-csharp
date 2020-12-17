using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Receitas_V2
{
    class ReceitaFavorita
    {
        #region Properties
        public Receita Receita { get; set; }
        public Utilizador Utilizador { get; set; }
        #endregion

        #region Constructor
        public ReceitaFavorita(Receita receita, Utilizador utilizador)
        {
            Receita = receita;
            Utilizador = utilizador;
        }
        #endregion

    }
}
