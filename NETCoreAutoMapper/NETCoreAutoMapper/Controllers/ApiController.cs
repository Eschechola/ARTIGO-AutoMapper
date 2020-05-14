using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NETCoreAutoMapper.Models;
using System.Collections.Generic;

namespace NETCoreAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {

        private readonly IMapper _mapper;

        public ApiController(IMapper mapper)
        {
            _mapper = mapper;
        }

        private IList<Client> clients = new List<Client>
        {
            new Client { Id = 1, Email = "client@eu.com", Name = "Client 1" },
            new Client { Id = 2, Email = "client2@eu.com", Name = "Client 2" },
            new Client { Id = 3, Email = "client3@eu.com", Name = "Client 3" },
        };

        [Route("/get/{id}")]
        public IActionResult Get(int id)
        {
            var client = clients.Where(x => x.Id == id).FirstOrDefault();

            var clientDTO = _mapper.Map<ClientDTO>(client);
            clientDTO.ModifiedDate = DateTime.Now;

            return Ok(clientDTO);
        }

        [Route("/post")]
        public IActionResult Post([FromBody]ClientDTO clientDTO)
        {
            var clientAdd = _mapper.Map<Client>(clientDTO);

            clients.Add(clientAdd);

            return Ok(clients);
        }
    }
}