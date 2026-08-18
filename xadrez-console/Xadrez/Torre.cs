using tabuleiro;

namespace Xadrez
{
    internal class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "T";
        }
        private bool podeMover(Posicao pos)
        {
            Peca p = Tab.pecas[pos.Linha, pos.Coluna];
            return p == null || p.cor != this.cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.linhas, Tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(this.posicao.Linha - 1, this.posicao.Coluna);
            while (this.Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                pos.Linha = pos.Linha - 1;
            }

            // abaixo
            pos.definirValores(this.posicao.Linha + 1, this.posicao.Coluna);
            while (this.Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                pos.Linha = pos.Linha + 1;
            }

            // direita
            pos.definirValores(this.posicao.Linha, this.posicao.Coluna + 1);
            while (this.Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                pos.Coluna += 1;
            }

            // esquerda 
            pos.definirValores(this.posicao.Linha, this.posicao.Coluna - 1);
            while (this.Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                pos.Coluna -= 1;
            }
            return mat;
        }
    }
}


