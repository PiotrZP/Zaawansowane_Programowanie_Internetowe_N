using WebStore.Services.Configuration;
using WebStore.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient(typeof(ILogger), typeof(Logger<Program>));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddCoreIdentity(builder.Configuration);
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddDomainServices();
builder.Services.AddSwagger();

builder.Services.AddControllersWithViews()
   .AddNewtonsoftJson(options =>
       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();

app.ConfigurePipeline(app.Environment.IsDevelopment());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
