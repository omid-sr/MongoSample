using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoSample.Controllers;
using MongoSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMongoRepository<FirstChild> _firstChildRepository;
        private readonly IMongoRepository<SecondChild> _secondChildRepository;
        private readonly IMongoRepository<Parent> _parentRepository;
        public WeatherForecastController(
            IMongoRepository<FirstChild> firstChildRepository,
            IMongoRepository<SecondChild> secondChildRepository, 
            IMongoRepository<Parent> parentRepository)
        {
            _firstChildRepository = firstChildRepository;
            _secondChildRepository = secondChildRepository;
            _parentRepository = parentRepository;
        }


        [HttpPost("TestMongoInheritance")]
        public async Task AddPerson()
        {
            Parent firstChild = new FirstChild()
            {
                Profession = "Developer"
            };
            await _parentRepository.InsertOneAsync(firstChild);

            Parent secondChild = new SecondChild()
            {
                Education = "Bachelor"
            };
            await _parentRepository.InsertOneAsync(secondChild);
          
            
            
            var x =  _parentRepository.FindById("61d587f79c75ec928c5efd13");
            var y = x is FirstChild;

        }
    }
}
