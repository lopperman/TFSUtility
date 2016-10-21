using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFS.BO.Interfaces
{
    /// <summary>
    /// Entity interface.
    /// </summary>
    public interface IEntity : IComparable<IEntity>
    {
        /// <summary>
        /// Gets or sets the Id of the Entity.
        /// </summary>
        /// <value>Id of the Entity.</value>
        string _id { get; set; }
        IDictionary<string, object> NonMappedFields { get; set; }
    }
}
