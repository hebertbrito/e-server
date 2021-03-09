﻿using Data.UseCases.Plan;
using Domain.Models.Plan.Request;
using Infra.Database.SQLServer.Plan;
using Infra.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserPlanController : Controller
    {
        [Route("plan/create")]
        [HttpPost]
        public async Task<ActionResult> CreatePlan(PlanModel planModel)
        {
            DatabaseHelperClass databaseHelperClass = new DatabaseHelperClass("Password=123456789;Persist Security Info=True;User ID=sqlserver;Initial Catalog=epharma;Data Source=34.95.222.223");
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Model is Invalid");
                }

                CreatePlanUserRepository createPlanUserRepository = new CreatePlanUserRepository();
                DbCreatePlanUser dbCreatePlanUser = new DbCreatePlanUser(createPlanUserRepository);
            }
            catch (Exception ex)
            {
                databaseHelperClass.connection.Close();
                return StatusCode(500, ex);
            }
        }
    }
}