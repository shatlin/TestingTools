using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing.Models;
using System.Web.Script.Serialization;
using System.Data.Objects.SqlClient;
using Nedbank.Infrastructure.Caching;

namespace Testing.Controllers
{
    public class AllocationController : Controller
    {
        private TestingEntities db = new TestingEntities();

        public List<User> UsersCache()
        {
            MemoryCacheManager Cache = new MemoryCacheManager();
            if (!Cache.IsSet("Users"))
            {
                List<User> users = db.Users.ToList();
                Cache.Set("Users", users, 9999);
                return users;
            }
            return Cache.Get<List<User>>("Users");
        }

        public string GetAllocations()
        {


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<AllocationViewModel> allocationViewModelList = new List<AllocationViewModel>();
            try
            {
                var AllocationQuery =
                        (from testcases in db.TestCases
                         join allocation in db.Allocations
                         on testcases.Id equals allocation.TestCaseId
                         select new
                             {
                                 id = allocation.Id,
                                 User = allocation.ExecutedUser.UserName,
                                 ScenarioName = testcases.ScenarioName,
                                 ScenarioDescription = testcases.ScenarioDescription,
                                 Module = testcases.ModuleId == null ? null : testcases.Module.SystemName,
                                 SystemName = testcases.SystemId == null ? null : testcases.System.SystemName,
                                 PlannedDate = allocation.PlannedDate,
                                 Comments = allocation.Comments,
                                 ReadyForRelease = allocation.ReadyForReleaseList.ReadyForReleaseValue,
                                 ReleasedBy = allocation.ReleasedByUser.UserName,
                                 ReferenceNumber = allocation.ReferenceNumber
                             }).ToList();

                foreach (var allocation in AllocationQuery)
                {
                    allocationViewModelList.Add(new AllocationViewModel
                    {
                        id = allocation.id,
                        User = allocation.User,
                        ScenarioName = allocation.ScenarioName,
                        ScenarioDescription = allocation.ScenarioDescription,
                        Module = allocation.Module,
                        SystemName = allocation.ScenarioName,
                        PlannedDate = allocation.PlannedDate.ToShortDateString(),
                        Comments = allocation.Comments,
                        ReadyForRelease = allocation.ReadyForRelease,
                        ReleasedBy = allocation.ReleasedBy,
                        ReferenceNumber = allocation.ReferenceNumber
                    });
                }

            }
            catch (Exception ex)
            {
            }
            return serializer.Serialize(allocationViewModelList);
        }

        public string GetMCPE()
        {


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<AllocationViewModel> allocationViewModelList = new List<AllocationViewModel>();

            try
            {
                var AllocationQuery =
                        (from testcases in db.TestCases
                         join allocation in db.Allocations
                         on testcases.Id equals allocation.TestCaseId
                         select new
                         {
                             id = allocation.Id,
                             Module = testcases.ModuleId == null ? null : testcases.Module.SystemName,
                             SystemName = testcases.SystemId == null ? null : testcases.System.SystemName,
                             User = allocation.ExecutedUser.UserName,
                             ReadyForRelease = allocation.ReadyForReleaseList.ReadyForReleaseValue,
                             ReleasedBy = allocation.ReleasedByUser.UserName,
                             ReferenceNumber = allocation.ReferenceNumber,
                             DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                             DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                             DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                             CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                             CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                             CreditOrSellAmount = allocation.CreditOrSellAmount,
                             ValueDate = allocation.ValueDate,
                             MCPEResultId = allocation.MCPEResultId,
                             MCPEResult=allocation.MCPE_ResultList.ResultName,
                             MCPEComments=allocation.MCPEComments,
                             ExceptionResult=allocation.ExceptionResultList.ResultName, 
                             ExceptionComments=allocation.ExceptionComments
                         }).ToList();

                foreach (var allocation in AllocationQuery)
                {
                    allocationViewModelList.Add(new AllocationViewModel
                    {
                        id = allocation.id,
                        User = allocation.User,
                        Module = allocation.Module,
                        SystemName=allocation.SystemName,
                        ReadyForRelease = allocation.ReadyForRelease,
                        ReleasedBy = allocation.ReleasedBy,
                        ReferenceNumber = allocation.ReferenceNumber,
                        DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                        DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                        DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                        CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                        CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                        CreditOrSellAmount = allocation.CreditOrSellAmount,
                        ValueDate = allocation.ValueDate.HasValue ? allocation.ValueDate.Value.ToString("dd-MM-yyyy") : null,
                        MCPEResultId = allocation.MCPEResultId,
                        MCPEResult = allocation.MCPEResult,
                        MCPEComments = allocation.MCPEComments,
                        ExceptionResult = allocation.ExceptionResult,
                        ExceptionComments = allocation.ExceptionComments
                    });
                }

            }
            catch (Exception ex)
            {
            }
            return serializer.Serialize(allocationViewModelList);
        }

