using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommissionApp.Entities.EntityExtensions
{
    public static class EntityExtensions
    {
        public static T? Copy<T>(this T itemCopy) where T : IEntity
        {
            var json = JsonSerializer.Serialize<T>(itemCopy);


            //return itemCopy;
            return JsonSerializer.Deserialize<T>(json);
        }
    }
    
}
