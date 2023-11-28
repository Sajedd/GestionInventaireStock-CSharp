using System;
using System.Text.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace GestionInventaireStock_CSharp.Models
{
    public class Orders
    {
        public required int Id { get; set; }
        public required int InvoiceId { get; set; }
        public required int ProductId { get; set; }
        public required int UserId { get; set; }
        public required int AdressId { get; set; }
        public required DateTime DepartureDate { get; set; }
        public required DateTime ArrivalDate { get; set; }
        public required string DeliveryCompany { get; set; }

        public string ToJSON()
        {
            string result = JsonSerializer.Serialize(this);
            return result;
        }
    }
}