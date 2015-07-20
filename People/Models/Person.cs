using System;

namespace People.Models
{
    public class Person
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Landline { get; set; }
        public Address Address { get; set; }
    }
}