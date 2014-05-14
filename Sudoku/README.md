SudokuAniapi
============

###Forma de usar:

* Instanciar uma objeto do tipo `Tabuleiro`

        private Tabuleiro _board;
        _board = new Tabuleiro();

* Agora já é possivel adicionar os valores ao Tabuleiro, desta forma:

        _board.AdicionaCampo("QB_L1_C5", 3);  

A notação é a seguinte:

![Mapa de campos](https://raw.githubusercontent.com/AnisanWesley/SudokuAniapi/master/image/sudoku.jpg)
* **Q** representa o Quadrante, vem seguido de uma letra de A a I correspondente.
* **L** representa a Linha, vem com o número correspondente.
* **C** representa a coluna
* Todas as marcações separadas por **underline (_)**
* O segundo parâmetro representa o valor passado naquele campo
 
* O método `_board.AdicionaCampo` irá retornar um valor boleano que representa se o campo é **unico** naquela linha, coluna ou quadrante.
* Para atualizar um valor, basta adicionar por cima, o Tabuleiro irá atualizar a validade de todos os valores
* Para zerar o campo chame `_board.RemoveCampo` ou adicione um campo passando o valor `0`.
* Para verificar se o jogo está finalizado, basta chamar `_board.VerificaSeCamposCompletos`, este retornará verdadeiro caso todos os campos sejam válidos e o sudoku esteja resolvido.
 
Veja os [Testes unitários](https://github.com/AnisanWesley/SudokuAniapi/tree/master/Test) para mais detalhes sobre a forma de usar.

###Forma de resolver:
Há também a classe SudokuResolver, ela tanto resolve um jogo quanto os cria.

* Cria-se uma instancia da classe SudokuSolver passando no construtor:
  * Valores do jogo na sequencia correta, por exemplo:
  * Condição boleana para indicar que está criando um tabuleiro randômico.
  
````csharp
var solver =  new SudokuSolver("710820904" +
                             "008006050" +
                             "240003010" +
                             "650049081" +
                             "470038092" +
                             "000100400" +
                             "120004060" +
                             "009007040" +
                             "830650709",false);
````
Note que onde tem o numero ´0´, é onde ele vai (tentar) substituir pelo número certo.

Ao chamar `solver.Solve()` ele retorna o jogo resolvido em uma cadeia de caracteres, se não for possivel resolver, retornará  "Impossível!"
