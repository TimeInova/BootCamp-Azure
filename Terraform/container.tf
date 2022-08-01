resource "azurerm_container_group" "bootcamp" {
  name                = "bootcamp"
  location            = azurerm_resource_group.bootcamp.location
  resource_group_name = azurerm_resource_group.bootcamp.name
  ip_address_type     = "Public"
  dns_name_label      = "bootcampici"
  os_type             = "Linux"

  image_registry_credential {
    server   = azurerm_container_registry.bootcampici.login_server
    username = azurerm_container_registry.bootcampici.admin_username
    password = azurerm_container_registry.bootcampici.admin_password
  }

  # NewsConsumer API
  container {
    name   = "newsconsumerapi"
    image  = "bootcampici.azurecr.io/newsconsumerapi:latest"
    cpu    = "0.5"
    memory = "1.5"

    ports {
      port     = 80
      protocol = "TCP"
    }

    environment_variables = {
      "ASPNETCORE_ENVIRONMENT"                            = "Production"
      "ASPNETCORE_NewsConsumerDatabase__DatabaseName"     = "NewsConsumer"
      "ASPNETCORE_NewsConsumerDatabase__ConnectionString" = azurerm_cosmosdb_account.account.connection_strings[0]
    }
  }

  # NewsConsumer Proxy
  container {
    name   = "newsconsumerproxy"
    image  = "bootcampici.azurecr.io/newsconsumerproxy:latest"
    cpu    = "0.5"
    memory = "1.5"

    ports {
      port     = 82
      protocol = "TCP"
    }

    environment_variables = {
      "NEWSCONSUMERAPI_ADDRESS" = "http://newsconsumerapi"
    }
  }

  # AnalyzeComments API
  container {
    name   = "analyzecommentsapi"
    image  = "bootcampici.azurecr.io/analyzecommentsapi:latest"
    cpu    = "0.5"
    memory = "1.5"

    ports {
      port     = 83
      protocol = "TCP"
    }

    environment_variables = {
      "ASPNETCORE_ENVIRONMENT"                             = "Production"
      "ASPNETCORE_ResultAnalyzeDatabase__DatabaseName"     = "AnalyzeComments"
      "ASPNETCORE_ResultAnalyzeDatabase__ConnectionString" = azurerm_cosmosdb_account.account.connection_strings[1]
      "ASPNETCORE_NewsConsumerAddress"                     = "http://newsconsumerapi/api/GetComments"
      "ASPNETCORE_URLS"                                    = "http://+:83"
      "ASPNETCORE_AzureCognitiveServices__Endpoint"        = ""
      "ASPNETCORE_AzureCognitiveServices__ApiKey"          = ""
    }
  }

  # AnalyzeComments Proxy
  container {
    name   = "analyzecommentsproxy"
    image  = "bootcampici.azurecr.io/analyzecommentsproxy:latest"
    cpu    = "0.5"
    memory = "1.5"

    ports {
      port     = 81
      protocol = "TCP"
    }

    environment_variables = {
      "ANALYZECOMMENTSAPI_ADDRESS" = "http://analyzecommentsapi"
    }
  }

  depends_on = [
    azurerm_container_registry.bootcampici,
    azurerm_cosmosdb_account.account,
    azurerm_cosmosdb_mongo_database.newsdb,
    azurerm_cosmosdb_mongo_database.analyzedb,
    null_resource.build_images,
    null_resource.upload_images
  ]
}
