# Exemplo Fluxo de Caixa

* Esse projeto visa apresentar uma arquitetura de referência para projetos que necessitam de alta performance e um baixo acoplamento entre os módulos do sistema.

## Arquitetura 

!(./specifications/architecture/architecture.drawio.png)

## Fluxo da informação

!(./specifications/diagram/fluxo-caixa-class.png)

## Domínio da aplicação

!(./specifications/diagram/fluxo-caixa-sequence.png)

### Configuracções appsettings

MessageQueueConnection => string de conexão do rabbitmq

### Configuracções appsettings

* MessageQueueConnection => string de conexão do rabbitmq

## Referências:

[Diagramas do projeto](https://real-world-plantuml.com/)
[Biblioteca de conexão com HabbitMq](https://github.com/EasyNetQ/EasyNetQ/wiki/Introduction)

Extensões vscode
- jebbs.plantuml -> Diagramas de sequencia