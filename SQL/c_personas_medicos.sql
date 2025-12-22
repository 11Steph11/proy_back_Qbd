SELECT
    Datos AS nombreCompleto,
    NULL AS fecha_nacimiento,
    NULL AS dni,
    fecha_creacion,
    fecha_creacion AS fecha_modificacion,
    Usuario AS creador_id,
    Usuario AS modificador_id,
    NULL AS telefono,
    NULL AS direccion
FROM
    Medicos;