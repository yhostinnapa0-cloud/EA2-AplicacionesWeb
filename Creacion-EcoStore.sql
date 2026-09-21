CREATE DATABASE EcoStoreDB;
GO

USE EcoStoreDB;
GO

-- =============================================
-- TABLA: Usuarios
-- =============================================
CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Rol NVARCHAR(30) NOT NULL
);
GO

-- =============================================
-- TABLA: Categorias
-- =============================================
CREATE TABLE Categorias (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);
GO

-- =============================================
-- TABLA: Productos
-- =============================================
CREATE TABLE Productos (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Descripcion NVARCHAR(500),
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    IdCategoria INT NOT NULL,

    CONSTRAINT FK_Productos_Categorias
        FOREIGN KEY (IdCategoria)
        REFERENCES Categorias(IdCategoria)
);
GO

-- =============================================
-- TABLA: Pedidos
-- =============================================
CREATE TABLE Pedidos (
    IdPedido INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    IdUsuario INT NOT NULL,
    Estado NVARCHAR(30) NOT NULL,
    Total DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_Pedidos_Usuarios
        FOREIGN KEY (IdUsuario)
        REFERENCES Usuarios(IdUsuario)
);
GO

-- =============================================
-- TABLA: DetallePedido
-- =============================================
CREATE TABLE DetallePedido (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdPedido INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_DetallePedido_Pedidos
        FOREIGN KEY (IdPedido)
        REFERENCES Pedidos(IdPedido),

    CONSTRAINT FK_DetallePedido_Productos
        FOREIGN KEY (IdProducto)
        REFERENCES Productos(IdProducto)
);
GO

-- USUARIOS
INSERT INTO Usuarios (Nombre, Email, Password, Rol)
VALUES
('Administrador EcoStore', 'admin@ecostore.com', '123456', 'Administrador'),
('Carlos Cliente', 'carlos@gmail.com', '123456', 'Cliente'),
('Ana Ventas', 'ana@ecostore.com', '123456', 'Ventas');
GO

-- CATEGORIAS
INSERT INTO Categorias (Nombre)
VALUES
('Hogar sostenible'),
('Cuidado personal'),
('Accesorios reutilizables'),
('Higiene ecológica');
GO

-- PRODUCTOS
INSERT INTO Productos
    (Nombre, Descripcion, Precio, Stock, IdCategoria)
VALUES
('Botella reutilizable',
 'Botella reutilizable de acero inoxidable',
 35.90, 20, 3),

('Cepillo de bambú',
 'Cepillo dental fabricado con bambú',
 12.50, 30, 2),

('Bolsas ecológicas',
 'Pack de bolsas reutilizables para compras',
 18.90, 15, 3),

('Jabón natural',
 'Jabón artesanal elaborado con ingredientes naturales',
 15.00, 25, 2),

('Set de limpieza ecológica',
 'Productos de limpieza para el hogar',
 45.90, 10, 1);
GO




SELECT * FROM Productos;
SELECT * FROM Usuarios;
SELECT * FROM Categorias;