using Newtonsoft.Json;

namespace MidTrans.Core.Adapter
{
    public abstract class BaseAdapter<T>
    {
        public virtual T ConvertFromJson(string json)
        {
            T result = JsonConvert.DeserializeObject<T>(json);

            return result;
        }

        public virtual string ConvertToJson(T model)
        {
            string json = JsonConvert.SerializeObject(model);

            return json;
        }
    }
}
