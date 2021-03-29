# e-stock-broker

Este repositório tem por finalidade gerar uma imagem docker para trabalhar como um broker. Foi optado o uso do RabitMQ, para essa função, mas acredito que futuramente possa ser adicionado o Kafika.

Para facilitar a criação da imagem, escrevi o arquivo ```e-mail-setup.sh```. Basta executá-lo que a imagem será criada. 
Após a execução acesse o endereço http://localhost:15672 e vualá, seu RabbitMQ estará no ar.

Comando a ser executado: ```e-mail-setup.sh [UserName] [Password] [VirtualHost]```

### docker-compose.yml

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

### rabbit-mq-plugins.dockerfile

Arquivo para gerar a imagem docker. 

Para compilar a nova imagem foram usados os plugins:
* rabbitmq_management
* rabbitmq_mqtt rabbitmq_web_mqtt
* rabbitmq_stomp rabbitmq_web_stomp

Atenção para o arquivo rabbitmq.conf. Ele informa usuário e senha e estes valores devem ser modificados antes de compilar a imagem.

### rabbitmq.conf

Arquivo de configuração do RabbitMQ. Deve ser modificado antes de se compilar para colocar valores mais seguros.
