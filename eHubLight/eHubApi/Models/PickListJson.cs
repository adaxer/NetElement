// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Container
{
    public string ContainerType { get; set; }
    public string Id { get; set; }
    public string InternalTrackingNumber { get; set; }
    public List<Item> Items { get; set; }
    public string MetaTags { get; set; }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class CustomAllocationData
{
    public string Wrkref { get; set; }
    public string Ordlin { get; set; }
    public string Orgcod { get; set; }
    public string StR1 { get; set; }
    public string StR2 { get; set; }
    public string StR3 { get; set; }
    public string StR4 { get; set; }
    public string StR5 { get; set; }
    public string StR6 { get; set; }
    public string StR7 { get; set; }
    public string StR8 { get; set; }
    public string StR9 { get; set; }
    public string StR10 { get; set; }
    public string StR11 { get; set; }
    public string StR12 { get; set; }
    public string StR13 { get; set; }
    public string StR14 { get; set; }
    public string StR15 { get; set; }
    public string StR16 { get; set; }
    public string StR17 { get; set; }
    public string StR18 { get; set; }
    public string InT1 { get; set; }
    public string InT2 { get; set; }
    public string InT3 { get; set; }
    public string InT4 { get; set; }
    public string InT5 { get; set; }
    public string FlT1 { get; set; }
    public string FlT2 { get; set; }
    public string FlT3 { get; set; }
    public string DtE1 { get; set; }
    public string DtE2 { get; set; }
    public string ExTPRTNUM { get; set; }
    public string CusTPRTNUM { get; set; }
    public string CusTORDERREF { get; set; }
    public string DeLNOTENUM { get; set; }
    public string SeTNUM { get; set; }
    public string SaleSUOM { get; set; }
    public string LinEQTY { get; set; }
}

public class Root
{
    public CustomAllocationData CustomAllocationData { get; set; }
}


public class CustomData
{
}

public class Item
{
    public string Quantity { get; set; }
}

public class Mission
{
    public string BatchId { get; set; }
    public List<Container> Containers { get; set; }
    public CustomAllocationData CustomAllocationData { get; set; }
    public DateTime DateCompleted { get; set; }
    public DateTime DateTimeCompleted { get; set; }
    public string DeliverState { get; set; }
    public int DepthIntId { get; set; }
    public string DepthUserDefId { get; set; }
    public string EquipmentCode { get; set; }
    public bool IsLastMissionForOrderLine { get; set; }
    public string LocationName { get; set; }
    public int MissionId { get; set; }
    public int OrderLineMissionNumber { get; set; }
    public string PickedByUser { get; set; }
    public int PickedQuantity { get; set; }
    public int PlannedQuantity { get; set; }
    public string PosUserDefId { get; set; }
    public DateTime ProductExpiryDate { get; set; }
    public string RemainingQuantity { get; set; }
    public List<object> ScanValues { get; set; }
    public string ShelfUserDefId { get; set; }
    public int TaskgroupId { get; set; }
    public string TimeCompleted { get; set; }
    public string TransportLocation { get; set; }
    public int UserId { get; set; }
    public string ZoneUserDefId { get; set; }
}

public class Order
{
    public string SpeditorId { get; set; }
}

public class OrderLine
{
    public bool CompleteLine { get; set; }
    public CustomAllocationData CustomAllocationData { get; set; }
    public CustomData CustomData { get; set; }
    public string ExtOrderId { get; set; }
    public int ExtOrderlineId { get; set; }
    public int ExtPicklistLineId { get; set; }
    public List<Mission> Missions { get; set; }
    public Order Order { get; set; }
    public int OrderlineCode { get; set; }
    public string PickedQuantity { get; set; }
    public string PlannedQuantity { get; set; }
    public Product Product { get; set; }
    public bool RestOrder { get; set; }
}

public class Product
{
    public string EanId { get; set; }
    public bool ExpiryDateRequired { get; set; }
    public string ProductName { get; set; }
    public string ProductNo { get; set; }
    public SalesUnit SalesUnit { get; set; }
}

public class PickListComplete
{
    public bool CompletePicklist { get; set; }
    public List<OrderLine> OrderLines { get; set; }
    public string OrderTypeId { get; set; }
    public string PicklistId { get; set; }
    public string PrinterCode { get; set; }
    public string PrinterName { get; set; }
    public int TransactionId { get; set; }
}

public class SalesUnit
{
    public int SalesUnitDepth { get; set; }
    public int SalesUnitHeight { get; set; }
    public string SalesUnitText { get; set; }
    public double SalesUnitVolum { get; set; }
    public double SalesUnitWeight { get; set; }
    public int SalesUnitWidth { get; set; }
}

