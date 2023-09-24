using Microsoft.EntityFrameworkCore;
using SeatManagement2;
using SeatManagement2.Models;
using SeatManagement2.Services;
using SeatManagement2.Interfaces;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SeatManagementContext>(options =>
           options.UseSqlServer("name=ConnectionStrings:DefaultConnection"), ServiceLifetime.Singleton);

builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly",
        policy => policy.RequireRole("Admin"));
});

builder.Services.AddSingleton<IRepository<CityLookUp>, Repository<CityLookUp>>();
builder.Services.AddSingleton<IRepository<BuildingLookUp>, Repository<BuildingLookUp>>();
builder.Services.AddSingleton<IRepository<Facility>, Repository<Facility>>();
builder.Services.AddSingleton<IRepository<DepartmentLookUp>, Repository<DepartmentLookUp>>();
builder.Services.AddSingleton<IRepository<AmenityLookUp>, Repository<AmenityLookUp>>();
builder.Services.AddSingleton<IRepository<Employee>, Repository<Employee>>();
builder.Services.AddSingleton<IRepository<CabinRoom>, Repository<CabinRoom>>();
builder.Services.AddSingleton<IRepository<GeneralSeat>, Repository<GeneralSeat>>();
builder.Services.AddSingleton<IRepository<MeetingRoom>, Repository<MeetingRoom>>();
builder.Services.AddSingleton<IRepository<RoomAmenity>, Repository<RoomAmenity>>();
builder.Services.AddSingleton<IRepository<AllocatedSeats>, Repository<AllocatedSeats>>();
builder.Services.AddSingleton<IRepository<UnallocatedSeats>, Repository<UnallocatedSeats>>();
builder.Services.AddSingleton<IRepository<UnallocatedCabinsView>, Repository<UnallocatedCabinsView>>();
builder.Services.AddSingleton<IRepository<AllocatedCabinsView>, Repository<AllocatedCabinsView>>();

builder.Services.AddSingleton<ICityService, CityService>();
builder.Services.AddSingleton<IBuildingService, BuildingService>();
builder.Services.AddSingleton<IFacilityService, FacilityService>();
builder.Services.AddSingleton<IAmenityService, AmenityService>();
builder.Services.AddSingleton<IDepartmentService, DepartmentService>();
builder.Services.AddSingleton<ICabinRoomService, CabinRoomService>();
builder.Services.AddSingleton<IGeneralSeatService, GeneralSeatService>();
builder.Services.AddSingleton<IMeetingRoomService, MeetingRoomService>();
builder.Services.AddSingleton<IRoomAmenityService, RoomAmenityService>();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<IReportService, ReportService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
