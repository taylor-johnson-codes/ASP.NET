// This is the entry point of the application
// The namespace{}/class{}/Main(){} statements that older versions of .NET showed are still there in the background of the Program.cs file
// (The compiler generates a class and Main method entry point for the application)

// ------------------------------- MIDDLEWARE PIPELINE (handles HTTP requests and responses) -------------------------------

using Class_Project.Data;
using Class_Project.Models;
using Microsoft.EntityFrameworkCore;
//using Class_Project.Services;  // moved data from FakeData service to SeedData database

var builder = WebApplication.CreateBuilder(args);  // sets up the basic features of the ASP.NET Core platform

builder.Services.AddControllersWithViews();  // for adding MVC into the project
//builder.Services.AddSingleton<IFakeData, FakeData>();  // for adding my hard-coded data as a service (later moved data from FakeData service to SeedData database)
//builder.Services.AddDbContext<MyDataDbContext>(options => options.UseSqlite("someDB.db"));  // for Entity Framework - will have to  re-compile to change DB
builder.Services.AddDbContext<MyDataDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("MyConnectionString")));  // for EF Core to change database without re-compiling code
    // the connection string comes from appsettings.json

var app = builder.Build();  // sets up middleware components

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<MyDataDbContext>();  // give access to context/database for Entity Framework
//context.Database.EnsureDeleted();  // if database exists, delete it and start with no existing DB
context.Database.EnsureCreated();  // if database doesn't exist, then create it (otherwise do nothing)
SeedData.SeedDatabase(context);  // only call this for testing purposes; normally the client would load the database with their data

//app.UseDefaultFiles();  // needed to serve the default.html file in the wwwroot folder
// not needed after upgrading project to MVC

app.UseStaticFiles();  // to enable the use of static files
                       // static files don't change at run time (e.g. wwwroot folder: HTML, CSS, image, JavaScript files)
                       // wwwroot is just a folder known as the project's web root directory

// The following code is adding MVC into the project with conventional routing

// Conventional routing is defined in Program.cs for one central location
// Conventional routing is order-dependent; top = highest priority, bottom = lowest priority
// Once a route is matched, it doesn't look at any other routes
// Conventional routing is shown below and is what we'll use; examples of attribute routing for learning purposes is shown in StudentController.cs

app.UseRouting();  // routing maps requests to actions

// default route:
// with this syntax, if "controller" is spelled wrong, there WON'T be a compiler error
app.MapControllerRoute(
    name: "default",  // we're not using the name anywhere, it's just part of the syntax
    //pattern: "{controller=Home}/{action=Index}/{id?}"  // NO SPACES in the pattern URL; ? is an optional segment of the URL
    pattern: "{controller=Instructor}/{action=Index}/{id?}"
    // with this pattern, Instructor controller and Index action are invoked by default if no other controller/action is specified in the URL
    );

// alternative default route:
// with this syntax, if "controller" is spelled wrong, there WILL be a compiler error
//app.MapControllerRoute(
//    name: "anotherRoute",
//    pattern: "Display/{id}",
//    defaults: new { controller = "Student", action = "Show" }
//    );

// always put the final "catch all" route at the bottom
app.MapControllerRoute(
    name: "catchAll",
    pattern: "{*whatever}",
    defaults: new { controller = "Student", action = "Index" }
    );

app.Run();



/* Commenting the rest out since we're upgrading this project to MVC

// This is the default middleware component created from spinning up the project; we'll use our own middleware components instead
//app.MapGet("/", () => "Hello World!");  // "Hello World" will only be printed on the homepage due to "/"

// The single request delegate/anonymous function is called in response to every HTTP request (not just the homepage request)
//app.Run(async context => { await context.Response.WriteAsync("Hello SMU"); });  // async and await are paired keywords

//For every HTTP request that is being received, the ASP.NET Core platform:
//- creates an object (called Request) that contains information about the request, and
//- creates an object (called Response) that will be sent back. 
//- These objects are properties of an object called "context"

// ---------------------------------------------------- Map() SECTION ----------------------------------------------------

static void HandleMenuRequest(IApplicationBuilder app)
{
    app.Run(async context =>
    { await context.Response.WriteAsync("Menu page isn't set up yet. :( "); });
}

static void HandleHoursRequest(IApplicationBuilder app)
{
    app.Run(async context =>
    { await context.Response.WriteAsync("Hours page isn't set up yet. :( "); });
}

app.Map("/menu.html", HandleMenuRequest);
app.Map("/hours.html", HandleHoursRequest);


// ------------------------------------------------- Use() & Run() SECTION -------------------------------------------------


// Use() allows the parameter "next" to reference the next middleware in the pipeline
app.Use(
    async (context, next) => { 
        await context.Response.WriteAsync("Middleware component 1 start\n");
        await next();  // have to use "next" statement when using app.Use()
        await context.Response.WriteAsync("Middleware component 1 end\n");
    }
);

app.Use(
    async (context, next) => {
        await context.Response.WriteAsync("Middleware component 2 start\n");
        await next();
        await context.Response.WriteAsync("Middleware component 2 end\n");
    }
);

// Run() doesn't have the "next" parameter
app.Run(async context => { await context.Response.WriteAsync("Run() called\n"); });

app.Run();  // terminates the pipeline
*/

/* Output:
Middleware component 1 start
Middleware component 2 start
Run() called
Middleware component 2 end
Middleware component 1 end
*/
// Note: Won't see this output with a default.html or index.html page in the project; those override this output


/*
// can't execute multiple Run() statements; use Use() instead
app.Run(async context => { await context.Response.WriteAsync("Path you requested: " + context.Request.Path); });
app.Run(async context => { await context.Response.WriteAsync("Second Run called"); });
*/