        public string GetException()
        {


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<AllocationViewModel> allocationViewModelList = new List<AllocationViewModel>();

            try
            {
                var AllocationQuery =
                        (from testcases in db.TestCases
                         join allocation in db.Allocations
                         on testcases.Id equals allocation.TestCaseId
                         select new
                         {
                             id = allocation.Id,
                             Module = testcases.ModuleId == null ? null : testcases.Module.SystemName,
                             SystemName = testcases.SystemId == null ? null : testcases.System.SystemName,
                             User = allocation.ExecutedUser.UserName,
                             ReadyForRelease = allocation.ReadyForReleaseList.ReadyForReleaseValue,
                             ReleasedBy = allocation.ReleasedByUser.UserName,
                             ReferenceNumber = allocation.ReferenceNumber,
                             DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                             DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                             DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                             CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                             CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                             CreditOrSellAmount = allocation.CreditOrSellAmount,
                             ValueDate = allocation.ValueDate,
                             ExceptionResultId = allocation.ExceptionResultId,
                             MCPEResult = allocation.MCPE_ResultList.ResultName,
                             MCPEComments = allocation.MCPEComments,
                             ExceptionResult = allocation.ExceptionResultList.ResultName,
                             ExceptionComments = allocation.ExceptionComments
                         }).ToList();

                foreach (var allocation in AllocationQuery)
                {
                    allocationViewModelList.Add(new AllocationViewModel
                    {
                        id = allocation.id,
                        User = allocation.User,
                        Module = allocation.Module,
                        SystemName = allocation.SystemName,
                        ReadyForRelease = allocation.ReadyForRelease,
                        ReleasedBy = allocation.ReleasedBy,
                        ReferenceNumber = allocation.ReferenceNumber,
                        DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                        DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                        DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                        CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                        CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                        CreditOrSellAmount = allocation.CreditOrSellAmount,
                        ValueDate = allocation.ValueDate.HasValue ? allocation.ValueDate.Value.ToString("dd-MM-yyyy") : null,
                        ExceptionResultId = allocation.ExceptionResultId,
                        MCPEResult = allocation.MCPEResult,
                        MCPEComments = allocation.MCPEComments,
                        ExceptionResult = allocation.ExceptionResult,
                        ExceptionComments = allocation.ExceptionComments
                    });
                }

            }
            catch (Exception ex)
            {
            }
            return serializer.Serialize(allocationViewModelList);
        }

