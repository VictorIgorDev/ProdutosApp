var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy",
    builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();
    if (app.Environment.IsDevelopment())
    {
            app.UseSwagger();
            app.UseSwaggerUI();
    }
app.UseAuthorization();
app.UseCors("DefaultPolicy");
app.MapControllers();
app.Run();