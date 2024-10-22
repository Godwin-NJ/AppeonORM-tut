﻿using SnapObjects.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeon.SnapObjectsDemo.Service.Models
{
    [Top(1000)]
    [SqlParameter("custId", typeof(int))]
    [SqlParameter("startOrderDate", typeof(DateTime))]
    [SqlParameter("endOrderDate", typeof(DateTime))]
    [Table("SalesOrderHeader", Schema = "Sales")]
    [SqlWhere("(CustomerId = :custId Or :custId = 0) " +
    " and (Orderdate Between :startOrderDate and :endOrderDate)")]
    public class SalesOrder
    {
        [Key]
        [Identity]
        [DisplayName("Order ID")]
        public int SalesOrderID { get; set; }

        [Required]
        [DisplayName("Revision Number")]
        public byte RevisionNumber { get; set; }

        [Required]
        [DisplayName("Order Date")]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        [Required]
        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [DisplayName("Ship Date")]
        [DataType(DataType.Date)]
        public DateTime? ShipDate { get; set; }

        [Required]
        public byte? Status { get; set; }

        [Required]
        [DisplayName("Online Order Flag")]
        public Boolean OnlineOrderFlag { get; set; }

        [DisplayName("Order Number")]
        [SqlCompute("(isnull(N'SO' + CONVERT([nvarchar](23), [SalesOrderID]), N'*** ERROR ***'))")]
        public string SalesOrderNumber { get; set; }

        [DisplayName("PO Number")]
        public string PurchaseOrderNumber { get; set; }

        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }

        [Required]
        [DisplayName("Customer")]
        public int CustomerID { get; set; }

        [DisplayName("Sales Person")]
        public int? SalesPersonID { get; set; }

        [DisplayName("Territory ID")]
        public int? TerritoryID { get; set; }

        [Required]
        [DisplayName("Bill To Address")]
        public int? BillToAddressID { get; set; }

        [Required]
        [DisplayName("Ship To Address")]
        public int? ShipToAddressID { get; set; }

        [Required]
        [DisplayName("Ship Method")]
        public int? ShipMethodID { get; set; }

        [DisplayName("Credit Card ID")]
        public int? CreditCardID { get; set; }

        [DisplayName("Card Approval Code")]
        public string CreditCardApprovalCode { get; set; }

        [DisplayName("Currency Rate")]
        public int? CurrencyRateID { get; set; }

        [Required]
        [DisplayName("Subtotal")]
        [DataType(DataType.Currency)]
        public decimal? SubTotal { get; set; }

        [Required]
        [DisplayName("Tax Amount")]
        [DataType(DataType.Currency)]
        public decimal? TaxAmt { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal? Freight { get; set; }

        [DisplayName("Total Due")]
        [DataType(DataType.Currency)]
        [PropertySave(SaveStrategy.ReadAfterSave)]
        public decimal? TotalDue { get; set; }

        public string Comment { get; set; }

        [DisplayName("Modified Date")]
        [DataType(DataType.Date)]
        [SqlDefaultValue("(getdate())")]
        public DateTime? ModifiedDate { get; set; }
    }
}
