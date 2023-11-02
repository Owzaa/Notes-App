using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Notes.Data;
using Microsoft.EntityFrameworkCore;

namespace Notes.Models
{
    public class NotesModel
    {
        // Property that Hold Note Title
        [Key]
        public int Id { get; set; }
        // Property: Title
        public string? Title { get; set; }
        //Property: Content
        public string? Content { get; set; }
        // Property: DateCreated
        public DateTime? CreatedDate { get; set; } = default(DateTime?);
        // Property: UpdatedDated
        public DateTime? UpdatedAt { get; set; }


        // Constructor that creates  New Note
        public NotesModel(string title,string content)
        {
            Title = title;
            Content= content;
            CreatedDate = DateTime.Now;
            UpdatedAt = DateTime.Now;

        }

        // A method that updates the note content and last modified date
        public void Update(string content)
        {
            Content = content;
            UpdatedAt = DateTime.Now;
        }

        // A method that returns a string representation of the note object
        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Content: {Content}, CreatedAt: {CreatedDate}, UpdatedAt: {UpdatedAt}";
        }

        internal static Task<ActionResult<IEnumerable<NotesModel>>> ToListAsync()
        {
            throw new NotImplementedException();
        }


    }


public static class NotesModelEndpoints
{
	public static void MapNotesModelEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/NotesModel", async (ApplicationDbContext db) =>
        {
            return await db.NotesModel.ToListAsync();
        })
        .WithName("GetAllNotesModels")
        .Produces<List<NotesModel>>(StatusCodes.Status200OK);

        routes.MapGet("/api/NotesModel/{id}", async (int Id, ApplicationDbContext db) =>
        {
            return await db.NotesModel.FindAsync(Id)
                is NotesModel model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetNotesModelById")
        .Produces<NotesModel>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/NotesModel/{id}", async (int Id, NotesModel notesModel, ApplicationDbContext db) =>
        {
            var foundModel = await db.NotesModel.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(notesModel);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateNotesModel")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/NotesModel/", async (NotesModel notesModel, ApplicationDbContext db) =>
        {
            db.NotesModel.Add(notesModel);
            await db.SaveChangesAsync();
            return Results.Created($"/NotesModels/{notesModel.Id}", notesModel);
        })
        .WithName("CreateNotesModel")
        .Produces<NotesModel>(StatusCodes.Status201Created);


        routes.MapDelete("/api/NotesModel/{id}", async (int Id, ApplicationDbContext db) =>
        {
            if (await db.NotesModel.FindAsync(Id) is NotesModel notesModel)
            {
                db.NotesModel.Remove(notesModel);
                await db.SaveChangesAsync();
                return Results.Ok(notesModel);
            }

            return Results.NotFound();
        })
        .WithName("DeleteNotesModel")
        .Produces<NotesModel>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}}
