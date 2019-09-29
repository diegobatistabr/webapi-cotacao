# webapi-cotacao

### Request Exemplo Valido
> {
  "nome": "João Batista",
  "nascimento": "1989-09-29",
  "endereco": {
    "logradouro": "Rua XXXX",
    "bairro": "XXXXXX",
    "cep": "13318-000",
    "cidade": "Brasília"
  },
  "coberturas": [
    "01",
    "02",
  ]
}

### Response Exemplo Valido
> {
  "premio": 130,
  "parcelas": 1,
  "valor_Parcelas": 130,
  "primeiro_Vencimento": "2019-10-07T00:00:00",
  "cobertura_Total": 55000
}

### Request CEP Inválido
> {
  "nome": "João Batista",
  "nascimento": "1989-09-29",
  "endereco": {
    "logradouro": "Rua XXXX",
    "bairro": "XXXXXX",
    "cep": "133000",
    "cidade": "Brasília"
  },
  "coberturas": [
    "01",
    "02",
  ]
}

### Response CEP Inválido
> [
  {
    "propertyName": "CEP",
    "errorMessage": "CEP Formato Invalido!",
    "severity": 0
  }
]


### Request Cidade E CEP Inválido
> {
  "nome": "João Batista",
  "nascimento": "1989-09-29",
  "endereco": {
    "logradouro": "Rua XXXX",
    "bairro": "XXXXXX",
    "cep": "133000",
    "cidade": "XXXXXXXX"
  },
  "coberturas": [
    "01",
    "02",
  ]
}

### Response Cidade E CEP Inválido
> [
  {
    "propertyName": "CEP",
    "errorMessage": "CEP Formato Invalido!",
    "severity": 0
  },
  {
    "propertyName": "Cidade",
    "errorMessage": "Cidade não existente!",
    "severity": 0
  }
]

### Request Uma Cobertura Obrigatório Inválido
> {
  "nome": "João Batista",
  "nascimento": "1989-09-29",
  "endereco": {
    "logradouro": "Rua XXXX",
    "bairro": "XXXXXX",
    "cep": "13318-000",
    "cidade": "Brasília"
  },
  "coberturas": [
    "02",
  ]
}

### Response Uma Cobertura Obrigatório Inválido
> [
  {
    "propertyName": "Coberturas",
    "errorMessage": "É necessario pelo menos ter um item Obrigatório na cotação!",
    "severity": 0
  }
]
