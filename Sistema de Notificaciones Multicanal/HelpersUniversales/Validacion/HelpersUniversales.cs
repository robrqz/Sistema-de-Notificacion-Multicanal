using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Multicanal.HelpersUniversales.Validacion
{
    public static class HelpersUniversales
    {
        public static (bool isValid, string MessageError) ValidateTextWithoutNumbers(string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(nombreCampo))
                return (false, $"No puede estar vacío.");

            if (nombreCampo.Any(char.IsDigit))
                return (false, $"No debe contener números.");

            return (true, string.Empty);
        }
    }
}
