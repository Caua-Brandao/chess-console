# Chess Console

Jogo de xadrez jogável via terminal, desenvolvido em C# com foco em aplicação prática de Programação Orientada a Objetos.

O objetivo do projeto é implementar as regras do xadrez do zero — sem bibliotecas de terceiros — exercitando modelagem de domínio, herança, polimorfismo e tratamento de exceções.

> **Status:** em desenvolvimento 🚧

---

## Tecnologias

- C# 14
- .NET 10
- Aplicação console

## Conceitos aplicados

- Herança e classes abstratas (hierarquia de peças)
- Polimorfismo (cálculo de movimentos possíveis por tipo de peça)
- Encapsulamento e separação de camadas (tabuleiro genérico × regras do xadrez)
- Exceções personalizadas para regras de negócio
- Matrizes bidimensionais para representação do tabuleiro
- Coleções (`List<T>`, `HashSet<T>`) para controle de peças em jogo e capturadas

## Estrutura do projeto

```
chess-console/                  # raiz da solução
├── chess-console.sln
├── .gitignore
├── README.md
└── xadrez-console/             # projeto de console
    ├── xadrez-console.csproj
    ├── Program.cs              # ponto de entrada
    ├── Tela.cs                 # impressão do tabuleiro e leitura de entrada
    ├── tabuleiro/              # camada genérica: Tabuleiro, Peca, Posicao, Cor, exceções
    └── xadrez/                 # regras do xadrez: PartidaDeXadrez, PecaDeXadrez, Rei, Torre...
```

> As pastas `tabuleiro/` e `xadrez/` são criadas conforme o projeto avança.

## Como executar

Pré-requisito: [.NET SDK 10](https://dotnet.microsoft.com/download) ou superior.

```bash
git clone https://github.com/SEU-USUARIO/chess-console.git
cd chess-console
dotnet run --project xadrez-console
```

Também é possível abrir o arquivo `chess-console.sln` diretamente no Visual Studio e executar com `F5`.

O jogo solicita a posição de origem e, em seguida, a de destino, em notação algébrica — por exemplo, `e2` e depois `e4`.

## Roadmap

- [ ] Tabuleiro e impressão no console
- [ ] Movimentação básica de peças
- [ ] Captura de peças
- [ ] Validação de movimentos por tipo de peça
- [ ] Controle de turnos e jogadores
- [ ] Xeque e xeque-mate
- [ ] Jogadas especiais: roque, en passant e promoção
- [ ] Tela de fim de partida e reinício

## Autor

Cauã — estudante de Análise e Desenvolvimento de Sistemas (UNIP)

[LinkedIn](https://linkedin.com/in/caua-brandao) · [GitHub](https://github.com/Caua-Brandao)
