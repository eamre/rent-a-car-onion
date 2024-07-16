using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommand : IRequest<DeletedBrandResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }

        public string? CacheKey => throw new NotImplementedException();

        public bool BypassCache => throw new NotImplementedException();

        public string? CacheGroupKey => "GetBrands";

        public class DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper) : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
        {
            private readonly IBrandRepository _brandRepository = brandRepository;
            private readonly IMapper _mapper = mapper;

            public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(b => b.Id == request.Id, cancellationToken: cancellationToken);
            
                await _brandRepository.DeleteAsync(brand);

                DeletedBrandResponse response = _mapper.Map<DeletedBrandResponse>(brand);
                return response;

            }
        }
    }
}
