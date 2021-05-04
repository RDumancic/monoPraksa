using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace day2.WebApi.Controllers
{
    public class DataContainer
    {
        private int id;
        private string name;

        public DataContainer(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }

    public class DataController : ApiController
    {
        private static List<DataContainer> storedData = new List<DataContainer>();

        [HttpGet]
        public HttpResponseMessage GetObject(int id)
        {
            foreach (DataContainer dat in storedData)
            {
                if (id == dat.Id)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, dat);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No object with that id exists");
        }

        [HttpPost]
        public HttpResponseMessage InsertData([FromBody]DataContainer data)
        {
            if(data.Id < 1 || data.Name == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Wrong input");
            }
            foreach(DataContainer dat in storedData)
            {
                if(data.Id == dat.Id)
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "There is already a user with that id");
                }
            }
            storedData.Add(data);
            return Request.CreateResponse(HttpStatusCode.OK, "Insert Successful");
        }

        [HttpPut]
        public HttpResponseMessage UpdateData(int id, [FromBody]DataContainer newData)
        {
            foreach (DataContainer dat in storedData)
            {
                if (id == dat.Id)
                {
                    dat.Id = newData.Id;
                    dat.Name = newData.Name;
                    return Request.CreateResponse(HttpStatusCode.OK, dat);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "User with that id doesn't exist");
        }

        [HttpDelete]
        public HttpResponseMessage DeleteData(int id)
        {
            
            foreach (DataContainer dat in storedData)
            {
                if (id == dat.Id)
                {
                    storedData = storedData.Where(data => data.Id != id).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, "Deletion Successful");
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No object with that id exists");
        }

    }
}
