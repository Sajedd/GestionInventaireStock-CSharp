using System;
using System.Collections.Generic;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace GestionInventaireStock_CSharp.Models
{
    public class Users
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Passwd { get; set; }

        public string ToJSON()
        {
            string result = JsonSerializer.Serialize(this);
            return result;
        }
    }
}