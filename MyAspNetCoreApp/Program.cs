var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


app.MapGet("/", () => "Hello World!");

app.Run();
