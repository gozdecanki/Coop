using Coop.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coop
{
    class Program
    {
        public static PoultryHandler PoultryHandler= new PoultryHandler();
        public static List<Data.PoultryDto> PoultryList= new List<Data.PoultryDto>();
        public static Data.ConfigurationDto.Configuration Configuration{get; set;}
        public static Data.DateDto Date {get;set;}
        static void Main(string[] args)
        {
            Configuration=Util.Configuration();
            Date= new Data.DateDto(Configuration.GlobalSetting.Reporting.DatePeriod, Configuration.GlobalSetting.Reporting.Value, DatePeriodTriggered)
            {
                Date=new DateTime(2000, 1, 1)
            };
            Console.WriteLine("Coop Simulator of "+ Configuration.PoultryDetail.Name);
           
            //util çalıştırılır
            Util.Init();
            Console.ReadLine();
        }
        public static void DatePeriodTriggered(object sender, EventArgs args)
        {
            Console.WriteLine(Program.Date.Date.ToString("dd-MM-yyyy")+
                " | F: "+Program.PoultryList.Count(a=>a.Sex==Enums.PoultrySex.Female)+
                " | M: "+Program.PoultryList.Count(a=>a.Sex==Enums.PoultrySex.Male)+
                " | AVG: "+Program.PoultryList.Average(a=>(Program.Date.Date-a.BirthDate).TotalDays));
        }
    }
}
