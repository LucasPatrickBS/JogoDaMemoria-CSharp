using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace JogoDaMemoria
{
    class Matriz
    {
        // Atributos
        private Image[,] vet_matriz;
        private int elementosNaNaMatriz;
        private int limiteLogico;
        int qtdLinhas, qtdColunas;

        // Construtor
        public Matriz(int lin, int col, int qtde, int lim)
        {
            elementosNaNaMatriz = qtde;
            limiteLogico = lim;
            vet_matriz = new Image[lin, col];
            qtdLinhas = lin;
            qtdColunas = col;
        }

        public bool estaCheia()
        {
            return (elementosNaNaMatriz == limiteLogico);
        }
        public bool celulacheia(int lin, int col)
        {
            return ConteudoPosicaoIndicada(lin, col) != null;
        }
        public void insereDadoNaMatriz(int lin, int col, Image nomeArq)
        {
            if (!estaCheia())
            {
                elementosNaNaMatriz++;
                vet_matriz[lin, col] = nomeArq;
            }
        }
        public void esvaziaMatriz()
        {
            int l = 0, c = 0;
            while (l < qtdLinhas)
            {
                while (c < qtdColunas)
                {
                    vet_matriz[l, c] = null;
                    c++;
                }
                l++;
            }
        }
        public Image ConteudoPosicaoIndicada (int lin, int col)
        {
            return vet_matriz[lin, col];
        }
    }
}
