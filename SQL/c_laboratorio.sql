SELECT
    fecha_emision,
    fecha_vcto,
    elaborado,
    autorizado,
    procedimiento,
    cod_adicional AS cod_term,
    canti_termo,
    aspecto,
    color,
    olor,
    ph,
    fecha_creacion,
    fecha_creacion AS fecha_modificacion,
    usuario AS creador_id,
    usuario AS modificador_id,
    cod_e AS empaque_id,
    registro AS id,
    4 AS sede_id
FROM
    Laboratorio;