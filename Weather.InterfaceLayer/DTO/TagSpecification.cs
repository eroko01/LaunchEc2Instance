using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ec2.InterfaceLayer.DTO
{
    public class TagSpecification
    {
        public TagSpecification()
        {
            Tags = new List<Tag>();
        }

        public string ResourceType { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
