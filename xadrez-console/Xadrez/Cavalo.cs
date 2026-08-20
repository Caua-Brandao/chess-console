using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using tabuleiro;

namespace xadrez_console.Xadrez
{
    internal class Cavalo : Peca 
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(cor, tab)
        {
        }

        public override bool podeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.cor != this.cor;
        }

        public override string ToString()
        {
            return "C";
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.linhas, Tab.colunas];
            Posicao pos = new Posicao(0, 0);

            // nordeste

            pos.definirValores(this.posicao.Linha - 2, this.posicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(this.posicao.Linha - 1, this.posicao.Coluna + 2);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // noroeste 
            pos.definirValores(this.posicao.Linha - 2, this.posicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(this.posicao.Linha - 1, this.posicao.Coluna - 2);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // sudeste
            pos.definirValores(this.posicao.Linha + 1, this.posicao.Coluna + 2);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(this.posicao.Linha + 2, this.posicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // sudoeste 
            pos.definirValores(this.posicao.Linha + 2, this.posicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(this.posicao.Linha + 1, this.posicao.Coluna - 2);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            return mat;
        }
    }
}
