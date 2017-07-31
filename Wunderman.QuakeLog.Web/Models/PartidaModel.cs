using System.Collections.Generic;

namespace Wunderman.QuakeLog.Web.Models
{
    public class PartidaModel
    {
        public int PartidaId { get; set; }
        public IList<JogadorModel> Jogadores { get; set; }
    }
}