        public string GetGL()
        {


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<AllocationViewModel> allocationViewModelList = new List<AllocationViewModel>();

            try
            {
                var AllocationQuery =
                        (from testcases in db.TestCases
                         join allocation in db.Allocations
                         on testcases.Id equals allocation.TestCaseId
                         select new
                         {
                             id = allocation.Id,
                             Module = testcases.ModuleId == null ? null : testcases.Module.SystemName,
                             SystemName = testcases.SystemId == null ? null : testcases.System.SystemName,
                             User = allocation.ExecutedUser.UserName,
                             ReadyForRelease = allocation.ReadyForReleaseList.ReadyForReleaseValue,
                             ReleasedBy = allocation.ReleasedByUser.UserName,
                             ReferenceNumber = allocation.ReferenceNumber,
                             DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                             DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                             DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                             CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                             CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                             CreditOrSellAmount = allocation.CreditOrSellAmount,
                             ValueDate = allocation.ValueDate,
                             GLResultId = allocation.GLResultId,
                             GLResult = allocation.GL_ResultList.ResultName,
                             GLComments = allocation.GLComments
                         }).ToList();

                foreach (var allocation in AllocationQuery)
                {
                    allocationViewModelList.Add(new AllocationViewModel
                    {
                        id = allocation.id,
                        User = allocation.User,
                        Module = allocation.Module,
                        SystemName = allocation.SystemName,
                        ReadyForRelease = allocation.ReadyForRelease,
                        ReleasedBy = allocation.ReleasedBy,
                        ReferenceNumber = allocation.ReferenceNumber,
                        DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                        DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                        DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                        CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                        CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                        CreditOrSellAmount = allocation.CreditOrSellAmount,
                        ValueDate = allocation.ValueDate.HasValue ? allocation.ValueDate.Value.ToString("dd-MM-yyyy") : null,
                        GLResultId = allocation.GLResultId,
                        GLResult = allocation.GLResult,
                        GLComments = allocation.GLComments
                    });
                }

            }
            catch (Exception ex)
            {
            }
            return serializer.Serialize(allocationViewModelList);
        }

        public string GetFinSurv()
        {


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<AllocationViewModel> allocationViewModelList = new List<AllocationViewModel>();

            try
            {
                var AllocationQuery =
                        (from testcases in db.TestCases
                         join allocation in db.Allocations
                         on testcases.Id equals allocation.TestCaseId
                         select new
                         {
                             id = allocation.Id,
                             Module = testcases.ModuleId == null ? null : testcases.Module.SystemName,
                             SystemName = testcases.SystemId == null ? null : testcases.System.SystemName,
                             User = allocation.ExecutedUser.UserName,
                             ReadyForRelease = allocation.ReadyForReleaseList.ReadyForReleaseValue,
                             ReleasedBy = allocation.ReleasedByUser.UserName,
                             ReferenceNumber = allocation.ReferenceNumber,
                             DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                             DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                             DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                             CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                             CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                             CreditOrSellAmount = allocation.CreditOrSellAmount,
                             ValueDate = allocation.ValueDate,
                             FinSurvResultId = allocation.FinSurvResultId,
                             FinSurvResult = allocation.FinSurvResultList.ResultName,
                             FinSurvComments = allocation.FinSurvComments
                         }).ToList();

                foreach (var allocation in AllocationQuery)
                {
                    allocationViewModelList.Add(new AllocationViewModel
                    {
                        id = allocation.id,
                        User = allocation.User,
                        Module = allocation.Module,
                        SystemName = allocation.SystemName,
                        ReadyForRelease = allocation.ReadyForRelease,
                        ReleasedBy = allocation.ReleasedBy,
                        ReferenceNumber = allocation.ReferenceNumber,
                        DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                        DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                        DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                        CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                        CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                        CreditOrSellAmount = allocation.CreditOrSellAmount,
                        ValueDate = allocation.ValueDate.HasValue ? allocation.ValueDate.Value.ToString("dd-MM-yyyy") : null,
                        FinSurvResultId = allocation.FinSurvResultId,
                        FinSurvResult = allocation.FinSurvResult,
                        FinSurvComments = allocation.FinSurvComments
                    });
                }

            }
            catch (Exception ex)
            {
            }
            return serializer.Serialize(allocationViewModelList);
        }

