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
        UCase([Usuario])='JMCC', 31,
        UCase([Usuario])='MMAA', 32,
        UCase([Usuario])='MJYM', 33,
    ) AS creador_id,

    creador_id AS modificador_id,

    4 AS sede_id

FROM Asistencia;
