using Project06_ConfigNotify.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register Configuration as Singleton and Services as Scoped
builder.Services.AddSingleton<Project06_ConfigNotify.Services.NotificationConfig>();
builder.Services.AddScoped<Project06_ConfigNotify.Services.NotificationService>();
builder.Services.AddScoped<Project06_ConfigNotify.Services.ThemeStateManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();