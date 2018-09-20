using Newtonsoft.Json;

namespace Rivington.IG.API.ViewModel
{
    [JsonObject(MemberSerialization.OptOut)]
    public class AppSettingsViewModel
    {
        #region Constructor
        public AppSettingsViewModel()
        {
        }
        #endregion
        #region Properties
        public string DefaultDateFormat { get; set; }
        public string EnvironmentName { get; set; }
        public bool CanConnectToDB { get; set; }
        public string ReadyToPrintStatus { get; set; }

	    public _ImageSizes ImageSizes { get; set; }

	    public class _ImageSizes
	    {
			public _Main Main { get; set; }
			public _Thumb Thumb { get; set; }

		    public class _Main
		    {
				public int Height { get; set; }
				public int Width { get; set; }
		    }
		    public class _Thumb
		    {
			    public int Height { get; set; }
			    public int Width { get; set; }
		    }
	    }
        public string Copyright { get; set; }
        public string AppVersion { get; set; }
        public string JsMapApiKey { get; set; }
        #endregion
    }
}
