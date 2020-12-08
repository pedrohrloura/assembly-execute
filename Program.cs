using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabFinal
{
    using System.IO; // Adicionando biblioteca para manipular arquivos
    class Program
    {
        static void Main(string[] args) //Main
        {
            Console.ForegroundColor = ConsoleColor.Green;  //Comando para trocar as letras de cor
            int i = 0; // Variável criada para segurar codigo até que a pessoa digite o nome de um arquivo válido
            //Sistema de pesquisa de arquivo 
            Console.WriteLine("<==========================+/ TRABALHO PRÁTICO /+==========================>\n");
            Console.WriteLine("Escolha o diretório do arquivo:\n1. Mesmo diretório do programa\n2. Outro diretório");
            Console.Write("\n-Escolha uma opção: ");
            int diretorio = Convert.ToInt32(Console.ReadLine());  //Variável para escolher onde está o arquivo que deseja ser analisado
            while (i != 1)  //Repetição que irá segurar o código até a pessoa digitar um arquivo que exista
            {
                string nomeArquivo = "Nome ou dirétorio"; //Variáel contendo a informação do nome ou do diretório do arquivo
                switch (diretorio) //switch para escolha do local do arquivo
                {
                    case 1:
                        Console.Write("Digite somente o nome do arquivo: ");
                        nomeArquivo = Console.ReadLine();  //Leitura do nome do arquivo. Obs: Somente nome sem a exteção.
                        nomeArquivo += ".txt";  //Adicionado a extenção do arquivo
                        break;
                    case 2:
                        Console.Write("Digite o diretório completo do arquivo: ");
                        nomeArquivo = Console.ReadLine();  //Leitura do diretório do arquivo. Obs: diretório completo, incluindo nome do arquivo. Ex: C:\Users\P3DR0\Downloads\teste.txt                      
                        break;
                }
                if (File.Exists(nomeArquivo))  // Condição para prosseguir só se o arquivo exista
                {
                    i = 1; //Se o arquivo existir o valor de 'i' atualiza para '1' para terminar o loop que verifica se o usuario digitou o nome de um arquivo que exista

                    //Declarações
                    int[] vetReg = new int[10]; //Declaração do vetor de registradores
                    INSTRUCAO[] instrucao = new INSTRUCAO[numComand(nomeArquivo)];  //Declaração do vetor instrucao

                    Console.Clear();
                    //Menu
                    int opc = -1;  //Variável que irá armazenar a opção

                    while (opc != 0)  //Repetição para retornar no menu sempre que acabar de executar os procedimentos/funções 
                    {
                        Console.Clear();
                        Console.WriteLine("<==========================+/ TRABALHO PRÁTICO /+==========================>");
                        Console.WriteLine("Menu:");
                        Console.WriteLine("1. Zera o vetor de registradores ");
                        Console.WriteLine("2. Número de comandos que existem no arquivo");
                        Console.WriteLine("3. Preecher vetor instrução a partir do arquivo");
                        Console.WriteLine("4. Alterar vetor registradores de acordo com as instruções");
                        Console.WriteLine("5. Exibir registradores");
                        Console.WriteLine("6. Exibir instruções");
                        Console.WriteLine("7. Criar arquivo com o conteúdo do registrador");
                        Console.WriteLine("8. Criar arquivo com as instruções");
                        Console.WriteLine("9. Exibir arquivo");
                        Console.WriteLine("0. Fechar programa");
                        Console.WriteLine("\n<==========================================================================>\n");
                        Console.Write("#Escolha uma opção: ");
                        opc = Convert.ToInt32(Console.ReadLine());  // Digitar a opção


                        //Menu
                        switch (opc) // Criar um switch para rodar o procedimento/função desejada
                        {
                            case 1:
                                Console.Clear();    //Limpando a tela das opções do menu (organização)**
                                Console.WriteLine("<==========================+/ Zerar Registradores /+==========================>\n");
                                zerar(vetReg);  // 1. Acionar procedimento para zerar registradores
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("<==========================+/ Número de comandos /+==========================>\n");
                                Console.WriteLine("Número de comandos do arquivo: {0}", numComand(nomeArquivo)); // 2. Acionar funcão para mostrar número de comandos e já exibir o seu valor
                                Console.WriteLine("\nPressione qualquer tecla para retornar ao menu.");
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("<==========================+/ Prencher instruções /+==========================>\n");
                                vetInstrucao(nomeArquivo, instrucao);  // 3. Acionar procedimento para prencher as instruções
                                break;
                            case 4:
                                Console.Clear();
                                Console.WriteLine("<==========================+/ Atualizar registradores /+==========================>\n");
                                attReg(instrucao, vetReg);   // 4. Acionar procedimento para atualizar vetor de instruções
                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("<==========================+/ Exibir registradores /+==========================>\n");
                                exibirReg(vetReg);  // 5. Procedimento que exibe o vetor de registradores
                                break;
                            case 6:
                                Console.Clear();
                                Console.WriteLine("<==========================+/ Exibir instruções /+==========================>\n");
                                exibirInstrucao(instrucao);    // 6. Acionar procedimento para exibir as instruções
                                break;
                            case 7:
                                Console.Clear();
                                Console.WriteLine("<==========================+/ Salvar registradores /+==========================>\n");
                                Console.Write("Digite o nome do arquivo que deseja criar: ");
                                string nomeNewArq = Console.ReadLine();  //Comando que irá perguntar o nome do arquivo que deve ser criado
                                nomeNewArq += ".txt"; //Adicionando extenção do arquivo
                                criarReg(vetReg, nomeNewArq);   // 7. Procedimento que salva o vetor de registradores em um arquivo com o nome fornecido acima
                                break;
                            case 8:
                                Console.Clear();
                                Console.WriteLine("<==========================+/ Salvar instruções /+==========================>\n");
                                Console.Write("Digite o nome do arquivo que deseja criar: ");
                                string nomeInstrucao = Console.ReadLine();  //Comando que irá perguntar o nome do arquivo que deve ser criado
                                nomeInstrucao += ".txt";  //Adicionando extenção do arquivo
                                criarInstrucao(instrucao, nomeInstrucao);   // 8. Procedimento que salva o vetor de instrucao em um arquivo com o nome fornecido acima
                                break;
                            case 9:
                                Console.Clear();
                                Console.WriteLine("<==========================+/ Exibir arquivo /+==========================>\n");
                                exibirArquivo(nomeArquivo);  //9. Procedimento que exibe o conteúdo do arquivo
                                break;
                            case 0:
                                opc = 0;  //Fechar programa...
                                break;
                            default:
                                Console.WriteLine("Opção inválida.");  //Mensagem de erro caso o usuário digitar uma opção que não exista
                                Console.ReadKey();
                                break;
                        }
                    }
                }
                else
                    Console.WriteLine("Este arquivo não existe.\n");
            }
        }
        struct INSTRUCAO  // Criando o "tipo" instrução
        {
            public string op; //load,add,sub,mult...
            public int dado, numRegOrigem, numRegDestino; //dado a ser gravado e os locais
        }

        // <=== Sub-rotinas=== > //
        //A , 1
        static void zerar(int[] vetReg)  //Procedimento que zera o vetor de registradores
        {
            for (int i = 0; i < vetReg.Length; i++)    //Criando a variavel 'i' para percorrer o vetor através do comando "for"
            {
                vetReg[i] = 0;  //Igualar todas as posiçoes a 0
            }
            Console.WriteLine("Vetor de registradores zerado.\n\nPressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
        }

        //B , 2
        static int numComand(string nomeArquivo)  //Função que lê o arquivo, conta e retorna quantos comandos existem no arquivo
        {
            StreamReader arquivo = new StreamReader(nomeArquivo); //Declaração do arquivo
            int numeroComandos = 0;
            while (!arquivo.EndOfStream) //Enquanto não chegar no final do aquivo não irá parar
            {
                arquivo.ReadLine();
                numeroComandos++;   //Variável que irá contar quantos comandos tem o arquivo
            }
            arquivo.Close();
            return (numeroComandos);    //Retornar o número de comandos do arquivo
        }

        //C , 3
        static void vetInstrucao(string nomeArquivo, INSTRUCAO[] instrucao)  //procedimento para preecher vetor de instruções
        {
            StreamReader arquivo = new StreamReader(nomeArquivo); //Declaração do arquivo

            for (int i = 0; i < instrucao.Length; i++)  //Cria repetição com condição de parada o número de linhas
            {
                int dado = -1, numRegOrigem = -1, numRegDestino = -1; //Iniciando com valores inválidos para caso esses dados não entre na condição
                string linha;   //Variável que irá salvar o conteúdo da linha do arquivos
                string[] pedacos;  //Vetor que irá armazenar a linha depois de fragmentada
                char[] seps = { ' ', ',', };  //Condições para o comando 'Split' fragmentar o texto
                linha = arquivo.ReadLine();   //Armazenamento da leitura da linha do arquivo
                pedacos = linha.Split(seps);  //Separando a linha para manipular os comandos

                if (pedacos.Length > 2) // Condição para permitir que só entre dados no formato INSTRUCAO
                {
                    if (pedacos[1].CompareTo("r") == -1) // Testa se o dado é local de origem ou um valor
                    {
                        dado = Convert.ToInt32(pedacos[1]); // Convertendo o valor (Split gera vetor de string) para 'int'
                    }
                    else // Se for um 'local' para buscar o valor, entra no else
                    {
                        numRegOrigem = Convert.ToInt32(pedacos[1].Substring(1)); // Tirar letra 'r' e deixar apenas a posição do registrador e coverter o texto para int
                    }
                    numRegDestino = Convert.ToInt32(pedacos[2].Substring(1)); // Tirar letra 'r' novamente e deixar só a posição do registrador e coverter o texto para int
                }
                //Atualizando vetor instrucao    
                instrucao[i].op = pedacos[0];  //instrucao[i].op recebe o primeiro conteúdo da linha (pedacos[0]) que é a operação desejada
                instrucao[i].dado = dado;
                instrucao[i].numRegDestino = numRegDestino;
                instrucao[i].numRegOrigem = numRegOrigem;
                //Vetor instruções atualizados
            }
            arquivo.Close();
            Console.WriteLine("Vetor de instruções atualizado.\n\nPressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
        }

        //D , 4
        static void attReg(INSTRUCAO[] instrucao, int[] vetReg)  //Procedimento para atualizar os registradores de acordo com as instruções
        {
            for (int i = 0; i < instrucao.Length; i++)
            {
                if (instrucao[i].op == "load")  //Se a operação for 'load' tem que carregar o dado no destino desejado
                {
                    if (instrucao[i].dado != -1) //Tratamento do código para quando o vetor pedaco[1] tiver um dado
                        vetReg[instrucao[i].numRegDestino] = instrucao[i].dado;
                    else  //Tratamento do código para quando o vetor pedaco[1] tiver um local para acessar o dado
                        vetReg[instrucao[i].numRegDestino] = vetReg[instrucao[i].numRegOrigem];
                }
                else if (instrucao[i].op == "add") //Se a operação for 'add' tem somar o valor de origem com o valor de destino
                {
                    if (instrucao[i].dado != -1)
                        vetReg[instrucao[i].numRegDestino] += instrucao[i].dado;
                    else
                        vetReg[instrucao[i].numRegDestino] += vetReg[instrucao[i].numRegOrigem];
                }
                else if (instrucao[i].op == "sub")  //Se a operação for 'sub' tem subtrair o valor de origem com o valor de destino
                {
                    if (instrucao[i].dado != -1)
                        vetReg[instrucao[i].numRegDestino] -= instrucao[i].dado;
                    else
                        vetReg[instrucao[i].numRegDestino] -= vetReg[instrucao[i].numRegOrigem];
                }
                else if (instrucao[i].op == "mult") //Se a operação for 'mult' tem que multiplicar o valor de origem com o valor de destino
                {
                    if (instrucao[i].dado != -1)
                        vetReg[instrucao[i].numRegDestino] *= instrucao[i].dado;
                    else
                        vetReg[instrucao[i].numRegDestino] *= vetReg[instrucao[i].numRegOrigem];
                }
                else if (instrucao[i].op == "halt")  //Quando for 'halt' o programa finaliza
                {
                    for (int x = 0; x < 10; x++)
                    {
                        if (vetReg[x] == 0)
                            vetReg[x] = -1; //Igualando posições vazias a -1
                    }
                    i = instrucao.Length;   //Igualar 'i' ao tamanho do vetor assim chegando a condição de parada do 'for'
                }
            }
            Console.WriteLine("Vetor de registradores atualizados.\n\nPressione qualquer tecla para retornar para o menu.");
            Console.ReadKey();
        }

        //E , 5
        static void exibirReg(int[] vetReg)  // Procedimento que exibe o vetor de registradores
        {
            Console.Write("Registradores: [");
            for (int i = 0; i < 9; i++)
            {
                Console.Write("{0}, ", vetReg[i]);
            }
            Console.Write("{0}]", vetReg[9]);
            Console.WriteLine("\n\nPressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
        }

        //F , 6
        static void exibirInstrucao(INSTRUCAO[] instrucao)  //Procedimento para exibir vetor de instruções 
        {
            for (int i = 0; i < instrucao.Length; i++)
            {
                Console.WriteLine("Posição {0}:", i);
                Console.WriteLine("-Operação: {0}", instrucao[i].op);
                Console.WriteLine("-Dado: {0}", instrucao[i].dado);
                Console.WriteLine("-Número do registrador de origem: {0}", instrucao[i].numRegOrigem);
                Console.WriteLine("-Número do registrador de destino: {0}\n", instrucao[i].numRegDestino);
            }
            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
        }

        //G , 7
        static void criarReg(int[] vetReg, string nomeNewArq)  //Procedimento que salva o conteúdo do vetor de registradores em um arquivo escolhido pelo usuario
        {
            StreamWriter arquivoReg = new StreamWriter(nomeNewArq);  //Declaração do novo arquivo do tipo 'escrita'
            arquivoReg.Write("Vetor de registradores: [");
            for (int i = 0; i < 9; i++) //Repetição para 'percorrer' o vetor de registradores da posição 0 até a 8. obs: até a 8 para que o depois do último número do vetor não tenha uma vírgula 
            {
                arquivoReg.Write("{0}, ", vetReg[i]);
            }
            arquivoReg.Write(vetReg[9] + "]"); //Escrever a posição 9 do vetor no arquivo
            arquivoReg.Close();    //Fechando o arquivo após acabar de escrever para salva-lo.
            Console.WriteLine("\nVetor salvo no arquivo '{0}'.\n\nPressione qualquer tecla para retornar ao menu.", nomeNewArq);
            Console.ReadKey();
        }

        //H , 8
        static void criarInstrucao(INSTRUCAO[] instrucao, string nomeInstrucao)  //Procedimento para salvar o conteúdo do vetor de instrução em um arquivo
        {
            StreamWriter arquivoInstrucao = new StreamWriter(nomeInstrucao);  //Declaração do novo arquivo do tipo 'escrita'
            arquivoInstrucao.WriteLine("Vetor de instruções: ");
            for (int i = 0; i < instrucao.Length; i++) //Repetição para percorrer vetor de instuções de acordo com seu tamanho que irá ser fornecido pela função "B , 2"
            {
                //Escrevendo no arquivo
                arquivoInstrucao.WriteLine("Posição {0}:", i);
                arquivoInstrucao.WriteLine("-Operação: {0}", instrucao[i].op);
                arquivoInstrucao.WriteLine("-Dado: {0}", instrucao[i].dado);
                arquivoInstrucao.WriteLine("-Número do registrador de origem: {0}", instrucao[i].numRegOrigem);
                arquivoInstrucao.WriteLine("-Número do registrador de destino: {0}\n", instrucao[i].numRegDestino);
            }
            arquivoInstrucao.Close();    //Fechando arquivo para salvar
            Console.WriteLine("Instruções salva no arquivo '{0}'\n\nPressione qualquer tecla para retornar ao menu.", nomeInstrucao);
            Console.ReadKey();
        }

        //I , 9
        static void exibirArquivo(string nomeArquivo)  //Procedimento que exibe o conteúdo do arquivo
        {
            StreamReader arquivo = new StreamReader(nomeArquivo); //Declaração do arquivo
            string linha = "lixo";
            while (!arquivo.EndOfStream) //Enquanto não chegar no final do aquivo não irá parar
            {
                linha = arquivo.ReadLine();  //Igualando a variável linha a linha do arquivo txt
                Console.WriteLine(linha);   //Exibir o que está na linha
            }
            arquivo.Close();
            Console.WriteLine("\nPressione enter para retornar ao menu.");
            Console.ReadKey();
        }
    }
}
