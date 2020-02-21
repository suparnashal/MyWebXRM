using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Framework.Enums
{
    public enum Project
    {
        [Description("Missing Project")]
        Undefined,
        XRMCore,
        XRMIntegration
    }
}
