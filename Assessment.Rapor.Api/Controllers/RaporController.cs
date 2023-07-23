using Assessment.Rapor.Api.Models;
using Assessment.Rapor.Api.Models.Dtos;
using Assessment.Rapor.Api.Repositories.Concrete;
using AutoMapper;
using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Assessment.Rapor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaporController : ControllerBase
    {
        RaporRepository _raporRepository;
        IMapper _mapper;
        ILogger<RaporController> _logger;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IPublishEndpoint _publishEndpoint;

        public RaporController(RaporRepository raporRepository, IMapper mapper, ILogger<RaporController> logger, IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider)
        {
            _raporRepository = raporRepository;
            _mapper = mapper;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
            _sendEndpointProvider = sendEndpointProvider;
        }





        [HttpGet]
        [Route("RaporRequest")]
        public async Task<IActionResult> RaporRequest()
        {

            try
            {
                var rapor = new RaporlarDto();  
                rapor.UUID = Guid.NewGuid();
                var yeniRapor = _mapper.Map<Raporlar>(rapor);

                var sonuc = await _raporRepository.InsertAsync(yeniRapor);

                if (sonuc)
                {
                    var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:rapor-istegi"));
                    RaporIstegiEvent raporIstegiEvent = new RaporIstegiEvent()
                    {
                        UUID = yeniRapor.UUID
                    };
                    //await _publishEndpoint.Publish(raporIstegiEvent);
                    await sendEndpoint.Send<RaporIstegiEvent>(raporIstegiEvent);
                    _logger.LogInformation($"Rapor İsteği gönderildi UUID={raporIstegiEvent.UUID}");
                    return Ok(sonuc);
                }
                else
                {
                    _logger.LogError("Rapor Request işlenirken hata");
                    return StatusCode(500, "Rapor eklenemedi.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet]
        [Route("rapor")]
        public async Task<IActionResult> GetAllRaporlar()
        {

            try
            {
                var raporlar = await _raporRepository.GetAllIncAsync();
                var raporList = _mapper.Map<IEnumerable<RaporlarDto>>(raporlar);
                return Ok(raporlar);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("{raporId}")]
        public async Task<IActionResult> GetRaporbyId(Guid? raporId = null)
        {
            if (raporId == null)
            {
                _logger.LogError("Rapor bilgisi getirilirken hata: raporId paramatresi gereklidir.");
                return StatusCode(500, "raporId paramatresi gereklidir.");
            }
            Guid gid = Guid.Parse(raporId.ToString());

            try
            {
                var rapor = await _raporRepository.GetByIdIncAsync(gid);
                var raporBilgisi = _mapper.Map<RaporlarDto>(rapor);
                return Ok(raporBilgisi);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
