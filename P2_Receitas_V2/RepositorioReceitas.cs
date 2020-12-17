using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Receitas_V2
{

    class RepositorioReceitas
    {
        // Conforme receitas forem adicionadas, serão adicionados itens ao ArrayList receitas
        // private, pois só é utilizada na classe repositorio
        private ArrayList receitas = new ArrayList();

        public void AdicionarReceita(Receita receita)
        {
            receitas.Add(receita);
        }

        // Consulta se o tipo de receitas solicitado existe no repositório 
        // Retorna um arrylist com as receitas (ou vazio, caso não existam receitas do tipo solicitado)
        public ArrayList ConsultarReceitas()
        {
            return receitas;
        }

        public ArrayList ConsultarReceitas(bool testada)
        {
            ArrayList receitasEncontradas = new ArrayList();

            foreach (Receita item in receitas)
            {
                if (testada && item is ReceitaTestada)
                {
                    receitasEncontradas.Add(item);
                }
                else if (!testada && item is ReceitaPorTestar)
                {
                    receitasEncontradas.Add(item);
                }
            }
            return receitasEncontradas;
        }

        // Busca receita por nome (não precisa ser o nome completo, pode ser parte do nome --> .Contains)
        // Adiciona as receitas encontradas ao ArrayList
        public ArrayList ConsultaReceitasPorNome(string nome)
        {
            ArrayList receitasPorNome = new ArrayList();

            foreach (Receita item in receitas)
            {
                if (item.Nome.ToLower().Contains(nome.ToLower()))
                {
                    receitasPorNome.Add(item);
                }
            }
            return receitasPorNome;
        }
    }
}


