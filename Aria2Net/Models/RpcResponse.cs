namespace Aria2Net.Models
{
    public class RpcResponse : RpcResponse<string> { }

    public class RpcResponse<T>
    {
        public string Id { get; set; }
        public string Jsonrpc { get; set; }
        public T Result { get; set; }
        public RpcError Error { get; set; }
    }

    public class RpcError
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
