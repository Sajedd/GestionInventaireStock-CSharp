using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;


namespace GestionInventaireStock_CSharp.Models
{
    public class Book
    {
        public required string Title { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }
        public required int Pages { get; set; }

        public string ToJSON()
        {
            string result = JsonSerializer.Serialize(this);
            return result;
        }
    }
}