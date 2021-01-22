# Proyecto Prueba Tecnica legis

API Rest C# de la prueba tecnica

## Tecnologias implementadas

- C#
- Visual Studio 2019
- SqlServer

## Ejecucion del programa

Los archivos para el Back-End de la prueba estan desarrollados en Visual Studio 2019. Y los Scripts de la base de datos estan en una carpeta dentro del proyecto llamada Scripts 

### Base de Datos
- Paso 1: Ejecutar el script `Creacion_DB.sql`
- Paso 2: (Opcional) Ejecutar script de la vista `V_Lista_Candidatos.sql` ya esta preparada la consulta para que traiga la lista de candidatos y sus postulaciones
- Paso 3: (Opcional) Ejecutar script de la vista `V_Votaciones.sql` esta consulta trae en cierta manera el requerimiento del reporte de los resultados de las votaciones

### Back-End
- Paso 1: Instalar Visual Studio 2019
- paso 2: Desacargar los paquetes de web
- Clonar repositorio y ejecutar

## Solucion de Problemas
Puede que el API no funcione, y puede ser por la cadena de conexion, en ese caso hay que modificar el json del archivo `appsetting.json`

