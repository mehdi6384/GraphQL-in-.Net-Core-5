using HotChocolate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [GraphQLDescription("Represents a purchased, valid license for the platfrom.")]
        public string LisenceKey { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
