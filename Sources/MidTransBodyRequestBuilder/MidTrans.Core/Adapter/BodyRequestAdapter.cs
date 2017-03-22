using MidTrans.Core.Models;
using Newtonsoft.Json;

namespace MidTrans.Core.Adapter
{
    public class BodyRequestAdapter
    {
        private static BodyRequestAdapter instance;

        public static BodyRequestAdapter Instance
        {
            get
            {
                return instance = instance ?? new BodyRequestAdapter();
            }
        }
        
        public BodyRequest ConvertFromJson(string json)
        {
            BodyRequest result = JsonConvert.DeserializeObject<BodyRequest>(json);

            return result;
        }

        public string ConvertToJson(BodyRequest model)
        {
            string json = JsonConvert.SerializeObject(model);

            return json;
        }
    }
}
