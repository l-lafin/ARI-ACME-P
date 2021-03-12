# Acme Product (AP)

Projeto de estudos para arquiteturas de integração.

## [POST]

Exemplos de dados para requisições `POST` das respectivas entidades.

### Cliente
```json
{
   "nome":"Nome do Aluno A",
   "cpf":"999",
   "dataNascimento":"2020-07-18T15:07:36.054Z",
   "endereco":{
      "bairro":"Jardim Paqueta",
      "cidade":"Belo Horizonte",
      "logradouro":"Rua Susana Maria",
      "numero":1212,
      "uf":"MG"
   },
   "enderecoCobranca":{
      "bairro":"Jardim Paqueta",
      "cidade":"Belo Horizonte",
      "logradouro":"Rua Susana Maria",
      "numero":1212,
      "uf":"MG"
   },
   "instalacoes":[
      {
         "codigo":"999",
         "dataInstalacao":"2020-07-18T15:07:36.054Z",
         "endereco":{
            "bairro":"Jardim Paqueta",
            "cidade":"Belo Horizonte",
            "logradouro":"Rua Susana Maria",
            "numero":1212,
            "uf":"MG"
         }
      }
   ]
}
```

### Instalação
```json
{
   "codigo":"999",
   "dataInstalacao":"2020-07-18T15:07:36.054Z",
   "cliente":{
      "cpf":"555.759.55-02"
   },
   "endereco":{
      "bairro":"Jardim Paqueta",
      "cidade":"Belo Horizonte",
      "logradouro":"Rua Susana Maria",
      "numero":1212,
      "uf":"MG"
   }
}
```

### Fatura
```json
{
   "codigo":"213v1323",
   "numeroLeitura":123123,
   "valorConta":58,
   "dataVencimento":"2021-03-12T04:10:12.740Z",
   "dataLeitura":"2021-03-12T04:10:12.740Z",
   "instalacao":{
      "codigo":"123ab"
   }
}
```