using webapi;
using webapi.Middlewares;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext>("Data Source=DESKTOP-1VCK87T\\SQLEXPRESS;Initial Catalog=TareasDB;user id=sa;password=123456");
//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
//builder.Services.AddScoped<(p=> new HelloWorldService());
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService());
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareasService, TareasService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();
//app.UseTimerMiddleware();

app.MapControllers();

app.Run();
