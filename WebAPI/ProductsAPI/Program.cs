using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProductsAPI.Models;
using ProductsAPI.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; //Cors ayarlamasını yapılandırmak için bir anahtar değeri belirledik.
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddDbContext<DatabaseContext>(x => x.UseSqlite("Data Source=products.db"));
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<DatabaseContext>();
builder.Services.AddScoped<JwtToken>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        options.AddPolicy(MyAllowSpecificOrigins, policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500")
            .AllowAnyHeader() //Bu urlden gelen tüm header'leri kabul et
            .AllowAnyMethod(); //Tüm methodları kabul et
        });
    });
});
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;

    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
});

//Jwt token'i imzalamak için gerekli ayarlamalar:
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, //api sağlayıcısını valid etmek için kullanılır. false değerinde bu işlemi atlar
            ValidIssuer = "muhammedhkmdr.com", //eğer ValidateIssuer'e true deseydik buradaki valid issuer ile token üretildiğindeki issuer'in aynı olması beklenirdi.
            ValidateAudience = false, //api'yi hangi service'ler için geliştirildiği ile ilgili bir string bekler. false diyip bu aşamayı geçiyoruz.
            ValidAudience = "", //tek bir service için service ismini buraya yazabiliriz.
            ValidAudiences = new string[] { "a", "b" }, //birden fazla değer için bu yapı kullanılır.
            ValidateIssuerSigningKey = true, //Key değerimizi validate ediyoruz.
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Secret").Value ?? "")), //kullandığımız key'i buraya vermemiz gerekiyor.
            ValidateLifetime = true //token süresini kontrol etmek için kullanılır. (Bizim verdiğimiz değere göre 1 gün sonra token kendini imha eder.)
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option => //Swagger'e token ekleme arayüzünü entegre etmek için kullanılır. (bunu yapmak şart değildir postman ile rahat bir şekilde bu sorun çözülebilir.)
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins); //Cors tanımlaması routing ile Authorization arasına yapılmalıdır.
app.UseAuthorization();

app.MapControllers();

app.Run();
