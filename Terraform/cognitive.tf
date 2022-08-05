resource "azurerm_cognitive_account" "bootcamp" {
  name                  = "bootcampACC"
  location              = azurerm_resource_group.bootcamp.location
  resource_group_name   = azurerm_resource_group.bootcamp.name
  kind                  = "TextAnalytics"
  sku_name              = "F0"
  custom_subdomain_name = "bootcampICIAnalytics"
}
