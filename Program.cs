using Microsoft.EntityFrameworkCore;
using itvisions_infotag;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<CustomerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Customer API endpoints

// GET /customers - Get all customers
app.MapGet("/customers", async (CustomerContext context) =>
{
    var customers = await context.Customers.ToListAsync();
    return Results.Ok(customers);
});

// GET /customers/{id} - Get customer by ID
app.MapGet("/customers/{id:int}", async (int id, CustomerContext context) =>
{
    var customer = await context.Customers.FindAsync(id);
    return customer is not null ? Results.Ok(customer) : Results.NotFound();
});

// POST /customers - Create a new customer
app.MapPost("/customers", async (Customer customer, CustomerContext context) =>
{
    context.Customers.Add(customer);
    await context.SaveChangesAsync();
    return Results.Created($"/customers/{customer.CustomerID}", customer);
});

// DELETE /customers/{id} - Delete customer by ID
app.MapDelete("/customers/{id:int}", async (int id, CustomerContext context) =>
{
    var customer = await context.Customers.FindAsync(id);
    if (customer is null)
    {
        return Results.NotFound();
    }

    context.Customers.Remove(customer);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
