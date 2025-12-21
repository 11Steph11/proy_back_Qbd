SELECT
    apoderado,
    DniA AS dni_apoderado,
    fecha_creacion,
    fecha_creacion AS fecha_modificacion,
    Usuario AS creador_id,
    Usuario AS modificador_id,
    NULL AS persona_id,
    condicion_fecha
FROM
    Pacientes;