namespace Directo.Wari.Infrastructure.Persistence.Constants
{
    public static class SPName
    {
        public static class ServicioAuthorization
        {
            //TODO: API_WEB_LISTAR_SERVICIOS_WARI_2_0_X4 es temporal luego debe trasladar la logica de paginacion a API_WEB_LISTAR_SERVICIOS_WARI_X4 
            public static string LISTAR_SERVICIOS_WARI = "API_WEB_LISTAR_SERVICIOS_WARI_2_0_X4";
            public static string LISTAR_SERVICIOS_FILTRO_WARI = "API_WEB_LISTAR_SERVICIOS_FILTRO_WARI_X1";
            public static string OBTENER_SERVICIOS_WARI = "API_WEB_OBTENER_SERVICIO_WARI_X9";
            public static string ServicioByCliente = "X22_ServicioByCliente";
        }

        public static class GenericaAuthorization
        {
            public static string GENERICA_GET_TIPO_PAGO_EMPRESA_CLIENTE = "API_WEB_GET_TIPO_PAGO_EMPRESA_CLIENTE_INTEGRATION_X2";
            public static string GENERICA_GET_TIPO_SERVICIO = "API_WEB_GET_TIPO_SERVICIO_INTEGRATION_X3";
            public static string GENERICA_GET_ALL_ESTADO = "API_WEB_GET_GENERICA_ID_ALL_ESTADO_INTEGRATION_X1";
            public static string GENERICA_GET_ID_ALL = "API_WEB_GET_GENERICA_ID_ALL_INTEGRATION_X1";
        }

        public static class Cliente
        {
            public static string CLIENTE_ID = "API_WEB_GET_CLIENTE_ID_INTEGRATION_X12";
            public static string RUTINA_CLIENTE_WEB_WARI = "EX4_RutinaByIdCliente";
        }

        public static class ClienteAuthorization
        {
            public static string CLIENTES_TELEFONO = "API_WEB_GET_CLIENTES_BY_TELEFONO_X1";
            public static string CLIENTE_EMPRESA_QUERY = "API_WEB_GET_CLIENTES_EMPRESA_QUERY_X3";
            public static string GET_CONFIGURACION_PREDET_COMPROBANTE_CLIENTE = "API_WEB_GET_CONF_PRED_COMPROBANTE_CLIENTE_X1";
        }

        public static class EmpresaAuthorization
        {
            public static string EMPRESA_ALL = "API_WEB_GET_EMPRESA_ALL_INTEGRATION_X2";
            public static string EMPRESA_ALL_ID_ROL = "API_WEB_GET_EMPRESA_ALL_ID_ROL_INTEGRATION_X2";
            public static string EMPRESA_ID = "API_WEB_GET_EMPRESA_ID_INTEGRATION_X1";
        }

        public static class CentroCostoAuthorization
        {
            public static string CENTROCOSTO_EMPRESA = "API_WEB_GET_CENTROCOSTO_EMPRESA_INTEGRATION_X2";
        }

        public static class ParametroAuthorization
        {
            public static string PARAMETRO_GET_PARAMETRO_ID = "API_WEB_GET_PARAMETRO_ID_INTEGRATION_X1";
        }

        public static class Servicio
        {
            public static string AUDITORIA_SERVICIOS_WEB_WARI = "AUDITORIA_SERVICIOS_WEB_WARI";
        }

        public static class Promocion
        {
            public static string API_WEB_WARI_PROMOCIONES_POR_CLIENTE = "promocionprueba3";
        }
    }
}
