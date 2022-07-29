using AutoMapper;
using Invocie.Core.Features.Invoice.Commands.CheckoutInvocie;
using Invocie.Core.Features.Invoice.Commands.UpdateInvocie;
using Invocie.Core.Features.Invoice.Queries;
using Invoice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invocie.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InvoiceData, InvoiceViewModel>().ReverseMap();
            CreateMap<InvoiceData, CheckoutInvoiceCommand>().ReverseMap();
            CreateMap<InvoiceData, UpdateInvocieCommand>().ReverseMap();
        }
    }
}
