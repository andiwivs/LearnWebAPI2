using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnWebAPI2.API.Controllers
{
    public class ExpenseGroupsController : ApiController
    {

        //IExpenseGroupRepository expenseGroupRepository

        //public ExpenseGroupsController(IExpenseGroupRepository expenseGroupRepository)
        //{
        //    _expenseGroupRepository = expenseGroupRepository;
        //}

        public IHttpActionResult Get()
        {
            try
            {
                //var expenseGroups = _repository.GetExpenseGroups().ToList();
                string expenseGroups = "TODO: implement expense groups repo";

                return Ok(expenseGroups);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
