using System;
using System.Text.Json.Serialization;

namespace GetJSON
{
    //本体データベース
    class JSONDATA
    {
        [JsonPropertyName("word")]
        public string Word { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}
