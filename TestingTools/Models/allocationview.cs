using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Testing.Models
{
    public class AllocationViewModel
    {

        public int id { get; set; }
        public int CycleId { get; set; }
        public string User { get; set; }
        public string Module { get; set; }
        public string SystemName { get; set; }
        public long ScenarioNumber { get; set; }
        public string ScenarioName { get; set; }
        public string ScenarioDescription { get; set; }
        public string PlannedDate { get; set; }
        public string Comments { get; set; }
        public string ReadyForRelease { get; set; }
        public string ReleasedBy { get; set; }
        public string ReferenceNumber { get; set; }
        [Display(Name = "Debit/Purchase Acc No")]
        public string DebitOrPurchaseAccNo { get; set; }
        [Display(Name = "Debit/Purchase Currency")]
        public string DebitOrPurchaseCurrency { get; set; }
        [Display(Name = "Debit/Purchase Amount")]
        public string DebitOrPurchaseAmt { get; set; }
        [Display(Name = "Credit/Sell Acc No")]
        public string CreditOrSellAccNo { get; set; }
        [Display(Name = "Credit/Sell Currency")]
        public string CreditOrSellCurrency { get; set; }
        [Display(Name = "Credit/Sell Amount")]
        public string CreditOrSellAmount { get; set; }
        [Display(Name = "Value Date")]
        public string ValueDate { get; set; }
        public int? MCPEResultId { get; set; }
        public string MCPEResult { get; set; }
        public string MCPEComments { get; set; }
        public int? ExceptionResultId { get; set; }
        public string  ExceptionResult { get; set; }
        public string ExceptionComments { get; set; }
        public int? SWIFTResultId { get; set; }
        public string SWIFTResult { get; set; }
        public string SWIFTComments { get; set; }
        public int? SanctionsResultId { get; set; }
        public string SanctionsResult { get; set; }
        public string SanctionsComments { get; set; }
        public int? FinSurvResultId { get; set; }
        public string FinSurvResult { get; set; }
        public string FinSurvComments { get; set; }
        public int? WSSResultId { get; set; }
        public string WSSResult { get; set; }
        public string WSSComments { get; set; }
        public int? REC7ResultId { get; set; }
        public string REC7Result { get; set; }
        public string REC7Comments { get; set; }
        public int? GLResultId { get; set; }
        public string GLResult { get; set; }
        public string GLComments { get; set; }
    }
}


