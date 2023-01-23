using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingApp.Infrastructure.Interfaces
{
    public interface IAdditionalPropertyProcessor
    {
        public string GetAdditionalPropertyValue(int id);
    }
}
