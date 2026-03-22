using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea_4
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        // propiedad calculada
        public string FullName => Name + " " + LastName;
    }
}
