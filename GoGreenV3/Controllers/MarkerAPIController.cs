using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GoGreenV3.Models;

namespace GoGreenV3.Controllers
{
    public class MarkerAPIController : ApiController
    {
        private MarkerDbContext db = new MarkerDbContext();

        // GET: api/MarkerAPI
        public IQueryable<MarkerModel> GetMarkers()
        {
            return db.Markers;
        }

        // GET: api/MarkerAPI/5
        [ResponseType(typeof(MarkerModel))]
        public async Task<IHttpActionResult> GetMarkerModel(int id)
        {
            MarkerModel markerModel = await db.Markers.FindAsync(id);
            if (markerModel == null)
            {
                return NotFound();
            }

            return Ok(markerModel);
        }

        // PUT: api/MarkerAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMarkerModel(int id, MarkerModel markerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != markerModel.Id)
            {
                return BadRequest();
            }

            db.Entry(markerModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkerModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MarkerAPI
        [ResponseType(typeof(MarkerModel))]
        public async Task<IHttpActionResult> PostMarkerModel(MarkerModel markerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Markers.Add(markerModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = markerModel.Id }, markerModel);
        }

        // DELETE: api/MarkerAPI/5
        [ResponseType(typeof(MarkerModel))]
        public async Task<IHttpActionResult> DeleteMarkerModel(int id)
        {
            MarkerModel markerModel = await db.Markers.FindAsync(id);
            if (markerModel == null)
            {
                return NotFound();
            }

            db.Markers.Remove(markerModel);
            await db.SaveChangesAsync();

            return Ok(markerModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarkerModelExists(int id)
        {
            return db.Markers.Count(e => e.Id == id) > 0;
        }
    }
}