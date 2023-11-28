using System;
using System.Collections.Generic;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace GestionInventaireStock_CSharp.Models
{
	public class Products
	{
		public required int Id { get; set; }
		public required string Name { get; set; }
		public required float Price { get; set; }
		public required string Vendor { get; set; }

        public string ToJSON()
        {
            string result = JsonSerializer.Serialize(this);
            return result;
        }
    }
}