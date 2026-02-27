<div align="center">

<h1>
  <br/>
  <br/>
  <div>🚨</div>
  <b>Hackathon Alerts</b>
  <br/>
  <br/>
  <br/>
</h1>

A **AgroSolutions** é uma cooperativa agrícola tradicional que busca se modernizar
para enfrentar os desafios do século XXI: otimização de recursos hídricos, aumento
da produtividade e sustentabilidade. Este sistema de alertas permite o monitoramento
em tempo real dos talhões agrícolas, enviando notificações críticas para tomada de
decisão rápida. A aplicação conta com arquitetura Domain-Driven Design (DDD),
ASP.NET Core 8, autenticação via JWT, banco de dados MongoDB, mensageria RabbitMQ
e integração com New Relic para monitoramento, além de contar com boas práticas de
arquitetura, segurança e escalabilidade com Kubernetes.

</div>

> \[!NOTE]
>
> Este projeto visa oferecer uma aplicação robusta, escalável e segura. O desenvolvimento deste projeto é baseado exclusivamente nas suas necessidades guiadas pelo curso de pós graduação Fiap.

<div align="center">

![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-512BD4?style=flat&logo=dotnet&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-47A248?style=flat&logo=mongodb&logoColor=white)
![RabbitMQ](https://img.shields.io/badge/RabbitMQ-FF6600?style=flat&logo=rabbitmq&logoColor=white)
![New Relic](https://img.shields.io/badge/New%20Relic-008C99?style=flat&logo=newrelic&logoColor=white)
![xUnit](https://img.shields.io/badge/xUnit-512BD4?style=flat&logo=.net&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-000000?style=flat&logo=jsonwebtokens&logoColor=white)
![DDD](https://img.shields.io/badge/DDD-Domain--Driven%20Design-FF6B6B?style=flat)

</div>

<details>

<summary>
  <b>Table of contents</b>
</summary>

#### TOC

- [📦 Começando](#-começando)
- [🖱️ Configuração inicial](#️-configuração-inicial)
- [🚧 Contruindo e publicando a aplicação](#-contruindo-e-publicando-a-aplicação)
- [✨ Características](#-características)
- [🚀 Recursos](#-recursos)

####

</details>

## 📦 Começando

Comece clonando o repositório `hackathon-alerts`, executando o comando:

```bash
git clone https://github.com/andersonsrocha/hackathon-alerts.git
```

Agora acesse o projeto usando:

```bash
cd hackathon-alerts
```

Certifique-se de que o MongoDB e RabbitMQ estão rodando localmente. Em seguida, atualize as strings de conexão no `appsettings.json` e realize a restauração dos pacotes:

```bash
dotnet restore
```

Ainda dentro da pasta raiz, execute o comando abaixo para iniciar a aplicação:

```bash
dotnet run --project src/HackathonAlerts.Api
```

E por fim poderá acessar a aplicação através do link [Documentação](http://localhost:5062/scalar).

<br/>

## 🖱️ Configuração inicial

Para utilizar o sistema de alertas, certifique-se de que os seguintes serviços estão rodando:

- **MongoDB**: `mongodb://localhost:27017`
- **RabbitMQ**: `localhost` com usuário `admin` e senha `admin123`

O sistema requer autenticação JWT. Configure as credenciais apropriadas através do endpoint de autenticação.

## 🚧 Contruindo e publicando a aplicação

Agora para construirmos a aplicação, basta executar o comando abaixo no diretório raiz do projeto:

```bash
dotnet build
```

E por fim, para publicar a aplicação:

> \[!TIP]
>
> É possível trocar a pasta de destino substituindo `./publish` pelo diretório desejado.

```bash
dotnet publish -c Release -o ./publish
```

## ✨ Características

- [x] ~~Sistema de alertas em tempo real.~~
- [x] ~~Monitoramento de talhões agrícolas.~~
- [x] ~~Banco de dados MongoDB.~~
- [x] ~~Autenticação JWT.~~
- [x] ~~Mensageria com RabbitMQ.~~
- [x] ~~Integração com New Relic.~~
- [x] ~~Testes unitários.~~
  - [x] ~~Criação de alertas.~~
  - [x] ~~Atualização de alertas.~~
  - [x] ~~Validações de domínio.~~
  - [x] ~~Handlers de aplicação.~~
- [x] ~~Criação de arquivo Dockerfile.~~
- [x] ~~Domain-Driven Design.~~
- [x] ~~API RESTful com documentação Scalar.~~
- [x] ~~Middleware de tratamento de exceções.~~
- [x] ~~Logging estruturado com Serilog.~~
- [x] ~~Correlação de IDs para rastreabilidade.~~
- [x] ~~Padrão CQRS com MediatR.~~
- [x] ~~Deploy com Kubernetes.~~

<br/>

## 🚀 Recursos

- 🎨 **.NET 8 SDK**: Framework moderno e multiplataforma da Microsoft que oferece alta performance, suporte nativo para contêineres, APIs mínimas e recursos avançados de desenvolvimento. Inclui melhorias significativas em performance, garbage collection otimizado e suporte completo para desenvolvimento de aplicações web robustas e escaláveis.
- 🗄️ **MongoDB**: Banco de dados NoSQL orientado a documentos, ideal para dados dinâmicos e escalabilidade horizontal. Oferece flexibilidade no esquema, alta performance para operações de leitura/escrita e suporte nativo para JSON, perfect para armazenar dados de alertas variáveis.
- 🐰 **RabbitMQ**: Message broker robusto para processamento assíncrono de alertas, garantindo entrega confiável e processamento em fila para alta disponibilidade do sistema.
- 📊 **New Relic**: Plataforma de monitoramento e observabilidade que coleta métricas, logs e traces da aplicação, permitindo insights em tempo real sobre performance e saúde do sistema de alertas.
- 🧪 **xUnit**: Framework de testes unitários para .NET que fornece uma base sólida para testes automatizados, com suporte para testes parametrizados, fixtures e execução paralela.
- 🐳 **Docker**: Containerização da aplicação para garantir consistência entre ambientes de desenvolvimento, teste e produção, facilitando deploy e escalabilidade.
- 🔐 **JWT Authentication**: Sistema de autenticação baseado em tokens seguros e stateless, permitindo autorização distribuída e controle de acesso granular.
- 🏗️ **Domain-Driven Design (DDD)**: Arquitetura que foca no domínio do negócio, promovendo código mais organizando, manutenível e alinhado com as regras de negócio.

<br/>

Copyright © 2026.
