using Protos.Product;

namespace SomeApp;

public class ProductService
{
    private readonly Product.ProductClient _productClient;

    public ProductService(Product.ProductClient productClient)
    {
        _productClient = productClient;
    }

    public async Task<ProductResponse> TestCallAsync()
    {
        var request = new ProductRequest
        {
            Test = "TestMessage"
        };
        
        return await _productClient.TestAsync(request, cancellationToken: CancellationToken.None);
    }
}