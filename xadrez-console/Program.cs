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
                PosicaoXadrez pos = new PosicaoXadrez('c', 7);
                Console.WriteLine(pos);

                Console.WriteLine(pos.ToPosicao());
            }
            catch(TabuleiroException te)
            {
                Console.WriteLine(te.Message);
            }
        }
    }
}
