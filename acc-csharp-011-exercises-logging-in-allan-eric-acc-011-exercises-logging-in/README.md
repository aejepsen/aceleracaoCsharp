# Boas-vindas ao repositório do exercício Logging In

Para realizar o projeto, atente-se a cada passo descrito a seguir. Se tiver qualquer dúvida, nos envie por _Slack_! #vqv 🚀

Aqui você vai encontrar os detalhes de como estruturar o desenvolvimento do seu projeto a partir deste repositório, utilizando uma branch específica e um _Pull Request_ para colocar seus códigos.

# Termos e acordos

Ao iniciar este projeto, você concorda com as diretrizes do Código de Conduta e do Manual da Pessoa Estudante da Trybe.

# Orientações

<details>
  <summary><strong>‼️ Antes de começar a desenvolver</strong></summary><br />

  1. Clone o repositório

  - Use o comando: `git clone git@github.com:tryber/acc-csharp-011-exercises-logging-in.git`.
  - Entre na pasta do repositório que você acabou de clonar:
    - `cd acc-csharp-011-exercises-logging-in`

  2. Instale as dependências
  
  - Entre na pasta `src/`.
  - Execute o comando: `dotnet restore`.
  
  3. Crie uma branch a partir da branch `master`

  - Certifique-se de que você está na branch `master`
    - Exemplo: `git branch`
  - Se não estiver, mude para a branch `master`
    - Exemplo: `git checkout master`
  - Agora crie uma branch à qual você vai submeter os `commits` do seu projeto
    - Você deve criar uma branch no seguinte formato: `nome-de-usuario-nome-do-projeto`
    - Exemplo: `git checkout -b joaozinho-acc-0x-exercises-logging-in`

  4. Adicione as mudanças ao _stage_ do Git e faça um `commit`

  - Verifique que as mudanças ainda não estão no _stage_
    - Exemplo: `git status` (deve aparecer listada a pasta _joaozinho_ em vermelho)
  - Adicione o novo arquivo ao _stage_ do Git
    - Exemplo:
      - `git add .` (adicionando todas as mudanças - _que estavam em vermelho_ - ao stage do Git)
      - `git status` (deve aparecer listado o arquivo _joaozinho/README.md_ em verde)
  - Faça o `commit` inicial
    - Exemplo:
      - `git commit -m 'iniciando o projeto x'` (fazendo o primeiro commit)
      - `git status` (deve aparecer uma mensagem tipo essa: _nothing to commit_ )

  5. Adicione a sua branch com o novo `commit` ao repositório remoto

  - Usando o exemplo anterior: `git push -u origin joaozinho-acc-0x-exercises-logging-in`

  6. Crie um novo `Pull Request` _(PR)_

  - Vá até a página de _Pull Requests_ do [repositório no GitHub](https://github.com/tryber/acc-csharp-011-exercises-logging-in/pulls)
  - Clique no botão verde _"New pull request"_
  - Clique na caixa de seleção _"Compare"_ e escolha a sua branch **com atenção**
  - Coloque um título para a sua _Pull Request_
    - Exemplo: _"Cria tela de busca"_
  - Clique no botão verde _"Create pull request"_
  - Adicione uma descrição para o _Pull Request_ e clique no botão verde _"Create pull request"_
  - **Não se preocupe em preencher mais nada por enquanto!**
  - Volte até a [página de _Pull Requests_ do repositório](https://github.com/tryber/acc-csharp-011-exercises-logging-in/pulls) e confira que o seu _Pull Request_ está criado

</details>

<details>
  <summary><strong>⌨️ Durante o desenvolvimento</strong></summary><br/>

  - Faça `commits` das alterações que você fizer no código regularmente

  - Lembre-se sempre de, após um (ou alguns) `commits`, atualizar o repositório remoto

  - Os comandos que você utilizará com mais frequência são:
    1. `git status` _(para verificar o que está em vermelho - fora do stage - e o que está em verde - no stage)_
    2. `git add` _(para adicionar arquivos ao stage do Git)_
    3. `git commit` _(para criar um commit com os arquivos que estão no stage do Git)_
    4. `git push -u origin nome-da-branch` _(para enviar o commit para o repositório remoto na primeira vez que fizer o `push` de uma nova branch)_
    5. `git push` _(para enviar o commit para o repositório remoto após o passo anterior)_

</details>

<details>
  <summary><strong>🤝 Depois de terminar o desenvolvimento (opcional)</strong></summary><br/>

  Para sinalizar que o seu projeto está pronto para o _"Code Review"_, faça o seguinte:

  - Vá até a página **DO SEU** _Pull Request_, adicione a label de _"code-review"_ e marque seus colegas:

    - No menu à direita, clique no _link_ **"Labels"** e escolha a _label_ **code-review**;

    - No menu à direita, clique no _link_ **"Assignees"** e escolha **o seu usuário**;

    - No menu à direita, clique no _link_ **"Reviewers"** e digite `students`, selecione o time `tryber/students-sd-0x`.

  Caso tenha alguma dúvida, [aqui tem um video explicativo](https://vimeo.com/362189205).

</details>

<details>
  <summary><strong>🕵🏿 Revisando um pull request</strong></summary><br />

  Use o conteúdo sobre [Code Review](https://app.betrybe.com/course/real-life-engineer/code-review) para te ajudar a revisar os _Pull Requests_.

</details>

<details>
  <summary><strong>🎛 Linter</strong></summary><br />

  Usaremos o [NetAnalyzer](https://docs.microsoft.com/pt-br/dotnet/fundamentals/code-analysis/overview) para fazer a análise estática do seu código.

  Este projeto já vem com as dependências relacionadas ao _linter_ configuradas no arquivo `.csproj`.

  O analisador já é instalado pelo plugin da `Microsoft C#` no `VSCode`. Para isso, basta fazer o download do [plugin](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) e instalá-lo.
</details>

<details>
  <summary><strong>🛠 Testes</strong></summary><br />

  O .NET já possui sua própria plataforma de testes.
  
  Este projeto já vem configurado e com suas dependências.

  ### Executando todos os testes

  Para executar os testes com o .NET, execute o comando dentro do diretório do seu projeto `src/<project>` ou de seus testes `src/<project>.Test`!

  ```
  dotnet test
  ```

  ### Executando um teste específico

  Para executar um teste específico, basta executar o comando `dotnet test --filter Name~TestMethod1`.

  :warning: **Importante:** o comando irá executar testes cujo nome contém `TestMethod1`.

  :warning: **O avaliador automático não necessariamente avalia seu projeto na ordem em que os requisitos aparecem no readme. Isso acontece para deixar o processo de avaliação mais rápido. Então, não se assuste se isso acontecer, ok?**

  ### Outras opções para testes
  - Algumas opções que podem lhe ajudar são:
    -  `-?|-h|--help`: exibe a descrição completa de como utilizar o comando.
    -  `-t|--list-tests`: lista todos os testes, ao invés de executá-los.
    -  `-v|--verbosity <LEVEL>`: define o nível de detalhe na resposta dos testes.
      - `q | quiet`
      - `m | minimal`
      - `n | normal`
      - `d | detailed`
      - `diag | diagnostic`
      - Exemplo de uso: 
         ```
           dotnet test -v diag
         ```
         ou
         ```            
           dotnet test --verbosity=diagnostic
         ``` 
</details>

<details>
  <summary><strong>🗣 Nos dê feedbacks sobre o projeto!</strong></summary><br />

Ao finalizar e submeter o projeto, não se esqueça de avaliar sua experiência preenchendo o formulário. 
**Leva menos de 3 minutos!**

[FORMULÁRIO DE AVALIAÇÃO DE PROJETO](https://be-trybe.typeform.com/to/PsefzL2e)

</details>

<details>
  <summary><strong>🗂 Compartilhe seu portfólio!</strong></summary><br />

  Você sabia que o LinkedIn é a principal rede social profissional e que compartilhar aprendizados lá é muito importante para quem deseja construir uma carreira de sucesso? Compartilhe este projeto no seu LinkedIn, marque o perfil da Trybe (@trybe) e mostre para a sua rede toda a sua evolução.

</details>

# Requisitos

Introdução

Agora que você já está fera em escrever logs e já sabe em quais contextos fazer isso e como testar se os logs foram enviados com sucesso, agora iremos trabalhar com uma situação que você encontrará com frequência em sua jornada como pessoa desenvolvedora!

Vamos imaginar que temos uma aplicação funcional para registrar animais em um banco de dados de uma clínica veterinária. Vocé é dev na empresa responsável pela manutenção do back end desse sistema.

Depois de algumas discussões com a equipe de produto, concluiu-se que é melhor criar novos logs no controller dessa aplicação, chamado `AnimalController`, para melhorar o acompanhamento das métricas do sistema, e você ficou responsável por essa task!

Vamos então ao desenvolvimento?

---

## 1 - Crie logs para o método `GetAll()`

<details>
  <summary>As requisições bem-sucedidas para o método <code>GetAll()</code> devem registrar um <strong>log de informação</strong> sobre esse retorno</summary><br />

A mensagem retornada deve seguir o padrão "GetAll executed with x animals", sendo o "x" o número de animais retornados do banco.
  
</details>

<details>
  <summary>As requisições para o método <code>GetAll()</code> que lançarem alguma exceção ao longo do fluxo devem registrar um <strong>log de erro</strong> indicando uma falha no servidor</summary><br />

O log registrado deve ter dois parâmetros: a exceção lançada na aplicação e a mensagem `"GetAll failed"`.
  
</details>

<details>
  <summary>Insira no método de teste <code>GetAllSuccessTest()</code> uma verificação, utilizando o <code>_loggerMock</code>, para detectar se o log de informação foi registrado corretamente</summary><br />

O método `LogInformation()` não pode ser verificado aqui, pois é um método de extensão e, por isso, estático. Mesmo que tenha utilizado o `LogInformation()` no controller, faça a verificação a partir do método `Log()`, que é invocado dentro do `LogInformation()`
  
</details>

---

## 2 - Crie logs para o método `GetById()`

<details>
  <summary>As requisições bem-sucedidas para o método <code>GetById()</code> devem registrar um <strong>log de informação</strong> sobre esse retorno</summary><br />

A mensagem retornada deve seguir o padrão "GetById executed with id x", sendo o "x" o número do id passado na requisição.
  
</details>

<details>
  <summary>As requisições para o método <code>GetById()</code> que não encontrarem nenhum objeto com o id solicitado devem registrar um <strong>log de aviso</strong> sobre esse retorno</summary><br />

A mensagem retornada deve seguir o padrão "GetById failed: the animal with id x was not found", sendo o "x" o número do id passado na requisição.
  
</details>

<details>
  <summary>As requisições para o método <code>GetById()</code> que lançarem alguma exceção ao longo do fluxo devem registrar um <strong>log de erro</strong> indicando uma falha no servidor</summary><br />

O log registrado deve ter dois parâmetros: a exceção lançada na aplicação e a mensagem `"GetById failed"`.
  
</details>

<details>
  <summary>Insira no método de teste <code>GetByIdSuccessTest()</code> uma verificação, utilizando o <code>_loggerMock</code>, para detectar se o log de informação foi registrado corretamente</summary><br />

O método `LogInformation()` não pode ser verificado aqui, pois é um método de extensão e, por isso, estático. Mesmo que tenha utilizado o `LogInformation()` no controller, faça a verificação a partir do método `Log()`, que é invocado dentro do `LogInformation()`
  
</details>

<details>
  <summary>Insira no método de teste <code>GetByIdNotFoundTest()</code> uma verificação, utilizando o <code>_loggerMock</code>, para detectar se o log de aviso foi registrado corretamente</summary><br />

O método `LogWarning()` não pode ser verificado aqui, pois é um método de extensão e, por isso, estático. Mesmo que tenha utilizado o `LogWarning()` no controller, faça a verificação a partir do método `Log()`, que é invocado dentro do `LogWarning()`
  
</details>

---

## 3 - Crie logs para o método `Create()`

<details>
  <summary>As requisições bem-sucedidas para o método <code>Create()</code> devem registrar um <strong>log de informação</strong> sobre esse retorno</summary><br />

A mensagem retornada deve seguir o padrão "Create executed with id x", sendo o "x" o número do id passado na requisição.
  
</details>

<details>
  <summary>As requisições para o método <code>Create()</code> que lançarem alguma exceção ao longo do fluxo devem registrar um <strong>log de erro</strong> indicando uma falha no servidor</summary><br />

O log registrado deve ter dois parâmetros: a exceção lançada na aplicação e a mensagem `"Create failed"`.
  
</details>

<details>
  <summary>Insira no método de teste <code>CreateSuccessTest()</code> uma verificação, utilizando o <code>_loggerMock</code>, para detectar se o log de informação foi registrado corretamente</summary><br />

O método `LogInformation()` não pode ser verificado aqui, pois é um método de extensão e, por isso, estático. Mesmo que tenha utilizado o `LogInformation()` no controller, faça a verificação a partir do método `Log()`, que é invocado dentro do `LogInformation()`.
  
</details>

---

## 4 - Crie logs para o método `Update()`

<details>
  <summary>As requisições bem-sucedidas para o método <code>Update()</code> devem registrar um <strong>log de informação</strong> sobre esse retorno</summary><br />

A mensagem retornada deve seguir o padrão "Update executed with id x", sendo o "x" o número do id passado na requisição.
  
</details>

<details>
  <summary>As requisições para o método <code>Update()</code> que não encontrarem nenhum objeto com o id solicitado devem registrar um <strong>log de aviso</strong> sobre esse retorno</summary><br />

A mensagem retornada deve seguir o padrão "Update failed: the animal with id x was not found", sendo o "x" o número do id passado na requisição.
  
</details>

<details>
  <summary>As requisições para o método <code>Update()</code> que lançarem alguma exceção ao longo do fluxo devem registrar um <strong>log de erro</strong> indicando uma falha no servidor</summary><br />

O log registrado deve ter dois parâmetros: a exceção lançada na aplicação e a mensagem `"Update failed"`.
  
</details>

<details>
  <summary>Insira no método de teste <code>UpdateSuccessTest()</code> uma verificação, utilizando o <code>_loggerMock</code>, para detectar se o log de informação foi registrado corretamente</summary><br />

O método `LogInformation()` não pode ser verificado aqui, pois é um método de extensão e, por isso, estático. Mesmo que tenha utilizado o `LogInformation()` no controller, faça a verificação a partir do método `Log()`, que é invocado dentro do `LogInformation()`
  
</details>

<details>
  <summary>Insira no método de teste <code>UpdateNotFoundTest()</code> uma verificação, utilizando o <code>_loggerMock</code>, para detectar se o log de aviso foi registrado corretamente</summary><br />

O método `LogWarning()` não pode ser verificado aqui, pois é um método de extensão e, por isso, estático. Mesmo que tenha utilizado o `LogWarning()` no controller, faça a verificação a partir do método `Log()`, que é invocado dentro do `LogWarning()`
  
</details>

---

## 5 - Crie logs para o método `Delete()`

<details>
  <summary>As requisições bem-sucedidas para o método <code>Delete()</code> devem registrar um <strong>log de informação</strong> sobre esse retorno</summary><br />

A mensagem retornada deve seguir o padrão "Delete executed with id x", sendo o "x" o número do id passado na requisição.
  
</details>

<details>
  <summary>As requisições para o método <code>Delete()</code> que não encontrarem nenhum objeto com id solicitado devem registrar um <strong>log de aviso</strong> sobre esse retorno</summary><br />

A mensagem retornada deve seguir o padrão "Delete failed: the animal with id x was not found", sendo o "x" o número do id passado na requisição.
  
</details>

<details>
  <summary>As requisições para o método <code>Delete()</code> que lançarem alguma exceção ao longo do fluxo devem registrar um <strong>log de erro</strong> indicando uma falha no servidor</summary><br />

O log registrado deve ter dois parâmetros: a exceção lançada na aplicação e a mensagem `"Delete failed"`
  
</details>

<details>
  <summary>Insira no método de teste <code>DeleteSuccessTest()</code> uma verificação, utilizando o <code>_loggerMock</code>, para detectar se o log de informação foi registrado corretamente</summary><br />

O método `LogInformation()` não pode ser verificado aqui, pois é um método de extensão e, por isso, estático. Mesmo que tenha utilizado o `LogInformation()` no controller, faça a verificação a partir do método `Log()`, que é invocado dentro do `LogInformation()`
  
</details>

<details>
  <summary>Insira no método de teste <code>DeleteNotFoundTest()</code> uma verificação, utilizando o <code>_loggerMock</code>, para detectar se o log de aviso foi registrado corretamente</summary><br />

O método `LogWarning()` não pode ser verificado aqui, pois é um método de extensão e, por isso, estático. Mesmo que tenha utilizado o `LogWarning()` no controller, faça a verificação a partir do método `Log()`, que é invocado dentro do `LogWarning()`
  
</details>

---

## 6 - Crie testes para os logs de erro de todos os métodos do `AnimalController`

<details>
  <summary>Insira no método de teste <code>InternalServerErrorTests()</code> uma verificação, utilizando o <code>_loggerMock</code>, para detectar se os log de erro foram registrados corretamente</summary><br />

O método `LogError()` não pode ser verificado aqui, pois é um método de extensão e, por isso, estático. Mesmo que tenha utilizado o `LogError()` no controller, faça a verificação a partir do método `Log()`, que é invocado dentro do `LogError()`.

Além disso, você deve utilizar **apenas uma verificação** que valha para os cinco métodos invocados no teste, já que a única diferença entre eles é a mensagem de erro.

> **Se liga na dica ✏️:** Para testar a mensagem de erro, você pode utilizar o método String.EndsWith(), já que todas as mensagens dos logs de erro terminam da mesma forma (`" failed"`).
  
</details>

---

Parabéns, agora temos uma aplicação que, além de funcional, implementa o uso de logs no controller e os respectivos testes unitários! Agora você já pode se aprofundar ainda mais no mundo dos logs no ASP.NET! 🚀
