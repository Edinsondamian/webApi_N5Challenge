namespace ChallengeN5.Infrastructure.CrossCutting.Constants;

public class ErrorCode
{
    public const string ERROR_CODE_TL9999 = "TL9999";
    public const string ERROR_DESCRIPTION_TL9999 = "Ocurrió un error inesperado. Por favor, contactarse con el soporte técnico.";

    public const string ERROR_CODE_TL0003 = "TL0003";
    public const string ERROR_DESCRIPTION_TL0003 = "Los datos proporcionados no cumplen con los criterios para ser procesado.";

    public const string ERROR_CODE_TL0004 = "TL0004";
    public const string ERROR_DESCRIPTION_TL0004 = "No se encontró el contrato solicitado en la búsqueda.";

    public const string ERROR_CODE_TL0009 = "TL0009";
    public const string ERROR_DESCRIPTION_TL0009 = "Problemas de timeout en el servicio backend.";

    public const string ERROR_CODE_TL0010 = "TL0010";
    public const string ERROR_DESCRIPTION_TL0010 = "No se encontró el recurso solicitado.";

    public const string ERROR_CODE_TL0011 = "TL0011";
    public const string ERROR_DESCRIPTION_TL0011 = "El cliente no está autorizado para realizar esta llamada al servicio.";

    public const string ERROR_CODE_TL0012 = "TL0012";
    public const string ERROR_DESCRIPTION_TL0012 = "El cliente no tiene los permisos necesarios para realizar esta llamada al servicio.";
}
