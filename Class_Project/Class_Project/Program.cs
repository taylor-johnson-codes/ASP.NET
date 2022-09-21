// LOOK AT SLIDES TO ADD NOTES

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();

app.UseStaticFiles();
// static file notes from notebook
// right-click project, add new folder, call it wwwroot
// add any files you wish to the folder



// MIDDLEWARE PIPELINE app.Use and app.Run

//app.MapGet("/", () => "Hello World!");  // replace with next line of code

//app.Run(async context => { await context.Response.WriteAsync("Hello SMU"); });  // async and await are paired keywords
// anonymous delegate: prints Hello SMU on every request page, not just the home page

/*
// can't run multiple Run statement, so use Use instead
app.Run(async context => { await context.Response.WriteAsync("Path you requested: " + context.Request.Path); });
app.Run(async context => { await context.Response.WriteAsync("Second Run called"); });
*/

app.Use(
    async (context, next) => { 
        await context.Response.WriteAsync("Use 1\n");
        await next();  // needed when using app.Use
        await context.Response.WriteAsync("Use 2\n");
    }
);

app.Use(
    async (context, next) => {
        await context.Response.WriteAsync("Use 3\n");
        await next();
        await context.Response.WriteAsync("Use 4\n");
    }
);

app.Run(async context => { await context.Response.WriteAsync("Run called\n"); });

app.Run();

/* Output:
Use 1
Use 3
Run called
Use 4
Use 2
*/


