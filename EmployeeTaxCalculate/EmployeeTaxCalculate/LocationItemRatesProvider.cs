using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace EmployeeTaxCalculate
{
    public class LocationItemRatesProvider : ILocationItemRatesProvider_Get, ILocationItemRatesProvider_Set
    {
        private static Dictionary<string, IList<ItemRates>> locationItemRatesDictionary = null;

        private  Dictionary<string, IList<ItemRates>> LocationItemRatesDictionary
        {
            get
            {
                if (locationItemRatesDictionary == null)
                {
                    locationItemRatesDictionary = new Dictionary<string, IList<ItemRates>>();
                    locationItemRatesDictionary.Add("Ireland", new[]
                    {
                        new ItemRates("Income Tax",new [] 
                            {
                                new Rate((decimal)0.00,(decimal)600.00,(decimal)25),
                                new Rate((decimal)601.00, decimal.MaxValue,(decimal)40)
                            }),
                        new ItemRates("Universal Social Charge",new[] 
                            {
                                new Rate((decimal)0.00,(decimal)500.00,(decimal)7),
                                new Rate((decimal)501.00, decimal.MaxValue,(decimal)8)
                            }),
                        new ItemRates("Pension",new [] 
                            {
                                new Rate((decimal)0.00,decimal.MaxValue,(decimal)4)
                            })
                    });

                    locationItemRatesDictionary.Add("Italy", new[]
                    {
                        new ItemRates("Income Tax",new [] 
                            {
                                new Rate((decimal)0.00, decimal.MaxValue,(decimal)25)
                            }),
                        new ItemRates("Universal Social Charge",new [] 
                            {
                                new Rate((decimal)0.00,decimal.MaxValue,(decimal)9.19),
                            })
                    });

                    locationItemRatesDictionary.Add("Germany", new[]
                    {
                        new ItemRates("Income Tax",new [] 
                            {
                                new Rate((decimal)0.00,(decimal)400.00,(decimal)25),
                                new Rate((decimal)401.00, decimal.MaxValue,(decimal)32)
                            }),
                        new ItemRates("Pension",new [] 
                            {
                                new Rate((decimal)0.00,decimal.MaxValue,(decimal)2)
                            })
                    });
                }
                return locationItemRatesDictionary;
            }
        }
        /// <summary>
        /// Add rate for a new location or update rate for an existing location.
        /// Can be overwritten.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="itemRates"></param>
        public virtual void SetLocationItemRates(string location, IList<ItemRates> itemRates)
        {
            string newlocation = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(location.ToLower());
            if (LocationItemRatesDictionary.ContainsKey(newlocation))
            {
                locationItemRatesDictionary[newlocation] = itemRates;
            }
            else
                locationItemRatesDictionary.Add(newlocation, itemRates);
        }
        /// <summary>
        /// Check if the rate of the location is defined. 
        /// </summary>
        /// <param name="location">Location Name</param>
        /// <returns>bool</returns>
        public virtual bool IsLocationExisted(string location)
        {
            string newlocation = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(location.ToLower());
            return LocationItemRatesDictionary.ContainsKey(newlocation);
        }
        /// <summary>
        /// Get all Item Rates of the passing location, can be overwritten.
        /// </summary>
        /// <param name="location">Location Name</param>
        /// <returns>IList<ItemRates></returns>
        public virtual IList<ItemRates> GetLocationItemRates(string location)
        {
            IList<ItemRates> itemRates=null;
            if (!string.IsNullOrEmpty(location))
            {
                string newlocation = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(location.ToLower());
                itemRates = LocationItemRatesDictionary.ContainsKey(newlocation) ? LocationItemRatesDictionary[newlocation] : null;
            }
            return itemRates;
        }
    }
}
