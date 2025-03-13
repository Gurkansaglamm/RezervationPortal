using Microsoft.EntityFrameworkCore;
using RezervationPortal.Abstract;
using RezervationPortal.Data;
using RezervationPortal.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RezervationPortalContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();


builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddControllers();












builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
