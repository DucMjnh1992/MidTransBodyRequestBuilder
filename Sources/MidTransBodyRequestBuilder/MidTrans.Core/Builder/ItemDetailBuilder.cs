using MidTrans.Core.Models;

namespace MidTrans.Core.Builder
{
    public class ItemDetailBuilder : BaseBuilder<ItemDetail>, IBuilder<ItemDetail>
    {
        private string id;
        private int price;
        private int quantity;
        private string name;

        public ItemDetailBuilder()
            : base(null)
        {
        }

        public ItemDetailBuilder(ItemDetail model)
            : base(model)
        {            
        }

        public static ItemDetailBuilder CreateInstance()
        {
            return new ItemDetailBuilder();
        }

        public static ItemDetailBuilder CreateInstance(ItemDetail model)
        {
            return new ItemDetailBuilder(model);
        }

        public ItemDetailBuilder SetModel(ItemDetail model)
        {
            this.model = model;

            return this;
        }

        public ItemDetailBuilder SetId(string id)
        {
            this.id = id;

            return this;
        }

        public ItemDetailBuilder SetPrice(int price)
        {
            this.price = price;

            return this;
        }        
        
        public ItemDetailBuilder SetQuantity(int quantity)
        {
            this.quantity = quantity;

            return this;
        }

        public ItemDetailBuilder SetName(string name)
        {
            this.name = name;

            return this;
        }
        
        public override ItemDetail Build()
        {
            this.model = this.model ?? new ItemDetail();

            this.model.Id = this.id;
            this.model.Price = this.price;
            this.model.Quantity = this.quantity;
            this.model.Name = this.name;

            return this.model;
        }
    }
}
