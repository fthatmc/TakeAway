using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAwaySignalR.Api.DAL;

namespace TakeAwaySignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly Context _context;

        public DeliveriesController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var values = _context.Deliveries.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult Post(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
            return Ok("Kaydedildi.");
        }
        [HttpPut]
        public IActionResult Put(Delivery delivery)
        {
            _context.Deliveries.Update(delivery);
            _context.SaveChanges();
            return Ok("Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.Deliveries.Find(id);
            _context.Deliveries.Remove(value);
            _context.SaveChanges();
            return Ok("Silindi");
        }
        [HttpGet("GetDeliveryByStatusIsYolda")]
        public IActionResult GetDeliveryByStatusIsYolda()
        {
            int value = _context.Deliveries.Where(x => x.Status == "Yolda").Count();
            return Ok(value);
        }
        [HttpGet("GetDeliveryByStatusIsSiparisAlindi")]
        public IActionResult GetDeliveryByStatusIsSiparisAlindi()
        {
            int value = _context.Deliveries.Where(x => x.Status == "Sipariş Alındı").Count();
            return Ok(value);
        }
        [HttpGet("GetDeliveryByStatusIsHazırlanıyor")]
        public IActionResult GetDeliveryByStatusIsHazırlanıyor()
        {
            int value = _context.Deliveries.Where(x => x.Status == "Hazırlanıyor").Count();
            return Ok(value);
        }
        [HttpGet("GetDeliveryByStatusIsTeslimEdildi")]
        public IActionResult GetDeliveryByStatusIsTeslimEdildi()
        {
            int value = _context.Deliveries.Where(x => x.Status == "Teslim Edildi").Count();
            return Ok(value);
        }
        [HttpGet("GetTotalPrice")]
        public IActionResult GetTotalPrice()
        {
            decimal value = _context.Deliveries.Sum(x => x.TotalPrice);
            return Ok(value);
        }
        [HttpGet("GetTotalDelivery")]
        public IActionResult GetTotalDelivery()
        {
            int value = _context.Deliveries.Count();
            return Ok(value);
        }
    }
}
