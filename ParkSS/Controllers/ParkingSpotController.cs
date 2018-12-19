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
        //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ParkSS.Properties.Settings.ConnStr"].ConnectionString;

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
                        Value = Boolean.Parse((string)reader["Value"]),
                        Timestamp = ((DateTime)reader["Timestamp"]).ToString()
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
        [Route("api/spots/{id}")] //specifies that the id parameter is an integer
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
                        Value = Boolean.Parse((string)reader["Value"]),
                        Timestamp = ((DateTime)reader["Timestamp"]).ToString()
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
        [Route("api/logspots/parks/{id}/{timespamp}")]
        public IEnumerable<ParkingSpot> GetAllSpotsFromParkAtMoment(string id, string timespamp)
        {
            timespamp = timespamp.Replace("-", "/");
            timespamp = timespamp.Replace("_", " ");
            timespamp = timespamp.Replace(",", ":");

            List<ParkingSpot> spots = new List<ParkingSpot>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT * FROM LogSpots WHERE Id LIKE '%'+@id+'%' AND FORMAT(Timestamp, 'dd/MM/YYYY HH:mm') = FORMAT(@timespamp, 'dd/MM/YYYY HH:mm')", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@timespamp", DateTime.Parse(timespamp));

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
                        Value = Boolean.Parse((string)reader["Value"]),
                        Timestamp = ((DateTime)reader["Timestamp"]).ToString()
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
        [Route("api/logspots/parks/{id}/{timespampS}/{timespampE}")]
        public IEnumerable<ParkingSpot> GetAllSpotsFromParkAtInterval(string id, string timespampS, string timespampE)
        {

            timespampS = timespampS.Replace("-", "/");
            timespampS = timespampS.Replace("_", " ");
            timespampS = timespampS.Replace(",", ":");

            timespampE = timespampE.Replace("-", "/");
            timespampE = timespampE.Replace("_", " ");
            timespampE = timespampE.Replace(",", ":");

            List<ParkingSpot> spots = new List<ParkingSpot>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT * FROM LogSpots WHERE Id LIKE '%'+@id+'%' AND Timestamp >= @timespampS AND Timestamp <= @timespampE", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@timespampS", DateTime.Parse(timespampS));
                cmd.Parameters.AddWithValue("@timespampE", DateTime.Parse(timespampE));

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
                        Value = Boolean.Parse((string)reader["Value"]),
                        Timestamp = ((DateTime)reader["Timestamp"]).ToString()
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

        // GET: api/logspots/free/{id}/{timespamp}
        [Route("api/logspots/free/{id}/{timestamp}")]
        public IEnumerable<ParkingSpot> GetAllFreeSpotsFromParkAtMoment(string id, string timestamp)
        {

            timestamp = timestamp.Replace("-", "/");
            timestamp = timestamp.Replace("_", " ");
            timestamp = timestamp.Replace(",", ":");

            List<ParkingSpot> spots = new List<ParkingSpot>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT * FROM LogSpots WHERE Id LIKE '%'+@id+'%' AND FORMAT(Timestamp,'yyyy-MM-dd HH:mm') = FORMAT(@timespamp,'yyyy-MM-dd HH:mm')", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@timespamp", DateTime.Parse(timestamp));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (((string)reader["Value"]).Equals("True"))
                    {
                        ParkingSpot p = new ParkingSpot
                        {
                            Id = (string)reader["Id"],
                            Type = (string)reader["Type"],
                            Name = (string)reader["Name"],
                            Location = (string)reader["Location"],
                            BateryStatus = (int)reader["BateryStatus"],
                            Value = Boolean.Parse((string)reader["Value"]),
                            Timestamp = ((DateTime)reader["Timestamp"]).ToString()
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
        [Route("api/spots/parks/{id}")]
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
                        Value = Boolean.Parse((string)reader["Value"]),
                        Timestamp = ((DateTime)reader["Timestamp"]).ToString()
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
        [Route("api/conf/parks/{id}")]
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

        // GET: api/logspots/{id}/{timespamp:dateTime}
        [Route("api/logspots/{id}/{timespamp:dateTime}")] //specifies that the id parameter is an integer
        public IHttpActionResult GetSpotAtMoment(string id, DateTime timespamp)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                ParkingSpot spot = null;

                SqlCommand cmd = new SqlCommand("SELECT * FROM LogSpots WHERE Id LIKE @id  AND FORMAT(Timestamp,'yyyy-MM-dd HH:mm') = FORMAT(@timespamp,'yyyy-MM-dd HH:mm')", conn);
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
                        Value = Boolean.Parse((string)reader["Value"]),
                        Timestamp = ((DateTime)reader["Timestamp"]).ToString()
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
                            Value = Boolean.Parse((string)reader["Value"]),
                            Timestamp = ((DateTime)reader["Timestamp"]).ToString()
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
        [Route("api/spots/critical/parks/{id}")]
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
                            Value = Boolean.Parse((string)reader["Value"]),
                            Timestamp = ((DateTime)reader["Timestamp"]).ToString()
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
        [Route("api/spots/parks/{id}/ocupation")]
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
                    if (Boolean.Parse((string)reader["Value"]) == true)
                    {
                        counterFree++;
                    }
                    counterSpots++;
                }

                reader.Close();
                conn.Close();
                int result = (counterFree * 100) / counterSpots;
                return Ok(result.ToString() + "%");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: api/confs
        [Route("api/confs")] //specifies that the id parameter is an integer
        public IEnumerable<Configuration> GetConfigurations()
        {
            SqlConnection conn = null;
            List<Configuration> confs = new List<Configuration>();
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();


                SqlCommand cmd = new SqlCommand("SELECT * FROM Conf", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Configuration conf = new Configuration
                    {
                        connectionType = (string)reader["connectionType"],
                        endpoint = (string)reader["endpoint"],
                        id = (string)reader["id"],
                        description = (string)reader["description"],
                        numberOfSpots = (int)reader["numberOfSpots"],
                        operatingHours = (string)reader["operatingHours"],
                        numberOfSpecialSpots = (int)reader["numberOfSpecialSpots"],
                        geoLocationFile = (string)reader["geoLocationFile"]
                    };
                    confs.Add(conf);
                }

                reader.Close();
                conn.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return confs;
        }
    }
}

