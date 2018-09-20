using System;
using System.Diagnostics;
using System.IO;
using ImageMagick;
using Rivington.IG.Domain.CustomCodes;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.Domain.Pdf
{
	public class WkHtmlToPdfService : IWkHtmlToPdfService
	{
		private const string WkhtmlToPdfPath = @"C:\Program Files\wkhtmltopdf\bin\wkhtmltopdf.exe";

		public WkHtmlToPdfService()
		{
		}

		public byte[] GeneratePdf(Guid id, string webHost)
		{
			//var data = GetIoReportData(id);
			//var dataString = JsonConvert.SerializeObject(GetActionResultValue<object>(data), Formatting.None);

			var json =
				AppSettings.Paths.FileServerPhysical + 
				$@"{AppSettings.Paths.IoReports}\{id}.json"
					.Substring(AppSettings.Paths.FileServer.Length);

			//File.WriteAllText(json, dataString);

			var url = $"{webHost}/reporting/order-management/inspection-order/{id}";
			
			var outputPath = json.Replace(".json", $"_{DateTime.Now:yyyyMMddHHmmss}.pdf");
			
			var arguments = new[]
			{
				"--no-stop-slow-scripts", // dontStopSlowScripts
				"-B 25.4 -L 25.4 -R 25.4 -T 25.4", // margins
				"--page-size Letter", // pageSize
				$"--window-status {AppSettings.ReadyToPrintStatus}", // printStatus
				//"test.pdf", // dummy?
				//"--load-error-handling ignore", //

				$"{url}?download=true",
				outputPath
			};

			var process = Process.Start(WkhtmlToPdfPath, string.Join(" ", arguments));
			process.WaitForExit(AppSettings.GenerateReportTimeout);

			if (!File.Exists(outputPath)) throw new Exception("Error occurred upon generation of PDF report.");

			////converting Pdf file into bytes array  
			var dataBytes = File.ReadAllBytes(outputPath);

			return File.ReadAllBytes(outputPath);
		}
	}
}