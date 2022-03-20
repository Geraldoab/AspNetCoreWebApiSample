using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Dto;
using Project.Domain.Interfaces;
using Project.Domain.Model;

namespace Project.Application.Controllers
{
    [ApiController]
    [Route("Employees")]
    [Authorize]
    public class EmployeeController
    {
        private readonly IEmployeeService service;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmployeeGet>), 200)]
        public async Task<IEnumerable<EmployeeGet>> GetAllAsync()
        {
            var result = await service.GetAllAsync();
            return mapper.Map<IEnumerable<EmployeeGet>>(result);         
        }

        [HttpPost("Add")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostAsync(EmployeePost request)
        {
            if(request == null) 
                return new BadRequestResult();

            var newEmployee = mapper.Map<Employee>(request);

            await service.InsertAsync(newEmployee);

            return new OkResult();
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            if(id == 0)
                return new BadRequestResult();

            var employee = await service.GetByIdAsync(id);

            if(employee == null)
                return new BadRequestResult();

            await service.DeleteAsync(id);    

            return new OkResult();   
        }

        [HttpPut("Update/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] EmployeePut request)
        {
            if(id == 0)
            {
                return new BadRequestResult();
            }

            if(request == null)
            {
                return new BadRequestResult();
            }

            var employee = mapper.Map<Employee>(request);
            employee.Id = id;

            await service.EditAsync(employee);

            return new OkResult(); 
        }
    }
}