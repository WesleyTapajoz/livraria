Requisitos minimos para instalação
Para o visual studio code
1-Instalar .Net FrameWork Core disponivel em https://dotnet.microsoft.com/download
2-Banco de Dados Sql Server

Etapas para execução do projeto
1- Abra seu editor visual studio code no diretorio C:\ewave-livraria-plenoII
2- Abra 1 terminal no seu editor visual studio code
3- Aponte 1 para o projeto C:\Git\ewave-livraria-plenoII\Livraria.Repository>
4- Execute a seguinte linha de comando dotnet ef --startup-project ../Livraria.WebAPI migrations add init após a execução concluida, execute o segundo comando
dotnet ef --startup-project ../Livraria.WebAPI database update após concluido feche o terminal.
5- Abra 2 terminais no seu editor visual studio code
6- Aponte 1 terminal para o projeto C:\Git\ewave-livraria-plenoII\Livraria.WebAPI>
7- Execute o comando dotnet watch run
8- Aponte o segundo para o projeto C:\Git\ewave-livraria-plenoII\Livraria-APP> Execute o comando npm i
9- Após a execução, execute ng serve
