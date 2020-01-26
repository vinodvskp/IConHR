//-----------------------------------------------------------------------
// <copyright file="ICONHRModel.cs" company="ICON Software pvt Ltd.">
//     Copyright (c) ICON Software pvt Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    ///<summary>
    ///ICONHR Model
    ///</summary>  
    public class AddressDetails
    {
        /// <summary>
        /// Gets or sets Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets Postal Code 
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets Country ID
        /// </summary>
        public int Country_ID { get; set; }

        /// <summary>
        /// Gets or sets Address
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        public string BillingEmail { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumber
        /// </summary>
        public string BillingPhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets Created By
        /// </summary>
        public string Created_By { get; set; }

        /// <summary>
        /// Gets or sets Last Updated By
        /// </summary>
        public string Last_Updated_By { get; set; }

        /// <summary>
        /// Gets or sets Employee ID
        /// </summary>
        public int Emp_ID { get; set; }
    }

    public class CountryDetails
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

    }
    public class CreditCardDetails : AddressDetails
    {
        /// <summary>
        /// Gets or sets Card Holder
        /// </summary>
        public string CardHolder { get; set; }

        /// <summary>
        /// Gets or sets CardNumber  
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets Card Type  
        /// </summary>
        public int CardTypeID { get; set; }

        /// <summary>
        /// Gets or sets CVV 
        /// </summary>
        public int CVV { get; set; }

        /// <summary>
        /// Gets or sets Card Expire Month ID
        /// </summary>
        public int Card_Exp_Month_ID { get; set; }

        /// <summary>
        /// Gets or sets Card Expire Year ID
        /// </summary>
        public int Card_Exp_Year_ID { get; set; }
  
        /// <summary>
        /// Gets or sets Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets Gateway Token ID
        /// </summary>
        public string GatewayToken_ID { get; set; }
    }

    public class EmployeeDetails : AddressDetails
    {
        /// <summary>
        /// Gets or sets Employee Name
        /// </summary>
        public string Emp_Name { get; set; }

        /// <summary>
        /// Gets or sets Employee Role
        /// </summary>
        public int Emp_Role { get; set; }

        /// <summary>
        /// Gets or sets Company ID
        /// </summary>
        public int Company_ID { get; set; }

        /// <summary>
        /// Gets or sets Company Name
        /// </summary>
        public string Company_Name { get; set; }

        /// <summary>
        /// Gets or sets Company Size
        /// </summary>
        public string Company_Size { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Password Token
        /// </summary>
        public string PasswordToken { get; set; }

        /// <summary>
        /// Gets or sets Password Salt
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets Password Hash
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets DOB
        /// </summary>
        public string DOB { get; set; }

        /// <summary>
        /// Gets or sets ProfilePhoto
        /// </summary>
        public byte[] ProfilePhoto { get; set; }
    }
  }
