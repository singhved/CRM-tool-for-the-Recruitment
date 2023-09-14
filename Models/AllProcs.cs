using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    public class AllProcs
    {
        public static string Getconnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["EducareContext"].ConnectionString;
            }
        }
        public static DataTable GetTableData(string TableName)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetTableData", con);
            cmd.Parameters.AddWithValue("@TableName", TableName);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetDepartments()
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetDepartments", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetSkill()
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetSkill", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetDegree()
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetDegree", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetUniversity()
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetUniversity", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }
        public static DataTable GetSubject()
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetSubject", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetLevel()
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetLevel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }


        public static DataTable GetAffiliation()
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetAffiliation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }


        public static DataTable StateChoice(int? Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("StateChoice", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }
        public static DataTable GetRquests(int? Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetRquests", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable FilterUsers(int? Type = null, int? Division = null)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("FilterUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Division", Division);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetContactPerson(int? Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetContactPerson", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetEducation(int? Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetEducation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetPaymentTerms()
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetPaymentTerms", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetDesignations()
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetDesignations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetCountry()
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetCountry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }
        public static DataTable GetState()
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetState", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetWorkExperiance(int? @Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetWorkExperiance", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static string CheckUser(string Username, string Password)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("CheckUser", con);
            cmd.Parameters.AddWithValue("@UserId", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.CommandType = CommandType.StoredProcedure;
            string res = "-1";
            try
            {
                con.Open();
                var r = cmd.ExecuteScalar();
                if (r != null)
                {
                    res = r.ToString();
                }
            }
            catch (Exception) { }
            finally { con.Close(); }
            return res;
        }

        public static void AddUpdateContactPerson(int Id, int? ClientId, string Name, int? DesignationId, int? DepartmentId, string Email, string ContactNo, string WhatsAppNo)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("AddUpdateContactPerson", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@ClientId", ClientId);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@DesignationId", DesignationId);
            cmd.Parameters.AddWithValue("@DepartmentId", DepartmentId);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            cmd.Parameters.AddWithValue("@WhatsAppNo", WhatsAppNo);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally { con.Close(); }
        }
        public static void AddMappedcandidate(int? RequestId, int? CandidateId)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("AddMappedcandidate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RequestId", RequestId);
            cmd.Parameters.AddWithValue("@CandidateId", CandidateId);
            cmd.Parameters.AddWithValue("@MappedBy", MyFunctions.GetUid);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally { con.Close(); }
        }

        public static void AddUpdateWorkExperiance(int Id, int? CandidateId, string Organization, string Designation, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("AddUpdateWorkExperiance", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CandidateId", CandidateId);
            cmd.Parameters.AddWithValue("@Organization", Organization);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally { con.Close(); }
        }

        public static void AddUpdateEducation(int Id, int? CandidateId, int DegreeId, string Specilization, int? UniversityId, string SchoolName, DateTime Startdate, DateTime Enddate)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("AddUpdateEducation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CandidateId", CandidateId);
            cmd.Parameters.AddWithValue("@DegreeId", DegreeId);
            cmd.Parameters.AddWithValue("@Specilization", Specilization);
            cmd.Parameters.AddWithValue("@UniversityId", UniversityId);
            cmd.Parameters.AddWithValue("@SchoolName", SchoolName);
            cmd.Parameters.AddWithValue("@Startdate", Startdate);
            cmd.Parameters.AddWithValue("@Enddate", Enddate);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally { con.Close(); }
        }

        public static void DeleteContactPersons(string Ids)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("DeleteContactPersons", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ids", Ids);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally { con.Close(); }
        }

        public static void DeleteEducation(string Ids)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("DeleteEducation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ids", Ids);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally { con.Close(); }
        }

        public static void DeleteWorkExperiance(string Ids)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("DeleteWorkExperiance", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ids", Ids);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally { con.Close(); }
        }

        public static DataTable GetClientContactPerson(int? ClientId)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetClientContactPerson", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", ClientId);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetSkillbyId(int? Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetSkillbyId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetContactPersonbyClientId(int? Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetContactPersonbyClientId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetClientDetailsById(int? Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetClientDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }

        public static DataTable GetContactPersonById(int? Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetContactPersonById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;

        }



        public static string GenerateSkillCode(int? SubjectId, int? LevelId, int? AffId = null)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GenerateSkillCode", con);
            cmd.Parameters.AddWithValue("@SubjectId", SubjectId);
            cmd.Parameters.AddWithValue("@LevelId", LevelId);
            cmd.Parameters.AddWithValue("@AffId", AffId);
            cmd.CommandType = CommandType.StoredProcedure;
            string res = "-1";

            try
            {
                con.Open();
                var r = cmd.ExecuteScalar();
                if (r != null)
                {
                    res = r.ToString();
                }
            }
            catch (Exception) { }
            finally { con.Close(); }
            return res;
        }


        public static DataSet GetCandidateDataTables(int? CandidateId)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("GetCandidateDataTables", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CandidateId", CandidateId);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(ds);
            }
            catch (Exception) { }
            return ds;

        }

        public static string ChangePassword(string Password, string NewPassword)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("ChangePassword", con);
            cmd.Parameters.AddWithValue("@Id", MyFunctions.GetUid);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@NewPassword", NewPassword);
            cmd.CommandType = CommandType.StoredProcedure;
            string res = "0";
            try
            {
                con.Open();
                var r = cmd.ExecuteScalar();
                if (r != null)
                    res = r.ToString();
            }
            catch (Exception) { }
            finally { con.Close(); }
            return res;
        }
    }
}
