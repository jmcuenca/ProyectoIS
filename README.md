# ProyectoIS
Proyecto de ingeniería de software

##Modelo
Esta la conexión con la base de datos
para actualizar el modelo cambiar la cadena de conexión en el archivo App.config

```
<connectionStrings>
    <add name="AsociacionEntities" connectionString="metadata=res://*/Modelo.csdl|res://*/Modelo.ssdl|res://*/Modelo.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=192.168.252.154\THCPD;initial catalog=Asociacion;user id=sa;password=Asiste2018;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
```
Se puede cambiar el nombre del servidor\instancia, usuario y contraseña



