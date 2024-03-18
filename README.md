Este proyecto demuestra el uso de semáforos para controlar el acceso a un recurso compartido en un programa concurrente en C#. El escenario simulado es un parque con un límite de personas que pueden estar dentro al mismo tiempo.

Funcionamiento:

Se crea un semáforo con un valor inicial que representa la capacidad máxima del parque.
Las personas que desean entrar al parque llaman al método Entrar(), que intenta adquirir un permiso del semáforo.
Si hay permisos disponibles, la persona entra al parque y se libera un permiso del semáforo.
Si no hay permisos disponibles, la persona espera hasta que un permiso sea liberado.
Cuando una persona sale del parque, llama al método Salir(), que libera un permiso del semáforo.
Archivos:

Parque.cs: Contiene la clase Parque que implementa la lógica del parque con semáforos.
Program.cs: Contiene el código principal que crea e instancia el parque, y simula la entrada y salida de personas.
Ejecución:

Compilar el proyecto con dotnet build.
Ejecutar el programa con dotnet run.
Ejemplo de salida:

Persona 1 ha entrado al parque
Persona 2 ha entrado al parque
Persona 3 ha entrado al parque
Persona 4 ha entrado al parque
El parque está lleno. Persona 5 no puede entrar
Persona 2 ha salido del parque
Persona 5 ha entrado al parque
Persona 3 ha salido del parque
Persona 4 ha salido del parque
Persona 1 ha salido del parque
Persona 5 ha salido del parque
![image](https://github.com/Gaby-0616/AppConcurrenteTiempoReal/assets/55850839/3d44bbf9-55ba-403c-b4b7-aeb77a44af3c)

Tecnologías:

C#
.NET Core
Semáforos
Uso:

Este ejemplo puede ser utilizado como base para comprender el uso de semáforos en programas concurrentes.
Se puede modificar y ampliar para simular escenarios más complejos.
Limitaciones:

Este ejemplo no tiene en cuenta la sincronización de otras operaciones que podrían ocurrir en un parque real, como la compra de entradas o la asignación de recursos.
