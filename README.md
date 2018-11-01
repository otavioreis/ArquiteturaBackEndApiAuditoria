# ArquiteturaBackEndApiAuditoria
Projeto criado como resulução do exercício 03 da aula 03 da disciplina Arquitetura de Backend e Microsserviços do curso de pós-graduação de Arquitetura de Softwares Distribuídos e, requisitado pelo professor Marco Mendes.

Este projeto tem como objetivo auditar todas as requisições feitas no projeto [ArquiteturaBackEndApiLivraria](https://github.com/otavioreis/ArquiteturaBackEndApiLivraria), salvando alguns dados em memória.

O projeto foi desenvolvido utilizando c# juntamente com ASP.NET Core 2.0

## Informações adicionais do projeto

**URL configurada para o projeto - Ambiente de Desenvolvimento**<br />
http://localhost:61000</br></br>

**URL da documentação utilizando o Swagger**<br />
http://localhost:61000/swagger
![alt text](https://i.snag.gy/yStUYX.jpg)


### DESENHO DA API:


**Autenticação**

**MÉTODOS PRIVADOS**

*Autentica um usuário e retorna um token JWT com validade de 30 minutos*
```
POST	/v1/private/auditoria
```

*Json que deve ser passado no corpo da requisição para gravar um registro de auditoria*
```json
{
  "isAuthenticated": true,
  "usuario": {
    "nome": "Teste auditoria inserção",
    "email": "testeauditoriainserção@teste.com",
    "authTime": "2018-06-25T19:54:29.1813525-03:00"
  },
  "caminhoRequest": "v1/public/get",
  "bodyContent": "",
  "queryString": ""
}
```

*Busca todos os registros de auditoria que foram inseridos no repositório em memória*
```
GET	/v1/private/auditoria
```

*Json de exemplo retornado ao invocar o método da API*
```json
[
  {
    "isAuthenticated": true,
    "usuario": {
      "nome": "Teste auditoria 1",
      "email": "testeauditoria@teste.com",
      "authTime": "2018-06-25T19:54:48.8894394-03:00"
    },
    "caminhoRequest": "v1/public/get",
    "bodyContent": "",
    "queryString": ""
  },
  {
    "isAuthenticated": true,
    "usuario": {
      "nome": "Teste auditoria 2",
      "email": "testeauditoria22@teste.com",
      "authTime": "2018-06-23T19:54:48.8894497-03:00"
    },
    "caminhoRequest": "v1/private/getTeste",
    "bodyContent": "",
    "queryString": ""
  }
]
```


**Códigos de Retorno da API***
```
Retorno: 200 - OK - Pode retornar uma string ou um json
Retorno: 404 - NotFound - Página não encontrada, verificar rota
Retorno: 415 - Unsuported Media Type - Verificar corpo da mensagem
```

### Justificativas das regras implementadas na API
1) Todos os recursos da API são baseados em substantivos. Exemplo: comentario, autor, carrinho, pedido, livros.
2) As coleções como Livros e comentários estão com seus nomes no plural.
3) Para um sistema onde o usuário pode pesquisar livros, fazer compra e olhar status do pedido essas entidades descritas no desenho da API suprem a necessidade do negócio.
4) Todos os nossos recursos são mais simples. Temos no máximo 4 partes na URI de delete para passar o id a ser deletado e o id do carrinho. Os demais têm 3 ou menos.
5) No caso de cadastro de livros, por exemplo, é possível informar um ou muitos livros no corpo da requisição.
6) Não está contemplado data e hora no desenho dessa API.
7) A documentação da API mostra os modelos JSON (esquema de dados, formatos suportados, etc.) e as respostas esperadas. Os nomes dos recursos também são de fácil entendimento.
8) Essa API será hospedada em um local com certificado e com SSL em sua URL.
9) Toda essa API está na versão 1 que é indicada com o início de sua formação: Exemplo: dominio/v1/conteudo
10) Para o recurso de listagem de livros por autor e nome do livro, que pode ter muitos dados, existem limites para paginação.
11) Os códigos de retorno do HTTP estão aplicados retornando 200 quando OK. Em caso de erro os retornos também serão adequados como 400 e etc.
