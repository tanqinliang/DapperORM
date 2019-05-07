using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public readonly Hoyan.Dapper.IRepository.IAdmin_GroupClassRepository adminGroupRepository;
        public ValuesController(Hoyan.Dapper.IRepository.IAdmin_GroupClassRepository _adminGroupRepository)
        {
            adminGroupRepository = _adminGroupRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Hoyan.Dapper.Entity.Admin_GroupClass obj = new Hoyan.Dapper.Entity.Admin_GroupClass();
            //int a =  adminGroupRepository.AddRecord(obj);
            //bool a = adminGroupRepository.DeleteRecord(18);
            //obj.ParentID = 10;
            //obj.Title = 77;
            //obj.ID = 19;
            //bool a = adminGroupRepository.UpdateRecord(obj);
            //List<Hoyan.Dapper.Entity.Admin_GroupClass> list = adminGroupRepository.GetRecordList().ToList();
            //DataTable dt = adminGroupRepository.GetRecordTable();
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    sb.Append(dt.Rows[i]["ID"]+"--"+ dt.Rows[i]["ParentID"]+"--------");
            //}
            //DBAccess.SplitPage<DataTable> page = adminGroupRepository.GetPageTable(1, 4);
            //int a = page.TotalPages;
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //for (int i = 0; i < page.PageData.Rows.Count; i++)
            //{
            //    sb.Append(page.PageData.Rows[i]["ID"] + "-" + page.PageData.Rows[i]["OrderNo"] + "------");
            //}
            List<Hoyan.Dapper.Entity.Admin_GroupClass> list = new List<Hoyan.Dapper.Entity.Admin_GroupClass>();
            for (int i = 0; i < 100; i++)
            {
                Hoyan.Dapper.Entity.Admin_GroupClass obj1 = new Hoyan.Dapper.Entity.Admin_GroupClass()
                {
                    OrderNo = i,
                    ParentID=i,
                    Title=i
                };
                list.Add(obj1);
            }
            adminGroupRepository.AddRecord(list);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
