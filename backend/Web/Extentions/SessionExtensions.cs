﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Extentions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {

            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }

        public static void SetShoppingCart(this ISession session, string key, List<OrderLineDTO> value)
        {

            foreach (var item in value)
            {
                if (item.Order != null)
                {
                    // So the reference does not loop
                    item.Order.OrderLines = null;
                }

            }
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static List<OrderLineDTO> GetShoppingCart(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(List<OrderLineDTO>) :
                JsonConvert.DeserializeObject<List<OrderLineDTO>>(value);
        }
    }

}
