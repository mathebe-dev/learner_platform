var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add JSON serializer settings
builder.Services.AddControllersWithViews().AddNewtonsoftJson();

var app = builder.Build();

// Enable CORS
app.UseCors(x => x
    .WithOrigins("http://localhost:4200/")
    .AllowAnyHeader()
    .AllowAnyMethod()
);

// Enable Swagger for all environments
app.UseSwagger();
app.UseSwaggerUI();

// Authorization middleware
app.UseAuthorization();

app.MapControllers();

// Redirect root URL to Swagger UI
app.MapGet("/", () => Results.Redirect("/swagger"));


app.Run();
