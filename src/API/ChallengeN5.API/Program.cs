var builder = WebApplication.CreateBuilder(args);
{

    builder.AddWebApplication();

    builder.Services
        .AddServicesApi(builder.Configuration)
        .AddServicesApplication()
        .AddServicesCrossCutting()
        .AddServicesInfrastructurePersistence(builder.Configuration);
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.AddGlobalErrorHandler();

    app.Run();
}