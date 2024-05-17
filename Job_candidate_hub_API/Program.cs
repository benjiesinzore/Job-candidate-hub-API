using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var dbCon = builder.Configuration.GetSection("ConnectionStrings:SQLServerConn").Value;
var insertOrUpdateContactInfo = builder.Configuration.GetSection("StoredProcedures:InsertOrUpdateContactInfo").Value;


var docVersion = builder.Configuration.GetSection("SwaggerDoc:DocVersion").Value;
var apiVersion = builder.Configuration.GetSection("SwaggerDoc:ApiVersion").Value;
var docTitle = builder.Configuration.GetSection("SwaggerDoc:Title").Value;
var docDescription = builder.Configuration.GetSection("SwaggerDoc:Description").Value;
var devName = builder.Configuration.GetSection("SwaggerDoc:Name").Value;
var devEmail = builder.Configuration.GetSection("SwaggerDoc:Email").Value;
var projectUrl = builder.Configuration.GetSection("SwaggerDoc:Url").Value;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

    options.SwaggerDoc(docVersion, new OpenApiInfo
    {
        Version = apiVersion,
        Title = docTitle,
        Description = docDescription,
        Contact = new OpenApiContact
        {
            Name = devName,
            Email = devEmail,
            Url = new Uri(projectUrl),
        },
    });

});


builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();

    loggingBuilder.AddFile(Path.Combine(AppContext.BaseDirectory, "Logs", "candidates_log-{Date}.txt"));
});


ParamsModel.DBConnection = dbCon;
ParamsModel.InsertOrUpdateContactInfo = insertOrUpdateContactInfo;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
