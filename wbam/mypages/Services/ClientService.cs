using Newtonsoft.Json;
using wbam.mypages.Models;
using wbam.mypages.Models.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http.Headers;

namespace wbam.mypages.Services
{
    public class ClientService : BaseService
    {
        public async Task<BamApiResponse<List<Clientbam>>> GetAllClientsAsync(string username)
        {
            HttpResponseMessage response;

            try
            {
                response = await Client.GetAsync("/clients/all/");
            }
            catch (Exception ex)
            {
                return new BamApiResponse<List<Clientbam>>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }

            DataContractJsonSerializer serializer;

            var stream = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode)
            {
                serializer = new DataContractJsonSerializer(typeof(List<Clientbam>));
                 
                var users = serializer.ReadObject(stream) as List<Clientbam>;

                return new BamApiResponse<List<Clientbam>>(response.StatusCode, users);
            }

            serializer = new DataContractJsonSerializer(typeof(ErrorMessage));
            var result = serializer.ReadObject(stream) as ErrorMessage;

            return new BamApiResponse<List<Clientbam>>(response.StatusCode, result.Message);
        }

        public async Task<BamApiResponse<List<Clientbam>>> GetByIdClientsAsync(string _id)
        {
            HttpResponseMessage response;

            try
            {
                response = await Client.GetAsync("http://ec2-3-129-59-197.us-east-2.compute.amazonaws.com:3100/bamapi/v1/clients/row/" + _id);
            }
            catch (Exception ex)
            {
                return new BamApiResponse<List<Clientbam>>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }

            DataContractJsonSerializer serializer;

            var stream = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode)
            {
                serializer = new DataContractJsonSerializer(typeof(List<Clientbam>));

                var users = serializer.ReadObject(stream) as List<Clientbam>;

                return new BamApiResponse<List<Clientbam>>(response.StatusCode, users);
            }

            serializer = new DataContractJsonSerializer(typeof(ErrorMessage));
            var result = serializer.ReadObject(stream) as ErrorMessage;

            return new BamApiResponse<List<Clientbam>>(response.StatusCode, result.Message);
        }


       
    }
}