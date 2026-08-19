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
                    try
                    {
                        Tela.imprimirPartida(partida);
                        Console.Write("\nOrigem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();
                        partida.validarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.pecas[origem.Linha, origem.Coluna].movimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();
                        partida.validarPosicaoDestino(origem, destino);
                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(partida);
            }
            catch(TabuleiroException te)
            {
                Console.WriteLine(te.Message);
            }
        }
    }
}
