using System.Text;
using Application.Interfaces;
<<<<<<< HEAD
using Application.Usecases.Customer;
=======
using Application.Usecases.Category;
>>>>>>> 891f2d5cb37eb101ebaead2182724cd7b33ef0c0
using Application.UseCases;
using Application.UseCases.Customer;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// DbContext //
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Repository //
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

// Security //
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

// UseCases //

//User
builder.Services.AddScoped<LoginUserUseCase>();
builder.Services.AddScoped<RegisterUserUseCase>();

//Product
builder.Services.AddScoped<GetProductsUseCase>();
builder.Services.AddScoped<CreateProductUseCase>();
builder.Services.AddScoped<DeleteProductUseCase>();
builder.Services.AddScoped<UpdateProductUseCase>();

//Category
builder.Services.AddScoped<GetCategoryByIdUseCase>();
builder.Services.AddScoped<GetAllCategoryUseCase>();
builder.Services.AddScoped<CreateCategoryUseCase>();

//Customer
builder.Services.AddScoped<CreateCustomerUseCase>();
builder.Services.AddScoped<UpdateCustomerUseCase>();
builder.Services.AddScoped<DeleteCustomerUseCase>();
builder.Services.AddScoped<GetCustomerByIdUseCase>(); 
builder.Services.AddScoped<GetAllCustomersUseCase>();
builder.Services.AddScoped<SearchCustomersUseCase>();
builder.Services.AddScoped<GetCustomerSegmentUseCase>();
builder.Services.AddScoped<GetCustomerPurchaseHistoryUseCase>();
//Inventory


//Order
builder.Services.AddScoped<CreateOrderUseCase>();
builder.Services.AddScoped<UpdateOrderUseCase>();
builder.Services.AddScoped<DelOrderUseCase>();
builder.Services.AddScoped<GetOrderIdUseCase>();
builder.Services.AddScoped<GetOrderByUserIdUseCase>();
builder.Services.AddScoped<GetAllOrderUseCase>();

//Order Item

//Payment

//Promotion
builder.Services.AddScoped<CreatePromotionUseCase>();
builder.Services.AddScoped<UpdatePromotionUseCase>();
builder.Services.AddScoped<DelPromotionUseCase>();
builder.Services.AddScoped<GetPromotionByIdUseCase>();
builder.Services.AddScoped<GetAllPromotionUseCase>();
builder.Services.AddScoped<GetPromotionsWithMinOrderAmountGreaterThanUseCase>();
//Supplier
builder.Services.AddScoped<GetSupplierByIdUseCase>();
builder.Services.AddScoped<GetAllSupplierUseCase>();
builder.Services.AddScoped<CreateSupplierUseCase>();    
builder.Services.AddScoped<UpdateSupplierUseCase>();
builder.Services.AddScoped<DeleteSupplierUseCase>();    
//----------//

// CORS //

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins(
                "http://localhost:5173"
                )
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


// JWT Config //
var config = builder.Configuration;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["Jwt:Issuer"],
            ValidAudience = config["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!))
        };
    });



builder.Services.AddControllers();

var app = builder.Build();

// app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
