using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int linhas { get; set; }
        public int coluna { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int coluna)
        {
            this.linhas = linhas;
            this.coluna = coluna;
            this.pecas = new Peca[linhas, coluna];
        }
    }
}
