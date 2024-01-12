using Grpc.Net.Client;

namespace KaspadRpc.Clients;

public class KaspadClient : RPC.RPCClient, IDisposable
{
    public RPC.RPCClient Client { get; private set; }
    
    private GrpcChannel channel;
    
    public KaspadClient(string url = "http://localhost:16110")  
    {
        channel = GrpcChannel.ForAddress(url);
        Client = new RPC.RPCClient(channel);
    }

    public void Dispose()
    {
        channel.Dispose();
    }
}
