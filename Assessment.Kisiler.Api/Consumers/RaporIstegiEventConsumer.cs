using Assessment.Kisiler.Api.Controllers;
using Assessment.Kisiler.Api.Models.Enums;
using Assessment.Kisiler.Api.Repositories.Abstract;
using Assessment.Kisiler.Api.Repositories.Concrete;
using MassTransit;
using MassTransit.Transports;
using Shared;

namespace Assessment.Kisiler.Api.Consumers
{
    public class RaporIstegiEventConsumer : IConsumer<RaporIstegiEvent>
    {
        ILogger<RaporIstegiEventConsumer> _logger;
        KisiRepository _kisiRepository;
        IletisimBilgisiRepository _iletisimBilgisiRepository;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IPublishEndpoint _publishEndpoint;

        public RaporIstegiEventConsumer(ILogger<RaporIstegiEventConsumer> logger, KisiRepository kisiRepository, IletisimBilgisiRepository iletisimBilgisiRepository, IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider)
        {
            _logger = logger;
            _kisiRepository = kisiRepository;
            _iletisimBilgisiRepository = iletisimBilgisiRepository;
            _publishEndpoint = publishEndpoint;
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Consume(ConsumeContext<RaporIstegiEvent> context)
        {
            var test = await _kisiRepository.GetAllAsync();
            _logger.LogInformation($"Rapor İsteği geldi UUID={context.Message.UUID}");
            var rapor = _iletisimBilgisiRepository.GetWhere(m => m.BilgiTipi == BilgiTipi.Konum)
                     .GroupBy(n => n.Icerik)
                     .Select(g => new RaporIcerik()
                     {
                         Konum = g.Key,
                         KisiSayisi = _kisiRepository.GetWhereInc(m => m.IletisimBilgileri.Any(n => n.Icerik == g.Key)).Count(),
                         TelefonSayisi = _kisiRepository.GetWhereInc(m => m.IletisimBilgileri.Any(n => n.Icerik == g.Key)).Where(m => m.IletisimBilgileri.Any(z => z.BilgiTipi == BilgiTipi.Telefon)).Count(),
                         RaporlarId = context.Message.UUID
                     }).ToList();

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:rapor-istegi-cevabi"));
            RaporCevabiEvent raporCevabiEvent = new RaporCevabiEvent()
            {
               UUID= context.Message.UUID,
               RaporIcerigi=rapor
            };
            //await _publishEndpoint.Publish(raporCevabiEvent);
            await sendEndpoint.Send<RaporCevabiEvent>(raporCevabiEvent);
            _logger.LogInformation($"Rapor cevabı gönderildi UUID= {raporCevabiEvent.UUID}");
        }
    }
}
