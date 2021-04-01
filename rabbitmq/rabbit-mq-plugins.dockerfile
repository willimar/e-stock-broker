FROM rabbitmq:3-management-alpine

WORKDIR e-stock-broker

RUN rabbitmq-plugins enable --offline rabbitmq_management \
     && rabbitmq-plugins enable --offline rabbitmq_mqtt rabbitmq_web_mqtt \
     && rabbitmq-plugins enable --offline rabbitmq_stomp rabbitmq_web_stomp \
     && rabbitmq-plugins list

ENV RABBITMQ_CONFIG_FILE=/etc/rabbitmq/rabbitmq
ADD ./rabbitmq.conf /etc/rabbitmq/rabbitmq.conf

WORKDIR e-stock-broker

ADD ./e-mail-setup.sh ./e-mail-setup.sh