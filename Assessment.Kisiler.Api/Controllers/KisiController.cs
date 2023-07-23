using Assessment.Kisiler.Api.Models;
using Assessment.Kisiler.Api.Models.Dtos;
using Assessment.Kisiler.Api.Models.Enums;
using Assessment.Kisiler.Api.Repositories.Abstract;
using Assessment.Kisiler.Api.Repositories.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Text.RegularExpressions;

namespace Assessment.Kisiler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KisiController : ControllerBase
    {
        KisiRepository _kisiRepository;
        IletisimBilgisiRepository _iletisimBilgisiRepository;
        IMapper _mapper;
        ILogger<KisiController> _logger;


        public KisiController(KisiRepository kisiRepository, IMapper mapper, ILogger<KisiController> logger, IletisimBilgisiRepository iletisimBilgisiRepository)
        {
            _kisiRepository = kisiRepository;
            _mapper = mapper;
            _logger = logger;
            _iletisimBilgisiRepository = iletisimBilgisiRepository;
        }

        [HttpPost]      
        public async Task<IActionResult> AddKisi(KisiDto kisi)
        {
            try
            {
                var yeniKisi = _mapper.Map<Kisi>(kisi);
                var sonuc= await _kisiRepository.InsertAsync(yeniKisi);
                if (sonuc)
                {
                    return Ok(sonuc);
                }
                else
                {
                    _logger.LogError("Kişi eklenirken hata");
                    return StatusCode(500, "Kişi eklenemedi.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveKisi(Guid? kisiId = null)
        {
           
            if(kisiId == null)
            {
                _logger.LogError("Kişi silinirken hata: kisiId paramatresi gereklidir.");
                return StatusCode(500, "kisiId paramatresi gereklidir.");
            }
            Guid gid = Guid.Parse(kisiId.ToString());
            try
            {
                var kisi = await _kisiRepository.GetByIdAsync(gid);
                if(kisi==null)
                {
                    _logger.LogError("Kişi silinirken hata: Kişi bulunmadı.");
                    return StatusCode(500, "Kişi bulunamadı");
                }

                var sonuc = await _kisiRepository.DeleteAsync(kisi);
                if (sonuc)
                {
                    return Ok(sonuc);
                }
                else
                {
                    return StatusCode(500, "Kişi silinemedi.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("addIletisimBilgisi")]
        public async Task<IActionResult> AddIletisimBilgisi(IletisimBilgisiDto iletisimBilgisi, Guid? kisiId = null)
        {
            if(iletisimBilgisi==null)
            {
                _logger.LogError("İletişim bilgisi eklenirken hata: İletişim Bilgisi paramatresi gereklidir.");
                return StatusCode(500, "İletişim Bilgisi paramatresi gereklidir.");
            }
            if (kisiId == null)
            {
                _logger.LogError("İletişim bilgisi eklenirken hata: kisiId paramatresi gereklidir.");
                return StatusCode(500, "kisiId paramatresi gereklidir.");
            }
            Guid gid = Guid.Parse(kisiId.ToString());

            try
            {
                var yeniIletisimBilgisi = _mapper.Map<IletisimBilgisi>(iletisimBilgisi);
                yeniIletisimBilgisi.KisiId = gid;
                var sonuc = await _iletisimBilgisiRepository.InsertAsync(yeniIletisimBilgisi);
                if (sonuc)
                {
                    return Ok(sonuc);
                }
                else
                {
                    _logger.LogError("İletişim bilgisi  eklenirken hata");
                    return StatusCode(500, "İletişim bilgisi  eklenemedi.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        [Route("removeIletisimBilgisibyId")]
        public async Task<IActionResult> RemoveIletisimBilgisibyId(Guid? iletisimBilgisiId = null)
        {

            if (iletisimBilgisiId == null)
            {
                _logger.LogError("İletişim bilgisi silinirken hata: iletisimBilgisiId paramatresi gereklidir.");
                return StatusCode(500, "iletisimBilgisiId paramatresi gereklidir.");
            }
            Guid giletisimBilgisiId = Guid.Parse(iletisimBilgisiId.ToString());
            try
            {
                var iletisimBilgisi = await _iletisimBilgisiRepository.GetByIdAsync(giletisimBilgisiId);
                var sonuc = await _iletisimBilgisiRepository.DeleteAsync(iletisimBilgisi);
                if (sonuc)
                {
                    return Ok(sonuc);
                }
                else
                {
                    _logger.LogError("İletişim bilgisi silinirken hata");
                    return StatusCode(500, "İletişim bilgisi silinemdi.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete]
        [Route("removeIletisimBilgisibyBilgiTipi")]
        public async Task<IActionResult> RemoveIletisimBilgisibyBilgiTipi(BilgiTipi? iletisimBilgisiTipiId, Guid? kisiId = null)
        {

            if (iletisimBilgisiTipiId == null)
            {
                _logger.LogError("İletişim bilgisi silinirken hata: iletisimBilgisiId paramatresi gereklidir.");
                return StatusCode(500, "iletisimBilgisiId paramatresi gereklidir.");
            }
           
            if (kisiId == null)
            {
                _logger.LogError("İletişim bilgisi silinirken hata: kisiId paramatresi gereklidir.");
                return StatusCode(500, "kisiId paramatresi gereklidir.");
            }
            Guid gid = Guid.Parse(kisiId.ToString());

            try
            {
                var iletisimBilgisi = await _iletisimBilgisiRepository.GetSingleAsync(m => m.KisiId == gid & m.BilgiTipi == iletisimBilgisiTipiId);
                var sonuc = await _iletisimBilgisiRepository.DeleteAsync(iletisimBilgisi);
                if (sonuc)
                {
                    return Ok(sonuc);
                }
                else
                {
                    _logger.LogError("İletişim bilgisi silinirken hata");
                    return StatusCode(500, "İletişim bilgisi silinemdi.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        
        [HttpGet]
        [Route("kisi")]
        public async Task<IActionResult> GetAllKisiler()
        {
             
            try
            {
                var kisiler = await _kisiRepository.GetAllAsync();
                var kisiList = _mapper.Map<IEnumerable<KisiListDto>>(kisiler);
                return Ok(kisiList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("kisiIncludeIletisimBilgileri")]
        public async Task<IActionResult> GetAllKisilerIncludeIletisimBilgileri()
        {

            try
            {
                var kisiler = await _kisiRepository.GetAllIncAsync();
                var kisiList = _mapper.Map<IEnumerable<KisiListWIncDto>>(kisiler);
                return Ok(kisiList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
         

        [HttpGet]
        [Route("{kisiId}")]
        public async Task<IActionResult> GetKisibyId(Guid? kisiId = null)
        {
            if (kisiId == null)
            {
                _logger.LogError("Kişi bilgisi getirilirken hata: kisiId paramatresi gereklidir.");
                return StatusCode(500, "kisiId paramatresi gereklidir.");
            }
            Guid gid = Guid.Parse(kisiId.ToString());

            try
            {
                var kisi = await _kisiRepository.GetByIdIncAsync(gid);
                var kisiBilgisi = _mapper.Map<KisiListWIncDto>(kisi);
                return Ok(kisiBilgisi);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
