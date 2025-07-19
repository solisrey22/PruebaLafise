# PruebaLafise

# Proyecto CRUD Productos - .NET Core 8 y ASP.NET 7

## Descripción

Este proyecto es un sistema CRUD para la gestión de productos, desarrollado con un backend en **.NET Core 8 Web API** y un frontend en **ASP.NET 7 MVC**. Se utiliza **Entity Framework Core (EF Core)** como ORM para interactuar con la base de datos.

El objetivo principal es practicar dos formas distintas de realizar operaciones en la base de datos:

- Los métodos **Crear** y **Actualizar** utilizan **Stored Procedures (SP)** en SQL Server.
- Los métodos **Listar**, **Obtener** y **Eliminar** se implementan utilizando directamente el **DbContext de EF Core**.

**Nota importante:**  
En este proyecto **no se utilizan migraciones de EF Core (migrations)** para gestionar la base de datos. Toda la estructura de tablas y los stored procedures se crean y mantienen directamente en SQL Server, fuera del contexto de EF. Esto permite un control manual y directo sobre el esquema de la base.

## Tecnologías usadas

- Backend:
  - .NET Core 8 Web API
  - Entity Framework Core 8 (sin migraciones)
  - SQL Server con Stored Procedures para ciertos métodos
- Frontend:
  - ASP.NET 7 MVC
  - Bootstrap 5 para estilos y modales
  - jQuery 3.6 para llamadas AJAX y manipulación DOM
- Base de datos:
  - SQL Server (con tablas y stored procedures)

## Funcionalidades

- Listar productos
- Ver detalles de un producto
- Crear nuevo producto (usando Stored Procedure)
- Editar producto existente (usando Stored Procedure)
- Eliminar producto (usando EF Core DbContext)
- Filtrar productos en frontend por nombre

## Estructura del proyecto

- **Backend** (ApiProductos o similar):
  - Controladores Web API que exponen los endpoints REST.
  - Uso de EF Core para consultas directas.
  - Invocación a stored procedures para creación y actualización.
  - **Sin uso de migraciones EF Core.**
- **Frontend** (`MvcProductos` o similar):
  - Proyecto ASP.NET MVC con vistas Razor.
  - Uso de Bootstrap para UI.
  - Uso de jQuery AJAX para consumir las APIs REST del backend.

## Requisitos para correr el proyecto

- Visual Studio 2022 o superior
- .NET SDK 8.0 para backend y .NET 7.0 para frontend instalados
- SQL Server con la base de datos y los stored procedures creados manualmente
- Configurar cadena de conexión en `appsettings.json` del backend

## Cómo ejecutar

1. Clona el repositorio
2. Configura la cadena de conexión en el backend en appsettings.json
3. Asegúrate que la base de datos y los stored procedures estén creados y disponibles (sin usar migraciones)
4. Ejecuta primero el proyecto backend (ApiProductos)
5. Ejecuta el proyecto frontend (MvcProductos)
6. Abre el navegador y navega a la URL del frontend (por defecto suele ser https://localhost:xxxx)
   
## Notas técnicas
- El backend usa DbContext para las operaciones de lectura y eliminación, lo que aprovecha el poder de EF Core para consultas simples y rápidas.
- Para las operaciones de creación y actualización, se usan stored procedures para validar y manejar la lógica en la base de datos, permitiendo un control más  granular y optimización.
- El proyecto no utiliza migraciones de EF Core, por lo que la estructura de la base de datos se mantiene manualmente en SQL Server.
- El frontend consume la API REST con llamadas AJAX mediante jQuery, actualizando la interfaz sin recargar la página.
- Se utiliza Bootstrap para la gestión de modales y estilos responsivos.
- El filtro de productos por nombre está implementado directamente en el frontend con jQuery.

## Notas importante
  Se añade en el repositorio script de BD para creación de la BD, con sus tablas relacionadas y creación de tablas y sp

## Notas importante
Desarrollador: Reynaldo Antonio Solís Silva
Email: solissilvareynaldo@gmail.com
GitHub: (https://github.com/solisrey22)


