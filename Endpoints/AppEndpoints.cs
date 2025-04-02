using System.Linq;
using App_Store.Api.Data;
using App_Store.Api.DTOs;
using App_Store.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace App_Store.Api.Endpoints;
public static class AppEndpoints
{
    private static readonly List<AppDto> appDto = [
    new(1, "Learn Arabic", "Educations", 20.99, new DateOnly(2002,03,17)),
    new(2, "Whatsapp", "Social Media", 22.35, new DateOnly(2012,03,17)),
    new(3, "Tawasol", "Social Media", 27.92, new DateOnly(2022,03,17)),
    new(3, "Picsart", "Design", 45.62, new DateOnly(2022,03,17)),
    new(3, "Calculator", "Maths", 15.12, new DateOnly(2022,03,17)),

];
    public static RouteGroupBuilder MapAppEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("apps").WithParameterValidation();

        // GET App_Store
        group.MapGet("/", (AppsStoreContext dbContext) =>
        {
            var app = dbContext.Apps.Include(a => a.Genres).Select(
                app => new AppDto(
                    app.Id,
                    app.Name,
                    app.Genres!.Name,
                    app.Price,
                    app.ReleaseDate
                )).ToList();
            return Results.Ok(app);
        });

        // GET App_Store by ID
        string item_last = "Get_App";
        group.MapGet("/{id}", (int id, AppsStoreContext dbContext) =>
        {
            var apps = dbContext.Apps.Include(a => a.Genres).FirstOrDefault(a => a.Id == id);
            if (apps == null)
            {
                return Results.NotFound("App not found.");
            }
            var app = new AppDto(
                    apps.Id,
                    apps.Name,
                    apps.Genres!.Name,
                    apps.Price,
                    apps.ReleaseDate
                );
            return Results.Ok(app);
        }).WithName(item_last);

        // POST App_Store
        group.MapPost("/", (CreateAppDto newApp, AppsStoreContext dbContext) =>
        {
            Apps app = new()
            {
                Name = newApp.Name,
                Genres = dbContext.Genres.Find(newApp.GenresId),
                Price = newApp.Price,
                ReleaseDate = newApp.ReleaseDate
            };
            dbContext.Apps.Add(app);
            dbContext.SaveChanges();

            AppDto appdto = new(
                app.Id,
                app.Name,
                app.Genres!.Name,
                app.Price,
                app.ReleaseDate
            );
            return Results.CreatedAtRoute(item_last, new { id = app.Id }, appdto);
        }
        ).WithParameterValidation();
        // PUT App_Store by ID
        group.MapPut("/{id}", async (int id, UpdateAppDto updateAppdto, AppsStoreContext dbContext) =>
        {
            var app = await dbContext.Apps.FindAsync(id);
            if (app == null)
            {
                return Results.NotFound("App Not Found.");
            }

            var genre = await dbContext.Genres.FindAsync(updateAppdto.GenresId);
            if (genre == null)
            {
                return Results.NotFound("Genre Not Found.");
            }

            app.Name = updateAppdto.Name;
            app.GenresId = updateAppdto.GenresId;
            app.Genres = genre;
            app.Price = updateAppdto.Price;
            app.ReleaseDate = updateAppdto.ReleaseDate;

            await dbContext.SaveChangesAsync();
            return Results.Ok(genre);
        }
        );
        // DELETE App_Store by ID
        group.MapDelete("/{id}", (int id, AppsStoreContext dbContext) =>
        {
            var app = dbContext.Apps.Find(id);

            if (app == null)
            {
                return Results.NotFound("App Not Found..!");
            }

            dbContext.Apps.Remove(app);
            dbContext.SaveChanges();
            return Results.Ok("Delete App Successfully.");

        });
        return group;
    }
};