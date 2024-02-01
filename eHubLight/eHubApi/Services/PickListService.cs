namespace eHubApi.Services;

public class PickListService : IPickListService
{
    public PICK_ERROR GetPickError(PickListComplete pickList)
    {
        var result = new PICK_ERROR();
        var missions = pickList.OrderLines.SelectMany(o => o.Missions);
        var segs = new List<PICK_ERR_SEG>();
        foreach (var mission in missions)
        {
            if (mission.PickedQuantity != mission.PlannedQuantity || true)
            {
                segs.Add(new PICK_ERR_SEG
                {
                    CANCOD = "Constant",
                    ERROR_DESCR = "No stock available",
                    CANQTY = mission.PlannedQuantity - mission.PickedQuantity,
                    WRKREF = mission.CustomAllocationData.Wrkref
                });
            }
        }
        result.PICK_ERR_SEG = segs.ToArray();
        return result;
    }
}
