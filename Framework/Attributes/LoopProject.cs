using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using Framework.Enums;

namespace Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
   public class LoopProjectAttribute : NUnitAttribute, IApplyToTest
    {
        public Project project;
        public LoopProjectAttribute(Project proj)
        {
            project = proj ;
        }

        public void ApplyToTest(Test t)
        {
            t.Properties.Add("LoopProject", project);
        }
    

    }
}
