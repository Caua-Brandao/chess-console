using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez_console.Xadrez
{
    internal class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(cor, tab)
        {
        }

        private bool estaLivre(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null;
        }

        private bool temInimigo(Posicao pos)
        {
            if (!(estaLivre(pos)) && Tab.Peca(pos).cor != this.cor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.linhas, Tab.colunas];
            Posicao pos = new Posicao(0, 0);

            // criando laço pra definir peões pretos e brancos

            if (this.cor == Cor.Branca)
            {
                // jogadas diagonais
                pos.definirValores(this.posicao.Linha - 1, this.posicao.Coluna + 1);
                if (Tab.posicaoValida(pos) && temInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.definirValores(this.posicao.Linha - 1, this.posicao.Coluna - 1);
                if (Tab.posicaoValida(pos) && temInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // jogada normal
                pos.definirValores(this.posicao.Linha - 1, this.posicao.Coluna);
                if (Tab.posicaoValida(pos) && estaLivre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                if (qtdMovimentos == 0)
                {
                    pos.definirValores(this.posicao.Linha - 2, this.posicao.Coluna);
                    if (Tab.posicaoValida(pos) && estaLivre(pos) && estaLivre(new Posicao(pos.Linha +1, pos.Coluna)))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                }
            }
            else
            {
                // jogadas diagonais
                pos.definirValores(this.posicao.Linha + 1, this.posicao.Coluna + 1);
                if (Tab.posicaoValida(pos) && temInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.definirValores(this.posicao.Linha + 1, this.posicao.Coluna - 1);
                if (Tab.posicaoValida(pos) && temInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // jogada normal
                pos.definirValores(this.posicao.Linha + 1, this.posicao.Coluna);
                if (Tab.posicaoValida(pos) && estaLivre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                if (qtdMovimentos == 0)
                {
                    pos.definirValores(this.posicao.Linha + 2, this.posicao.Coluna);
                    if (Tab.posicaoValida(pos) && estaLivre(pos) && estaLivre(new Posicao(pos.Linha - 1, pos.Coluna)))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                }
            }
            return mat;
        }
        public override bool podeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || podeMover(pos);
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
