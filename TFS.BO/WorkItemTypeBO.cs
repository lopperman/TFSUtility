using System.Collections.Generic;
using TFS.BO.Interfaces;

namespace TFS.BO
{
    public class WorkItemTypeBO: IEntity, IObjectId, IIndex<WorkItemTypeBO>
    {

        public string _id { get; set; }
        public int Id { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }

        public int CompareTo(IEntity other)
        {
            return other._id.CompareTo(_id);
        }

        public IDictionary<string, object> NonMappedFields { get; set; } = new Dictionary<string, object>();

        public WorkItemTypeBO()
            {
            }
    }
}