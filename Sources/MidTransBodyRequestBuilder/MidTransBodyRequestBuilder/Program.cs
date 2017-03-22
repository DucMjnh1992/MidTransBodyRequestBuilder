using MidTrans.Core.Builder;
using MidTrans.Core.Models;
using System.Collections.Generic;

namespace MidTransBodyRequestBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            BodyRequest bodyRequest = BodyRequestBuilder
                .CreateInstance()
                .SetTransactionDetail(TransactionDetailBuilder
                    .CreateInstance()
                    .SetOrderId("ORDER-101")
                    .SetGrossAmount(10)
                    .Build()
                )
                .AddItemToItemDetailsUnique(ItemDetailBuilder
                    .CreateInstance()
                    .SetId("ITEM1")
                    .SetPrice(10)
                    .SetQuantity(1)
                    .SetName("Midtrans Bear")
                    .Build()
                )
                .AddItemToEnabledPaymentsUnique("credit_card")
                .AddItemToEnabledPaymentsUnique("mandiri_clickpay")
                .SetCreditCard(CreditCardBuilder.CreateInstance()
                    .SetSecure(true)
                    .SetChannel("migs")
                    .SetBank("bca")
                    .SetInstallment(InstallmentBuilder
                        .CreateInstance()
                        .SetRequired(false)
                        .SetTerm(TermBuilder
                            .CreateInstance()
                            .AddItemToBnisUnique("3")
                            .AddItemToBnisUnique("6")
                            .AddItemToBnisUnique("12")
                            .SetBnis(new List<string>()
                            {
                                "3",
                                "6",
                                "12"
                            })
                            .AddItemToCimbsUnique("3")
                            .AddItemToBcasUnique("3")
                            .AddItemToBcasUnique("6")
                            .AddItemToBcasUnique("12")
                            .AddItemToOfflinesUnique("6")
                            .AddItemToOfflinesUnique("12")
                            .Build()
                        )
                        .Build()
                    )
                    .AddItemToWhitelistBinsUnique("48111111")
                    .AddItemToWhitelistBinsUnique("41111111")
                    .Build()
                )
                .SetCustomerDetail(CustomerDetailBuilder
                    .CreateInstance()
                    .SetFirstName("TEST")
                    .SetLastName("MIDTRANSER")
                    .SetEmail("test@midtrans.com")
                    .SetPhone("+628123456")
                    .SetBillingAddress(AddressDetailBuilder
                        .CreateInstance()
                        .SetFirstName("TEST")
                        .SetLastName("MIDTRANSER")
                        .SetEmail("test@midtrans.com")
                        .SetPhone("081 2233 44-55")
                        .SetAddress("Sudirman")
                        .SetCity("Jakarta")
                        .SetPostalCode("12190")
                        .SetCountryCode("IDN")
                        .Build()
                    )
                    .SetBillingAddress(AddressDetailBuilder
                        .CreateInstance()
                        .SetFirstName("TEST")
                        .SetLastName("MIDTRANSER")
                        .SetEmail("test@midtrans.com")
                        .SetPhone("0 8128-75 7-9338")
                        .SetAddress("Sudirman")
                        .SetCity("Jakarta")
                        .SetPostalCode("12190")
                        .SetCountryCode("IDN")
                        .Build()
                    )
                    .Build()
                )
                .SetExpiry(ExpiryBuilder
                    .CreateInstance()
                    .SetStartTime("2017-04-13 18:11:08 +0700")
                    .SetUnit("minutes")
                    .SetDuration(1)
                    .Build()
                 )
                .Build();
        }
    }
}