﻿namespace ShopMicroservices.BasketApi.Application.Models;

public class ShoppingCart
{
    public string UserName { get; set; }
    public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }

    public decimal TotalPrice
    {
        get
        {
            int totalPriceInCents = 0;
            foreach (var item in Items)
            {
                totalPriceInCents += item.PriceInCents * item.quantity;
            }

            return totalPriceInCents/100;
        }
    }


}