        public string GetWSS()
        {


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<AllocationViewModel> allocationViewModelList = new List<AllocationViewModel>();

            try
            {
                var AllocationQuery =
                        (from testcases in db.TestCases
                         join allocation in db.Allocations
                         on testcases.Id equals allocation.TestCaseId
                         select new
                         {
                             id = allocation.Id,
                             Module = testcases.ModuleId == null ? null : testcases.Module.SystemName,
                             SystemName = testcases.SystemId == null ? null : testcases.System.SystemName,
                             User = allocation.ExecutedUser.UserName,
                             ReadyForRelease = allocation.ReadyForReleaseList.ReadyForReleaseValue,
                             ReleasedBy = allocation.ReleasedByUser.UserName,
                             ReferenceNumber = allocation.ReferenceNumber,
                             DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                             DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                             DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                             CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                             CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                             CreditOrSellAmount = allocation.CreditOrSellAmount,
                             ValueDate = allocation.ValueDate,
                             WSSResultId = allocation.WSSResultId,
                             WSSResult = allocation.WSS_ResultList.ResultName,
                             WSSComments = allocation.WSSComments
                         }).ToList();

                foreach (var allocation in AllocationQuery)
                {
                    allocationViewModelList.Add(new AllocationViewModel
                    {
                        id = allocation.id,
                        User = allocation.User,
                        Module = allocation.Module,
                        SystemName = allocation.SystemName,
                        ReadyForRelease = allocation.ReadyForRelease,
                        ReleasedBy = allocation.ReleasedBy,
                        ReferenceNumber = allocation.ReferenceNumber,
                        DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                        DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                        DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                        CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                        CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                        CreditOrSellAmount = allocation.CreditOrSellAmount,
                        ValueDate = allocation.ValueDate.HasValue ? allocation.ValueDate.Value.ToString("dd-MM-yyyy") : null,
                        WSSResultId = allocation.WSSResultId,
                        WSSResult = allocation.WSSResult,
                        WSSComments = allocation.WSSComments
                    });
                }

            }
            catch (Exception ex)
            {
            }
            return serializer.Serialize(allocationViewModelList);
        }

        public string GetREC7()
        {


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<AllocationViewModel> allocationViewModelList = new List<AllocationViewModel>();

            try
            {
                var AllocationQuery =
                        (from testcases in db.TestCases
                         join allocation in db.Allocations
                         on testcases.Id equals allocation.TestCaseId
                         select new
                         {
                             id = allocation.Id,
                             Module = testcases.ModuleId == null ? null : testcases.Module.SystemName,
                             SystemName = testcases.SystemId == null ? null : testcases.System.SystemName,
                             User = allocation.ExecutedUser.UserName,
                             ReadyForRelease = allocation.ReadyForReleaseList.ReadyForReleaseValue,
                             ReleasedBy = allocation.ReleasedByUser.UserName,
                             ReferenceNumber = allocation.ReferenceNumber,
                             DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                             DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                             DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                             CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                             CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                             CreditOrSellAmount = allocation.CreditOrSellAmount,
                             ValueDate = allocation.ValueDate,
                             REC7ResultId = allocation.Rec7ResultId,
                             REC7Result = allocation.REC7_ResultList.ResultName,
                             REC7Comments = allocation.Rec7Comments
                         }).ToList();

                foreach (var allocation in AllocationQuery)
                {
                    allocationViewModelList.Add(new AllocationViewModel
                    {
                        id = allocation.id,
                        User = allocation.User,
                        Module = allocation.Module,
                        SystemName = allocation.SystemName,
                        ReadyForRelease = allocation.ReadyForRelease,
                        ReleasedBy = allocation.ReleasedBy,
                        ReferenceNumber = allocation.ReferenceNumber,
                        DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                        DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                        DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                        CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                        CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                        CreditOrSellAmount = allocation.CreditOrSellAmount,
                        ValueDate = allocation.ValueDate.HasValue ? allocation.ValueDate.Value.ToString("dd-MM-yyyy") : null,
                        REC7ResultId = allocation.REC7ResultId,
                        REC7Result = allocation.REC7Result,
                        REC7Comments = allocation.REC7Comments
                    });
                }

            }
            catch (Exception ex)
            {
            }
            return serializer.Serialize(allocationViewModelList);
        }

