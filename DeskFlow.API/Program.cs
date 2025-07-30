using DeskFlow.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register the ProjectService as a singleton
builder.Services.AddSingleton<IProjectService, ProjectService>();

// Register the TaskService as a singleton
builder.Services.AddSingleton<ITaskService, TaskService>();

// Register the NoteService as a Singleton
builder.Services.AddSingleton<INoteService, NoteService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
