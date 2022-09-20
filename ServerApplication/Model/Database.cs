using Microsoft.Data;
using Microsoft.Data.SqlClient;
using ServerApplication.Data;

namespace ServerApplication.Model
{
    internal class Database
    {
        private readonly SqlConnection con = new(@"");
        private string? que;

        internal bool testCon()
        {
            bool test = false;
            que = "select 1";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            {
                con.Close();
            }
            GC.Collect();
            return test;
        }

        /*
        internal List<> Get()
        {
            List<> list = new();
            Class r;
            que = "select * from ";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        r = new Class
                        {

                        };
                        list.Add(r);
                    }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        internal void Set(int id)
        {
            que = "exec insert_logouttime @id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
        }
        */

        #region Citizen Section
        internal List<Citizen> GetCitizens_all()
        {
            List<Citizen> list = new();
            Citizen r;
            que = "select id,nic,name,age,address,latitude,longtitude,profession,email,affiliation,active from citizen";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        r = new Citizen
                        {
                            id = dr.GetInt32(0),
                            nic = dr.GetString(1),
                            name = dr.GetString(2),
                            age = dr.GetInt32(3),
                            address = dr.GetString(4),
                            latitude = dr.GetString(5),
                            longtitude = dr.GetString(6),
                            profession = dr.GetString(7),
                            email = dr.GetString(8),
                            affiliation = dr.GetString(9),
                            active = dr.GetString(10)
                        };
                        list.Add(r);
                    }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        internal Citizen GetCitizen(string nic)
        {
            Citizen r = new();
            que = "select id,nic,name,age,address,latitude,longtitude,profession,email,affiliation,active from citizen";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        r = new Citizen
                        {
                            id = dr.GetInt32(0),
                            nic = dr.GetString(1),
                            name = dr.GetString(2),
                            age = dr.GetInt32(3),
                            address = dr.GetString(4),
                            latitude = dr.GetString(5),
                            longtitude = dr.GetString(6),
                            profession = dr.GetString(7),
                            email = dr.GetString(8),
                            affiliation = dr.GetString(9),
                            active = dr.GetString(10)
                        };
                    }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return r;
        }

