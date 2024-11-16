# Proyecto: N Capas con ASP.NET Core MVC, ADO.NET y MSSQL

## Descripción:
Este proyecto es un ejemplo de una aplicación CRUD (Crear, Leer, Actualizar, Eliminar) desarrollada en ASP.NET Core MVC utilizando una arquitectura en N Capas. La aplicación utiliza ADO.NET para interactuar con una base de datos MSSQL para realizar operaciones CRUD en una tabla de productos.

## Tecnologías Utilizadas:
- ASP.NET Core MVC
- ADO.NET
- MSSQL Server
- .NET 8

## Patrón de Arquitectura:
La aplicación sigue una arquitectura en N Capas, donde se separa la lógica de presentación, lógica de negocio y acceso a datos en diferentes capas para una mejor modularidad y mantenibilidad del código.

## Archivos del Proyecto:
- PresentationLayer/Controllers/ : Controladores de ASP.NET Core MVC
- DataAccess/Order.cs : Modelo de datos de la aplicación
- PresentationLayer/Views/ : Vistas de la aplicación
- DataAccess/OrderData.cs : Clase de acceso a datos y configuración de la base de datos
- BusinessLayer/OrderService.cs : Servicios de aplicación y lógica de negocio

## Instrucciones de Ejecución:
1. Asegúrate de tener instalado .NET 8 y MSSQL Server en tu sistema.
2. Clona este repositorio en tu máquina local.
3. Abre el proyecto en tu entorno de desarrollo preferido.
4. Instala la BD Northwind y ejecuta el script que se encuentra en la carpeta.
5. Actualiza la cadena de conexión en el archivo `appsettings.json` con los detalles de tu servidor de base de datos.
6. Ejecuta el proyecto y navega a la URL para probar la aplicación.