        public string GetSanctions()
        {


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<AllocationViewModel> allocationViewModelList = new List<AllocationViewModel>();

            try
            {
                var AllocationQuery =
                        (from testcases in db.TestCases
                         join allocation in db.Allocations
                         on testcases.Id equals allocation.TestCaseId
                         select new
                         {
                             id = allocation.Id,
                             Module = testcases.ModuleId == null ? null : testcases.Module.SystemName,
                             SystemName = testcases.SystemId == null ? null : testcases.System.SystemName,
                             User = allocation.ExecutedUser.UserName,
                             ReadyForRelease = allocation.ReadyForReleaseList.ReadyForReleaseValue,
                             ReleasedBy = allocation.ReleasedByUser.UserName,
                             ReferenceNumber = allocation.ReferenceNumber,
                             DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                             DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                             DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                             CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                             CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                             CreditOrSellAmount = allocation.CreditOrSellAmount,
                             ValueDate = allocation.ValueDate,
                             SanctionsResultId = allocation.SanctionsResultId,
                             SanctionsResult = allocation.SanctionsResultList.ResultName,
                             SanctionsComments = allocation.SanctionsComments
                         }).ToList();

                foreach (var allocation in AllocationQuery)
                {
                    allocationViewModelList.Add(new AllocationViewModel
                    {
                        id = allocation.id,
                        User = allocation.User,
                        Module = allocation.Module,
                        SystemName = allocation.SystemName,
                        ReadyForRelease = allocation.ReadyForRelease,
                        ReleasedBy = allocation.ReleasedBy,
                        ReferenceNumber = allocation.ReferenceNumber,
                        DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                        DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                        DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                        CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                        CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                        CreditOrSellAmount = allocation.CreditOrSellAmount,
                        ValueDate = allocation.ValueDate.HasValue ? allocation.ValueDate.Value.ToString("dd-MM-yyyy") : null,
                        SanctionsResultId = allocation.SanctionsResultId,
                        SanctionsResult = allocation.SanctionsResult,
                        SanctionsComments = allocation.SanctionsComments
                    });
                }

            }
            catch (Exception ex)
            {
            }
            return serializer.Serialize(allocationViewModelList);
        }

        public string GetSWIFT()
        {


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<AllocationViewModel> allocationViewModelList = new List<AllocationViewModel>();

            try
            {
                var AllocationQuery =
                        (from testcases in db.TestCases
                         join allocation in db.Allocations
                         on testcases.Id equals allocation.TestCaseId
                         select new
                         {
                             id = allocation.Id,
                             Module = testcases.ModuleId == null ? null : testcases.Module.SystemName,
                             SystemName = testcases.SystemId == null ? null : testcases.System.SystemName,
                             User = allocation.ExecutedUser.UserName,
                             ReadyForRelease = allocation.ReadyForReleaseList.ReadyForReleaseValue,
                             ReleasedBy = allocation.ReleasedByUser.UserName,
                             ReferenceNumber = allocation.ReferenceNumber,
                             DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                             DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                             DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                             CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                             CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                             CreditOrSellAmount = allocation.CreditOrSellAmount,
                             ValueDate = allocation.ValueDate,
                             SWIFTResultId = allocation.SwiftResultId,
                             SWIFTResult = allocation.Swift_ResultList.ResultName,
                             SWIFTComments = allocation.SwiftComments
                         }).ToList();

                foreach (var allocation in AllocationQuery)
                {
                    allocationViewModelList.Add(new AllocationViewModel
                    {
                        id = allocation.id,
                        User = allocation.User,
                        Module = allocation.Module,
                        SystemName = allocation.SystemName,
                        ReadyForRelease = allocation.ReadyForRelease,
                        ReleasedBy = allocation.ReleasedBy,
                        ReferenceNumber = allocation.ReferenceNumber,
                        DebitOrPurchaseAccNo = allocation.DebitOrPurchaseAccNo,
                        DebitOrPurchaseCurrency = allocation.DebitOrPurchaseCurrency,
                        DebitOrPurchaseAmt = allocation.DebitOrPurchaseAmt,
                        CreditOrSellAccNo = allocation.CreditOrSellAccNo,
                        CreditOrSellCurrency = allocation.CreditOrSellCurrency,
                        CreditOrSellAmount = allocation.CreditOrSellAmount,
                        ValueDate = allocation.ValueDate.HasValue ? allocation.ValueDate.Value.ToString("dd-MM-yyyy") : null,
                        SWIFTResultId = allocation.SWIFTResultId,
                        SWIFTResult = allocation.SWIFTResult,
                        SWIFTComments = allocation.SWIFTComments
                    });
                }

            }
            catch (Exception ex)
            {
            }
            return serializer.Serialize(allocationViewModelList);
        }

