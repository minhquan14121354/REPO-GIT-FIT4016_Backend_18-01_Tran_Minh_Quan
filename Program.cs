using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Khai báo dịch vụ
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Đăng ký Swagger
builder.Services.AddDbContext<SchoolContext>();

var app = builder.Build();

// 2. BẬT SWAGGER (Luôn bật, không cần kiểm tra Development nữa)
app.UseSwagger();
app.UseSwaggerUI();

// 3. Định tuyến
app.MapControllers();

// 4. Chạy Server
app.Run();