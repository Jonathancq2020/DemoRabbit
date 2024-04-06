# DemoRabbit

1. Levantar el RabbitMq con docker compose, el archivo yamel se encuentra en la carpeta RabbitMq.
2. Configurar las configuraciones del Mail para el envio de correo, esta configuración se debe realizar en el archivo appsettings.Development.json 
   del proyecto DemoRabbitMq.Consumer.
3. Configurar la conexión de RabbitMq en los archivos appsettings.Development.json de los proyectos DemoRabbitMq.Consumer y DemoRabbitMq.WebApi.
4. Ejecutar la aplicación y probar con swagger y/o postman