        [HttpPost]
        public JsonResult UpdateMCPE(List<AllocationViewModel> AllocationViewModel)
        {

            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            int? resultId = AllocationViewModel[0].MCPEResultId;

            //int employeeId = (from user in UsersCache()
            //                  where empId.Contains(empId)
            //                  select user).FirstOrDefault().Id;

            List<int> selectedAllocationId=new List<int>();

            foreach(var all in AllocationViewModel)
            {
                selectedAllocationId.Add(all.id);
            }

            List<Allocation> allocationList = db.Allocations.Where(e => selectedAllocationId.Contains(e.Id)).ToList();
            foreach (var allocation in allocationList)
            {

                allocation.MCPEResultId = resultId;
                allocation.MCPEVerifiedBy=null;
                allocation.MCPEVerifiedDate = DateTime.Now;
                db.Entry(allocation).State = System.Data.Entity.EntityState.Modified;


            }

            db.SaveChanges();
            return Json("Success");
        }


        [HttpPost]
        public JsonResult UpdateException(List<AllocationViewModel> AllocationViewModel)
        {

            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            int? resultId = AllocationViewModel[0].ExceptionResultId;

            //int employeeId = (from user in UsersCache()
            //                  where empId.Contains(empId)
            //                  select user).FirstOrDefault().Id;

            List<int> selectedAllocationId = new List<int>();

            foreach (var all in AllocationViewModel)
            {
                selectedAllocationId.Add(all.id);
            }

            List<Allocation> allocationList = db.Allocations.Where(e => selectedAllocationId.Contains(e.Id)).ToList();
            foreach (var allocation in allocationList)
            {

                allocation.ExceptionResultId = resultId;
                allocation.ExceptionVerifiedBy = null;
                allocation.ExceptionVerifiedDate = DateTime.Now;
                db.Entry(allocation).State = System.Data.Entity.EntityState.Modified;


            }

            db.SaveChanges();
            return Json("Success");
        }


        [HttpPost]
        public JsonResult UpdateGL(List<AllocationViewModel> AllocationViewModel)
        {

            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            int? resultId = AllocationViewModel[0].GLResultId;

            //int employeeId = (from user in UsersCache()
            //                  where empId.Contains(empId)
            //                  select user).FirstOrDefault().Id;

            List<int> selectedAllocationId = new List<int>();

            foreach (var all in AllocationViewModel)
            {
                selectedAllocationId.Add(all.id);
            }

            List<Allocation> allocationList = db.Allocations.Where(e => selectedAllocationId.Contains(e.Id)).ToList();
            foreach (var allocation in allocationList)
            {

                allocation.GLResultId = resultId;
                allocation.GLVerifiedBy = null;
                allocation.GLVerifiedDate = DateTime.Now;
                db.Entry(allocation).State = System.Data.Entity.EntityState.Modified;


            }

            db.SaveChanges();
            return Json("Success");
        }

