using Grpc.Core;
using Protos.Product;

namespace PCommerce.API.RpcServices;

public class ProductRpcService : Product.ProductBase
{
    public override Task<ProductResponse> Test(ProductRequest request, ServerCallContext context)
    {
        return Task.FromResult(new ProductResponse
        {
            Test = request.Test
        });
    }
}