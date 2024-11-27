using lexicon_web_dashboard.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://lexicon-api-argqa9bbcwdefwh4.northeurope-01.azurewebsites.net/")
});

builder.Services.AddScoped<StudentService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
