using LearnWebAPI2.API.DomainModel;
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

        #region FakeDb

        private static List<ExpenseGroup> _ExpenseGroup = null;

        private static List<ExpenseGroup> ExpenseGroup
        {
            get
            {
                if (_ExpenseGroup == null)
                    _ExpenseGroup = new List<DomainModel.ExpenseGroup>
                    {
                        new ExpenseGroup
                        {
                            Id = 1,
                            Title = "Test group 1",
                            Description = "Description for expense group 1",
                            Expenses = new Expense[0]
                        },
                        new ExpenseGroup
                        {
                            Id = 2,
                            Title = "Test group 2",
                            Description = "Description for expense group 2",
                            Expenses = new Expense[0]
                        },
                        new ExpenseGroup
                        {
                            Id = 3,
                            Title = "Test group 3",
                            Description = "Description for expense group 3",
                            Expenses = new Expense[0]
                        },
                        new ExpenseGroup
                        {
                            Id = 4,
                            Title = "Test group 4",
                            Description = "Description for expense group 4",
                            Expenses = new Expense[0]
                        },
                        new ExpenseGroup
                        {
                            Id = 5,
                            Title = "Test group 5",
                            Description = "Description for expense group 5",
                            Expenses = new Expense[0]
                        }
                    };

                return _ExpenseGroup;
            }
        }

        #endregion

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

                var expenseGroups = ExpenseGroup;

                return Ok(expenseGroups);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var expenseGroup = ExpenseGroup.SingleOrDefault(eg => eg.Id == id);

                if (expenseGroup == null)
                    return NotFound();

                return Ok(expenseGroup);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] ExpenseGroup expenseGroup)
        {
            // TODO: figure out why this doesn't work??!! :(

            try
            {
                if (expenseGroup == null)
                    return BadRequest();
                
                // simulate create
                expenseGroup.Id = ExpenseGroup.Max(eg => eg.Id) + 1;
                ExpenseGroup.Add(expenseGroup); // should return fresh copy of created entity
                bool created = true;

                if (created)
                    return Created($"{Request.RequestUri}/{expenseGroup.Id}", expenseGroup);
                
                return BadRequest();
            }
            catch(Exception)
            {
                return InternalServerError();
            }
        }
    }
}
