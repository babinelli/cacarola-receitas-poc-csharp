using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Receitas_V2
{

    class Receita
    {
        #region Enumerators
        public enum EnumCategoria : ushort
        {
            Aperitivo = 1,
            Entrada = 2,
            PratoPrincipal = 3,
            Acompanhamento = 4,
            Sobremesa = 5,
            Bebida = 6
        }
        public enum EnumDificuldade : ushort
        {
            Facil = 1,
            Medio = 2,
            Dificil = 3
        }
        #endregion

        #region Properties
        public string Nome { get; set; }
        public EnumCategoria Categoria { get; set; } 
        public ArrayList Ingredientes { get; set; }
        public string Preparo { get; set; }
        public EnumDificuldade Dificuldade { get; set; } 
        public int Duracao { get; set; }
        public bool Testada { get; set; }

        #endregion

        #region Methods
        public string ConverteCategoriaParaString()
        {
            string categoria = string.Empty;
            switch (Categoria)
            {
                case EnumCategoria.Aperitivo:
                    categoria = "Aperitivo";
                    break;
                case EnumCategoria.Entrada:
                    categoria = "Entrada";
                    break;
                case EnumCategoria.PratoPrincipal:
                    categoria = "Prato Principal";
                    break;
                case EnumCategoria.Acompanhamento:
                    categoria = "Acompanhamento";
                    break;
                case EnumCategoria.Sobremesa:
                    categoria = "Sobremesa";
                    break;
                case EnumCategoria.Bebida:
                    categoria = "Bebida";
                    break;
                default:
                    break;
            }
            return categoria;
        }

        public string ConverteDificuldadeParaString()
        {
            string dificuldade = string.Empty;
            switch (Dificuldade)
            {
                case EnumDificuldade.Facil:
                    dificuldade = "Fácil";
                    break;
                case EnumDificuldade.Medio:
                    dificuldade = "Médio";
                    break;
                case EnumDificuldade.Dificil:
                    dificuldade = "Difícil";
                    break;
                default:
                    break;
            }
            return dificuldade;
        }

        public string ConverteIngredientesParaString()
        {
            string ingredientes = string.Empty;
            foreach (string item in Ingredientes)
            {
                ingredientes = $"{ingredientes}\n- {item}";
            }
            return ingredientes;
        }

        public string ConverteReceitaCompletaParaString()
        {
            string receita = ($"\n{Nome.ToUpper()}\n\nCategoria: {ConverteCategoriaParaString()}\n\nIngredientes: {ConverteIngredientesParaString()}\n\nPreparo:\n- {Preparo}\n\nDificuldade: {ConverteDificuldadeParaString()}\n\nDuração: {Duracao} minutos");
            return receita;
        }

        // Mostra apenas Número, Nome, Categoria e Dificuldade
        public string ConverteReceitaMenuParaString()
        {
            string receita = ($"{Nome.ToUpper()} | Categoria: {ConverteCategoriaParaString()} | Dificuldade: {ConverteDificuldadeParaString()}");
            return receita;
        }
        #endregion
    }
}
