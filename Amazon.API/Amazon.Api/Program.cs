using Amazon.Api.Business.Manager;
using Amazon.Api.ConfigureSwagger;
using Amazon.Api.Data;
using Amazon.Api.Data.Validators;
using Amazon.Api.Handlers.Cart;
using Amazon.Api.Handlers.Image;
using Amazon.Api.Handlers.ImageType;
using Amazon.Api.Handlers.Order;
using Amazon.Api.Handlers.Product;
using Amazon.Api.Handlers.ProductDetail;
using Amazon.Api.Handlers.ProductTag;
using Amazon.Api.Handlers.Review;
using Amazon.Api.Handlers.Tag;
using Amazon.Api.Handlers.User;
using Amazon.Api.Handlers.UserCart;
using Amazon.Api.Services.Interfaces;
using Amazon.Api.Services.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

public class Program {
    public static void Main(string[] args) {

        Serilog.Debugging.SelfLog.Enable(Console.Error);
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            // Create logger that will be reconfigured to use the serilog service definitions
            // in the running host
            .CreateBootstrapLogger();

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });

        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();


        RegisterContext(builder);
        RegisterValidator(builder);
        RegisterSerilog(builder);
        RegisterDataService(builder);
        RegisterHandler(builder);
        RegisterManager(builder);

        //builder.Configuration["Jwt:Key"] = Environment.GetEnvironmentVariable("Key");
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        });

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        //builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
    private static void RegisterDataService(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IUserDataService, UserDataService>();
        builder.Services.AddTransient<ICartService, CartService>();
        builder.Services.AddTransient<IProductService, ProductService>();
        builder.Services.AddTransient<IProductDetailService, ProductDetailService>();
        builder.Services.AddTransient<ITagService, TagService>();
        builder.Services.AddTransient<IProductTagService, ProductTagService>();
        builder.Services.AddTransient<IReviewService, ReviewService>();
        builder.Services.AddTransient<IImageService, ImageService>();
        builder.Services.AddTransient<IOrderService, OrderService>();
        builder.Services.AddTransient<IUserCartService, UserCartService>();
        builder.Services.AddTransient<IImageTypeService, ImageTypeService>();
        builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
    }

    private static void RegisterManager(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<UserManager>();
        builder.Services.AddTransient<CartManager>();
        builder.Services.AddTransient<ProductManager>();
        builder.Services.AddTransient<ProductDetailManager>();
        builder.Services.AddTransient<TagManager>();
        builder.Services.AddTransient<ProductTagManager>();
        builder.Services.AddTransient<ReviewManager>();
        builder.Services.AddTransient<ImageManager>();
        builder.Services.AddTransient<OrderManager>();
        builder.Services.AddTransient<UserCartManager>();
        builder.Services.AddTransient<ImageTypeManager>();
    }

    private static void RegisterContext(WebApplicationBuilder builder)
    {
        //builder.Configuration["ConnectionStrings:NeonDbConnection"] = Environment.GetEnvironmentVariable("ConnectionStrings__NeonDbConnection");
        
        builder.Services.AddDbContext<AmazonContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("NeonDbConnection")));
    }

    private static void RegisterValidator(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<UserValidator>();
        builder.Services.AddTransient<CartValidator>();
        builder.Services.AddTransient<ProductValidator>();
        builder.Services.AddTransient<ProductDetailValidator>();
        builder.Services.AddTransient<TagValidator>();
        builder.Services.AddTransient<ProductTagValidator>();
        builder.Services.AddTransient<ReviewValidator>();
        builder.Services.AddTransient<ImageValidator>();
        builder.Services.AddTransient<OrderValidator>();
        builder.Services.AddTransient<UserCartValidator>();
        builder.Services.AddTransient<ImageTypeValidator>();
    }

    private static void RegisterHandler(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<GetUserListHandler>();
        builder.Services.AddTransient<GetUserHandler>();
        builder.Services.AddTransient<AddUserHandler>();
        builder.Services.AddTransient<UpdateUserHandler>();
        builder.Services.AddTransient<DeleteUserHandler>();
        builder.Services.AddTransient<LoginUserHandler>();

        builder.Services.AddTransient<GetCartListHandler>();
        builder.Services.AddTransient<GetCartHandler>();
        builder.Services.AddTransient<AddCartHandler>();
        builder.Services.AddTransient<UpdateCartHandler>();
        builder.Services.AddTransient<DeleteCartHandler>();

        builder.Services.AddTransient<GetProductListHandler>();
        builder.Services.AddTransient<GetProductHandler>();
        builder.Services.AddTransient<AddProductHandler>();
        builder.Services.AddTransient<UpdateProductHandler>();
        builder.Services.AddTransient<DeleteProductHandler>();
        builder.Services.AddTransient<GetProductsByCartIdHandler>();
        builder.Services.AddTransient<GetProductsByCategoriesHandler>();

        builder.Services.AddTransient<GetProductDetailListHandler>();
        builder.Services.AddTransient<GetProductDetailHandler>();
        builder.Services.AddTransient<AddProductDetailHandler>();
        builder.Services.AddTransient<UpdateProductDetailHandler>();
        builder.Services.AddTransient<DeleteProductDetailHandler>();
        builder.Services.AddTransient<GetProductDetailsByProductIdHandler>();

        builder.Services.AddTransient<GetTagListHandler>();
        builder.Services.AddTransient<GetTagHandler>();
        builder.Services.AddTransient<AddTagHandler>();
        builder.Services.AddTransient<UpdateTagHandler>();
        builder.Services.AddTransient<DeleteTagHandler>();

        builder.Services.AddTransient<GetProductTagListHandler>();
        builder.Services.AddTransient<GetProductTagHandler>();
        builder.Services.AddTransient<AddProductTagHandler>();
        builder.Services.AddTransient<UpdateProductTagHandler>();
        builder.Services.AddTransient<DeleteProductTagHandler>();

        builder.Services.AddTransient<GetReviewListHandler>();
        builder.Services.AddTransient<GetReviewHandler>();
        builder.Services.AddTransient<AddReviewHandler>();
        builder.Services.AddTransient<UpdateReviewHandler>();
        builder.Services.AddTransient<DeleteReviewHandler>();

        builder.Services.AddTransient<GetImageListHandler>();
        builder.Services.AddTransient<GetImageHandler>();
        builder.Services.AddTransient<AddImageHandler>();
        builder.Services.AddTransient<UpdateImageHandler>();
        builder.Services.AddTransient<DeleteImageHandler>();
        builder.Services.AddTransient<GetImagesByProductIdHandler>();
        builder.Services.AddTransient<GetFilteredProductsHandler>();

        builder.Services.AddTransient<GetOrderListHandler>();
        builder.Services.AddTransient<GetOrderHandler>();
        builder.Services.AddTransient<AddOrderHandler>();
        builder.Services.AddTransient<UpdateOrderHandler>();
        builder.Services.AddTransient<DeleteOrderHandler>();

        builder.Services.AddTransient<GetUserCartListHandler>();
        builder.Services.AddTransient<GetUserCartHandler>();
        builder.Services.AddTransient<AddUserCartHandler>();
        builder.Services.AddTransient<UpdateUserCartHandler>();
        builder.Services.AddTransient<DeleteUserCartHandler>();

        builder.Services.AddTransient<GetImageTypeListHandler>();
        builder.Services.AddTransient<GetImageTypeHandler>();
        builder.Services.AddTransient<AddImageTypeHandler>();
        builder.Services.AddTransient<UpdateImageTypeHandler>();
        builder.Services.AddTransient<DeleteImageTypeHandler>();
    }

    static void RegisterSerilog(WebApplicationBuilder builder)
    {
        builder.Services.AddSerilog((services, logBuilder) =>
        {
            // Load logBuilder from appsettings.*.json
            logBuilder.ReadFrom.Configuration(builder.Configuration);
            logBuilder.Enrich.FromLogContext();

            // Write to Azure loggers (when deployed to App Service)
            // NOTE: Serilog has support for Azure log streaming and App Insights telemetry
            //       but is simpler to use the loggers configured (injected) by Azure site extensions
            var providers = new LoggerProviderCollection();
            services.GetServices<ILoggerProvider>();
            logBuilder.WriteTo.Providers(providers);
        });
    }
}

