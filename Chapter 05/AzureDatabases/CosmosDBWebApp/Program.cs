using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

SocketsHttpHandler socketsHttpHandler = new SocketsHttpHandler();
// Customize this value based on desired DNS refresh timer
socketsHttpHandler.PooledConnectionLifetime = TimeSpan.FromMinutes(5);
// Registering the Singleton SocketsHttpHandler lets you reuse it across any HttpClient in your application
builder.Services.AddSingleton<SocketsHttpHandler>(socketsHttpHandler);

// Use a Singleton instance of the CosmosClient
builder.Services.AddSingleton<CosmosClient>(serviceProvider =>
{
    SocketsHttpHandler socketsHttpHandler = serviceProvider.GetRequiredService<SocketsHttpHandler>();
    CosmosClientOptions cosmosClientOptions = new CosmosClientOptions()
    {
        HttpClientFactory = () => new HttpClient(socketsHttpHandler, disposeHandler: false)
    };

    return new CosmosClient("https://thiagocosmosdb.documents.azure.com:443/", "tBXgs21B8293MdNZZefy8BCt4QaPrLsLhvxecyGDh61HpoUQUSb98Kk5eCfc2I2mOfGkagZgP0MHACDb1rPeYQ==", cosmosClientOptions) ;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

