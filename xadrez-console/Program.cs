using System;
using tabuleiro;
using Xadrez;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);
            Torre t = new Torre(tab, Cor.Preta);
            tab.colocarPeca(t, new Posicao(1, 4));
            Tela.ImprimirTabuleiro(tab);
            
        }
    }
}
