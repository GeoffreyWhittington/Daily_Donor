using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity.Core.Objects;

namespace Donor2.Controllers
{
    public class DonorsController : ApiController
    {
        private GeoffDBEntities db = new GeoffDBEntities();




        [HttpGet]
        [Route("api/Donors/LastName/{query}")]
        public ObjectResult<DonorsLastNameSearch_Result> LastNameSearch (string query)
        {
            return db.DonorsLastNameSearch(query);
        }





        // GET: api/Donors
        public IQueryable<Donor> GetDonors()
        {
            return db.Donors;
        }

        // GET: api/Donors/5
        [ResponseType(typeof(Donor))]
        public IHttpActionResult GetDonor(int id)
        {
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return NotFound();
            }

            return Ok(donor);
        }

        // PUT: api/Donors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonor(int id, Donor donor)
        {
            string newID = id.ToString();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newID != donor.Donor_ID)
            {
                return BadRequest();
            }

            db.Entry(donor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonorExists(id))
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

        // POST: api/Donors
        [ResponseType(typeof(Donor))]
        public IHttpActionResult PostDonor(Donor donor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Donors.Add(donor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donor.Donor_ID }, donor);
        }

        // DELETE: api/Donors/5
        [ResponseType(typeof(Donor))]
        public IHttpActionResult DeleteDonor(int id)
        {
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return NotFound();
            }

            db.Donors.Remove(donor);
            db.SaveChanges();

            return Ok(donor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonorExists(int id)
        {
            string stringID = id.ToString();
            return db.Donors.Count(e => e.Donor_ID == stringID) > 0;
        }
        
    }
}