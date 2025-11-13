📘 README — Venta de Aparatos Electrónicos (.NET MAUI + SQLite)

Este proyecto es una aplicación desarrollada en .NET MAUI, que permite gestionar un sistema básico de venta de aparatos electrónicos.
Incluye login, menú principal y cuatro módulos: Inventario, Trabajadores, Clientes y Facturas.

✅ Requisitos

Visual Studio 2022 (17.4 o superior)

SDK .NET 8 o .NET 7

Paquete NuGet:

sqlite-net-pcl

▶️ Cómo ejecutar el proyecto

Abrir la solución en Visual Studio.

Verificar que el paquete sqlite-net-pcl esté instalado.

Seleccionar plataforma (Windows o Android).

Ejecutar la aplicación.

Credenciales de ingreso
Usuario: admin
Contraseña: 1234

📌 Estructura del proyecto

El proyecto contiene:

LoginPage — Validación de usuario contra SQLite.

MainPage — Menú principal.

InventarioPage — CRUD básico de productos.

TrabajadoresPage — CRUD básico de trabajadores.

ClientesPage — CRUD básico de clientes.

FacturasPage — CRUD básico de facturas.

AppDatabase.cs — Creación de tablas y operaciones SQLite.

Models.cs — Modelos: Usuario, InventarioItem, Trabajador, Cliente, Factura.

🗄️ Base de datos

La base de datos SQLite se crea automáticamente al iniciar la aplicación.
Incluye las tablas:

Usuarios

InventarioItem

Trabajador

Cliente

Factura

Usuario por defecto:

admin / 1234

🧭 Navegación

La app usa NavigationPage y navegación clásica con:

Navigation.PushAsync(new Pagina());

✔️ Estado del proyecto

El proyecto está completo y funcional, con todas las páginas operativas y conectadas a la base de datos SQLite.
