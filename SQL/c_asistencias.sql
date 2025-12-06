SELECT
    tipo,
    hora_asignada,
    hora_marcada,
    tiempo_atraso,
    tiempo_extra,
    observacion,
    fecha_creacion AS fecha_modificacion,
    fecha_creacion,
    Switch(
        UCase([Usuario])='ADMIN', 1,
        UCase([Usuario])='FJBM', 1,
        UCase([Usuario])='DMAB', 2,
        UCase([Usuario])='RVG', 3,
        UCase([Usuario])='MJRV', 4,
        UCase([Usuario])='GABJ', 5,
        UCase([Usuario])='LMV', 6,
        UCase([Usuario])='LTP', 7,
        UCase([Usuario])='NUQ', 8,
        UCase([Usuario])='ECY', 9,
        UCase([Usuario])='ECE', 9,
        UCase([Usuario])='AVG', 10
    ) AS creador_id,

    creador_id AS modificador_id,

    1 AS sede_id

FROM Asistencia;
