﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Elipgo.ShoeStock.Api.Constants;
using Elipgo.ShoeStock.Api.Dtos.Responses;
using Elipgo.ShoeStock.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Elipgo.ShoeStock.Api.Controllers
{
    [Route("services/stores")]
    [ApiController]
    [Authorize]
    public class StoresController : ControllerBase
    {
        protected readonly IDatabaseProvider _databaseProvider;
        protected readonly IMapper _mapper;
        public StoresController(IDatabaseProvider databaseProvider, IMapper mapper) : base()
        {
            _databaseProvider = databaseProvider;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetStores()
        {
            var stores = _databaseProvider.GetStores().ToList();
            var response = new StoresListResponseDto() { TotalElements = stores.Count(), Stores = _mapper.Map<List<StoreDto>>(stores) };
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStore(int id)
        {
            var store = _databaseProvider.GetStore(id);
            if (store == null)
            {
                return NotFound(new ErrorResponse() { ErrorCode = 404, ErrorMessage = MessageConstants.StoreNotFoundMessage });
            }
            var response = new StoreResponseDto() { Store = _mapper.Map<StoreDto>(store) };
            return Ok(response);
        }
    }
}