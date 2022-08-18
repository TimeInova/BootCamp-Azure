<header>
 <div>
  <p align="center">
 <image src = "https://media.glassdoor.com/sqll/2425544/instituto-das-cidades-inteligentes-squareLogo-1611168482412.png" </img>
   </p>
 </div> 
 <p align="center">
<h1 align="center">ICI - INSTITUTO DE CIDADES INTELIGENTES</h1>
<h2 align="center">BOOTCAMP - DOCUMENTO DE VISÃO</h2>
 </p>
</header>



## 1. Introdução

### 1.1. Finalidade

A finalidade deste documento é coletar, analisar e definir as características e necessidades de alto nível do Software. Ele contém as expectativas do cliente, o escopo acordado, a solução proposta e os requisitos funcionais e não funcionais. O documento de visão também é utilizado como evidência que os requisitos foram coletados e aprovados pelos principais envolvidos.

### 1.2. Documentos de Referências e Registros de Reuniões

Esta documentação não foi baseada em documentações externas.

## 2. Necessidades e Envolvidos

### 2.1 Cenário Atual

Como documento de finalização do BootCamp, foi passado o desafio de criação de um clipping de notícias, de modo que utilizemos o que foi ensinado em relação ao ambiente Azure e apliquemos na estruturação do clipping.


### 2.2 Papéis e Responsabilidades


| *Papel*  |  *Responsabilidade*  |
| ------------------- | ------------------- |
|  Time de desenvolvimento |  Coletar, analisar, validar e documentar os requisitos do produto. Elaborar e atualizar o documento de visão. Validar e aprovar o documento de visão junto ao fornecedor de requisitos. Aprovar o documento de visão |
|  Professor |  Realizar elaboração de aulas em relação ao ambiente Azure e realizar correção do desafio definido. |

## 3. Visão Geral do Produto

### 3.1 Solução Proposta

A solução proposta para este desafio consiste em criar um clipping das notícias referentes à Prefeitura de Curitiba, analisando os sentimentos dos comentários referentes a essas notícias.

### 3.2 Arquitetura da Solução

![Arquitetura](https://i.ibb.co/4dvrcfr/arqu-jpg.jpg)

| *Nº*  |  *Item*  |  *Descrição* |
| ------------------- | ------------------- | ------------------- |
| 1. | ENI01 - Desenvolvimento de serviços em cloud | Serão utilizados os serviços disponíveis no ambiente Azure. |
| 2. | ENI02 - Integrações  | Integrações diferentes das listadas abaixo: API Twitter / API Microsoft Cognitive Services / API Gateway.|
| 3. | ENI03 - Linguagem | Não está previsto desenvolvimento do sistema em línguas que não o Português do Brasil. |
| 4. | ENI04 - Mobile  | Não está previsto desenvolvimento de aplicação mobile. |

### 3.4 Premissas e Restrições

| *Nº*  |  *Item*  |  *Descrição* |
| ------------------- | ------------------- | ------------------- |
| 1. | RES01 - Custo | O desenvolvimento será feito através da conta gratuita do Azure, sem geração de custo para o time. |

## 4. Requisitos
### 4.1 Requisitos Funcionais

| *Nº*  |  *Requisito*  |  *Descrição* |
| ------------------- | ------------------- | ------------------- |
| 1. | REQ001 - Manter API Gateway |  |
| 2. | REQ002 - Manter API do Twitter |  |
| 3. | REQ003 - Manter API Cognitive Services |  |

## 4.2 Requisitos Não Funcionais

  *Requisito*  |  *Descrição* |
| ------------------- | ------------------- |
| Homologação | A homologação do que foi desenvolvido durante o BootCamp será feita pelos integrantes do time. |
| Homologação | A implantação será realizada no ambiente Azure de forma incrementa |
| Plataforma Tecnológica | Para desenvolvimento da interface do sistema: Framework ICI .NET 6 / Azure; |
| Testes | Os testes serão realizados em paralelo com o desenvolvimento das funcionalidades, sendo estes primordiais para o aceite do desenvolvimento. |

# Desenvolvedores
 - Álvaro José Baranoski
 - Karine Trevisan
 - Lennon Alberto dos Santos
 - Paulo Rebouças 
 - Thales Gomes

# BootCamp-Azure
Repositório dedicado ao BootCamp do ICI

 - Link para acessar o swagger do microserviço de Clipping `http://localhost/swagger/index.html`
 - Link para acessar o swagger do microserviço de Analyze  `http://localhost:81/swagger/index.html`
