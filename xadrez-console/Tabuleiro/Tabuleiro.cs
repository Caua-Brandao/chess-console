using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        public Peca[,] pecas { get; private set; }

        public Tabuleiro(int linhas, int coluna)
        {
            this.linhas = linhas;
            this.colunas = coluna;
            this.pecas = new Peca[linhas, coluna];
        }
    }
}
