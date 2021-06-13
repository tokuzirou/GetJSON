using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GetJSON
{
    //ラップデータベース
    public class JSON
    {
        //[注意]Dictionaryなので、同じキーは存続できない
        [JsonPropertyName("words")]
        public Dictionary<string, JSONDATA> Words { get; set; }

        internal JSON()
        {
            this.Words = new Dictionary<string, JSONDATA>();
        }
    }
}