        [HttpPost]
        public JsonResult UpdateFinSurv(List<AllocationViewModel> AllocationViewModel)
        {

            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            int? resultId = AllocationViewModel[0].FinSurvResultId;

            //int employeeId = (from user in UsersCache()
            //                  where empId.Contains(empId)
            //                  select user).FirstOrDefault().Id;

            List<int> selectedAllocationId = new List<int>();

            foreach (var all in AllocationViewModel)
            {
                selectedAllocationId.Add(all.id);
            }

            List<Allocation> allocationList = db.Allocations.Where(e => selectedAllocationId.Contains(e.Id)).ToList();
            foreach (var allocation in allocationList)
            {

                allocation.FinSurvResultId = resultId;
                allocation.FinSurvVerifiedBy = null;
                allocation.FinSurvVerifiedDate = DateTime.Now;
                db.Entry(allocation).State = System.Data.Entity.EntityState.Modified;


            }

            db.SaveChanges();
            return Json("Success");
        }

        [HttpPost]
        public JsonResult UpdateWSS(List<AllocationViewModel> AllocationViewModel)
        {

            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            int? resultId = AllocationViewModel[0].WSSResultId;

            //int employeeId = (from user in UsersCache()
            //                  where empId.Contains(empId)
            //                  select user).FirstOrDefault().Id;

            List<int> selectedAllocationId = new List<int>();

            foreach (var all in AllocationViewModel)
            {
                selectedAllocationId.Add(all.id);
            }

            List<Allocation> allocationList = db.Allocations.Where(e => selectedAllocationId.Contains(e.Id)).ToList();
            foreach (var allocation in allocationList)
            {

                allocation.WSSResultId = resultId;
                allocation.WSSVerifiedBy = null;
                allocation.WSSVerifiedDate = DateTime.Now;
                db.Entry(allocation).State = System.Data.Entity.EntityState.Modified;


            }

            db.SaveChanges();
            return Json("Success");
        }


        [HttpPost]
        public JsonResult UpdateREC7(List<AllocationViewModel> AllocationViewModel)
        {

            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            int? resultId = AllocationViewModel[0].REC7ResultId;

            //int employeeId = (from user in UsersCache()
            //                  where empId.Contains(empId)
            //                  select user).FirstOrDefault().Id;

            List<int> selectedAllocationId = new List<int>();

            foreach (var all in AllocationViewModel)
            {
                selectedAllocationId.Add(all.id);
            }

            List<Allocation> allocationList = db.Allocations.Where(e => selectedAllocationId.Contains(e.Id)).ToList();
            foreach (var allocation in allocationList)
            {

                allocation.Rec7ResultId = resultId;
                allocation.Rec7VerifiedBy = null;
                allocation.Rec7VerifiedDate = DateTime.Now;
                db.Entry(allocation).State = System.Data.Entity.EntityState.Modified;


            }

            db.SaveChanges();
            return Json("Success");
        }

        [HttpPost]
        public JsonResult UpdateSanctions(List<AllocationViewModel> AllocationViewModel)
        {

            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            int? resultId = AllocationViewModel[0].SanctionsResultId;

            //int employeeId = (from user in UsersCache()
            //                  where empId.Contains(empId)
            //                  select user).FirstOrDefault().Id;

            List<int> selectedAllocationId = new List<int>();

            foreach (var all in AllocationViewModel)
            {
                selectedAllocationId.Add(all.id);
            }

            List<Allocation> allocationList = db.Allocations.Where(e => selectedAllocationId.Contains(e.Id)).ToList();
            foreach (var allocation in allocationList)
            {

                allocation.SanctionsResultId = resultId;
                allocation.SanctionsVerifiedBy = null;
                allocation.SanctionsVerifiedDate = DateTime.Now;
                db.Entry(allocation).State = System.Data.Entity.EntityState.Modified;


            }

            db.SaveChanges();
            return Json("Success");
        }

