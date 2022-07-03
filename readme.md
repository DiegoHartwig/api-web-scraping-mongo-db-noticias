## Web Scraping para buscar informações e persistir no MongoDB

- .NET
- MongoDB

Para rodar o MongoDB no Docker basta seguir os seguintes passos:

docker pull mongo

docker run --name mongodb -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=seuUsuario -e MONGO_INITDB_ROOT_PASSWORD=suaSenha mongo
