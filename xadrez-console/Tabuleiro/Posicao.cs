namespace tabuleiro
{
    internal class Posicao
    {
        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public int Linha { get; set; }
        public int Coluna { get; set; }

        public void definirValores(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }

        public override string ToString()
        {
            return Linha
                + ", "
                + Coluna;
        }
    }
}