        [HttpPost]
        public JsonResult UpdateSWIFT(List<AllocationViewModel> AllocationViewModel)
        {

            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            int? resultId = AllocationViewModel[0].SWIFTResultId;

            //int employeeId = (from user in UsersCache()
            //                  where empId.Contains(empId)
            //                  select user).FirstOrDefault().Id;

            List<int> selectedAllocationId = new List<int>();

            foreach (var all in AllocationViewModel)
            {
                selectedAllocationId.Add(all.id);
            }

            List<Allocation> allocationList = db.Allocations.Where(e => selectedAllocationId.Contains(e.Id)).ToList();
            foreach (var allocation in allocationList)
            {

                allocation.SwiftResultId = resultId;
                allocation.SwiftVerifiedBy = null;
                allocation.SwiftVerifiedDate = DateTime.Now;
                db.Entry(allocation).State = System.Data.Entity.EntityState.Modified;


            }

            db.SaveChanges();
            return Json("Success");
        }


        public ActionResult MCPE()
        {
            return View();
        }

        public ActionResult Exception()
        {
            return View();
        }

        public ActionResult GL()
        {
            return View();
        }

        public ActionResult FinSurv()
        {
            return View();
        }

        public ActionResult REC7()
        {
            return View();
        }

        public ActionResult WSS()
        {
            return View();
        }

        public ActionResult Sanctions()
        {
            return View();
        }

        public ActionResult SWIFT()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Allocation/Details/5

        public ActionResult Details(int id = 0)
        {

            return View();
        }

        //
        // GET: /Allocation/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Allocation/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Allocation allocation)
        {
            if (ModelState.IsValid)
            {
                db.Allocations.Add(allocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allocation);
        }

        //
        // GET: /Allocation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Allocation allocation = db.Allocations.Find(id);
            allocation.StartTime = DateTime.Now;
            if (allocation == null)
            {
                return HttpNotFound();
            }

            List<User> queryUsers = (from user in db.Users
                                     join cycleuser in db.CycleTesters
                                     on user.Id equals cycleuser.UserId
                                     where cycleuser.CycleId == allocation.CycleId
                                     select user).ToList();

            ViewBag.ReadyForReleaseId = new SelectList(db.ReadyForReleaseLists.ToList(), "Id", "ReadyForReleaseValue", allocation.ReadyForReleaseId);
            ViewBag.RequestToReleaseUserId = new SelectList(queryUsers, "Id", "UserName", allocation.RequestToReleaseUserId);
            ViewBag.ReleasedByUserId = new SelectList(queryUsers, "Id", "UserName", allocation.ReleasedByUserId);
            ViewBag.BlockedReasonId = new SelectList(db.BlockedReasonLists.ToList(), "Id", "BlockedReasonValue", allocation.BlockedReasonId);
            Response.CacheControl = "no-cache";
            return PartialView("Edit", allocation);
        }

        //
        // POST: /Allocation/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public void Edit(Allocation allocation, string empId)
        {
            allocation.EndTime = allocation.ModifiedDate = allocation.ExecutedDate = DateTime.Now;
            allocation.ModifiedBy = (from user in UsersCache()
                                     where empId.Contains(empId)
                                     select user).FirstOrDefault().Id;
            if (ModelState.IsValid)
            {
                db.Entry(allocation).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetEdit(String stateCode)
        {

            return Json(null);
        }
        //
        // GET: /Allocation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Allocation allocation = db.Allocations.Find(id);
            if (allocation == null)
            {
                return HttpNotFound();
            }
            return View(allocation);
        }

        //
        // POST: /Allocation/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Allocation allocation = db.Allocations.Find(id);
            db.Allocations.Remove(allocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}