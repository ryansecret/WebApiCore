using System.Collections.Generic;
using DapperEx;
using WebApiCore.DomainModel;

namespace WebApiCore.Repository.Utility
{
    public static class Extension
    {
        public static void AddPredicate(this PredicateGroup predicateGroup, bool conditon, IPredicate predicate)
        {
            if (conditon)
            {
                
                predicateGroup.Predicates.Add(predicate);
            }
        }

        public static PredicateGroup GetNewPredicateGroup()
        {
            PredicateGroup predicateGroup=new PredicateGroup();
            predicateGroup.Predicates=new List<IPredicate>();
            return predicateGroup;
        }

        public static void CheckPage(this QueryBase param)
        {
            if (param.PageIndex <= 0)
            {
                param.PageIndex = 1;
            }
            if (param.PageSize <= 0)
            {
                param.PageSize = 20;
            }
        }
    }
}