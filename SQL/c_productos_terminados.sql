SELECT
    costo,
    cantidad,
    diagnostico,
    aplicacion AS zona_aplicacion,
    estado,
    fecha_creacion,
    fecha_creacion AS fecha_modificacion,
    usuario AS creador_id,
    usuario AS modificador_id,
    cuot AS pedido_id,
    codigo AS producto_id,
    4 AS sede_id,
    iden AS id
FROM
    Productos_Terminados;