        internal bool SetCitizen(Citizen c)
        {
            bool t = false;
            que = "insert into citizen (nic,name,age,address,latitude,longtitude,profession,email,affiliation,active) values ('" + c.nic + "','" + c.name + "'," + c.age + ",'" + c.address + "','" + c.latitude + "','" + c.longtitude + "','" + c.profession + "','" + c.email + "','" + c.affiliation + "','false')";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal bool UpdateActive(string nic, string value)
        {
            bool t = false;
            que = "update citizen set active = '" + value + "' where id = '" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal bool DeleteCitizen(string id)
        {
            bool t = false;
            que = "delete from citizen where nic = '" + id + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        #endregion

        #region Certificate Section
        internal bool SetCertificate(Certificate c)
        {
            bool t = false;
            que = "insert into certificate (nic,name,year) values ('" + c.nic + "','" + c.name + "'," + c.year + ")";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal bool DeleteCertificate(int id)
        {
            bool t = false;
            que = "delete from certificate where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal List<Certificate> GetCertificates(string nic)
        {
            List<Certificate> list = new();
            Certificate r;
            que = "select nic,name,year,id from certificate where nic = '" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        r = new Certificate
                        {
                            nic = dr.GetString(0),
                            name = dr.GetString(1),
                            year = dr.GetInt32(3),
                            id = dr.GetInt32(4)
                        };
                        list.Add(r);
                    }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }
        #endregion

        #region Complaint Section
        internal List<Complaint> GetComplaints(string nic)
        {
            List<Complaint> list = new();
            Complaint r;
            que = "select nic,complaint,reply,id from complaint where nic = '" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        r = new Complaint
                        {
                            nic = dr.GetString(0),
                            complaint = dr.GetString(1),
                            reply = dr.GetString(3),
                            id = dr.GetInt32(4)
                        };
                        list.Add(r);
                    }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        internal bool DeleteComplaints(int id)
        {
            bool t = false;
            que = "delete from complaint where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal bool SetComplaints(Complaint c)
        {
            bool t = false;
            que = "insert into complaint (nic,complaint) values ('" + c.nic + "','" + c.complaint + "')";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal bool UpdateComplaints(Complaint c)
        {
            bool t = false;
            que = "update complaint set reply = '" + c.reply + "' where id = " + c.id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }
        #endregion

        #region Contact Section
        internal List<Contact> GetContacts(string nic)
        {
            List<Contact> list = new();
            Contact r;
            que = "select nic,contact,id from contact where nic = '" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        r = new Contact
                        {
                            nic = dr.GetString(0),
                            contact = dr.GetString(1),
                            id = dr.GetInt32(2)
                        };
                        list.Add(r);
                    }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        internal bool DeleteContacts(int id)
        {
            bool t = false;
            que = "delete from contact where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal bool SetContacts(Contact c)
        {
            bool t = false;
            que = "insert into contact (nic,contact) values ('" + c.nic + "','" + c.contact + "')";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }
        #endregion

        #region Degree Section
        internal List<Degree> GetDegrees(string nic)
        {
            List<Degree> list = new();
            Degree r;
            que = "select nic,id,degreetype,name,institute,year from degree where nic = '" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        r = new Degree
                        {
                            nic = dr.GetString(0),
                            id = dr.GetInt32(1),
                            degreetype = dr.GetString(2),
                            name = dr.GetString(3),
                            institute = dr.GetString(4),
                            year = dr.GetInt32(5)
                        };
                        list.Add(r);
                    }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        internal bool DeleteDegree(int id)
        {
            bool t = false;
            que = "delete from degree where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal bool SetDegree(Degree c)
        {
            bool t = false;
            que = "insert into degree (nic,degreetype,name,institute,year) values ('" + c.nic + "','" + c.degreetype + "','" + c.name + "','" + c.institute + "'," + c.year + ")";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }
        #endregion

        #region Diploma Section
        internal List<Diploma> GetDiplomas(string nic)
        {
            List<Diploma> list = new();
            Diploma r;
            que = "select nic,id,name,institute,year from diploma where nic = '" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        r = new Diploma
                        {
                            nic = dr.GetString(0),
                            id = dr.GetInt32(1),
                            name = dr.GetString(2),
                            institute = dr.GetString(3),
                            year = dr.GetInt32(4)
                        };
                        list.Add(r);
                    }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        internal bool DeleteDiploma(int id)
        {
            bool t = false;
            que = "delete from diploma where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal bool SetDiploma(Diploma c)
        {
            bool t = false;
            que = "insert into diploma (nic,name,institute,year) values ('" + c.nic + "','" + c.name + "','" + c.institute + "'," + c.year + ")";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }
        #endregion

        #region Experience Section
        internal List<Experience> GetExperience(string nic)
        {
            List<Experience> list = new();
            Experience r;
            que = "select nic,id,posision,duration,organization from experience where nic = '" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        r = new Experience
                        {
                            nic = dr.GetString(0),
                            id = dr.GetInt32(1),
                            posision = dr.GetString(2),
                            duration = dr.GetString(3),
                            organization = dr.GetString(4)
                        };
                        list.Add(r);
                    }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        internal bool DeleteExperience(int id)
        {
            bool t = false;
            que = "delete from experience where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal bool SetExperience(Experience c)
        {
            bool t = false;
            que = "insert into experience (nic,posision,duration,organization) values ('" + c.nic + "','" + c.posision + "','" + c.duration + "','" + c.organization + "')";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }
        #endregion

        #region Qualification Section
        internal Qualification GetQualifications(string nic)
        {
            List<Qualification> list = new();
            Qualification r = new();
            que = "select nic,education from qualification where nic = '" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        r = new Qualification
                        {
                            nic = dr.GetString(0),
                            education = dr.GetString(1)
                        };
                    }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return r;
        }

        internal Qualification GetQualifications_byq(string nic)
        {
            List<Qualification> list = new();
            Qualification r = new();
            que = "select nic,education from qualification where education = '" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        r = new Qualification
                        {
                            nic = dr.GetString(0),
                            education = dr.GetString(1)
                        };
                        list.Add(r);
                    }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return r;
        }

        internal bool UpdateQualification(string nic, string field)
        {
            bool t = false;
            que = "update qualification set education = " + field + " where nic = '" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal bool SetQualification(string nic, string value)
        {
            bool t = false;
            que = "insert into qualification (nic,education) values ('" + nic + "','" + value + "')";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        #endregion

        #region Skill Section
        internal List<Skills> GetSkills(string nic)
        {
            List<Skills> list = new();
            Skills r;
            que = "select nic,id,name from skills where nic = '" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        r = new Skills
                        {
                            nic = dr.GetString(0),
                            id = dr.GetInt32(1),
                            name = dr.GetString(2)
                        };
                        list.Add(r);
                    }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        internal bool DeleteSkills(int id)
        {
            bool t = false;
            que = "delete from skills where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal bool SetSkills(Skills c)
        {
            bool t = false;
            que = "insert into skills (nic,name) values ('" + c.nic + "','" + c.name + "')";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); t = false; }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }
        #endregion
    }
}
