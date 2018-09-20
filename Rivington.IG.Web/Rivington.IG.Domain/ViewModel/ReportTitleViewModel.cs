
using System;
using Newtonsoft.Json;
namespace Rivington.IG.Domain.ViewModel
{
  [JsonObject(MemberSerialization.OptOut)]
  public class ReportTitleViewModel
  {
    #region Constructor
    public ReportTitleViewModel()
    {
    }
    #endregion

    #region Properties
    public Guid Id { get; set; }
    public string InsuredFullname {get;set;}
    public string InsuredAddress { get; set; }
    public string InsuredCityStateZipCode{ get; set; }
    public string InspectorFullName { get; set; }
    public string InspectorEmail { get; set; }

    public string InspectorMobileNumber { get; set; }

    public string AgentName { get; set; }
    public string AgencyName { get; set; }
    public string AgentPhoneNumber { get; set; }

    public DateTime? InspectionDate { get; set; }
    public string PolicyNumber { get; set; }

    public string Photo { get; set; }
    #endregion
  }
}
