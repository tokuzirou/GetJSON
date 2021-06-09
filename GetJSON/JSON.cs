using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GetJSON
{
    //ラップデータベース
    class JSON
    {
        //[注意]Dictionaryなので、同じキーは存続できない
        [JsonPropertyName("wordsdata")]
        public Dictionary<string, JSONDATA> Words { get; set; }
    }
}
