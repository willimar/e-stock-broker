set ADMIN_USER=%1
set ADMIN_PASSWORD=%2
set RABBITMQ_VHOST=%3

docker-compose down -v

docker-compose up --build