using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace JustGivingAPITesting
{
    [TestClass]
    public class UnitTest1
    {
        private string _appId = StaticValues.APIStaticValues.AppId;
        private string _EmailValid = Account.AccountValidStaticVariables.emailValid;
        private string SandBoxApiUrl = StaticValues.APIStaticValues.SandBoxApiUrl;

        [TestMethod]
        public void ValidEmailAccount()
        {

          var response =  RequestValidationOnEmailAccount(_EmailValid);
            Assert.IsTrue(response.StatusDescription.Contains("Account exists"));
        }

        [TestMethod]
        public void InValidEmailAccount()
        {
            var response = RequestValidationOnEmailAccount("gm_blahBlah");

            Assert.IsTrue(response.StatusDescription.Contains("Account does not exist"));
        }

        [TestMethod]
        public void NoEmailSpecified()
        {
            var response = RequestValidationOnEmailAccount("");
            //Could check the status code 403
            Assert.IsTrue(response.StatusDescription.Contains("Unauthorized"));
        }

        [TestMethod]
        public void DeleteMethodSpecified()
        {
            var response = RequestValidationOnEmailAccount(_EmailValid, Method.DELETE);

            HttpStatusCode statuscode = response.StatusCode;

            Assert.AreEqual((int)statuscode, 404);
        }


        [TestMethod]
        public void PutMethodSpecified()
        {
            var response = RequestValidationOnEmailAccount(_EmailValid, Method.PUT);

            HttpStatusCode statuscode = response.StatusCode;

            Assert.AreEqual((int)statuscode, 400);
        }



        private IRestResponse RequestValidationOnEmailAccount(string email, Method type = Method.GET)
        {
            IRestResponse response;
            var client = new RestClient(SandBoxApiUrl);

            var request = new RestRequest("v1/account/{email}", type);

            request.AddUrlSegment("email", email);

            request.AddHeader("x-api-key", _appId);

            response = client.Execute(request);
            return response;
        }

    }
}
