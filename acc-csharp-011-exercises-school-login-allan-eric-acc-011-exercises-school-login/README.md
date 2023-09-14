# Boas-vindas ao repositório do exercício `Login de Escola`

Para realizar o projeto, atente-se a cada passo descrito a seguir. Se tiver qualquer dúvida, nos envie por _Slack_! #vqv 🚀

Aqui você vai encontrar os detalhes de como estruturar o desenvolvimento do seu projeto a partir deste repositório, utilizando uma branch específica e um _Pull Request_ para colocar seus códigos.

# Termos e acordos

Ao iniciar este projeto, você concorda com as diretrizes do Código de Conduta e do Manual da Pessoa Estudante da Trybe.

# Orientações

<details>
  <summary><strong>‼️ Antes de começar a desenvolver</strong></summary><br />

  1. Clone o repositório

  - Use o comando: `git clone git@github.com:tryber/acc-csharp-0x-project/exercises-school-login.git`.
  - Entre na pasta do repositório que você acabou de clonar:
    - `cd acc-csharp-0x-project/exercises-school-login`

  2. Instale as dependências
  
  - Entre na pasta `src/`.
  - Execute o comando: `dotnet restore`.
  
  3. Crie uma branch a partir da branch `master`

  - Verifique que você está na branch `master`
    - Exemplo: `git branch`
  - Se não estiver, mude para a branch `master`
    - Exemplo: `git checkout master`
  - Agora crie uma branch à qual você vai submeter os `commits` do seu projeto
    - Você deve criar uma branch no seguinte formato: `nome-de-usuario-nome-do-projeto`
    - Exemplo: `git checkout -b joaozinho-acc-0x-project/exercises-school-login`

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
      - `git status` (deve aparecer uma mensagem tipo essa:  _nothing to commit_ )

  5. Adicione a sua branch com o novo `commit` ao repositório remoto

  - Usando o exemplo anterior: `git push -u origin joaozinho-acc-0x-project/exercises-school-login`

  6. Crie um novo `Pull Request` _(PR)_

  - Vá até a página de _Pull Requests_ do [repositório no GitHub](https://github.com/tryber/acc-csharp-0x-project/exercises-school-login/pulls)
  - Clique no botão verde _"New pull request"_
  - Clique na caixa de seleção _"Compare"_ e escolha a sua branch **com atenção**
  - Coloque um título para a sua _Pull Request_
    - Exemplo: _"Cria tela de busca"_
  - Clique no botão verde _"Create pull request"_
  - Adicione uma descrição para o _Pull Request_ e clique no botão verde _"Create pull request"_
  - **Não se preocupe em preencher mais nada por enquanto!**
  - Volte até a [página de _Pull Requests_ do repositório](https://github.com/tryber/acc-csharp-0x-project/exercises-school-login/pulls) e confira que o seu _Pull Request_ está criado

</details>

<details>
  <summary><strong>⌨️ Durante o desenvolvimento</strong></summary><br/>

  - Faça `commits` das alterações que você fizer no código regularmente

  - Lembre-se sempre, após um (ou alguns) `commits` de atualizar o repositório remoto

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

  Para executar um teste expecífico, basta executar o comando `dotnet test --filter Name~TestMethod1`.

  :warning: **Importante:** o comando irá executar testes cujo nome contém `TestMethod1`.

  :warning: **O avaliador automático não necessariamente avalia seu projeto na ordem em que os requisitos aparecem no readme. Isso acontece para deixar o processo de avaliação mais rápido. Então, não se assuste se isso acontecer, ok?**

  ### Outras opções para testes
  - Algumas opções que podem lhe ajudar são:
    -  `-?|-h|--help`: exibem a descrição completa de como utilizar o comando.
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

[FORMULÁRIO DE AVALIAÇÃO DE PROJETO](https://be-trybe.typeform.com/to/ZTeR4IbH#cohort_hidden=CH11&template=betrybe/acc-csharp-0x-exercises-school-login)

</details>

<details>
  <summary><strong>🗂 Compartilhe seu portfólio!</strong></summary><br />

  Você sabia que o LinkedIn é a principal rede social profissional e que compartilhar aprendizados lá é muito importante para quem deseja construir uma carreira de sucesso? Compartilhe este projeto no seu LinkedIn, marque o perfil da Trybe (@trybe) e mostre para a sua rede toda a sua evolução.

</details>

# Requisitos

Olá, Tryber! Estamos precisando de um sistema de login em um de nossos projetos aqui na Trybe. Para a criação desse em específico, contamos com a sua ajuda!

Deve ser aplicado o conceito de autenticação para pessoas estudantes, onde ao realizar o Login, caso essa pessoa estudante esteja disponível em uma base de dados, tem que ser realizada a geração de um Token, utilizando o método `JWT`. 

## Utilize o modelo para as pessoas estudantes

<details>
  <summary>Utilize da classe de Modelo em `Student.cs`</summary><br />

Duas propriedades estão incluídas. Sendo elas: e-mail e senha. Ambas com o tipo `string`.

</details>

## Não se preocupe com a base de dados

<details>
  <summary>Uma outra equipe já lidou com os dados!</summary><br />

O seu objetivo principal vai ser apenas validar os dados consumindo um serviço já existente e gerar o Token após essa validação. 

Para consumir o serviço de se uma pessoa estudante será valida, utilize uma instância da classe `StudentRepository` e utilize a função `StudentExists()`. Essa função espera um argumento, sendo um objeto de `Student` e retorna um valor booleano, uma indicação de se a pessoa estudante existe ou não.

A lista das pessoas estudantes válidas:

```csharp
{ Email = "tulio.olivieri@betrybe.com", Password = "Tulio123"}
{ Email = "marina.novais@betrybe.com", Password = "Marina123"}
{ Email = "jaqueline.milsted@betrybe.com", Password = "Jack123"}
{ Email = "arthur.procopio@betrybe.com", Password = "Arthur123"}
```

</details>

## 1 - Crie o serviço gerador de Token

<details>
  <summary>Não se esqueça de adicionar as referências dos pacotes ao projeto</summary><br />

Relembrando🧠: Adicione os pacotes `Microsoft.AspNetCore.Authentication` e `Microsoft.AspNetCore.Authentication.JwtBearer` ao projeto.

Crie o serviço gerador de Token na pasta `Services`, com uma classe de responsabilidade única denominada `TokenGenerator.cs`.

Crie a função `Generate()`, cujo a mesma, vai gerar um Token `JWT` e retornar um valor do tipo `string`, o Token.

Relembrando🧠: Não esqueça de inserir o valor de `Secret` (Utilize a classe `TokenConstants.cs` e altere a constante `Secret` para sua chave) na aplicação para geração do Token. E utilize de objetos como `JwtSecurityTokenHandler` e `SecurityTokenDescriptor` para gerar o Token.

</details>

<details>
  <summary>Crie Testes Unitários para o Serviço Gerador de Token</summary><br />

 Utilize a classe TestTokenGenerator.cs para os testes do serviço gerador de Token

Para garantir eficiência na geração de Token, crie testes unitários para função `TestTokenGeneratorSuccess()` e `TestTokenGeneratorKeysSuccess()`.

A função `TestTokenGeneratorSuccess()` deve apenas validar que o retorno do serviço gerador de Token não é vazio ou nulo.

A `TestTokenGeneratorKeysSuccess()` deve verificar se o Token está realmente respeitando o formato `JWT`.

Relembrando🧠: Um token `JWT` é composto por 3 partes: header, payload e signature. E juntas elas formam o Token. Ah, e cada elemento é separado por um ponto. 

Se certifique que o Token retornado está possuindo 3 partes como deveria. 

De olho na dica👀: Pode ser utilizada a função `Split()` da classe `String` para essa verificação.

</details>


## 2 - Construa o *endpoint* com ação de Login na `API`

<details>
  <summary>Utilize da classe LoginController.cs</summary><br />

Realize a construção da ação de `Login()` cujo a função vai receber um objeto de `Student` do *Client* que solicitar a aplicação e vai retornar uma `ActionResult<string>`. 

Utilize o bloco `try-catch` para capturar exceções. 

Caso a pessoa usuária não exista. Retorne uma ação de `NotFound()`.

E no bloco catch, utilize do objeto `Exception` para retornar `BadRequest()` passando a mensagem da exceção como argumento, caso no processo seja capturada uma exceção.

Retorne o Token dentro de um objeto `Ok()` se tudo der certo!

Exemplo:

`return Ok(token);`

</details>

<details>
  <summary>Realize testes de integração para o *endpoint* com ação de Login na `API`</summary><br />

Utilize da classe TestLoginController.cs

Para realizar testes na ação de Login, realize testes para os cenários:

`TestLoginSuccess()`: Vai ser o resultado de sucesso para a função, onde o e-mail e senha passados em objeto `Student` serão encontrados e o Token será gerado. Para validar, utilize o retorno da requisição `HTTP` e valide se a propriedade `StatusCode` é do tipo `Ok`. 

Exemplo:  `response.Result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);`

`TestLoginNotFoundFail()`: Vai ser o resultado de pessoa estudantes não encontrada para a função, onde o e-mail e senha passados em objeto `Student` não serão encontrados e o Token não será gerado, pois o retorno de `NotFound()` acontecerá antes da ação de geração do Token. Para validar o teste, utilize o retorno da requisição `HTTP` e valide se a propriedade `StatusCode` é do tipo `NotFound`. 

Exemplo:  `response.Result.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);`

`TestLoginBadRequestFail()`: Vai ser o resultado caso ocorra uma exceção durante o processo de Login, para acontecer esse tipo de erro durante a execução, pelo menos um dos parâmetros precisa estar vazio ou nulo, dessa forma uma exceção será lançada e o fluxo de controle vai para o bloco `catch` na ação da `API` onde o retorno de `BadRequest()` acontecerá. Para validar o teste, utilize o retorno da requisição `HTTP` e valide se a propriedade `StatusCode` é do tipo `BadRequest`. 

Exemplo:  `response.Result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);`

</details>


## 3 - Construa *endpoint* que necessita de autorização 

<details>
  <summary>Utilize da classe HomeController.cs</summary><br />

Crie a função `Private()` onde a mesma terá um atributo `[Authorize]` e dessa forma para o `client` conseguir acessar tal função, será necessário passar um token válido no `Header` da requisição.

Para essa função, retorne uma simples `string` contendo o valor:

`"Parabéns, você realizou a autenticação com sucesso!"`.

</details>

<details>
  <summary>Realize Testes de Integração para *endpoint* que necessita de autorização </summary><br />

Utilize da classe TestHomeController.cs

Para realizar testes na ação de Login, realize testes para os cenários:

`TestHomePrivateSuccess()`: Nesse cenário consuma o endpoint de `Login` passando valores de pessoas estudantes válidos e aptos ao `Token` para simular uma ação de Login ocorrendo, e após isso, utilize o retorno dessa ação, o Token `JWT` para passar no Header da requisição de `Private()` da classe `HomeController.cs`.

Para validar, verifique se a mensagem retornada é a mesma que foi descrita no retorno da função na `API`. Como por exemplo:

`responsePrivateString.Result.Should().Be(resultExpected);`

`TestHomePrivateUnauthorizedFail()`: Nesse cenário consuma o endpoint de `Login` passando valores inválidos de pessoas estudantes, para simular uma ação de Login ocorrendo sem sucesso, e após isso, utilize o retorno dessa ação, o Token `JWT` inexistente nesse cenário, para passar no Header da requisição de `Private()` da classe `HomeController.cs`. Dessa forma, um erro do tipo `Unauthorized` tem que ser retornado. 

Para validar utilizando `FluentAssertions` utilize o seguinte código:

`responsePrivate.Result.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);`

</details>
