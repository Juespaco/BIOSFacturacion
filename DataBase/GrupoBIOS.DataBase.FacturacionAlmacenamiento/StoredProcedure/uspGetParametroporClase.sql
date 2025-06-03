-- =============================================
-- Author:		Oscar Donato Garcia
-- Create date (dd-MM-yyyy): 07-04-2025
-- Description:	Se encarga de devolver todos los Parametros de una clase predeterminada.
-- exec uspGetParametroporClase 1
-- =============================================
CREATE PROCEDURE [dbo].[uspGetParametroporClase] 
@IDClase int
AS
BEGIN
	SELECT IDParametro
	,IDClase
	,Nombre
	,Descripcion
	,Estado
	,FechadeCreacion
	,CreadoPor FROM Parametro
	WHERE IDClase=@IDClase
END