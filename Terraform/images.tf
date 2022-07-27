variable "build_images_command" {
  default = <<-EOT
        docker build -t bootcampici.azurecr.io/newsconsumerapi ./NewsConsumer/API && 
        docker build -t bootcampici.azurecr.io/newsconsumerapi ./NewsConsumer/Proxy && 
        docker build -t bootcampici.azurecr.io/analyzecommentsapi ./AnalyzeComments/API && 
        docker build -t bootcampici.azurecr.io/analyzecommentsapi ./AnalyzeComments/Proxy
      EOT
}

resource "null_resource" "build_images" {
  provisioner "local-exec" {
    working_dir = "${path.module}/../"
    command     = chomp(var.build_images_command)
    interpreter = ["sh", "-c"]
  }
}

variable "upload_images_command" {
  default = <<-EOT
        az acr login --name bootcampici &&
        docker push bootcampici.azurecr.io/newsconsumerapi:latest &&
        docker push bootcampici.azurecr.io/newsconsumerproxy:latest &&
        docker push bootcampici.azurecr.io/analyzecommentsapi:latest &&
        docker push bootcampici.azurecr.io/analyzecommentsproxy:latest
      EOT
}

resource "null_resource" "upload_images" {
  triggers = {
    order = azurerm_container_registry.bootcampici.id
  }

  provisioner "local-exec" {
    working_dir = "${path.module}/../"
    command     = chomp(var.upload_images_command)
    interpreter = ["sh", "-c"]
  }

  depends_on = [
    azurerm_container_registry.bootcampici,
    null_resource.build_images
  ]
}
