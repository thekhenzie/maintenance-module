using Newtonsoft.Json;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.API.ViewModel
{
  [JsonObject(MemberSerialization.OptOut)]
  public class UserViewModel
  {
    #region Constructor
    public UserViewModel()
    {
    }
    #endregion
    #region Properties
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Contact { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public Image ProfilePhoto { get; set; }
    #endregion
  }
}
