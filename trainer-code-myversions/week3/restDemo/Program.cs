using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<User> users = new List<User>();

users.Add(new User(1, "John", "Doe"));
users.Add(new User(2, "Jane", "Doe"));

//List users
app.MapGet("/users", () => users);

//Show user by id
app.MapGet("/users/{id}", (int id) =>
{
    var user = users.FirstOrDefault(user => user.ID == id);

    if (user != null)
    {
        return Results.Ok(user);
    }
    else
    {
        return Results.NotFound("User with this id does not exist.");
    }
});

//Create user
app.MapPost("/users/AddUser/", ([FromBody] User user) =>
{
    users.Add(user);
    return Results.Created($"User {user.firstName} added successfully", user);
});

//Update user name
app.MapPatch("/users/Rename/{id}/{firstName}", (int id) =>
{
    string newName = "Kate";
    var user = users.FirstOrDefault(user => user.ID == id);

    if (user != null)
    {
        user.firstName = newName;
        return Results.Ok($"User with id {id} was renamed.");
    }
    else
    {
        return Results.NotFound($"User with id {id} does not exist.");
    }
});

//Delete User
app.MapDelete("/users/Deleteuser/{id}", (int id) => {
    var user = users.FirstOrDefault(user => user.ID == id); //find a user where the user.ID is equal to the id passed in as a parameter

    if (user != null)
    {
        users.Remove(user);
        return Results.Ok($"User with id {id} was removed.");
    }
    else
    {
        return Results.NotFound($"User with id {id} does not exist.");
    }
});

app.Run();