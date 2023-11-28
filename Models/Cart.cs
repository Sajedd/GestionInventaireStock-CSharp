using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;


namespace GestionInventaireStock_CSharp.Models
{
    public class Cart
    {
        public required int UserId { get; set; }
        public required int ProductId { get; set; }
        public required int Quantity { get; set; }

        public string ToJSON()
        {
            string result = JsonSerializer.Serialize(this);
            return result;
        }
    }
}