using Smart_Park.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParkSS.Controllers
{
    public class SpotsController : ApiController
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ParkDatabaseAPI.Properties.Settings.ConnStr"].ConnectionString;

        [Route("api/spots")]
        public IEnumerable<ParkingSpot> GetAllSpots()
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM ParkDB", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ParkingSpot p = new ParkingSpot
                    {
                        Id = (string)reader["Id"],
                        Type = (string)reader["Type"],
                        Name = (string)reader["Name"],
                        Location = (string)reader["Location"],
                        BateryStatus = (int)reader["BateryStatus"],
                        Value = (Boolean)reader["Value"],
                        Timestamp = (string)reader["Timestamp"]
                    };
                    spots.Add(p);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return spots;
        }

        // GET: api/spots/{id}
        [Route("api/spots/{id:string}")] //specifies that the id parameter is an integer
        public IHttpActionResult GetSpot(string id)
        {

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                ParkingSpot spot = null;

                SqlCommand cmd = new SqlCommand("SELECT * FROM ParkDB WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    spot = new ParkingSpot
                    {
                        Id = (string)reader["Id"],
                        Type = (string)reader["Type"],
                        Name = (string)reader["Name"],
                        Location = (string)reader["Location"],
                        BateryStatus = (int)reader["BateryStatus"],
                        Value = (Boolean)reader["Value"],
                        Timestamp = (string)reader["Timestamp"]
                    };
                }

                reader.Close();
                conn.Close();

                return Ok(spot);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
