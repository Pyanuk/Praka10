using System;
using System.Collections.Generic;

namespace Emias_WPF.Models
{
    public partial class Patient
    {


        public long? Oms { get; set; }
        public string Surname { get; set; } = null!;
        public string PatientName { get; set; } = null!;
        public string? Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PatientAddress { get; set; } = null!;
        public string? LivingAddress { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Nickname { get; set; }


    }
}
