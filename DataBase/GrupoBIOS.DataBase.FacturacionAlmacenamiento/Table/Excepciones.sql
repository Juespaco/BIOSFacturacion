CREATE TABLE Excepciones (
    IdExcepcion INT IDENTITY(1,1) PRIMARY KEY,
    IdCompania INT NOT NULL, 
    Planta VARCHAR(255) NOT NULL,
    Nit VARCHAR(50)  NOT NULL,
    NombreCliente VARCHAR(255) NOT NULL,
    Estado BIT NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    CreadoPor VARCHAR(100) NOT NULL,

    CONSTRAINT FK_Excepciones_Compania FOREIGN KEY (IdCompania)
        REFERENCES Compania(IDCompania)
);
