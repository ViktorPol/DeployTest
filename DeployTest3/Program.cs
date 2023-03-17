var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (context) =>
{
    var responceData = new {Time = DateTime.Now, Message = "Server is running..."};
    await context.Response.WriteAsJsonAsync(responceData);

});

app.MapGet("/ping", async (context) =>
{
    var responceData = new { Time = DateTime.Now, Message = "pong" };
    await context.Response.WriteAsJsonAsync(responceData); ;
} );


app.Run();
