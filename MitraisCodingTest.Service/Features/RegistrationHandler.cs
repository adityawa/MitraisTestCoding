using AutoMapper;
using MitraisCodingTest.Repository;
using MitraisCodingTest.Service.Common;
using MitraisCodingTest.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitraisCodingTest.Service.Features
{
    public class RegistrationHandler : BaseFeatures<RegistrationModel>
    {
        public override ResponseMessageModel Save(RegistrationModel registrasi)
        {
            var response = new ResponseMessageModel();
            var resp_validate = new RegistrationValidation().Validate(registrasi);
            if (resp_validate != null && resp_validate.Code.ToString() == myEnums.enumStatusCode.S.ToString())
            {

                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var newEntity = Mapper.Map<RegistrationModel, tblT_Registrasi>(registrasi);
                        newEntity.CreatedBy = "SYSTEM";
                        newEntity.CreatedDate = DateTime.Now;
                        newEntity.IsActive = true;
                        context.tblT_Registrasi.Add(newEntity);
                        int result= context.SaveChanges();
                        transaction.Commit();

                        if (result > 0)
                        {
                            response.Code = myEnums.enumStatusCode.S.ToString();
                            response.Message = "Save Successful";
                            response.Description = "Registration Process Successfull";
                        }
                    
                    }

                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        response.Code = myEnums.enumStatusCode.E.ToString();
                        response.Message = "Error Occured";
                        response.Description = ex.Message ?? ex.InnerException.Message;
                    }
                }

                return response;
            }
            else
            {
                return resp_validate;
            }

        }

        public List<RegistrationModel> GetData()
        {
            List<RegistrationModel> ls = new List<RegistrationModel>();
            var get = context.tblT_Registrasi.Where(x => x.IsActive == true);
            foreach(var item in get)
            {
                ls.Add(Mapper.Map<tblT_Registrasi, RegistrationModel>(item));
            }

            return ls;
        }
    }
}
