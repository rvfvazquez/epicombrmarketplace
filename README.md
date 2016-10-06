# epicombrmarketplace
EPICOM. MHUB 

Este projeto é uma implementação de exemplo de um desafio de integração com a epicom

<h1>Rodar a applicação </h1>

Abrir RVF.DesafioEpicom.sln no Visual Studio 2015 e rodar a aplicação no IIS Express(RVF.Marketplace.API).

<h1>Suite de testes</h1>

Abrir RVF.DesafioEpicom.sln no Visual Studio 2015 e rodar a suite pelo test explorer (RVF.Marketplace.API.Tests).

<H1>A Documentação da API  </H1>

A Documentação da API esta disponível via Swagger http://{servidor}/swagger

<H2>RVF.Marketplace.Api</H2>

Embora a API seja disponivel através de uma única URI "/api/SKUs" , separei as responsabilidades em dois Controllers
<ul>
<li><b>SKUs</b></li>
<li><b>NotificacaoSKU</b></li>
</ul>

<b>SKUs</b>
<br>
<ul>
<li>GET /api/SKUs/preco/{precode}/ate/{precoate}</li>
<li>GET /api/SKUs</li>
<li>POST /api/SKUs</li>
<li>DELETE /api/SKUs/{id}</li>
<li>GET /api/SKUs/{id}</li>
<li>PUT /api/SKUs/{id}</li>
</ul>

<b>Estrutura da Mensagem SKU<b>

{
  "idSKU": 0,
  "cdSKU": "string",
  "idProduto": 0,
  "preco": 0,
  "DataCriacao": "2016-10-06T01:26:23.136Z",
  "DataAlteracao": "2016-10-06T01:26:23.136Z"
}

<b>NotificacaoSKU</b> 
<br>
<ul>
<li>POST /api/SKUs/Notificacao</li>
</ul>

<br>
<b>Estrutura da Mensagem Notificação</b>
<br>
{
  "tipo": "criacao_sku",
  "dataEnvio": "2015-07-14T13:56:36",
  "parametros": {
    "idProduto": 100,
    "idSku": 200
  }
}
