using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.Domain.Concrete;
using Basket.Infrastructure.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly IUserRepositoryDal _userRepositoryDal;
        public readonly IBasketRepositoryDal _basketRepository;

        public ValuesController(IUserRepositoryDal userRepositoryDal, IBasketRepositoryDal basketRepositoryDal)
        {
            _userRepositoryDal = userRepositoryDal;
            _basketRepository = basketRepositoryDal;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var user = _userRepositoryDal.GetList();
            return Ok(user);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var a = _userRepositoryDal.GetById(id);
            return a;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Domain.Concrete.Basket> Post([FromBody] Domain.Concrete.Basket basket)
        {
             _basketRepository.AddProductToBasket(basket);
             return Ok(basket);


        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id,  User value)
        {
            var entity = _userRepositoryDal.GetById(id);
            entity.Name = value.Name;
            entity.Surname = value.Surname;

            _userRepositoryDal.Update(entity);

        }

        // DELETE api/values/5
        [HttpPut]
        public ActionResult<Domain.Concrete.Basket> Get([FromBody] Domain.Concrete.Basket basket)
        {
           _basketRepository.RemoveProductFromBasket(basket);
           return Ok(basket);
        }
    }
}
