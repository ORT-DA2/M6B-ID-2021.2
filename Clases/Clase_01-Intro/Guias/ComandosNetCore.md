# Cheat sheet (Lista de comandos desde la consola)

|Comando|Resultado  |
|--|--|
|```dotnet new sln``` |Creamos una solucion (principalmente util para VisualStudio, cuando queremos abir la solucion y levantar los proyectos asociados)
|```dotnet new webapi -n "Nombre del proyecto"```  | Crear un nuevo proyecto del template WebApi. "-n" permite agregar el nombre entre "".
| ```dotnet sln add "Nombre del proyecto"```|Asociamos el proyecto creado al .sln 
| ```dotnet sln list``` | Vemos todos los proyectos asociados a la solucion 
| ```dotnet new classlib -n "Nombre del proyecto2"``` | Crea una nueva libreria (standard)
|```dotnet add "Nombre del proyecto 1" reference "Nombre del proyecto 2"``` | Agrega una referencia del Proyecto 2 al Proyecto 1
|```dotnet add "Nombre Proyecto" package "Microsoft.EntityFrameworkCore"``` | Instala el Package "Microsoft.EntityFrameworkCore" al proyecto "Nombre Proyecto". Similar a cuando se agregaban paquetes de Nuget en .NET Framework
|```dotnet clean``` | Borra lo compilado
|```dotnet build``` | Compila y genera los archivos prontos para ser desplegados
|```dotnet run``` | Compila y corre el proyecto
| ```dotnet -h``` | Ayuda para ejecutar un comando o para inspeccionar diferentes comandos

## Es necesario crear una solucion? (SLN)

No, no es necesario. Sin embargo...

Tener una solucion permite crear/compilar/manejar todos los proyectos involucrados juntos, sin tener que correr cada uno, por ejemplo. Se maneja todo como una unica unidad.
