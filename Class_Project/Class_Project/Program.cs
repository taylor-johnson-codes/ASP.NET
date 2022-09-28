// This is the entry point of the application
// The namespace{}/class{}/Main(){} statements that older versions of .NET showed are still there in the background of the Program.cs file
// (The compiler generates a class and Main method entry point for the application)

var builder = WebApplication.CreateBuilder(args);  // sets up the basic features of the ASP.NET Core platform

builder.Services.AddControllersWithViews();  // for adding MVC into the project

// ------------------------------- MIDDLEWARE PIPELINE (handles HTTP requests and responses) -------------------------------

var app = builder.Build();  // sets up middleware components

//app.UseDefaultFiles();  // needed to serve the default.html file in the wwwroot folder
                         // not needed after upgrading project to MVC

app.UseStaticFiles();  // to enable the use of static files
                       // static files don't change at run time (e.g. wwwroot folder: HTML, CSS, image, JavaScript files)
                       // wwwroot is just a folder known as the project's web root directory

// for adding MVC into the project:
// (conventional routing)

app.UseRouting();

app.MapControllerRoute(
    name: "anotherRoute",
    pattern: "Display/{id}",
    defaults: new { controller = "Student", action = "Show"}
    );

//app.MapDefaultControllerRoute();

// default route:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"  // default route; NO SPACES in the pattern URL; ? is an optional segment
    );

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
