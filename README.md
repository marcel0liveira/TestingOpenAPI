# TestingOpenAPI
Apenas uma API de teste com OpenAPI (visto que Swagger .net >9 está complicado)

## Como executar o projeto

### Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Docker](https://www.docker.com/get-started) (opcional, para execução em container)

### Executando localmente (sem Docker)

1. No terminal, navegue até a pasta do projeto:
```bash 
cd src/TestingOpenAPI
```

2. Execute o projeto:
```bash 
dotnet run
```

3. Acesse a API em:
   - http://localhost:8080/weatherforecast/ -> [Link](http://localhost:8080/weatherforecast/)

### Executando com Docker Compose

1. Na raiz do projeto (onde está o arquivo `docker-compose.yml`), execute:

```bash
docker-compose up --build
```

2. Acesse a API em:
   - http://localhost:8080/weatherforecast/ -> [Link](http://localhost:8080/weatherforecast/)

### Testando a API

Você pode testar o endpoint usando o arquivo `TestingOpenAPI.http`, ferramentas como Postman ou via terminal:

```bash
curl http://localhost:8080/weatherforecast/
```