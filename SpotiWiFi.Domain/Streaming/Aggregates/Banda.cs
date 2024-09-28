using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpotiWiFi.Domain.Streaming.Aggregates
{
    public class Banda
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("nome")]
        public String Nome { get; set; }
        
        [JsonProperty("descricao")]
        public String Descricao { get; set; }
        
        [JsonProperty("backdrop")]
        public String Backdrop { get; set; }
        
        [JsonProperty("albums")]
        public IList<Album> Albums { get; set; } = new List<Album>();

        [JsonProperty("bandaKey")]
        public String BandaKey = "banda-partition";

        public void AdicionarAlbum(Album album)
        {
            Albums.Add(album);
        }
    }
}
