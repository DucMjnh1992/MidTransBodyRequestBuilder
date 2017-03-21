using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTransBodyRequestBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}


public class Rootobject
{
    public Transaction_Details transaction_details { get; set; }
    public Item_Details[] item_details { get; set; }
    public string[] enabled_payments { get; set; }
    public Credit_Card credit_card { get; set; }
    public Customer_Details customer_details { get; set; }
    public Expiry expiry { get; set; }
    public string custom_field1 { get; set; }
    public string custom_field2 { get; set; }
    public string custom_field3 { get; set; }
}

public class Transaction_Details
{
    public string order_id { get; set; }
    public int gross_amount { get; set; }
}

public class Credit_Card
{
    public bool secure { get; set; }
    public string channel { get; set; }
    public string bank { get; set; }
    public Installment installment { get; set; }
    public string[] whitelist_bins { get; set; }
}

public class Installment
{
    public bool required { get; set; }
    public Terms terms { get; set; }
}

public class Terms
{
    public int[] bni { get; set; }
    public int[] mandiri { get; set; }
    public int[] cimb { get; set; }
    public int[] bca { get; set; }
    public int[] offline { get; set; }
}

public class Customer_Details
{
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public Billing_Address billing_address { get; set; }
    public Shipping_Address shipping_address { get; set; }
}

public class Billing_Address
{
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string postal_code { get; set; }
    public string country_code { get; set; }
}

public class Shipping_Address
{
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string postal_code { get; set; }
    public string country_code { get; set; }
}

public class Expiry
{
    public string start_time { get; set; }
    public string unit { get; set; }
    public int duration { get; set; }
}

public class Item_Details
{
    public string id { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
    public string name { get; set; }
}
