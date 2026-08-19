using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Text;

namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        public Peca[,] pecas { get; private set; }

        public Peca Peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        public Tabuleiro(int linhas, int coluna)
        {
            this.linhas = linhas;
            this.colunas = coluna;
            this.pecas = new Peca[linhas, coluna];
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição!");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (pecas[pos.Linha, pos.Coluna] == null)
            {
                return null;
            }
            else
            {
                Peca aux = pecas[pos.Linha, pos.Coluna];
                aux.posicao = null;
                pecas[pos.Linha, pos.Coluna] = null;
                return aux;
            }
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return pecas[pos.Linha, pos.Coluna] != null;
        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= linhas || pos.Coluna < 0 || pos.Coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }
    }
}
