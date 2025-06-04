CREATE TYPE ExcepcionType AS TABLE
(
    IdExcepcion INT,
    IdCompania INT,
    Planta VARCHAR(255),
    Nit VARCHAR(50),
    NombreCliente VARCHAR(255),
    Estado BIT,
    CreadoPor VARCHAR(100)
);
