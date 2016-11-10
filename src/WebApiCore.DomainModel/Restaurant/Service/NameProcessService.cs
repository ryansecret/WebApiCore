using System.Collections.Generic;

namespace WebApiCore.DomainModel.Restaurant.Service
{
    //
    public class NameProcessService
    {
        public const char Split = '|';
        public static string GetAllName(string name,string subName)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            return name + Split + subName;
        }


        public static IList<string> GetNames(string name)
        {
            return name.Split(Split);
        }
    }
}