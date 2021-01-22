CREATE VIEW V_Lista_Candidatos AS
SELECT 
	TP.Nombre as Candidatura,
	C.Nombre,
	C.Apellido,
	P.Propuesta
FROM 
	Candidato C 
	INNER JOIN Postulacion P on C.Id = P.fk_Candidato 
	INNER JOIN TipoPropuesta TP on TP.Id = P.fk_TipoPropuesta