using MidTrans.Core.Models;
using Newtonsoft.Json;

namespace MidTrans.Core.Adapter
{
    public class ResponseAdapter : BaseAdapter<Response>
    {
        private static ResponseAdapter instance;

        public static ResponseAdapter Instance
        {
            get
            {
                return instance = instance ?? new ResponseAdapter();
            }
        }
    }
}
