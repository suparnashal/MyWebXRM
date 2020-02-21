using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple =false,Inherited =false)]
    public class TeamAttribute : NUnitAttribute,IApplyToTest
    {
        public string teamname;
        public TeamAttribute(string team)
        {
            teamname = team;
        }

        public void ApplyToTest(Test t)
        {
            t.Properties.Add("Team", teamname);
        }
    }
}
