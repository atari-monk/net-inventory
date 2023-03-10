using AutoMapper;
using CRUDCommandHelper;
using Inventory.Data;
using Serilog;

namespace Inventory.Modern.Lib;

public class StockStateInsertCommand
    : InsertManyToManyCommand<IInventoryUnitOfWork>
        , IStockStateInsertCommand
{
    public StockStateInsertCommand(
        IInventoryUnitOfWork unitOfWork
        , ILogger log
        , IMapper mapper)
            : base(unitOfWork, log, mapper)
    {
    }

    protected override void InsertEntity(int stockId, int stateId)
    {
        var stock = UnitOfWork.Stock.GetById(stockId);
        var state = UnitOfWork.State.GetById(stateId);
        if(stock == null || state == null) return;
        stock.States?.Add(state);
    }
}