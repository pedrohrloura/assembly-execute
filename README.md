# Assembly Execute

Sistema que monta as instruções e as executa para um computador.
### Descrição
- O programa é organizado de modo a montar as instruções lidas a partir de um arquivo texto em
um outro vetor que representa o conjunto de instruções a serem executadas.
- Cada linha lida do arquivo é processada, de modo a fazer as devidas conversões e identificações
dos números dos registradores para acesso ao vetor de registradores.

### Procedimentos
1. Procedimento que zera o vetor de registradores;
2. Função que lê o arquivo, conta e retorna quantos comandos existem no arquivo;
3. Procedimento que recebe o nome do arquivo com as instruções (nome lido no principal), e
preenche o vetor de instruções a partir dos dados do arquivo a ser lido.
4. Procedimento que recebe o vetor de instruções e o vetor de registradores, executando as
alterações nos registradores, conforme as instruções armazenadas;
5. Procedimento que recebe o vetor de registradores e exibe o seu conteúdo;
6. Procedimento que recebe o vetor de instruções e exibe o seu conteúdo;
7. Procedimento que recebe o nome de um arquivo e o vetor de registradores e salva o
conteúdo do vetor no arquivo a ser criado;
8. Procedimento que recebe o nome de um arquivo e o vetor de instruções e salva o conteúdo
do vetor no arquivo a ser criado;
9. Procedimento que recebe o nome de um arquivo e exibe o seu conteúdo.
