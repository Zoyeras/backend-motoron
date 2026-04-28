var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Configuration
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowFrontend", builder =>
	{
		var corsOrigins = (Environment.GetEnvironmentVariable("CORS_ALLOWED_ORIGINS") 
			?? "http://localhost:3000,http://localhost:5173").Split(",");
        
		builder
			.WithOrigins(corsOrigins)
			.AllowAnyMethod()
			.AllowAnyHeader()
			.AllowCredentials();
	});
});

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

// Health check endpoint
app.MapGet("/health", () => Results.Ok(new { status = "healthy" }))
	.WithName("Health")
	.WithOpenApi();

app.Run();
