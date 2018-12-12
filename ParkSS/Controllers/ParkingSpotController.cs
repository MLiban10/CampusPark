using Smart_Park.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Smart_Park.Controllers
{
    public class SpotsController : ApiController
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Smart_Park.Properties.Settings.ConnStr"].ConnectionString;

        // GET: api/spots
        [Route("api/spots")]
        public IEnumerable<ParkingSpot> GetAllSpots()
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Spots", conn);

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

                SqlCommand cmd = new SqlCommand("SELECT * FROM Spots WHERE Id LIKE @id", conn);
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

        // GET: api/conf/parks
        [Route("api/conf/parks")]
        public IEnumerable<string> GetAllParks()
        {
            List<string> parks = new List<string>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT id FROM Conf", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    parks.Add((string)reader["id"]);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return parks;
        }

        // GET: api/logspots/parks/{id}/{timespamp}
        [Route("api/logspots/parks/{id:string}/{timespamp:DateTime}")]
        public IEnumerable<ParkingSpot> GetAllSpotsFromParkAtMoment(string id, DateTime timespamp)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM LogSpots WHERE Id LIKE '%'+@id+'%' AND Timespamp = @timespamp", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@timespamp", timespamp);

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

        // GET: api/logspots/parks/{id}/{timespampsS}/{timespampE}
        [Route("api/logspots/parks/{id:string}/{timespampS:dateTime/{timespampE:DateTime}")]
        public IEnumerable<ParkingSpot> GetAllSpotsFromParkAtInterval(string id, DateTime timespampS, DateTime timespampE)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM LogSpots WHERE Id LIKE '%'+@id+'%' AND Timespamp >= @timespampS AND Timespamp <= @timespampE", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@timespampS", timespampS);
                cmd.Parameters.AddWithValue("@timespampE", timespampE);

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

        // GET: api/spots/parks/{id}/{timespamp}
        [Route("api/logspots/parks/free/{id:string}/{timespamp:DateTime}")]
        public IEnumerable<ParkingSpot> GetAllFreeSpotsFromParkAtMoment(string id, DateTime timespamp)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM LogSpots WHERE Id LIKE '%'+@id+'%' AND Timespamp = @timespamp", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@timespamp", timespamp);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((Boolean)reader["Value"] == true)
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

        // GET: api/conf/parks/{id}
        [Route("api/spots/parks/{id:string}")]
        public IEnumerable<ParkingSpot> GetAllSpotsFromPark(string id)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Spots WHERE Id LIKE '%'+@id+'%'", conn);
                cmd.Parameters.AddWithValue("@id", id);

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

        // GET: api/spots/parks/{id}
        [Route("api/conf/parks/{id:string}")]
        public IEnumerable<string> GetPark(string id)
        {
            List<string> parks = new List<string>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT id FROM Conf WHERE Id LIKE @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    parks.Add((string)reader["id"]);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return parks;
        }

        // GET: api/spots/{id}
        [Route("api/logspots/{id:string}/{timespamp:DateTime}")] //specifies that the id parameter is an integer
        public IHttpActionResult GetSpotAtMoment(string id, DateTime timespamp)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                ParkingSpot spot = null;

                SqlCommand cmd = new SqlCommand("SELECT * FROM LogSpots WHERE Id LIKE @id  AND Timespamp = @timespamp", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@timespamp", timespamp);

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

        // GET: api/spots/critical
        [Route("api/spots/critical")]
        public IEnumerable<ParkingSpot> GetAllSpotsWithCriticalBattery()
        {

            List<ParkingSpot> spots = new List<ParkingSpot>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Spots", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((int)reader["BateryStatus"] == 1)
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


        // GET: api/spots/critical/parks/{id}
        [Route("api/spots/critical/parks/{id:string}")]
        public IEnumerable<ParkingSpot> GetAllSpotsWithCriticalBatteryAtPark(string id)
        {

            List<ParkingSpot> spots = new List<ParkingSpot>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Spots WHERE Id LIKE '%'+@id+'%'", conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((int)reader["BateryStatus"] == 1)
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


        // GET: api/spots/parks/{id}/ocupation
        [Route("api/spots/parks/{id:string}/ocupation")]
        public IHttpActionResult GetParkOcupation(string id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Spots WHERE Id LIKE '%'+@id+'%'", conn);
                cmd.Parameters.AddWithValue("@id", id);

                int counterFree = 0;
                int counterSpots = 0;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((Boolean)reader["Value"] == true)
                    {
                        counterFree++;
                    }
                    counterSpots++;
                }

                reader.Close();
                conn.Close();

                return Ok((counterFree * 100) / counterSpots);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}

