using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental.Data;
using Rental.DTO;
using Rental.Models;

namespace Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutRepository _repo;
        private readonly IMapper _mapper;

        public CheckoutController(ICheckoutRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        [HttpPost()]
        public async Task<IActionResult> Book(CheckoutDTO checkoutdto)
                                            
        {
           try
            {
                if (ModelState.IsValid)
                {
                    var checkout = new Booking
                    {
                        A_FK_USERID=checkoutdto.UserId,
                        A_FK_CARID=checkoutdto.CarId,
                        A_LEASE_START_DATE = checkoutdto.StartDate,
                        A_LEASE_END_DATE=checkoutdto.EndDate,
                        A_TENURE = checkoutdto.Tenure,
                        A_PRICE = checkoutdto.Price
                        
                        

                    };

                    var checkedoutUser = await _repo.Book(checkout);

                    return StatusCode(201);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return BadRequest();
        }
    }
}
