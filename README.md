# Documentación del Proyecto

## Descripción General

Este proyecto es una API para la gestión de vehículos, ventas y compradores. Está desarrollado en C# utilizando .NET 8 y Entity Framework Core para la gestión de la base de datos.

## Componentes del Proyecto

### Controllers

- **VehiculosController.cs**: Controlador principal para la gestión de vehículos. Incluye métodos para obtener, crear y editar vehículos.

  - **Get()**: Método para obtener la lista de vehículos.
  - **Crear([FromBody] Vehiculos vehiculo)**: Método para crear un nuevo vehículo.
  - **Editar([FromBody] Vehiculos vehiculo)**: Método para editar un vehículo existente.

- **PrecioController.cs**: Controlador para la gestión de precios de vehículos. Incluye métodos para obtener la lista de precios.

  - **listaPrecios()**: Método para obtener la lista de precios ejecutando un procedimiento almacenado.

- **VentasController.cs**: Controlador para la gestión de ventas. Incluye métodos para obtener y agregar ventas.

  - **get()**: Método para obtener la lista de ventas.
  - **Agregar([FromBody] VentaComprador ventaComprador)**: Método para agregar una nueva venta.

- **UsuarioController.cs**: Controlador para la gestión de usuarios. Incluye métodos para obtener y crear usuarios.
  - **Get()**: Método para obtener la lista de usuarios.
  - **Crear([FromBody] Usuario usuario)**: Método para crear un nuevo usuario.

### Models

- **Vehiculos.cs**: Modelo que representa un vehículo. Incluye propiedades como:

  - `VehiculoID`: Identificador único del vehículo.
  - `Tipo`: Tipo de vehículo.
  - `Modelo`: Modelo del vehículo.
  - `Color`: Color del vehículo.
  - `Kilometraje`: Kilometraje del vehículo.
  - `Valor`: Valor del vehículo.
  - `FechaRegistro`: Fecha de registro del vehículo.
  - `Estado`: Estado del vehículo.
  - `Imagen`: Imagen del vehículo.
  - `CarroID`: Identificador del carro.
  - `Cilindraje`: Cilindraje del vehículo.
  - `NumeroVelocidades`: Número de velocidades del vehículo.

- **VentaComprador.cs**: Modelo que representa la relación entre una venta y un comprador. Incluye propiedades como:

  - `Nombre`: Nombre del comprador.
  - `IdVehiculo`: Identificador del vehículo.
  - `TipoDocumentoIdentidad`: Tipo de documento de identidad del comprador.
  - `DocumentoIdentidad`: Documento de identidad del comprador.
  - `Telefono`: Teléfono del comprador.
  - `Email`: Correo electrónico del comprador.
  - `Direccion`: Dirección del comprador.
  - `FechaNacimiento`: Fecha de nacimiento del comprador.

- **Reporte.cs**: Modelo que representa un reporte de ventas. Incluye propiedades como:

  - `SumasVentas`: Suma de las ventas.
  - `cantidadVehiculos`: Cantidad de vehículos vendidos.
  - `Modelo`: Modelo del vehículo.
  - `Tipo`: Tipo de vehículo.

- **Venta.cs**: Modelo que representa una venta. Incluye propiedades como:

  - `Id`: Identificador único de la venta.
  - `IdVehiculo`: Identificador del vehículo vendido.
  - `FechaVenta`: Fecha de la venta.

- **Comprador.cs**: Modelo que representa un comprador. Incluye propiedades como:

  - `Id`: Identificador único del comprador.
  - `Nombre`: Nombre del comprador.
  - `TipoDocumentoIdentidad`: Tipo de documento de identidad del comprador.
  - `DocumentoIdentidad`: Documento de identidad del comprador.
  - `Telefono`: Teléfono del comprador.
  - `Email`: Correo electrónico del comprador.
  - `Direccion`: Dirección del comprador.
  - `FechaNacimiento`: Fecha de nacimiento del comprador.

- **Usuario.cs**: Modelo que representa un usuario. Incluye propiedades como:
  - `Id`: Identificador único del usuario.
  - `Nombre`: Nombre del usuario.
  - `Email`: Correo electrónico del usuario.
  - `Password`: Contraseña del usuario.

### Services

- **ServicesVehiculo.cs**: Servicio para la gestión de vehículos. Incluye métodos para crear vehículos de manera asíncrona.

### VehiculoBDContext

- **VehiculosDbContext.cs**: Contexto de la base de datos para la gestión de vehículos, ventas y compradores. Incluye DbSet para cada modelo y la configuración del modelo en el método `OnModelCreating`.

### Program.cs

- Configuración del host y los servicios de la aplicación.
  - **AddControllers()**: Añade soporte para controladores.
  - **AddSwaggerGen()**: Añade soporte para Swagger.
  - **AddCors()**: Configura CORS para permitir cualquier origen, método y encabezado.
  - **AddScoped()**: Añade el servicio `ServicesVehiculo` con un ciclo de vida Scoped.
  - **AddDbContext()**: Configura el contexto de la base de datos para usar SQL Server con opciones de reintento en caso de fallo.

## Versiones Utilizadas

- **C#**: 12.0
- **.NET**: 8
- **Entity Framework Core**: Última versión compatible con .NET 8

## Repositorio de Git

El repositorio de Git para la documentación se encuentra en la siguiente URL: https://github.com/kevega3/Back-sincoayf.git
