using MitraisCodingTest.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MitraisCodingTest.Service.Features
{
    public class RegistrationValidation:BaseFeatures<RegistrationModel>
    {
      

        public override ResponseMessageModel Validate(RegistrationModel regist)
        {
            var response = new ResponseMessageModel();
            IList<string> errorFields = new List<string>();
            if (String.IsNullOrEmpty(regist.MobileNo) || String.IsNullOrWhiteSpace(regist.MobileNo))
            {
                errorFields.Add("Mobile No");
            }
            else
            {
                if(!Regex.IsMatch(regist.MobileNo, @"\+?([ -]?\d+)+|\(\d+\)([ -]\d+)"))
                {
                    errorFields.Add("Mobile No");
                }
            }
            if (String.IsNullOrEmpty(regist.FirstName) || String.IsNullOrWhiteSpace(regist.FirstName))
            {
                errorFields.Add("First Name");
            }
            if (String.IsNullOrEmpty(regist.LastName) || String.IsNullOrWhiteSpace(regist.LastName))
            {
                errorFields.Add("Last Name");
            }

            if (String.IsNullOrEmpty(regist.Email) || String.IsNullOrWhiteSpace(regist.Email))
            {
                errorFields.Add("Email");
            }
            else if (!Regex.IsMatch(regist.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}"))
            {
                errorFields.Add("Email");
            }

            if (errorFields.Any())
            {
                response.Code = "E";
                response.Message = "Error occured";
                response.Description = $"Validation Error for following fields : { String.Join(",", errorFields)}";
                return response;
            }
            if (validateEmail(regist.Email))
            {
                response.Code = "E";
                response.Message = "Error occured";
                response.Description = $"Email already exist, please use another";
                return response;
            }

            

            if (validateMobileNo(regist.MobileNo))
            {
                response.Code = "E";
                response.Message = "Error occured";
                response.Description = $"Mobile No exist, please use another";
                return response;
            }

            response.Code = "S";
            response.Message = "SUCCESS";
            response.Description = "VAIDATION SUCCESS";

            return response;
        }

        

        private bool validateEmail(string email)
        {
            return context.tblT_Registrasi.Any(x => x.Email == email);
        }
        private bool validateMobileNo(string mobileNo)
        {
            return context.tblT_Registrasi.Any(x => x.MobileNo == mobileNo);
        }
    }
}
