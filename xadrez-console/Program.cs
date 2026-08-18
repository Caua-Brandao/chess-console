using System;
using System.Linq.Expressions;
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
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.terminada)
                {
                    Tela.ImprimirTabuleiro(partida.tab);
                    Console.Write("\nOrigem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();

                    bool[,] posicoesPossiveis = partida.tab.pecas[origem.Linha, origem.Coluna].movimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();
                    partida.executaMovimento(origem, destino);
                }
            }
            catch(TabuleiroException te)
            {
                Console.WriteLine(te.Message);
            }
        }
    }
}
