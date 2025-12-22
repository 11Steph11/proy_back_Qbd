SELECT
    costo,
    cantidad,
    diagnostico,
    aplicacion as zona_aplicacion,
    estado,
    fecha_creacion,
    fecha_creacion as fecha_modificacion,
    usuario as creador_id,
    usuario as modificador_id,
    cuot as pedido_id,
    codigo as producto_id,
    4 as sede_id,
    iden as id
FROM
    Productos_Terminados;