using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSCommunication.BusinessObjects
{
    public class TfsArea
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TfsArea()
        {

        }

        public TfsArea(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id}:{Name}";
        }
    }
}
