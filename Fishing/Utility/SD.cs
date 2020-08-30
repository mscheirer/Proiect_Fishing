﻿using Fishing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishing.Utility
{
    public class SD
    {
        public const string DefaultFishImage = "default_fisherman.jpg";

        public const string ManagerUser = "Manager";
        public const string KitchenUser = "Sef";
        public const string FrontDeskUser = "Casier";
        public const string CustomerEndUser = "Client";

        public const string ssShoppingCartCount = "ssCartCount";
        public const string ssCouponCode = "ssCouponCode";

        public const string StatusSubmitted = "Comanda Plasata";
        public const string StatusInProcess = "In Procesare";
        public const string StatusReady = "In Verificare";
        public const string StatusCompleted = "Efectuat";
        public const string StatusCancelled = "Anulat";

        public const string PaymentStatusPending = "In asteptare";
        public const string PaymentStatusApproved = "Aprobat";
        public const string PaymentStatusRejected = "Respins";





        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }


        public static double DiscountedPrice(Coupon couponFromDb, double OriginalOrderTotal)
        {
            if (couponFromDb == null)
            {
                return OriginalOrderTotal;
            }
            else
            {
                if (couponFromDb.MinimumAmount > OriginalOrderTotal)
                {
                    return OriginalOrderTotal;
                }
                else
                {
                    //everything is valid
                    if (Convert.ToInt32(couponFromDb.CouponType) == (int)Coupon.ECouponType.Leu)
                    {
                        //10 lei la 100 lei
                        return Math.Round(OriginalOrderTotal - couponFromDb.Discount, 2);
                    }
                    if (Convert.ToInt32(couponFromDb.CouponType) == (int)Coupon.ECouponType.Percent)
                    {
                        //10% din 100 lei
                        return Math.Round(OriginalOrderTotal - (OriginalOrderTotal * couponFromDb.Discount / 100), 2);
                    }
                }
            }
            return OriginalOrderTotal;
        }

    }
}

