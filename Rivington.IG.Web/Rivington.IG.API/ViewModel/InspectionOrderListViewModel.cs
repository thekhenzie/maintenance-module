using System;
using Newtonsoft.Json;

namespace Rivington.IG.API.ViewModel
{
  [JsonObject(MemberSerialization.OptOut)]
  public class InspectionOrderListViewModel
  {
    #region Constructor
    public InspectionOrderListViewModel()
    {
    }
    #endregion
    #region Properties
    public Guid OrderId { get; set; }
    public int Item { get; set; }
    public string Policy { get; set; }
    public string InsuredName { get; set; }
    public string Location { get; set; }
    public DateTime DateAssigned { get; set; }
    public DateTime DateCreated { get; set; }
    public string Inspector { get; set; }
    public string Status { get; set; }
    public string DateDifference { get; set; }
    #endregion
  }
}
