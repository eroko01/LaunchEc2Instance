using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ec2.InterfaceLayer.DTO;

namespace Ec2.ApplicationLayer
{
    public interface IService
    {
        Task<RunInstanceResponse> LaunchInstanceByRestCall(RunInstanceRequest runInstanceRequest);
        Task<RunInstanceResponse> LaunchInstanceByCmd(RunInstanceRequest runInstanceRequest);
    }
}
