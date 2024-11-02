using Autofac;
using Autofac.Extensions.DependencyInjection;
using RollMaster.WebApp;
using RollMaster.WebApp.Routes;
using TruSoft.StdLib;
using TruSoft.StdLib.DependencyInjection.Autofac;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents();
        // .AddInteractiveServerComponents();

        builder.Services.AddHttpContextAccessor();
        // builder.Services.AddDistributedMemoryCache();
        builder.Services.AddAntiforgery();
        // builder.Services.AddTransient<SessionManager>();
        
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(b =>
        {
        	new AutofacBuilder(b)
		        // Backend
		        .WithAssemblyRegistrations(typeof(StdLibModule).Assembly)
		        
		        // Frontend
		        .WithAssemblyRegistrations(typeof(RollMasterWebAppModule).Assembly)
        		.RegisterTypedFactories()
        		;
        });
		        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        // app.UseSession();
        app.UseAntiforgery();

        var routerRegister = app.Services.GetService<RouteRegister>();
        routerRegister!.Register(app);

        app.Run();
    }
}