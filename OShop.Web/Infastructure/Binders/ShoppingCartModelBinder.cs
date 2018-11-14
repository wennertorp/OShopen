﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OShop.Logic.Cart;

namespace OShop.Web.Infastructure.Binders
{
    public class ShoppingCartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Get the Cart from the session
            ShoppingCart cart = null;
            if(controllerContext.HttpContext.Session != null)
            {
                cart = (ShoppingCart)controllerContext.HttpContext.Session[sessionKey];
            }

            // Create the Cart if there wasn't one in the session data
            if (cart == null)
            {
                cart = new ShoppingCart();
                if(controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

            return cart;
        }
   
    }
}