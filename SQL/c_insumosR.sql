SELECT
    codigoFR AS formulaR_id,
    codigo AS insumo_id,
    porcentaje,
    fecha_creacion,
    fecha_creacion AS fecha_modificacion,
    usuario AS creador_id,
    usuario AS modificador_id
FROM
    InsumosR;