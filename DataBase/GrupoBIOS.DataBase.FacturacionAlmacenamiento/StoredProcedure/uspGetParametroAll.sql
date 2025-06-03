-- =============================================
-- Author:		Oscar Donato Garcia
-- Create date (dd-MM-yyyy): 29-03-2025
-- Description:	Se encarga de devolver todos los Parametros.
-- exec uspGetParametroAll
-- =============================================
CREATE PROCEDURE [dbo].[uspGetParametroAll]
AS
BEGIN
	SELECT IDParametro
	,IDClase
	,Nombre
	,Descripcion
	,Estado
	,FechadeCreacion
	,CreadoPor FROM Parametro
END