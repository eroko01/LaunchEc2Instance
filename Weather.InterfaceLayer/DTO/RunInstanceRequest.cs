using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ec2.InterfaceLayer.DTO
{
    public class RunInstanceRequest
    {
        public RunInstanceRequest()
        {
            TagSpecifications = new List<TagSpecification>();
        }

        public int MaxCount { get; set; }
        public int MinCount { get; set; }
        public string InstanceType { get; set; }
        public LaunchTemplate LaunchTemplate { get; set; }
        public InstanceMarketOptions InstanceMarketOptions { get; set; }
        public List<TagSpecification> TagSpecifications { get; set; }
    }
}
