using Mango.GatewaySolution.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.AddAppAuthetication();
builder.Configuration.AddJsonFile("ocelot.json",optional:false,reloadOnChange:true);
builder.Services.AddOcelot();
var app = builder.Build();


app.MapGet("/", () => "Hello World!");
app.UseOcelot().GetAwaiter().GetResult();


app.Run();
