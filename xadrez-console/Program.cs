using System;
using tabuleiro;
using Xadrez;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);
                Torre t = new Torre(tab, Cor.Branca);
                Rei r = new Rei(tab, Cor.Preta);
                tab.colocarPeca(t, new Posicao(1, 2));
                tab.colocarPeca(r, new Posicao(6, 7));
                Tela.ImprimirTabuleiro(tab);
            }
            catch(TabuleiroException te)
            {
                Console.WriteLine(te.Message);
            }
        }
    }
}
