using Microsoft.EntityFrameworkCore;
using QuizApplication.Data;
using QuizApplication.Models.Entities;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(connectionString));

var app = builder.Build();
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

if (!dbContext.Questions.Any())
{
    var question1Answer = Guid.NewGuid();
    var question1 = new Question()
    {
        Text = "What is the capital of New zealand",
        Option = new List<Option>
        {
            new Option()
            {
                Id = Guid.NewGuid(),
                Text = "Auckland"
            },
            new()
            {
                 Id = question1Answer,
                Text = "Wellington"
            },
            new()
            {
                 Id = Guid.NewGuid(),
                Text = "Christchurch"
            },
             new()
            {
                 Id = Guid.NewGuid(),
                Text = "Queenstown"
            }
        },
        CoorectOption = question1Answer
    };

    var question2Answer = Guid.NewGuid();
    var question2 = new Question()
    {
        Text = "What is the capital of India",
        Option = new List<Option>
        {
            new Option()
            {
                Id = Guid.NewGuid(),
                Text = "Au"
            },
            new()
            {
                 Id = question2Answer,
                Text = "New Delhi"
            },
            new()
            {
                 Id = Guid.NewGuid(),
                Text = "Christchurch"
            },
             new()
            {
                 Id = Guid.NewGuid(),
                Text = "Queenstown"
            }
        },
        CoorectOption = question2Answer
    };

    //save the questions in the db
    dbContext.Questions.AddRange([question1, question2]);
    dbContext.SaveChanges();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Quiz}/{action=Index}/{id?}");

app.Run();
