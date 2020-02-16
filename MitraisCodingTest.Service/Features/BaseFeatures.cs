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
    public abstract class BaseFeatures<T> where T:class
    {
        protected DB_MitraisCodingTestEntities context { get; set; }

        public BaseFeatures()
        {
            this.context = Utilities.GetDataContext();
        }

        public virtual ResponseMessageModel Save(T Model) { return null; }
        public virtual ResponseMessageModel Validate(T Model) { return null; }

        
    }
}
