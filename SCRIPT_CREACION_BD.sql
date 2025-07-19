CREATE DATABASE Prueba;
GO
-----------------------------------------------------
USE Prueba;
GO
------------------------------------------------------

CREATE TABLE Categoria (
    IdCategoria INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);
GO

-----------------------------------------------------
CREATE TABLE Producto (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100) NULL,
    IdCategoria INT NOT NULL, FOREIGN KEY (IdCategoria) REFERENCES categoria(IdCategoria)
);
GO

INSERT INTO Categoria (Nombre) 
VALUES 
('Tarjetas'),
('Pr�stamos'),
('Cuenta de Ahorro');

-- Insertar datos en la tabla producto
INSERT INTO producto (Nombre, Descripcion, IdCategoria) 
VALUES 
('Tarjetas de Cr�dito', 'El beneficio de nuestras tarjetas premium', 1),   
('Pr�stamos personales', 'El pr�stamo para tu negocio', 2),              
('Tarjetas de D�bito', 'Tarjetas Cl�sicas, Platinum, etc', 1),          
('Pr�stamos veh�culos', 'Tu auto so�ado a tu alcance', 2),         
('Cuenta Digital', 'Tu cuenta digital en minutos', 3),              
('Tarifario', 'Tarifario oficial', 3); 

------------SP --------------------------------------------------------------
CREATE PROCEDURE [dbo].[sp_ActualizarProducto]
    @IdProducto INT,
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(100) = NULL,
    @IdCategoria INT
AS
BEGIN
    UPDATE Producto
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        IdCategoria = @IdCategoria
    WHERE IdProducto = @IdProducto
END

-------------------
CREATE PROCEDURE [dbo].[sp_InsertarProducto]
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(100) = NULL,
    @IdCategoria INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Producto (Nombre, Descripcion, IdCategoria)
    VALUES (@Nombre, @Descripcion, @IdCategoria);
END