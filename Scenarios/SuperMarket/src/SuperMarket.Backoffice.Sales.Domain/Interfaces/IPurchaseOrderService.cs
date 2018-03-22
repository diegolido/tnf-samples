﻿using SuperMarket.Backoffice.Sales.Domain.Entities;
using System;
using System.Threading.Tasks;
using Tnf.Domain.Services;

namespace SuperMarket.Backoffice.Sales.Domain.Interfaces
{
    public interface IPurchaseOrderService : IDomainService
    {
        Task<PurchaseOrder> NewPurchaseOrder(PurchaseOrder.INewPurchaseOrderBuilder newPurchaseOrderBuilder);
        Task<PurchaseOrder> UpdatePurchaseOrder(PurchaseOrder.IUpdatePurchaseOrderBuilder updatePurchaseOrderBuilder);
        Task UpdateTaxPurchaseOrder(Guid purchaseOrderId, decimal tax);
    }
}
