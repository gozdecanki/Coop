using System;
using System.Collections.Generic;
using System.Text;

namespace Coop.Helper
{
    public class FileHelper
    {
        public static string ReadFile(string path)
        {
            string result=null;
            try
            {
                result=System.IO.File.ReadAllText(path);
            }
            catch (Exception e)
            {

                
            }
            return result;
        }
    }
}
