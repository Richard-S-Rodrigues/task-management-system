using TaskManagementSystem.Server.Data;
using TaskManagementSystem.Server.Services.TaskService;
using TaskManagementSystem.Server.Services.TaskListService;
using TaskManagementSystem.Server.Services.TaskBoardService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDbAccess, DbAccess>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskListService, TaskListService>();
builder.Services.AddScoped<ITaskBoardService, TaskBoardService>();
builder.Services.AddControllers();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true) 
    .AddEnvironmentVariables();

MigrationRunner.RunMigrations(builder.Configuration.GetConnectionString("DefaultConnection")!);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Map("/", async context =>
{
    await context.Response.WriteAsync("Migrations executed successfully.");
});

await app.RunAsync();
