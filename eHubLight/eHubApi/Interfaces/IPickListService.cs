namespace eHubApi;

public interface IPickListService
{
    PICK_ERROR GetPickError(PickListComplete pickList);
}