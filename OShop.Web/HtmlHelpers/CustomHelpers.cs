using System;
using System.Globalization;
using System.Text;
using System.Web.Mvc;

namespace OShop.Web.HtmlHelpers
{
    public static class CustomHelpers
    {
        // Formats amount with group separator and adds kr.
        public static string FormatAmount(this HtmlHelper html, int amount)
        {
            if(amount == 0)
            {
                return "";
            }
            else
            {
                var nfi = new NumberFormatInfo { NumberGroupSeparator = " " };
                string result = amount.ToString("#,0", nfi);

                return result + " kr";
            }

        }

        // 
        public static string FormatCartItems(this HtmlHelper html, int items)
        {
            if (items == 1)
            {
                return " (" + items.ToString() + " vara)";
            }
            else if (items > 1)
            {
                return " (" + items.ToString() + " varor)";
            }
            else return "";
        }


        // Returns classname depending on orderStatus
        public static string FormatFromOrderStatus (this HtmlHelper html, int orderStatus)
        {
            string className;

            switch(orderStatus)
            {
                case -1:
                    className = "order-rejected";
                    break;
                case 1:
                    className = "order-submitted";
                    break;
                default:
                    className = "order-pending";
                    break;
            }

            return className;
        }

        // Returns imagenames according to orderstatus
        public static string OrderStatusImageCreator(this HtmlHelper html, int orderStatus)
        {
            string imageName = "/Content/Images/os" + orderStatus + ".png";
            return imageName;
        }
    }
}
