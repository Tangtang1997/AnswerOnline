using System.Collections.Generic;
using System.Threading.Tasks;
using AnswerOnline.Application.Commissioners.Dto;
using AnswerOnline.Domain.Entities.Commissioners;
using AnswerOnline.Toolkit.UnifyModel;
using AutoMapper;

namespace AnswerOnline.Application.Commissioners
{
    public class CommissionerAppService : ICommissionerAppService
    {
        private readonly ICommissionerRepository _commissionerRepository;
        private readonly IMapper _mapper;

        public CommissionerAppService(ICommissionerRepository commissionerRepository, IMapper mapper)
        {
            _commissionerRepository = commissionerRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<CommissionerDto>>> GetAllAsync()
        {
            var commissiners = await _commissionerRepository.ListAllAsync();

            return new Result<List<CommissionerDto>>
            {
                IsSucceeded = true,
                Data = _mapper.Map<List<CommissionerDto>>(commissiners)
            };
        }
    }
}