using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DoubleVPartners.Application.Mapper
{
    public static class MappersExtension
    {
        public static T MapToModel<T>(this object value) => JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(value));
    }
}
