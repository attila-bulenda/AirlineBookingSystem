using AirlineBookingSystem.Invoices.Core.DTOs;
using AirlineBookingSystem.Invoices.Core.Models;
using AutoMapper;

namespace AirlineBookingSystem.Invoices.Application.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
        }
    }
}
