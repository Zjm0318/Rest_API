using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Newtonsoft.Json;

namespace IOT_Rest_Common
{
    public class ListClass
    {
        public List<T> GetDataList<T>(DataTable tb) where T : class, new()
        {
            return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(tb));
        }

        
    }
}
