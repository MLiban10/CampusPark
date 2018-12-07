using Smart_Park.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Smart_Park.Controllers
{
    public class SpotController : ApiController
    {

        List<Models.ParkingSpot> spots = new List<ParkingSpot>
            {
                new ParkingSpot
                {
                    Id="TESTE", Type="TESTE", BateryStatus=0, Location="TESTE", Name="TESTE", Timestamp=new DateTime(), Value="TESTE"
                }
            };

        // GET all: api/Spot
        public IEnumerable<ParkingSpot> GetAllParkingSpots()
        {
            return spots;
        }

        // GET: api/Spot/TESTE
        [Route("api/spots/{id:int}")]
        public IHttpActionResult GetProduct(int id)
        {
            string idToUse = id.ToString();
            var spot = spots.FirstOrDefault((s) => s.Id == idToUse);
            if (spot == null)
            {
                return NotFound();
            }
            return Ok(spot); //Respecting HTTP errors (200 OK)
        }


        /// <summary>
        /// ////////////////////////////Smart park will only use gets//////////////////////////////////
        /// </summary>
        /// <param name="value"></param>
        // POST: api/Spot
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Spot/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Spot/5
        public void Delete(int id)
        {
        }
    }
}
