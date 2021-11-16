using System.Collections.Generic;

namespace Aria2Net.Models
{
    public class RpcRequest
    {
        public string Id { get; set; }
        public string Jsonrpc { get; set; }
        public string Method { get; set; }
        public List<object> Params { get; set; }
    }
}
