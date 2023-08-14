using calculator;

/**
 * Creates API for the calculator. Runs on localhost:5050, and listens to localhost:5051/Calculator
 */
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(
                "http://localhost:63342",
                "https://localhost:63342",
                "http://localhost:5051",
                "https://localhost:5051")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Calculator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run("http://localhost:5050");
