using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ec2.InterfaceLayer.DTO
{
    public class RunInstanceResponse
    {
        public RunInstanceResponse()
        {
            TagSpecifications = new List<TagSpecification>();
        }

        public int MaxCount { get; set; }
        public int MinCount { get; set; }
        public string InstanceType { get; set; }
        public LaunchTemplate LaunchTemplate { get; set; }
        public InstanceMarketOptions InstanceMarketOptions { get; set; }
        public List<TagSpecification> TagSpecifications { get; set; }
        public string ResponseMessage { get; set; }
        public HttpStatusCode code { get; set; }
    }
}
