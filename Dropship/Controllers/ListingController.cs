using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dropship.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Dropship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private XDocument getDoc()
        {
            return XDocument.Load("..\\assets\\XMLFile.xml");\
        }
        // GET: api/Listing/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            var xml = getDoc();
            var query = from x in xml.Root.Descendants("listing")
                        where (int)x.Attribute("ID") == id
                        select x;
            if (query.Any() && query.Count() == 1)
            {
                var attr = query.First();
                try
                {
                    var listing = new Listing
                    {
                        Title = attr.Elements("Title").First().Value,
                        Description = attr.Elements("Description").First().Value,
                        ID = id,
                        BasePrice = Convert.ToDecimal(attr.Elements("BasePrice").First().Value)
                    };
                    return JsonSerializer.Serialize(listing, typeof(Listing));
                }
                catch (FormatException e)
                {
                    return JsonSerializer.Serialize(new Listing { Title = "Server Error", Description = $"Server error. Please email us at <SET EMAIL>, with this info: {e.Message}, and {id}" }, typeof(Listing));
                }
            }
            else
            {
                return JsonSerializer.Serialize(new Listing { Title = "Multiple Listings with id", Description = $"Please email us at <SET EMAIL>, with this info: Multiple listings under same ID, {id}" }, typeof(Listing));
            }
        }

        // POST: api/Listing
        [HttpPost]

        // PUT: api/Listing/5
        [Authorize(Roles = "Poster, Administrator")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var xml = getDoc();
            var vals = JsonSerializer.Deserialize<Listing>(value);
            if (vals != null)
            {
                var lstng = new XElement("Listing", new XAttribute("ID", id),
                    new XElement("Title", vals.Title),
                    new XElement("Description", vals.Description),
                    new XElement("BasePrice", vals.BasePrice.ToString()));
                xml.Root.Add(lstng);
            }
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
