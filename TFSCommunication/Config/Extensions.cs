using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace TFSCommunication.Config
{
    public static class Extensions
    {
        public static string ToString(this WorkItemType wit)
        {
            return $"{wit.Name}:{wit.Description}";
        }
    }
}
