-- =============================================
-- Author:		Oscar Donato Garcia
-- Create date (dd-MM-yyyy): 12-04-2025
-- Description:	Se encarga de devolver un Parametros por medio del IDParametro.
-- exec uspGetParametroporId 1
-- =============================================
CREATE PROCEDURE [dbo].[uspGetParametroporId] 
@IDParametro int
AS
BEGIN
	SELECT IDParametro
	,IDClase
	,Nombre
	,Descripcion
	,Estado
	,FechadeCreacion
	,CreadoPor FROM Parametro
	WHERE IDParametro=@IDParametro
END