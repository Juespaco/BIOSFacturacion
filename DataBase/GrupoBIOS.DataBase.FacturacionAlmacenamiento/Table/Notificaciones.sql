CREATE TABLE Notificaciones (
    IdNotificacion INT IDENTITY(1,1) PRIMARY KEY,
	IdCompania INT NOT NULL,  
    Puerto INT NOT NULL,
    SSL BIT NOT NULL,
    Host VARCHAR(255) NOT NULL,
    EmailRemitente VARCHAR(255) NOT NULL,
    NombreRemitente VARCHAR(255) NOT NULL,
    UsuarioEmail VARCHAR(255) NOT NULL,
    ContrasenaEmail VARCHAR(255) NOT NULL,
    Estado BIT NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    CreadoPor VARCHAR(100) NOT NULL,
   
    CONSTRAINT FK_Notificaciones_Compania FOREIGN KEY (IdCompania)
        REFERENCES Compania(IDCompania)
);
