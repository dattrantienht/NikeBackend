﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nike.Application.Common.Models;
using Nike.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nike.Application.ProductCategories.Queries.GetProductCategoriesQuery;
using Nike.Application.ProductCategories.Queries.GetProductCategoryById;

namespace Nike.Api.Controllers
{
    public class ProductCategoriesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<ProductCategoryDto>>>> GetAllProductCategories(CancellationToken cancellationToken)
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllProductCategoriesQuery(), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<ProductCategoryDto>>> GetProductCategoryById(int id)
        {
            return Ok(await Mediator.Send(new GetProductCategoryByIdQuery { ProductCategoryId = id }));
        }

        //[HttpPost]
        //public async Task<ActionResult<ServiceResult<CityDto>>> Create(CreateCityCommand command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}

        //[HttpPut]
        //public async Task<ActionResult<ServiceResult<CityDto>>> Update(UpdateCityCommand command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<ServiceResult<CityDto>>> Delete(int id)
        //{
        //    return Ok(await Mediator.Send(new DeleteCityCommand { Id = id }));
        //}
    }
}
