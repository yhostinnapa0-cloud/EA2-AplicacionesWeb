USE EcoStoreDB;
GO

CREATE PROCEDURE spListarProductos
AS
BEGIN
    SELECT
        p.IdProducto,
        p.Nombre,
        p.Descripcion,
        p.Precio,
        p.Stock,
        p.IdCategoria,
        c.Nombre AS Categoria
    FROM Productos p
    INNER JOIN Categorias c
        ON p.IdCategoria = c.IdCategoria
    ORDER BY p.IdProducto;
END;
GO

CREATE PROCEDURE spInsertarProducto
    @Nombre NVARCHAR(150),
    @Descripcion NVARCHAR(500),
    @Precio DECIMAL(10,2),
    @Stock INT,
    @IdCategoria INT
AS
BEGIN
    INSERT INTO Productos
    (
        Nombre,
        Descripcion,
        Precio,
        Stock,
        IdCategoria
    )
    VALUES
    (
        @Nombre,
        @Descripcion,
        @Precio,
        @Stock,
        @IdCategoria
    );
END;
GO

CREATE PROCEDURE spEditarProducto
    @IdProducto INT,
    @Nombre NVARCHAR(150),
    @Descripcion NVARCHAR(500),
    @Precio DECIMAL(10,2),
    @Stock INT,
    @IdCategoria INT
AS
BEGIN
    UPDATE Productos
    SET
        Nombre = @Nombre,
        Descripcion = @Descripcion,
        Precio = @Precio,
        Stock = @Stock,
        IdCategoria = @IdCategoria
    WHERE IdProducto = @IdProducto;
END;
GO

CREATE PROCEDURE spEliminarProducto
    @IdProducto INT
AS
BEGIN
    DELETE FROM Productos
    WHERE IdProducto = @IdProducto;
END;
GO

EXEC spListarProductos;
EXEC spInsertarProducto
    @Nombre = 'Esponja ecológica',
    @Descripcion = 'Esponja reutilizable para limpieza del hogar',
    @Precio = 8.90,
    @Stock = 20,
    @IdCategoria = 1;
    EXEC spEditarProducto
    @IdProducto = 1,
    @Nombre = 'Botella reutilizable premium',
    @Descripcion = 'Botella reutilizable de acero inoxidable mejorada',
    @Precio = 39.90,
    @Stock = 25,
    @IdCategoria = 3;
    EXEC spEliminarProducto
    @IdProducto = 6;