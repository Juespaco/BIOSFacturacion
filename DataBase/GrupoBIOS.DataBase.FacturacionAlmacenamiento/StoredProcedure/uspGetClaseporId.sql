-- =============================================
-- Author:		Oscar Donato Garcia
-- Create date (dd-MM-yyyy): 12-04-2025
-- Description:	Se encarga de devolver una Clase por medio del IDClase.
-- exec uspGetClaseporId 1
-- =============================================
CREATE PROCEDURE [dbo].[uspGetClaseporId] 
@IDClase int
AS
BEGIN
	SELECT IDClase
	,Nombre
	,Descripcion
	,Estado
	,FechadeCreacion
	,CreadoPor FROM Clase
	WHERE IDClase=@IDClase
END