---SE MODIFICO LA TABLA ORDERS EN NORTHWIND-----------------------------------

ALTER TABLE Orders
ADD 
    ConfirmationDate DATETIME NULL,              -- Nueva columna para la fecha de confirmación
    Estado NVARCHAR(20) NOT NULL DEFAULT 'No confirmado',  -- Nueva columna para el estado del pedido, por defecto 'No confirmado'
    Commments NVARCHAR(500) NULL;         --Comentarios
