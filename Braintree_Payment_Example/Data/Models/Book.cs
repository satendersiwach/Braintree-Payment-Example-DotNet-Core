using System;
using System.ComponentModel.DataAnnotations;

namespace Braintree_Payment_Example.Data.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
