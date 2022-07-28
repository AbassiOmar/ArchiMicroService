using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Invocie.Core.Features.Invoice.Commands.CheckoutInvocie;
using Invocie.Core.Features.Invoice.Commands.UpdateInvocie;
using Invocie.Core.Features.Invoice.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvoiceApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{userName}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<InvoiceViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InvoiceViewModel>>> GetOrdersByUserName(string userName)
        {
            var query = new GetInvoicesQuery(userName);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        // testing purpose
        [HttpPost(Name = "CheckoutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CheckoutOrder([FromBody] CheckoutInvoiceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateInvocieCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        //[HttpDelete("{id}", Name = "DeleteOrder")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult> DeleteOrder(int id)
        //{
        //    var command = new DeleteOrderCommand() { Id = id };
        //    await _mediator.Send(command);
        //    return NoContent();
        //}
    }
}
