//-----------------------------------------------------------------------
//<copyright file="ICONHRRepository.cs" company="ICON Software pvt Ltd.">
// Copyright (c) ICON Software Pvt Ltd.All rights reserved.
//</copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ICONHRPortal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONHRPortal.Data
{
    /// <summary>
    /// ICON HR Repository
    /// </summary>
    public class ICONHRRepository
    {
        /// <summary>
        /// SQL Connection Strings
        /// </summary>
        /// 
        private SqlConnection sqlConn;

        #region Variables
        string responseMsg = string.Empty;
        #endregion

        public ICONHRRepository()
        {
            string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());
            this.sqlConn = new SqlConnection(connectionString);
        }

        ///<summary>To check email id exists or not</summary>
        ///<param name="empmodel">EmpModel class</param>
        /// <returns>Returns success message</returns>
        public string CheckEmailId(EmployeeDetails empmodel)
        {
            responseMsg = string.Empty;

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spCheckEmailID", this.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@EmailID", SqlDbType.NVarChar).Value = empmodel.Email;
                sqlCmd.Parameters.Add("@ResponseMsg", SqlDbType.NVarChar, 2000).Direction = ParameterDirection.Output;
                sqlCmd.ExecuteNonQuery();
                responseMsg = Convert.ToString(sqlCmd.Parameters["@ResponseMsg"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return responseMsg;
        }

        ///<summary>To add employee details</summary>
        ///<param name="empmodel">EmpModel class</param>
        /// <returns>Returns success message</returns>
        public string AddNewEmpDetails(EmployeeDetails empmodel)
        {
            responseMsg = string.Empty;

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spAddEmployeeDetails", this.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value =empmodel.Emp_Name;
                sqlCmd.Parameters.Add("@EmpRoleID", SqlDbType.Int).Value = empmodel.Emp_Role;
                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empmodel.Email;
                sqlCmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = empmodel.PhoneNumber;
                sqlCmd.Parameters.Add("@PasswordSalt", SqlDbType.NVarChar).Value = empmodel.PasswordSalt;
                sqlCmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar).Value = empmodel.PasswordHash;                        
                sqlCmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = empmodel.Company_Name;
                sqlCmd.Parameters.Add("@CompanySize", SqlDbType.NVarChar).Value = empmodel.Company_Size;             
                sqlCmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = empmodel.Gender;
                sqlCmd.Parameters.Add("@DateOfBirth", SqlDbType.NVarChar).Value = empmodel.DOB;
                sqlCmd.Parameters.Add("@ProfilePhoto", SqlDbType.Image).Value = empmodel.ProfilePhoto;
                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empmodel.Address;
                sqlCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = empmodel.Country_ID;
                sqlCmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar).Value = empmodel.PostalCode;
                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = empmodel.Created_By;
                sqlCmd.Parameters.Add("@ResponseMsg", SqlDbType.NVarChar, 2000).Direction = ParameterDirection.Output;
                sqlCmd.ExecuteNonQuery();
                responseMsg = Convert.ToString(sqlCmd.Parameters["@ResponseMsg"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return responseMsg;
        }

        public List<CountryDetails> getCountryDetails()
        {
            List<CountryDetails> countries = new List<CountryDetails>();

            try
            {
                SqlConnection sqlConn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["SqlConn"].ToString()));
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetCountryDetails",sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                using (SqlDataReader sdr = sqlCmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        countries.Add(new CountryDetails
                        {
                            CountryId = Convert.ToInt32(sdr["CountryId"]),
                            CountryName = sdr["CountryName"].ToString()
                        });
                    }
                }
               // sqlAdp.Fill(dt_CountryDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return countries;
        }
        public string UpdateEmpDetailsByEmpId(EmployeeDetails empmodel)
        {
            responseMsg = string.Empty;

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spUpdateEmployeeDetails", this.sqlConn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCmd.Parameters.Add("@EmpId", SqlDbType.NVarChar).Value = empmodel.Emp_ID;
                sqlCmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = empmodel.Emp_Name;
                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empmodel.Email;
                sqlCmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = empmodel.PhoneNumber;
                sqlCmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = empmodel.Gender;
                sqlCmd.Parameters.Add("@DateOfBirth", SqlDbType.NVarChar).Value = empmodel.DOB;
                sqlCmd.Parameters.Add("@ProfilePhoto", SqlDbType.Image).Value = empmodel.ProfilePhoto;
                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empmodel.Address;
                sqlCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = empmodel.Country_ID;
                sqlCmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar).Value = empmodel.PostalCode;
                sqlCmd.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar).Value = empmodel.Emp_Name;
                sqlCmd.Parameters.Add("@ResponseMsg", SqlDbType.NVarChar, 2000).Direction = ParameterDirection.Output;
                sqlCmd.ExecuteNonQuery();
                responseMsg = Convert.ToString(sqlCmd.Parameters["@ResponseMsg"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return responseMsg;
        }
        ///<summary>To add credit card details</summary>
        ///<param name="creditcardmodel">EmpModel class</param>
        /// <returns>Returns success message</returns>
        public string AddCreditCardDetails(CreditCardDetails ccDetails)
        {
            responseMsg = string.Empty;

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spAddCreditCardDetails", this.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@EmpID", SqlDbType.Int).Value = ccDetails.Emp_ID;
                sqlCmd.Parameters.Add("@CardHolder", SqlDbType.NVarChar).Value = ccDetails.CardHolder;
                sqlCmd.Parameters.Add("@CardType", SqlDbType.Int).Value = ccDetails.CardTypeID;
                sqlCmd.Parameters.Add("@CardNumber", SqlDbType.NVarChar).Value = ccDetails.CardNumber;
                sqlCmd.Parameters.Add("@CardExpMonth", SqlDbType.Int).Value = ccDetails.Card_Exp_Month_ID;
                sqlCmd.Parameters.Add("@CardExpYear", SqlDbType.Int).Value = ccDetails.Card_Exp_Year_ID;
                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = ccDetails.Created_By;
                sqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ccDetails.Name;
                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = ccDetails.Address;
                sqlCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = ccDetails.Country_ID;
                sqlCmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar).Value = ccDetails.PostalCode;
                sqlCmd.Parameters.Add("@MobileNumber", SqlDbType.NVarChar).Value = ccDetails.BillingPhoneNumber;
                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = ccDetails.BillingEmail;             
                sqlCmd.Parameters.Add("@ResponseMsg", SqlDbType.NVarChar, 2000).Direction = ParameterDirection.Output;
                sqlCmd.ExecuteNonQuery();
                responseMsg = Convert.ToString(sqlCmd.Parameters["@ResponseMsg"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return responseMsg;
        }

        /// <summary>
        /// To get user login information
        /// </summary>
        /// <param name="empmodel">EmpModel class</param>
        /// <returns>Returns user login information</returns>
        public DataTable GetLoginDetails(EmployeeDetails empmodel)
        {
            DataTable dt_LoginDetails = new DataTable();

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetLoginDetails", this.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID", empmodel.Email == string.Empty ? DBNull.Value : (object)empmodel.Email);
                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                sqlAdp.Fill(dt_LoginDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return dt_LoginDetails;
        }

        /// <summary>
        /// To get user login information
        /// </summary>
        /// <param name="empmodel">EmpModel class</param>
        /// <returns>Returns user login information</returns>
        public DataTable GetLoginDetailsByEmpId(EmployeeDetails empmodel)
        {
            DataTable dt_LoginDetails = new DataTable();

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetLoginDetailsByEmpId", this.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmpID", SqlDbType.Int).Value = empmodel.Emp_ID;
                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                sqlAdp.Fill(dt_LoginDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return dt_LoginDetails;
        }


        public DataTable GetEmployeeDetailsByEmpId(int empId)
        {
            DataTable dt_EmployeeDetails = new DataTable();

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetEmployeeDetailsByEmpId", this.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmpID", SqlDbType.Int).Value = empId;
                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                sqlAdp.Fill(dt_EmployeeDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return dt_EmployeeDetails;
        }

        ///<summary>To check Email Address exists or not</summary>
        ///<param name="empmodel">EmpModel class</param>
        /// <returns>Returns success message</returns>
        public DataTable ForgotPassword(EmployeeDetails empmodel)
        {
            DataTable dt_ForgotPassword = new DataTable();

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spForgotPassword", this.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@EmailID", SqlDbType.NVarChar).Value = empmodel.Email;
                sqlCmd.Parameters.Add("@PasswordToken", SqlDbType.NVarChar).Value = empmodel.PasswordToken;
                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                sqlAdp.Fill(dt_ForgotPassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return dt_ForgotPassword;
        }

        ///<summary>To check password token</summary>
        ///<param name="empmodel">EmpModel class</param>
        /// <returns>Returns success message</returns>
        public string CheckPasswordToken(EmployeeDetails empmodel)
        {
            responseMsg = string.Empty;

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spCheckPasswordToken", this.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@PasswordToken", SqlDbType.NVarChar).Value = empmodel.PasswordToken;
                sqlCmd.Parameters.Add("@ResponseMsg", SqlDbType.NVarChar, 2000).Direction = ParameterDirection.Output;
                sqlCmd.ExecuteNonQuery();
                responseMsg = Convert.ToString(sqlCmd.Parameters["@ResponseMsg"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return responseMsg;
        }

        ///<summary>To reset password</summary>
        ///<param name="empmodel">EmpModel class</param>
        /// <returns>Returns success message</returns>
        public string ResetPassword(EmployeeDetails empmodel)
        {
            responseMsg = string.Empty;

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spResetPassword", this.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empmodel.Email;
                sqlCmd.Parameters.Add("@PasswordSalt", SqlDbType.NVarChar).Value = empmodel.PasswordSalt;
                sqlCmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar).Value = empmodel.PasswordHash;               
                sqlCmd.Parameters.Add("@ResponseMsg", SqlDbType.NVarChar, 2000).Direction = ParameterDirection.Output;
                sqlCmd.ExecuteNonQuery();
                responseMsg = Convert.ToString(sqlCmd.Parameters["@ResponseMsg"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return responseMsg;
        }

        ///<summary>To check old password</summary>
        ///<param name="empmodel">EmpModel class</param>
        /// <returns>Returns success message</returns>
        public DataTable GetOldPassword(EmployeeDetails empmodel)
        {
            DataTable dt_OldPwdDetails = new DataTable();

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetOldPassword", this.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@EmpID", SqlDbType.Int).Value = empmodel.Emp_ID;
                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                sqlAdp.Fill(dt_OldPwdDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return dt_OldPwdDetails;
        }

        ///<summary>To change password</summary>
        ///<param name="empmodel">EmpModel class</param>
        /// <returns>Returns success message</returns>
        public string ChangePassword(EmployeeDetails empmodel)
        {
            responseMsg = string.Empty;

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spChangePassword", this.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@EmpID", SqlDbType.Int).Value = empmodel.Emp_ID;
                sqlCmd.Parameters.Add("@PasswordSalt", SqlDbType.NVarChar).Value = empmodel.PasswordSalt;
                sqlCmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar).Value = empmodel.PasswordHash;
                sqlCmd.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar).Value = empmodel.Last_Updated_By;
                sqlCmd.Parameters.Add("@ResponseMsg", SqlDbType.NVarChar, 2000).Direction = ParameterDirection.Output;
                sqlCmd.ExecuteNonQuery();
                responseMsg = Convert.ToString(sqlCmd.Parameters["@ResponseMsg"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return responseMsg;
        }

        ///<summary>To get country month year details</summary>
        /// <returns>Returns Country Month Year Details</returns>
        public DataSet GetCountryAndCardDetails()
        {
            DataSet ds_CountryAndCardDetails = new DataSet();

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spCountryAndCardDetails", this.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                sqlAdp.Fill(ds_CountryAndCardDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return ds_CountryAndCardDetails;
        }

        ///<summary>To get Department, Job Roles and Reporting Manager details</summary>
        /// <returns>Returns Country Month Year Details</returns>
        public DataSet GetDeptJobRolesRpMgrDetails()
        {
            DataSet ds_DeptJobRolesRpMgrDetails = new DataSet();

            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetDeptJobRolesRpMgrDetails", this.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                sqlAdp.Fill(ds_DeptJobRolesRpMgrDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return ds_DeptJobRolesRpMgrDetails;
        }

        public byte[] GetProfileImageById(int employeeId)
        {
            DataSet dt = new DataSet();
            Byte[] tempLogo = null;
            try
            {
                this.sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("select * from tblEmployeeDetails where EmpID="+employeeId, this.sqlConn);
                sqlCmd.CommandType = CommandType.Text;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    tempLogo = (byte[])reader["ProfilePhoto"];
                    //tempLogo = Encoding.ASCII.GetBytes(reader.GetByte(["ProfilePhoto"].ToString()); //Convert.(reader["ProfilePhoto"].ToString());
                }
                this.sqlConn.Close();
                
                //sqlCmd.Parameters.Add("@EmpID", SqlDbType.Int).Value = employeeId;
                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                sqlAdp.Fill(dt);
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sqlConn.Close();
                this.sqlConn.Dispose();
            }

            return tempLogo;
        }
    }
}