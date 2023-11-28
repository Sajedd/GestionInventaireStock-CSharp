using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GestionInventaireStock_CSharp.Models
{
	public class Invoices
	{
		public required int Id { get; set; }
		public required int UserId { get; set; }
		public required int ProductId { get; set; }
		public required DateTime Date { get; set; }
		public required float UnitPrice { get; set; }
		public required int Quantity { get; set; }
		public required float Total {  get; set; }

        public string ToJSON()
        {
            string result = JsonSerializer.Serialize(this);
            return result;
        }
    }
}