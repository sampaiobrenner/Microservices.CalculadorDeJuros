﻿# Microservices.CalculadorDeJuros

[![CodeFactor](https://www.codefactor.io/repository/github/sampaiobrenner/microservices.calculadordejuros/badge)](https://www.codefactor.io/repository/github/sampaiobrenner/microservices.calculadordejuros)

## Para configuração do client deve ser alterada a URL no appsettings
```
src/Microservices.CalculadorDeJuros.WebApi/appsettings.json
src/Microservices.CalculadorDeJuros.WebApi/appsettings.Development.json
```

### Rotas disponíveis:
```
/swagger/index.html
api/v1/calculajuros
api/v1/showMeTheCode
```

### O MS de taxa de juros está disponível no link: 
```
https://github.com/sampaiobrenner/Microservices.TaxaDeJuros
```

### O container no docker dessa aplicação está disponível no link: 
```
https://hub.docker.com/r/sampaiobrenner/microservices-calculador-de-juros
```

### Para executar o container e efetuar o build do projeto basta executar o comando abaixo na raiz do projeto:
```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build -d
```

### Para somente executar o container basta executar o comando abaixo na raiz do projeto:
```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```
