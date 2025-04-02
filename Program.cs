using App_Store.Api.Data;
using App_Store.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var Connection_String = builder.Configuration.GetConnectionString("AppStore");
builder.Services.AddSqlite<AppsStoreContext>(Connection_String);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll");

app.MapAppEndpoints();

app.MigrateDb();

app.Run();