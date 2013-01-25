using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models {
    public class FlexibleDiscountHelper : IDiscountHelper {

        //applies different discounts based on the magnitude of the total being discounted
        public decimal ApplyDiscount( decimal totalParam ) {
            decimal discount = totalParam > 100 ? 70 : 25;
            return ( totalParam - ( discount / 100m * totalParam ) );
        }

    }
}