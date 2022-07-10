using AutoMapper;
using Car.Core.Contracts;
using Car.Core.Entities;
using Car.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Car.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ChallengeController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public ChallengeController(IUnitOfWork unitOfWork, ILogger<ChallengeController> logger, IMapper mapper, IAuthManager authManager)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }

        /// <summary>
        /// This method returns token as {addressToken: "token"}. You can test by {"userName":"test-user", "password":"test1234"}
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns>Returns token in an object {addressToken:[token]}</returns>
        [HttpPost(Name = "Login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDTO userDTO)
        {
            _logger.LogInformation($"Login attempted with {userDTO.UserName}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!await _authManager.ValidateUser(userDTO))
                {
                    return Unauthorized(userDTO);
                }
                return Ok(new { AddressToken = await _authManager.CreateToken() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Invalid login attempt in {nameof(Login)}");
                return BadRequest(new { success = false, product = userDTO });
            }
        }
        /// <summary>
        /// Gets the list of all car details in database. It needs token in header as {"Authorization": "Bearer [token]"}
        /// </summary>
        /// <returns>Returns list of all car details.</returns>
        [Authorize]
        [HttpGet(Name = "GetCars")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCars()
        {
            _logger.LogInformation($"Attempted get cars.");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var cars = await _unitOfWork.cars.GetAll();
                return Ok(cars);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Invalid get cars attempt in {nameof(GetCars)}");
                return BadRequest("Something went wrong. Check the logs.");
            }
        }
        /// <summary>
        /// Adds a car details in database. It needs token in header as {"Authorization": "Bearer [token]"}
        /// </summary>
        /// <param name="carDTO"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost(Name = "AddCar")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCar([FromBody] CarDetailsDTO carDTO)
        {
            _logger.LogInformation($"Add car attempted with {carDTO.Brand} {carDTO.Model}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var car = _mapper.Map<CarDetails>(carDTO);
                await _unitOfWork.cars.Insert(car);
                await _unitOfWork.Save();
                return Ok(car);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Invalid add car attempt in {nameof(AddCar)}");
                return BadRequest($"Something went wrong. Check the logs.");
            }
        }
    }
}
