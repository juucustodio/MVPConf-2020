|  Project  |  Status  |
|---|---|
| Backend | ![.NET Core](https://github.com/juucustodio/MVPConf-2020/workflows/.NET%20Core/badge.svg) |
| App Android | [![Build status](https://build.appcenter.ms/v0.1/apps/1992a565-2f14-4f18-88a0-e4301b088ab4/branches/master/badge)](https://appcenter.ms) |
| App iOS | [![Build status](https://build.appcenter.ms/v0.1/apps/57b724d1-6908-45c1-94f3-03f0ff6ac527/branches/master/badge)](https://appcenter.ms) |

# MVPConf-2020

Esta aplicação foi desenvolvida com o intuito de demonstrar como podemos desenvolver uma aplicação, um MVP, utilizando tecnologias como Xamarin e Azure.


# Requisitos de sistema
- Dotnet core
- Visual Studio  (Windows ou Mac)
- Xamarin (Com os sdks da respectivas plataformas)
- Conta na Azure - Crie uma conta gratuita](https://azure.microsoft.com/pt-br/free/)

# Mock da aplicação

![Mock do aplicativo](assets/images/MVP%20Conf%20Diagram-APP.png)

# Screenshots
<image width="170px" src="Screenshots/Screenshot_1607791656.png"/> <image width="170px" src="Screenshots/Screenshot_1607791864.png"/> <image width="170px" src="Screenshots/Screenshot_1607791874.png"/> <image width="170px" src="Screenshot_1607791883.png"/> <image width="170px" src="Screenshot_1607791888.png"/>

# Arquitetura do Backend

![Diagrama arquitetural](assets/images/MVP%20Conf%20Diagram-Arquitetura.png)


## Recursos no Azure

- **Function APP**: Neste recurso serão disponibilizadas as functions que serão consumidas pelo aplicativo
- **Storage Account**: Ao criar um function app, também será criado um storage account
- **Storage Account process**: Este storage account será utilizado para manter os dados dos paletrantes e das talks. Fique a vontade para utilizar o próprio storage account criado juntamente com o function app. Mas por questões de organização e separação de responsabilidades, criei um storage account a parte.

### Criação dos recursos

Você poderá criar os recursos diretamente no Azure, utilizando o recurso de **Cloud Shell**, ou instalando o Azure CLI em sua máquina. Os seguintes comandos devem ser executados para a criação dos recursos(após digitado cada linha, pressione enter):

```bash

resourceGroup="MvpConf-2020"
location="eastus"
funcAppName="MvpConfBackEnd"
storageAccountProcess="mvpconfsaprocess"
storageAccountFunction="mvpconffuncsa"

az group create --name $resourceGroup --location $location

az storage account create -n $storageAccountFunction -g $resourceGroup -l $location --sku Standard_LRS

az storage account create -n $storageAccountProcess -g $resourceGroup  -l $location --sku Standard_LRS 

az functionapp create --resource-group $resourceGroup --consumption-plan-location $location --runtime dotnet --functions-version 3 --name $functionAppName --storage-account $storageAccountFunction

```

As primeiras 5 linhas criam variáveis para facilitar o uso nos comandos do Azure CLI.

Em seguida são executados comandos para a criação dos seguintes recursos em ordem:
- Resource Group - Onde serão organizados todos os recursos
- Storage account function - Criação de um storage account para ser utilizado pelas functions. Todos os functions apps necessitam de um storage account por padrão
- Storage account process - conforme mencionado anteriormente, este storage account será criado para separar as responsabildiades. Neste caso, será utilizado para a persistência das informações que serão disponibilizadas para o APP
- Function App - criação da function app

Ao criar os recursos na Azure, você poderá publicar a aplicação através do Visual Studio ou do Visual Studio Code. A publicação automática deste recurso será disponbilizada posteriormente.

Se preferir, pode utilizar o seguinte botão:

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fjuucustodio%2FMVPConf-2020%2Fmaster%2Farm-template%2Ftemplate.json%3Ftoken%3DABO4J37ZRRYTURA7EXZOM4S75DPY2)

# Tasks
- [ ] Documentar publicação pelo Git Actions (Repo público)
- [ ] Documentar publicação App Center


