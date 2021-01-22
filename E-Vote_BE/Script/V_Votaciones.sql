CREATE VIEW V_Votaciones AS
SELECT 
	V.Id as Id_Voto,
	(S.Nombre + ' ' + S.Apellido) as Votante,
	S.Fk_TipoDoc as TipoDoc,
	S.Identificacion,
	TP.Nombre as Postulacion,
	(C.Nombre + ' ' + C.Apellido) as Voto_Para,
	V.Inicio,
	V.Fin
FROM 
	Votacion V
	INNER JOIN Sufragante S ON V.Votante_Id = S.Id
	INNER JOIN TipoPropuesta TP ON V.Propuesta_Id = TP.Id
	INNER JOIN Candidato C ON V.Voto = C.Id