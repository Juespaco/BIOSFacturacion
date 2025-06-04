CREATE PROCEDURE sp_Excepciones_CrearActualizar
    @Excepciones ExcepcionType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    MERGE INTO Excepciones AS Target
    USING @Excepciones AS Source
    ON Target.IdExcepcion = Source.IdExcepcion

    WHEN MATCHED THEN
        UPDATE SET 
            Target.IdCompania = Source.IdCompania,
            Target.Planta = Source.Planta,
            Target.Nit = Source.Nit,
            Target.NombreCliente = Source.NombreCliente,
            Target.Estado = Source.Estado,
            Target.CreadoPor = Source.CreadoPor

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (IdCompania, Planta, Nit, NombreCliente, Estado, CreadoPor)
        VALUES (Source.IdCompania, Source.Planta, Source.Nit, Source.NombreCliente, Source.Estado, Source.CreadoPor);
END
