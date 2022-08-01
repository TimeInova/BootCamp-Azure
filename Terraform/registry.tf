resource "azurerm_container_registry" "bootcampici" {
  name                = "bootcampici"
  resource_group_name = azurerm_resource_group.bootcamp.name
  location            = azurerm_resource_group.bootcamp.location
  sku                 = "Basic"
  admin_enabled       = true

  depends_on = [
    azurerm_resource_group.bootcamp
  ]
}
