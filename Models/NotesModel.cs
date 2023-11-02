using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
}
