using Grpc.Core;
using KaspadRpc;
using KaspadRpc.Clients;

var url = "http://192.168.1.45:16110";

Console.WriteLine("Start gRPC calling to [{0}]...", url);

var kaspadClient = new KaspadClient(url);

using var messageStream = kaspadClient.Client.MessageStream();
var getBalanceRequest = new KaspadRequest
{
    GetBalanceByAddressRequest = new GetBalanceByAddressRequestMessage
    {
        Address = "kaspa:qpdytw6ujmesjxptnntk7sesnrlc5g9w3vtwddah8v3x7sk3mmvqc3xvzy4jt"
    }
};

await messageStream.RequestStream.WriteAsync(getBalanceRequest);
await messageStream.ResponseStream.MoveNext();
var response = messageStream.ResponseStream.Current;

Console.WriteLine("Balance is [{0}]", response.GetBalanceByAddressResponse.Balance);
