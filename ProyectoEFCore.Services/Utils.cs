using Microsoft.EntityFrameworkCore;

namespace ProyectoEFCore.Services;

public static class Utils
{
    public static string GetFriendlyMessage(DbUpdateException exception)
    {
        var result = string.Empty;
        if ((exception.InnerException != null) && exception.InnerException.Message.Contains("duplicate key"))
        {
            result = "Se intentó insertar un valor duplicado";
        }

        return result;
    }
}