using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ec2.InterfaceLayer.DTO;
using AutoMapper;
using System.Text.Json;
using Newtonsoft.Json;
using RestSharp;

namespace Ec2.ApplicationLayer
{
    public class Service : IService
    {
        private readonly IMapper _mapper;
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
            IncludeFields = true
        };

        public Service(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<RunInstanceResponse> LaunchInstanceByRestCall(RunInstanceRequest runInstanceRequest)
        {
            var url = "https://aws.amazon.com/ec2/instance"; //ToDo: read base url from the appsettings or from the secret

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(runInstanceRequest);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            var response = _mapper.Map(runInstanceRequest, new RunInstanceResponse());
            response.ResponseMessage = result;

            if (httpResponse.StatusCode != HttpStatusCode.Created || httpResponse.StatusCode != HttpStatusCode.OK)
                throw new NotImplementedException("Http Exception handler to be defined");

            return response;
        }

        public async Task<RunInstanceResponse> LaunchInstanceByCmd(RunInstanceRequest runInstanceRequest)
        {
            string jsonRequest = JsonConvert.SerializeObject(runInstanceRequest);
            string result;
            string command = $"aws ec2 run-instances --cli-input-json {jsonRequest}";
            using (Process p = new Process())
            {
                p.StartInfo = new ProcessStartInfo("cmd.exe")
                {
                    RedirectStandardInput = true,
                    UseShellExecute = false
                };

                // start process
                p.Start();
                // send command to its input
                p.StandardInput.Write(command + p.StandardInput.NewLine);
                //wait
                p.WaitForExit();
                result = p.StandardOutput.ReadToEnd();
            }

            var response = _mapper.Map(runInstanceRequest, new RunInstanceResponse());
            response.ResponseMessage = result;

            return response;
        }
    }
}
