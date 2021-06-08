using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GetJSON
{
    //データクラス
    class JSON
    {
        [JsonPropertyName("word")]
        public List<string> Word { get; set; }
    }
}
