using ExploreTheProgramCsFile;
using ExploreTheProgramCsFile.NewFolder;
using ExploreTheProgramCsFile.Scoped;
using ExploreTheProgramCsFile.Singleton;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Services Life cycle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddCustomServices();

builder.Services.AddScoped<IUserSessionService, UserSessionService>();
//builder.Services.AddSingleton<IUserSessionService, UserSessionService>();
//builder.Services.AddTransient<IUserSessionService, UserSessionService>();
var app = builder.Build();


// Middleware to log ScopedService GUID
app.Use(async (context, next) =>
{
    var scopedService = context.RequestServices.GetService<IScopedService>();
    var transientService = context.RequestServices.GetService<ITransientService>();
    var singletonService = context.RequestServices.GetService<ISingletonService>();

    var scopedGuid = scopedService?.GetOperationId() ?? Guid.Empty;
    var transientGuid = transientService?.GetOperationId() ?? Guid.Empty;
    var singletonGuid = singletonService?.GetOperationId() ?? Guid.Empty;

    // Log each GUID on a separate line
    Console.WriteLine($"[Request: {context.Request.Method} {context.Request.Path}]");
    Console.WriteLine($"- Scoped Service GUID: {scopedGuid}");
    Console.WriteLine($"- Transient Service GUID: {transientGuid}");
    Console.WriteLine($"- Singleton Service GUID: {singletonGuid}");

    await next();
});
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
