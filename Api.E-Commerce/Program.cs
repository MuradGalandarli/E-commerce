﻿using Business.Commerce.Abstract;
using Business.Commerce.AbstractCostumer;
using Business.Commerce.Concret;
using Business.Commerce.ConcretCostumer;
using DataAccess.Commerce;
using DataAccess.Commerce.Abstract;
using DataAccess.Commerce.AbstractCostumer;
using DataAccess.Commerce.Concrete;
using DataAccess.Commerce.ConcreteCostumer;
using DataTransferObject.DtoProfile;
using DataTransferObject.EntityDto;
using EntityCommerce;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.X509.Qualified;
using Serilog;
using Shared.Commerce;
using StackExchange.Redis;
using Stripe;
using System.Text;
using static Business.Commerce.ConcretCostumer.PaymentManager;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase")));


builder.Services.AddScoped<IPaymentService,PaymentService>();
builder.Services.AddScoped<IStripeRepository,StripeRepository>();
builder.Services.AddScoped<ICostumerCommentService,CostumerCommentManager>();
builder.Services.AddScoped<ICostumerCommentDal, EFCommentRepositoryCostumer > ();
builder.Services.AddScoped<ICostumerCategoryDal, EFCategoryRepositoryCostumer>();
builder.Services.AddScoped<ICostumerGoodsDal,EFGoodsRepositoryCostumer>();
builder.Services.AddScoped<ICostumerSellerDal, EFSellerRepositoryCostumer>();

builder.Services.AddScoped<ICostumerCategorySevice,CostumerCategoryManager>();
builder.Services.AddScoped<ICostumerGoodsService,CostumerGoodsManager>();
builder.Services.AddScoped<ICostumerOrderService, CostumerOrderManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<ICostumerSellerService, CostumerSellerManager>();
builder.Services.AddScoped<ICostumerUserService, CostumerUserManager>();
builder.Services.AddScoped<IFavoriteGoodsDal, EFFavoriteGoodsRepositoryCostumer>();
builder.Services.AddScoped<ICostumerFavoriteGoodsService, CostumeFavoriteGoodsManager>();
builder.Services.AddScoped<ICostumerAnswerDal, EFAnswerRepositoryCostumer>();
builder.Services.AddScoped<ICostumerAnswerService, CostumerAnswerManager>();
builder.Services.AddScoped<ICostumerQuestionDal, EFQuestionRepositoryCostumer>();
builder.Services.AddScoped<ICostumerQuestionService, CostumerQuestionManager>();

builder.Services.AddScoped<ICampaignService, CampaignManager>();
builder.Services.AddScoped<ICampaignDal, EFCampaignRepository>();
builder.Services.AddScoped<IGoodsDal,EfGoodsRepository>();
builder.Services.AddScoped<IGoodsService, GoodsManager>();
builder.Services.AddScoped<IOrderService,OrderManager>();
builder.Services.AddScoped<ICostumerOrderDal,EFOrderRepositoryCostumer>();
builder.Services.AddScoped<IOrderDal,EFOrderRepository>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<ICostumerUserDal, EFUserRepositoryCostumer>();
builder.Services.AddScoped<ISellerDal, EFSellerRepository>();
builder.Services.AddScoped<ISellerService, SellerManager>();
builder.Services.AddScoped<ICouponDal, EFCouponRepository>();
builder.Services.AddScoped<ICouponService, CouponManager>();

builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<IEmailService, SmtpEmailService>();
builder.Services.AddScoped<IEmailDal, EfEmailRepository>();
builder.Services.AddScoped<IAuthService, AuthManager>();
builder.Services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped<IOtherCampaignDal, EFOtherCampaignReposiyory>();
builder.Services.AddScoped<IOtherCampaignService, OtherCapaignManager>();
builder.Services.AddScoped<ICategoryDal, EFCategoryRepository>();
builder.Services.AddScoped<ApplicationContext>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IImageService, ImageManager>();
builder.Services.AddScoped<IImageDal, EFImageRepository>();
builder.Services.AddScoped<ICostumerSellerService , CostumerSellerManager >();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

builder.Services.AddScoped<CostumerRedisManager<SellerDto>>();






builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationContext>()
        .AddDefaultTokenProviders();

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .WriteTo.File(@"D:\File\Log\Log.txt", rollingInterval: RollingInterval.Day).MinimumLevel.Information()
    .CreateLogger();
    builder.Host.UseSerilog();


builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));
builder.Services.AddScoped<IUrlHelper>(provider =>
{
    var actionContext = provider.GetRequiredService<IActionContextAccessor>().ActionContext;
    return new UrlHelper(actionContext);
});

var redisConnectionString = Configuration.GetSection("ConnectionStringRedis").GetValue<string>("Redis");
var redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);

builder.Services.AddSingleton<IConnectionMultiplexer>(redisConnection);
builder.Services.AddScoped(typeof(ICostumerGenericRedis<>), typeof(CostumerRedisManager<>));


builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(DtoProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
