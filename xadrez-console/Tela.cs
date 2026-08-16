using tabuleiro;

namespace xadrez_console
{
    internal class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i=0;i<tab.linhas;i++)
            {
                for (int j = 0;j<tab.colunas;j++)
                {
                    if (tab.pecas[i,j]==null) 
                    {
                        Console.Write("- ");
                    } 
                    else
                    {
                        Console.Write(tab.pecas[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
