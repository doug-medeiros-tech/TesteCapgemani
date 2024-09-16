using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2
{
    public class Campeonato
    {
        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }

        [JsonProperty("data")]
        public List<Jogo>? Jogos { get; set; }

        public Campeonato()
        {
            if (TotalPages == null || TotalPages == 0)
            {
                TotalPages = 1;
            }
        }

    }
}
