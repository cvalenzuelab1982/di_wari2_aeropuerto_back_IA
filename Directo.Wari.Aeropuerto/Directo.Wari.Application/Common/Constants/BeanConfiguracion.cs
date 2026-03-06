namespace Directo.Wari.Application.Common.Constants
{
    /// <summary>
    /// Variable constantes Email_Contraseña y Email_Correo no son considerados como estaticaS
    /// </summary>
    public static class BeanConfiguracion
    {
        // Códigos de respuesta API
        public const int HTTP_OK_MSG = 1;
        public const int HTTP_OK_NOMSG = 2;
        public const int HTTP_ALGUN_ERROR = 0;
        public const int HTTP_ERROR_MSG = -1;
        public const int HTTP_ERROR_NOMSG = -2;

        public const string OK_MSG = "La petición se ejecutó correctamente";

        // Tipos de vuelo
        public const int VUELO_TIPO_NACIONAL = 1;
        public const int VUELO_TIPO_INTERNACIONAL = 2;

        public const int VUELO_ESTADO_SALIDA = 1;
        public const int VUELO_ESTADO_LLEGADA = 2;

        // Tipos de presupuesto
        public const int PRESUPUESTO_ENTERO = 1;
        public const int PRESUPUESTO_PORCENTAJE = 2;

        // Tipos de pago
        public const int VALE = 1;
        public const int EFECTIVO = 2;
        public const int VALE_ELECTRONICO = 6;
        public const int TARJETA = 7;

        // Tipos de servicio
        public const int POR_TIEMPO = 5;
    }
}
