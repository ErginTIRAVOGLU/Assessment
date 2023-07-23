using Assessment.Rapor.Api.Models.Enums;
using Assessment.Rapor.Api.Repositories.Concrete;
using AutoMapper;
using MassTransit;
using Shared;

namespace Assessment.Rapor.Api.Consumers
{
    public class RaporCevabiEventConsumer : IConsumer<RaporCevabiEvent>
    {
        ILogger<RaporCevabiEventConsumer> _logger;
        RaporRepository _raporRepository;
        RaporIcerikRepository _raporIcerikRepository;
        IMapper _mapper;

        public RaporCevabiEventConsumer(ILogger<RaporCevabiEventConsumer> logger, RaporRepository raporRepository, RaporIcerikRepository raporIcerikRepository, IMapper mapper)
        {
            _logger = logger;
            _raporRepository = raporRepository;
            _raporIcerikRepository = raporIcerikRepository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<RaporCevabiEvent> context)
        {
            _logger.LogInformation($"Rapor cevabi geldi UUID={context.Message.UUID}");
            
            var rapor= await _raporRepository.GetSingleAsync(m => m.UUID == context.Message.UUID);
            rapor.RaporDurumu = RaporDurumu.Tamamlandi;
            _raporRepository.UpdateAsync(rapor);

            var raporIcerigi = context.Message.RaporIcerigi;
            var raporList = _mapper.Map<List<Models.RaporIcerik>>(raporIcerigi);
            var durum = await _raporIcerikRepository.InsertRangeAsync(raporList);
            
        }
    }
}
