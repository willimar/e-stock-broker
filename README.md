# e-stock-broker

Este repositório tem por finalidade gerar uma imagem docker para trabalhar como um brocker. Foi optado o uso do RabitMQ, para essa função, mas acredito que futuramente possa ser adicionado o Kafika.

## docker-compose.yml

Arquivo para subir um container. Foram usadas variaveis de ambiente para informar a senha e usuário da UI do RabbitMQ.
Necessária atenção para as variáveis de ambiente:
* ${ADMIN_USER}: Usuário para login no gerenciador do RabbitMQ.
* ${ADMIN_PASSWORD}: Senha que será usada no gerenciador do RabbitMQ.
* ${RABBITMQ_VHOST}: Nome do ambiente virtual padrão.

O nome do container é informado hardcode ``` container_name: e-stock-broker ``` logo é importante excluir o container anterior antes de criar um novo.
Caso esteja usando um Kubernets, esta linha deverá ser excluída.

Comandos uteis:
```
    # Para executar o container
    docker-compose up --build
    
    # Para desfazer as modificações do up
    docker-compose down -v
```

## rabbit-mq-plugins.dockerfile

## rabbitmq.conf
