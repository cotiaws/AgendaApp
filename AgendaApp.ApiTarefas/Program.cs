using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; }); //endpoints em caixa-baixa

builder.Services.AddEndpointsApiExplorer(); //swagger
builder.Services.AddSwaggerGen(); //swagger

//Cors
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger(); //swagger
app.UseSwaggerUI(); //swagger

app.MapScalarApiReference(options => { options.WithTheme(ScalarTheme.Saturn); }); //scalar

app.UseCors("AllowAll"); //Cors

app.UseAuthorization();
app.MapControllers();
app.Run();
