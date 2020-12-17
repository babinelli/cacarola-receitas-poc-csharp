using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Receitas_V2
{
    class RepositorioReceitasFavoritas
    {

        // Conforme o usuário favorita receitas, serão adicionados itens ao ArrayList receitasFavoritas
        // private, pois só é utilizada na classe repositorio
        private ArrayList receitasFavoritas = new ArrayList();

        public void AdicionarReceitaFavoritaPorUsuario(ReceitaFavorita receitaFavoritaPorUsuario)
        {
            receitasFavoritas.Add(receitaFavoritaPorUsuario);
        }

        // Consulta se existem receitas favoritadas no repositório 
        // Retorna um arrylist com as receitas favoritas (ou vazio, caso não existam receitas do tipo solicitado)
        public ArrayList ConsultarReceitasFavoritasPorutilizador(Utilizador user)
        {
            ArrayList resultado = new ArrayList();
            foreach (ReceitaFavorita item in receitasFavoritas)
            {
                if (item.Utilizador == user )
                {
                    resultado.Add(item.Receita);
                }
            }
            return resultado;
        }

        public ReceitaFavorita ConsultarReceitaFavoritaPorUtilizador(Receita receita, Utilizador utilizador)
        {
            foreach (ReceitaFavorita item in receitasFavoritas)
            {
                if (item.Receita == receita && item.Utilizador == utilizador)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
