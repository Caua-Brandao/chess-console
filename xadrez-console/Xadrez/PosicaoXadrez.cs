using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    internal class PosicaoXadrez
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char Coluna, int Linha)
        {
            coluna = Coluna;
            linha = Linha;
        }

        public Posicao ToPosicao() => new Posicao(8 - linha, coluna - 'a');

        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
