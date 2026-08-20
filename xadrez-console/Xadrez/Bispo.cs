using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using tabuleiro;

namespace xadrez_console.Xadrez
{
    internal class Bispo : Peca 
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(cor, tab)
        {
        }

        public override bool podeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.cor != this.cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.linhas, Tab.colunas];
            Posicao pos = new Posicao(0, 0);

            // sudeste 
            pos.definirValores(this.posicao.Linha + 1, this.posicao.Coluna + 1);
            while (this.Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.Linha++;
                pos.Coluna++;
            }

            // sudoeste 

            pos.definirValores(this.posicao.Linha + 1, this.posicao.Coluna - 1);
            while (this.Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.Linha++;
                pos.Coluna--;
            }

            // noroeste 

            pos.definirValores(this.posicao.Linha - 1, this.posicao.Coluna -1);
            while (this.Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.Linha--;
                pos.Coluna--;
            }

            // nordeste

            pos.definirValores(this.posicao.Linha - 1, this.posicao.Coluna + 1);
            while (this.Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.Linha--;
                pos.Coluna++;
            }
            return mat;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
