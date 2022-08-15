using Microsoft.EntityFrameworkCore;
using DropBoxApp.Models;

/*string path = Directory.GetCurrentDirectory();
Console.WriteLine("The current directory is {0}", path);
path = (Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\FilesDB.db"));
Console.WriteLine("The current directory is {0}", path);*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<FileContext>(opt => opt.UseInMemoryDatabase("FileList"));
builder.Services.AddDbContext<FileContext>(opt => opt.UseSqlite("Data Source="+
          Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\FilesDB.db")));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "DropBoxApi", Version = "v1" });
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DropBoxApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
