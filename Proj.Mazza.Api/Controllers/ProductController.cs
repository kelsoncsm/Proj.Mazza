using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proj.Mazza.Application.CommandHandlers;
using Proj.Mazza.Application.Commands;
using Proj.Mazza.Application.Contracts;
using Proj.Mazza.Application.DTOs;
using Proj.Mazza.Application.Models;
using Proj.Mazza.Application.QueryHandlers;
using Proj.Mazza.Domain.Aggregations.Products.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj.Mazza.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IProductQueryHandler _productQueryHandler;
        public ProductController(IMediator mediator, IProductQueryHandler productQueryHandler)
        {
            _mediator = mediator;
            _productQueryHandler = productQueryHandler;
        }

    

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(IEnumerable<ProductGridDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return new JsonResult(await _productQueryHandler.GetAllProduct());

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        //[HttpGet("GetProductsByFilter")]
        //[ProducesResponseType(typeof(IEnumerable<ProductGridDTO>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetProductsByFilter(SearchModel filtros)
        //{
        //    try
        //    {
        //        return new JsonResult(await _productQueryHandler.GetSearch(filtros));

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        [HttpPut("GetProductsByFilter")]
        [ProducesResponseType(typeof(ProductGridDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductsByFilter(SearchModel filtros)
        {
            try
            {
                return new JsonResult(await _productQueryHandler.GetSearch(filtros));

                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateNewProductCommand command)
        {
            var result = await _mediator.Send(command);

            return new JsonResult(result);
        }



        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);

        }



        ///// <summary>
        ///// Alterar Produto.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="cartorioModel"></param>
        ///// <response code="200">Registro alterado com sucesso.</response>
        //[HttpPut("{id}")]
        //[ProducesResponseType(200)]
        //public async Task<IActionResult> PutAsync([FromBody] Produto produto)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.BadRequest(this.ModelState);
        //    }


        //    return this.Ok(await _repository.Update(produto));
        //}

        ///// <summary>
        ///// Excluir Produto.
        ///// </summary>
        ///// <param name="id"></param>
        //[HttpDelete("{id}")]
        //[ProducesResponseType(200)]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.BadRequest(this.ModelState);
        //    }


        //    return this.Ok(await _repository.Delete(id));
        //}








    }
}
