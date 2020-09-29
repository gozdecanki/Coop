
using System;

namespace Coop.Data
{
   public class PoultryDto// hayvanların bilgiler
    {
        public DateTime BirthDate {get; set;}
        public Enums.PoultrySex Sex{get; set;}
        public bool Pregnant {get; set;}
        public DateTime? PregnantDate{get; set;}//hamile olmak zorunda değil
    }
}
