using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Receitas_V2
{

    class ReceitaPorTestar : Receita
    {

        #region Constructors
        public ReceitaPorTestar(string nome, EnumCategoria categoria, ArrayList ingrediente, string preparo, EnumDificuldade dificuldade, int duracao)
        {
            Nome = nome;
            Categoria = categoria;
            Ingredientes = ingrediente;
            Preparo = preparo;
            Dificuldade = dificuldade;
            Duracao = duracao;
        }
        #endregion
    }
}
