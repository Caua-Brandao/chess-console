using System.Net.Http.Headers;
using tabuleiro;

namespace Xadrez
{
    internal class Rei : Peca
    {
        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(cor, tab)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool podeMover(Posicao pos)
        {
            Peca p = Tab.pecas[pos.Linha, pos.Coluna];
            return p == null || p.cor != this.cor;
        }

        private bool posicaoTorreParaRoque(Posicao pos)
        {
            if (Tab.Peca(pos) != null && Tab.Peca(pos) is Torre && Tab.Peca(pos).cor == this.cor)
            {
                return true;
            }
            return false;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.linhas, Tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.definirValores(this.posicao.Linha - 1, this.posicao.Coluna);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // nordeste
            pos.definirValores(this.posicao.Linha - 1, this.posicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // direita
            pos.definirValores(this.posicao.Linha, this.posicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // sudeste
            pos.definirValores(this.posicao.Linha + 1, this.posicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // abaixo
            pos.definirValores(this.posicao.Linha + 1, this.posicao.Coluna);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // sudoeste
            pos.definirValores(this.posicao.Linha + 1, this.posicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // esquerda
            pos.definirValores(this.posicao.Linha, this.posicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // noroeste
            pos.definirValores(this.posicao.Linha - 1, this.posicao.Coluna-1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #jogadas especiais
            if (qtdMovimentos == 0 && !partida.xeque)
            {

                // jogada especial roque pequeno 
                Posicao posT = new Posicao(this.posicao.Linha, this.posicao.Coluna + 3);
                Posicao p1 = new Posicao(this.posicao.Linha, this.posicao.Coluna + 1);
                Posicao p2 = new Posicao(this.posicao.Linha, this.posicao.Coluna + 2);
                if (posicaoTorreParaRoque(posT))
                {
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null)
                    {
                        mat[posicao.Linha, posicao.Coluna + 2] = true;
                    }
                }

                // jogada especial roque grande
                Posicao post2 = new Posicao(this.posicao.Linha, this.posicao.Coluna - 4);
                Posicao P1 = new Posicao(this.posicao.Linha, this.posicao.Coluna - 1);
                Posicao P2 = new Posicao(this.posicao.Linha, this.posicao.Coluna - 2);
                Posicao P3 = new Posicao(this.posicao.Linha, this.posicao.Coluna - 3);

                if (posicaoTorreParaRoque(post2))
                {
                    if (Tab.Peca(P1) == null && Tab.Peca(P2) == null && Tab.Peca(P3) == null)
                    {
                        mat[posicao.Linha, posicao.Coluna - 2] = true;
                    }
                }
            }
            return mat;

        }
    }
}
