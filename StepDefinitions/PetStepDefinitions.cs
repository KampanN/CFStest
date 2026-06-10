using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using CFStest.Models;
using CFStest.Helpers;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFStest.StepDefinitions
{
    [Binding]
    public class PetStepDefinitions
    {
        private readonly ApiClient _apiClient;
        private Pet _petData;
        private RestResponse _response;

        public PetStepDefinitions()
        {
            _apiClient = new ApiClient();
        }

        [Given("User creates dynamic pet payload")]
        public void GivenUserCreatesDynamicPetPayload()
        {
            _petData = TestDataGenerator.CreatePetData();
        }

        [When("User sends POST request to create pet")]
        public void WhenUserSendsPOSTRequestToCreatePet()
        {
            _response = _apiClient.ExecutePost("pet", _petData);
            TestContext.Progress.WriteLine("Response status: " + (int)_response.StatusCode);
            TestContext.Progress.WriteLine("Response body: " + _response.Content);
        }

        [Then("Pet should be created successfully")]
        public void ThenPetShouldBeCreatedSuccessfully()
        {
            Assert.That((int)_response.StatusCode, Is.EqualTo(200), "Create returned unexpected status");

            var responseBody = JsonConvert.DeserializeObject<Pet>(_response.Content);
            
            Assert.That(responseBody.id, Is.EqualTo(_petData.id));
        }

        [When("User sends GET request using pet id")]
        public void WhenUserSendsGETRequestUsingPetId()
        {
            _response = _apiClient.ExecuteGet($"pet/{_petData.id}");
        }

        [Then("Response data should match created pet")]
        public void ThenResponseDataShouldMatchCreatedPet()
        {
            Assert.That((int)_response.StatusCode, Is.EqualTo(200), "GET returned unexpected status");

            
            var responseBody = JsonConvert.DeserializeObject<Pet>(_response.Content);
            
            Assert.That(responseBody.id, Is.EqualTo(_petData.id));
            Assert.That(responseBody.name, Is.EqualTo(_petData.name));
            TestContext.Progress.WriteLine("Response status: " + (int)_response.StatusCode);
            TestContext.Progress.WriteLine("Response body: " + _response.Content);
        }

        [When("User updates pet name")]
        public void WhenUserUpdatesPetName()
        {
            _petData.name = _petData.name + "_updated";
            _response = _apiClient.ExecutePut("pet", _petData);
        }

        [Then("Updated response should contain modified name")]
        public void ThenUpdatedResponseShouldContainModifiedName()
        {
            Assert.That((int)_response.StatusCode, Is.EqualTo(200), "Update returned unexpected status");
            
            var responseBody = JsonConvert.DeserializeObject<Pet>(_response.Content);
            
            Assert.That(responseBody.name, Is.EqualTo(_petData.name));
            TestContext.Progress.WriteLine("Response status: " + (int)_response.StatusCode);
            TestContext.Progress.WriteLine("Response body: " + _response.Content);
        }

        [When("User deletes the pet")]
        public void WhenUserDeletesThePet()
        {
            _response = _apiClient.ExecuteDelete($"pet/{_petData.id}");
        }

        [Then("Deleted pet should return not found response")]
        public void ThenDeletedPetShouldReturnNotFoundResponse()
        {
            Assert.That((int)_response.StatusCode, Is.EqualTo(200), "Delete did not return expected success status");

            var getResp = _apiClient.ExecuteGet($"pet/{_petData.id}");
            Assert.That((int)getResp.StatusCode, Is.EqualTo(404));
        }
    }
}
