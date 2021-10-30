﻿using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Nike.Application.Common.Interfaces;
using Nike.Application.Common.Models;
using Nike.Application.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Nike.Application.Products.Queries.GetList
{
    public class GetAllListProductQuery : IRequestWrapper<List<ListProductDto>>
    {
    }

    public class GetAllListProductQueryHandler : IRequestHandlerWrapper<GetAllListProductQuery, List<ListProductDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllListProductQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<ListProductDto>>> Handle(GetAllListProductQuery request, CancellationToken cancellationToken)
        {
            var query = await (from a in _context.Products
                               join b in _context.ProductCategories
                               on a.ProductCategoryId equals b.Id
                               select new ListProductDto()
                               {
                                   Id = a.Id,
                                   Name = a.Name,
                                   Image = a.Image,
                                   Price = a.Price,
                                   ProductCategoryName = b.Name
                               }).ToListAsync(cancellationToken);

            return query.Count > 0 ? ServiceResult.Success(query) : ServiceResult.Failed<List<ListProductDto>>(ServiceError.NotFound);
        }
    }
}