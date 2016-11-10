using System.Collections.Generic;
using System.Linq;

namespace WebApiCore.Repository.Utility
{
    public class SqlCondition
    {
        private readonly IList<string> _clause; 
        public SqlCondition()
        {
             _clause=new List<string>();
        }

        public void Add(bool predicate, string clause)
        {
            if (predicate)
            { 
                _clause.Add(clause);
            }
        }

        public string GetWhere()
        {
            if (_clause.Any())
            {
                return " where "+string.Join(" and ", _clause);
            }
            return string.Empty;
        }
    }

     
}