using MidTrans.Core.Models;
using Newtonsoft.Json;

namespace MidTrans.Core.Adapter
{
    public class BodyRequestAdapter : BaseAdapter<BodyRequest>
    {
        private static BodyRequestAdapter instance;

        public static BodyRequestAdapter Instance
        {
            get
            {
                return instance = instance ?? new BodyRequestAdapter();
            }
        }
    }
}
