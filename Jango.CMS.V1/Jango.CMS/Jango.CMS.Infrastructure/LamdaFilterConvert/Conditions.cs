using System.Collections.Generic;
using System.Linq;

namespace Jango.CMS.Infrastructure.LamdaFilterConvert
{
    public class Conditions
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }

        public string Relation { get; set; }

        public static List<Conditions> BuildConditions(string[] fields,string[] operators,string[] values,
            string[] relations)
        {
            var conditions = fields.Select((t, i) => new Conditions
            {
                Field = t,
                Operator = operators[i],
                Value = values[i],
                Relation = relations[i]
            }).ToList();
            return conditions;
        }
    }
}