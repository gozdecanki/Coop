﻿
using Coop.Data;
using System;
using System.IO;

namespace Coop
{
    public class Util
    {
        public static void Init()
        {
           new Threads();
        }

        public static Data.ConfigurationDto.Configuration Configuration()
        {
            Data.ConfigurationDto.Configuration configuration=null;
            try
            {
                //configürasyon dosyasını okuyacak
               string json=Helper.FileHelper.ReadFile(System.AppDomain.CurrentDomain.BaseDirectory +"\\Configuration.json");
             
                if (!string.IsNullOrWhiteSpace(json))
                {
                    configuration=Newtonsoft.Json.JsonConvert.DeserializeObject<Data.ConfigurationDto.Configuration>(json);
                }
            }
            catch 
            {
              
               
            }
            return  configuration;
        }
        public static void ColdStart()
        {
            for (int i = 1; i <= Program.Configuration.ColdStart.FemalePopulation; i++)
            {
                Program.PoultryHandler.Add(new Data.PoultryDto(){ 
                    Sex=Enums.PoultrySex.Female,
                    Pregnant=false,
                    PregnantDate=null,
                    BirthDate=Program.Date.Date
                    });
            }
           for (int i = 1; i <= Program.Configuration.ColdStart.MalePopulation; i++)
            {
                Program.PoultryHandler.Add(new Data.PoultryDto(){ 
                    Sex=Enums.PoultrySex.Male,
                    Pregnant=false,
                    PregnantDate=null,
                    BirthDate=Program.Date.Date
                    });
            }
        }
    }
}
