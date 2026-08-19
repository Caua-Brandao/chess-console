using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        public HashSet<Peca> pecas { get; private set; }
        public HashSet<Peca> capturadas { get; private set; }
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            tab.validarPosicao(destino);
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCapturada != null) capturadas.Add(pecaCapturada);
            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQtdMovimentos();
            if (pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino); 

            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em cheque!");
            }

            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (testeXequeMate(adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                mudaJogador();
            }
        }

        public void validarPosicaoOrigem(Posicao pos)
        {
            if (tab.pecas[pos.Linha, pos.Coluna] == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }
            if (jogadorAtual != tab.pecas[pos.Linha, pos.Coluna].cor)
            {
                throw new TabuleiroException("A peça de origem não é sua!");
            }
            if (!tab.pecas[pos.Linha, pos.Coluna].existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem selecionada!");
            }
        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.Peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino invalida");
            }
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapituradas(Cor cor)
        {
            return capturadas.Where(x => x.cor == cor).ToHashSet();
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>(pecas.Where(x => x.cor == cor));
            aux.ExceptWith(pecasCapituradas(cor));
            return aux;
        }

        private Cor adversaria(Cor cor)
        {
            return cor == Cor.Branca ? Cor.Preta : Cor.Branca;
        }

        private Peca rei(Cor cor)
        {
            foreach(Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);

            foreach(Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.posicao.Linha, R.posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testeXequeMate(Cor cor)
        {
            if (!estaEmXeque(cor))
            {
                return false;
            }
            foreach(Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();
                for (int i = 0; i < tab.linhas; i++)
                {
                    for (int j=0;j<tab.colunas;j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;

        }
        public void colocarNovaPeca(char coluna, int linha, Peca p)
        {
            tab.colocarPeca(p, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(p);
        }

        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));
            colocarNovaPeca('h', 7, new Torre(tab, Cor.Branca));

            colocarNovaPeca('a', 8, new Rei(tab, Cor.Preta));
            colocarNovaPeca('b', 8, new Torre(tab, Cor.Preta));

        }
    }
}
