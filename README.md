# dotnet-url-shortener

## Infra as Code

### Download Azure CLI

### Log in into Azure

```bash
az login
```

### Create Resource Group

```bash
az group create --bame urlshortener-dev --location westeurope
```

<!-- az deployment group what-if --resource-group urlshortener-dev --template-file Infra/main.bicep -->

<!-- az deployment group create --resource-group urlshortener-dev --template-file Infra/main.bicep -->s
