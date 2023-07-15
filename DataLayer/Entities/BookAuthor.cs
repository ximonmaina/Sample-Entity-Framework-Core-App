﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstEfCoreApp.Data.Entities
{
    public class BookAuthor
    {
        [Key] // #A
        [Column(Order = 0)] // #B
        public int BookId { get; set; }
        [Key] // #A
        [Column(Order = 1)] // #B
        public int AuthorId { get; set; }
        public byte Order { get; set; }

        // Relationships
        public Book Book { get; set; }
        public Author Author { get; set; }

        /************************************
         #A The [Key] attribute tells EF Core that this property is a primary key
        #B The [Column(Order = nn)] tells EF Core the order in which the keys should appear in the composite key. Note; The numbers are relative
        *************************************/

    }
}
