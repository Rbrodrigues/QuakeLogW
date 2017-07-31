using System.ComponentModel;

namespace Wunderman.QuakeLog.Core.Domain.Entities
{
    public enum TipoRegistro
    {
        [Description("INITGAME")]
        InitGame = 0,
        [Description("KILL")]
        Kill = 1,
        [Description("CLIENTUSERINFOCHANGED")]
        ClientUserInfoChanged = 2,
        [Description("INVALIDO")]
        Invalido = 3
    }
}
