﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Medilo.API.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public int AddressId { get; set; }

        public Address Address { get; set; }

        [JsonIgnore]
        public Doctor? Doctor { get; set; }

        [JsonIgnore]
        public Receptionist? Receptionist { get; set; }

        [JsonIgnore]
        public PatientCard? PatientCard { get; set; }
    }
}
