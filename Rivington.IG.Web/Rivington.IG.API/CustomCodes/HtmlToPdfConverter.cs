// Decompiled with JetBrains decompiler
// Type: PDFConverter.HtmlToPdfConverter
// Assembly: Converter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB13F3F1-BE73-4659-B780-D47C9954336A
// Assembly location: D:\Downloads\Skype Downloads\toTest\Converter.dll

//using Converter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace PDFConverter
{
  public class HtmlToPdfConverter
  {
    private static object globalObj = new object();
    private static string[] ignoreWkHtmlToPdfErrLines = new string[6]
    {
      "Exit with code 1 due to network error: ContentNotFoundError",
      "QFont::setPixelSize: Pixel size <= 0",
      "Exit with code 1 due to network error: ProtocolUnknownError",
      "Exit with code 1 due to network error: HostNotFoundError",
      "Exit with code 1 due to network error: ContentOperationNotPermittedError",
      "Exit with code 1 due to network error: UnknownContentError"
    };
    private bool batchMode;
    private const string headerFooterHtmlTpl = "<!DOCTYPE html><html><head>\r\n<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\" />\r\n<script>\r\nfunction subst() {{\r\n    var vars={{}};\r\n    var x=document.location.search.substring(1).split('&');\r\n\r\n    for(var i in x) {{var z=x[i].split('=',2);vars[z[0]] = unescape(z[1]);}}\r\n    var x=['frompage','topage','page','webpage','section','subsection','subsubsection'];\r\n    for(var i in x) {{\r\n      var y = document.getElementsByClassName(x[i]);\r\n      for(var j=0; j<y.length; ++j) y[j].textContent = vars[x[i]];\r\n    }}\r\n}}\r\n</script></head><body style=\"border:0; margin: 0;\" onload=\"subst()\">{0}</body></html>\r\n";
    private Process WkHtmlToPdfProcess;

    public event EventHandler<DataReceivedEventArgs> LogReceived;

    public HtmlToPdfConverter()
    {
	    string str = "C:\\Program Files\\wkhtmltopdf\\bin"; // Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wkhtmltopdf");
      //if (HttpContext.Current != null)
      //  str = Path.Combine(HttpRuntime.AppDomainAppPath, "C:\\Program Files\\wkhtmltopdf\\bin");
      this.PdfToolPath = str;
      this.TempFilesPath = (string) null;
      this.WkHtmlToPdfExeName = "wkhtmltopdf.exe";
      this.Orientation = HtmlToPdfConverter.PageOrientation.Default;
      this.Size = HtmlToPdfConverter.PageSize.A3;
      this.LowQuality = false;
      this.Grayscale = false;
      this.Quiet = true;
      this.Zoom = 1f;
    }

    public void BeginBatch()
    {
      if (this.batchMode)
        throw new InvalidOperationException("HtmlToPdfConverter is already in the batch mode.");
      this.batchMode = true;
      this.EnsureWkHtmlLibs();
    }

    private void CheckExitCode(int exitCode, string lastErrLine, bool outputNotEmpty)
    {
      int num;
      switch (exitCode)
      {
        case 0:
          num = 0;
          break;
        case 1:
          if (Array.IndexOf<string>(HtmlToPdfConverter.ignoreWkHtmlToPdfErrLines, lastErrLine.Trim()) >= 0)
          {
            num = !outputNotEmpty ? 1 : 0;
            break;
          }
          goto default;
        default:
          num = 1;
          break;
      }
      if (num != 0)
        throw new Exception(lastErrLine);
    }

    private void CheckWkHtmlProcess()
    {
      if (!this.batchMode && this.WkHtmlToPdfProcess != null)
        throw new InvalidOperationException("WkHtmlToPdf process is already started");
    }

    private string ComposeArgs(HtmlToPdfConverter.PdfSettings pdfSettings)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (this.Quiet)
        stringBuilder.Append(" -q ");
      if ((uint) this.Orientation > 0U)
        stringBuilder.AppendFormat(" -O {0} ", (object) this.Orientation.ToString());
      if ((uint) this.Size > 0U)
        stringBuilder.AppendFormat(" -s {0} ", (object) this.Size.ToString());
      if (this.LowQuality)
        stringBuilder.Append(" -l ");
      if (this.Grayscale)
        stringBuilder.Append(" -g ");
      if (this.PageWidth.HasValue)
        stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, " --page-width {0}", new object[1]
        {
          (object) this.PageWidth
        });
      if (this.PageHeight.HasValue)
        stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, " --page-height {0}", new object[1]
        {
          (object) this.PageHeight
        });
      if (pdfSettings.HeaderFilePath != null)
        stringBuilder.AppendFormat(" --header-html \"{0}\"", (object) pdfSettings.HeaderFilePath);
      if (pdfSettings.FooterFilePath != null)
        stringBuilder.AppendFormat(" --footer-html \"{0}\"", (object) pdfSettings.FooterFilePath);
      if (!string.IsNullOrEmpty(this.CustomWkHtmlArgs))
        stringBuilder.AppendFormat(" {0} ", (object) this.CustomWkHtmlArgs);
      if (pdfSettings.CoverFilePath != null)
      {
        stringBuilder.AppendFormat(" cover \"{0}\" ", (object) pdfSettings.CoverFilePath);
        if (!string.IsNullOrEmpty(this.CustomWkHtmlCoverArgs))
          stringBuilder.AppendFormat(" {0} ", (object) this.CustomWkHtmlCoverArgs);
      }
      if (this.GenerateToc)
      {
        stringBuilder.Append(" toc ");
        if (!string.IsNullOrEmpty(this.TocHeaderText))
          stringBuilder.AppendFormat(" --toc-header-text \"{0}\"", (object) this.TocHeaderText.Replace("\"", "\\\""));
        if (!string.IsNullOrEmpty(this.CustomWkHtmlTocArgs))
          stringBuilder.AppendFormat(" {0} ", (object) this.CustomWkHtmlTocArgs);
      }
      foreach (HtmlToPdfConverter.WkHtmlInput inputFile in pdfSettings.InputFiles)
      {
        stringBuilder.AppendFormat(" \"{0}\" ", (object) inputFile.Input);
        string str = inputFile.CustomWkHtmlPageArgs ?? this.CustomWkHtmlPageArgs;
        if (!string.IsNullOrEmpty(str))
          stringBuilder.AppendFormat(" {0} ", (object) str);
        if (inputFile.HeaderFilePath != null)
          stringBuilder.AppendFormat(" --header-html \"{0}\"", (object) inputFile.HeaderFilePath);
        if (inputFile.FooterFilePath != null)
          stringBuilder.AppendFormat(" --footer-html \"{0}\"", (object) inputFile.FooterFilePath);
        if ((double) this.Zoom != 1.0)
          stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, " --zoom {0} ", new object[1]
          {
            (object) this.Zoom
          });
      }
      stringBuilder.AppendFormat(" \"{0}\" ", (object) pdfSettings.OutputFile);
      return stringBuilder.ToString();
    }

    private void CopyStream(Stream inputStream, Stream outputStream, int bufSize)
    {
      byte[] buffer = new byte[bufSize];
      int count;
      while ((count = inputStream.Read(buffer, 0, buffer.Length)) > 0)
        outputStream.Write(buffer, 0, count);
    }

    private string CreateTempFile(string content, string tempPath, List<string> tempFilesList)
    {
      string path = Path.Combine(tempPath, "pdfgen-" + Path.GetRandomFileName() + ".html");
      tempFilesList.Add(path);
      if (content != null)
        File.WriteAllBytes(path, Encoding.UTF8.GetBytes(content));
      return path;
    }

    private void DeleteFileIfExists(string filePath)
    {
      if (filePath == null || !File.Exists(filePath))
        return;
      try
      {
        File.Delete(filePath);
      }
      catch
      {
      }
    }

    public void EndBatch()
    {
      if (!this.batchMode)
        throw new InvalidOperationException("HtmlToPdfConverter is not in the batch mode.");
      this.batchMode = false;
      if (this.WkHtmlToPdfProcess == null)
        return;
      if (!this.WkHtmlToPdfProcess.HasExited)
      {
        this.WkHtmlToPdfProcess.StandardInput.Close();
        this.WkHtmlToPdfProcess.WaitForExit();
        this.WkHtmlToPdfProcess.Close();
      }
      this.WkHtmlToPdfProcess = (Process) null;
    }

    private void EnsureWkHtmlLibs()
    {
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      string[] manifestResourceNames = executingAssembly.GetManifestResourceNames();
      string str = "NReco.PdfGenerator.WkHtmlToPdf.";
      foreach (string name in manifestResourceNames)
      {
        if (name.StartsWith(str))
        {
          string path = Path.Combine(this.PdfToolPath, Path.GetFileNameWithoutExtension(name.Substring(str.Length)));
          lock (HtmlToPdfConverter.globalObj)
          {
            if (!File.Exists(path) || File.GetLastWriteTime(path) <= File.GetLastWriteTime(executingAssembly.Location))
            {
              if (!Directory.Exists(this.PdfToolPath))
                Directory.CreateDirectory(this.PdfToolPath);
              using (GZipStream gzipStream = new GZipStream(executingAssembly.GetManifestResourceStream(name), CompressionMode.Decompress, false))
              {
                using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                  byte[] buffer = new byte[65536];
                  int count;
                  while ((count = gzipStream.Read(buffer, 0, buffer.Length)) > 0)
                    fileStream.Write(buffer, 0, count);
                }
              }
            }
          }
        }
      }
    }

    private void EnsureWkHtmlProcessStopped()
    {
      if (this.WkHtmlToPdfProcess == null)
        return;
      if (!this.WkHtmlToPdfProcess.HasExited)
      {
        try
        {
          this.WkHtmlToPdfProcess.Kill();
          this.WkHtmlToPdfProcess.Close();
          this.WkHtmlToPdfProcess = (Process) null;
        }
        catch (Exception ex)
        {
        }
      }
      else
      {
        this.WkHtmlToPdfProcess.Close();
        this.WkHtmlToPdfProcess = (Process) null;
      }
    }

    public byte[] GeneratePdf(string htmlContent)
    {
      return this.GeneratePdf(htmlContent, (string) null);
    }

    public byte[] GeneratePdf(string htmlContent, string coverHtml)
    {
      MemoryStream memoryStream = new MemoryStream();
      this.GeneratePdf(htmlContent, coverHtml, (Stream) memoryStream);
      return memoryStream.ToArray();
    }

    public void GeneratePdf(string htmlContent, string coverHtml, Stream output)
    {
      if (htmlContent == null)
        throw new ArgumentNullException(nameof (htmlContent));
      this.GeneratePdfInternal((HtmlToPdfConverter.WkHtmlInput[]) null, htmlContent, coverHtml, "-", output);
    }

    public void GeneratePdf(string htmlContent, string coverHtml, string outputPdfFilePath)
    {
      if (htmlContent == null)
        throw new ArgumentNullException(nameof (htmlContent));
      this.GeneratePdfInternal((HtmlToPdfConverter.WkHtmlInput[]) null, htmlContent, coverHtml, outputPdfFilePath, (Stream) null);
    }

    public byte[] GeneratePdfFromFile(string htmlFilePath, string coverHtml)
    {
      MemoryStream memoryStream = new MemoryStream();
      this.GeneratePdfInternal(new string[1]{ htmlFilePath }, coverHtml, (Stream) memoryStream);
      return memoryStream.ToArray();
    }

    public void GeneratePdfFromFile(string htmlFilePath, string coverHtml, Stream output)
    {
      this.GeneratePdfInternal(new string[1]{ htmlFilePath }, coverHtml, output);
    }

    public void GeneratePdfFromFile(string htmlFilePath, string coverHtml, string outputPdfFilePath)
    {
      if (File.Exists(outputPdfFilePath))
        File.Delete(outputPdfFilePath);
      this.GeneratePdfInternal(new HtmlToPdfConverter.WkHtmlInput[1]
      {
        new HtmlToPdfConverter.WkHtmlInput(htmlFilePath)
      }, (string) null, coverHtml, outputPdfFilePath, (Stream) null);
    }

    public void GeneratePdfFromFiles(HtmlToPdfConverter.WkHtmlInput[] inputs, string coverHtml, string outputPdfFilePath)
    {
      if (File.Exists(outputPdfFilePath))
        File.Delete(outputPdfFilePath);
      this.GeneratePdfInternal(inputs, (string) null, coverHtml, outputPdfFilePath, (Stream) null);
    }

    public void GeneratePdfFromFiles(string[] htmlFiles, string coverHtml, Stream output)
    {
      this.GeneratePdfInternal(htmlFiles, coverHtml, output);
    }

    public void GeneratePdfFromFiles(string[] htmlFiles, string coverHtml, string outputPdfFilePath)
    {
      this.GeneratePdfFromFiles(this.GetWkHtmlInputFromFiles(htmlFiles), coverHtml, outputPdfFilePath);
    }

    private void GeneratePdfInternal(string[] htmlFiles, string coverHtml, Stream output)
    {
      this.GeneratePdfInternal(this.GetWkHtmlInputFromFiles(htmlFiles), (string) null, coverHtml, "-", output);
    }

    private void GeneratePdfInternal(HtmlToPdfConverter.WkHtmlInput[] htmlFiles, string inputContent, string coverHtml, string outputPdfFilePath, Stream outputStream)
    {
      if (!this.batchMode)
        this.EnsureWkHtmlLibs();
      this.CheckWkHtmlProcess();
      string tempPath = this.GetTempPath();
      HtmlToPdfConverter.PdfSettings pdfSettings = new HtmlToPdfConverter.PdfSettings()
      {
        InputFiles = htmlFiles,
        OutputFile = outputPdfFilePath
      };
      List<string> tempFilesList = new List<string>();
      pdfSettings.CoverFilePath = !string.IsNullOrEmpty(coverHtml) ? this.CreateTempFile(coverHtml, tempPath, tempFilesList) : (string) null;
      pdfSettings.HeaderFilePath = !string.IsNullOrEmpty(this.PageHeaderHtml) ? this.CreateTempFile("<!DOCTYPE html><html><head>< meta http - equiv = \"content-type\" content = \"text/html; charset=utf-8\" />< script >function subst() {{    var vars = { { } }; var x = document.location.search.substring(1).split('&');    for(var i in x) { { var z = x[i].split('=', 2); vars[z[0]] = unescape(z[1]); } }var x =['frompage', 'topage', 'page', 'webpage', 'section', 'subsection', 'subsubsection'];    for(var i in x) {    {       var y = document.getElementsByClassName(x[i]);      for (var j = 0; j < y.length; ++j) y[j].textContent = vars[x[i]];  } }  }}</ script ></ head >< body style = \"border:0; margin: 0;\" onload = \"subst()\" >{ this.PageHeaderHtml}</ body ></ html >", tempPath, tempFilesList) : (string) null;
      pdfSettings.FooterFilePath = !string.IsNullOrEmpty(this.PageFooterHtml) ? this.CreateTempFile("<!DOCTYPE html><html><head>< meta http - equiv = \"content -type\" content = \"text/html; charset=utf-8\" /> < script > function subst() {    {      var vars = { { } };    var x = document.location.search.substring(1).split('&');     for(var i in x) { { var z = x[i].split('=', 2); vars[z[0]] = unescape(z[1]); } }     var x =['frompage', 'topage', 'page', 'webpage', 'section', 'subsection', 'subsubsection']; for(var i in x)     {          {          var y = document.getElementsByClassName(x[i]);          for (var j = 0; j < y.length; ++j) y[j].textContent = vars[x[i]];      }  }  }} </ script ></ head >< body style = \"border:0; margin: 0;\" onload = \"subst()\" >{ this.PageFooterHtml}</ body ></ html >", tempPath, tempFilesList) : (string) null;
      if (pdfSettings.InputFiles != null)
      {
        foreach (HtmlToPdfConverter.WkHtmlInput inputFile in pdfSettings.InputFiles)
        {
          inputFile.HeaderFilePath = !string.IsNullOrEmpty(inputFile.PageHeaderHtml) ? this.CreateTempFile("<!DOCTYPE html><html><head>  < meta http - equiv = \"content -type\" content = \"text/html; charset=utf-8\" />  < script >   function subst() {  {    var vars = { { } };      var x = document.location.search.substring(1).split('&'); for(var i in x) { { var z = x[i].split('=', 2); vars[z[0]] = unescape(z[1]); } }  var x =['frompage', 'topage', 'page', 'webpage', 'section', 'subsection', 'subsubsection'];  for(var i in x)     {     {        var y = document.getElementsByClassName(x[i]);      for (var j = 0; j < y.length; ++j) y[j].textContent = vars[x[i]];    }   } }  }</ script ></ head >< body style = \"border:0; margin: 0;\" onload = \"subst()\" >{ input.PageHeaderHtml}</ body ></ html > ", tempPath, tempFilesList) : (string) null;
          inputFile.FooterFilePath = !string.IsNullOrEmpty(inputFile.PageFooterHtml) ? this.CreateTempFile("<!DOCTYPE html><html><head> < meta http - equiv = \"content -type\" content = \"text/html; charset=utf-8\" /> < script > function subst() {      {     var vars = { { } };     var x = document.location.search.substring(1).split('&'); for(var i in x) { { var z = x[i].split('=', 2); vars[z[0]] = unescape(z[1]); } }   var x =['frompage', 'topage', 'page', 'webpage', 'section', 'subsection', 'subsubsection'];  for(var i in x)   {    {    var y = document.getElementsByClassName(x[i]);   for (var j = 0; j < y.length; ++j) y[j].textContent = vars[x[i]];  }  }   } } </ script ></ head >< body style = \"border:0; margin: 0;\" onload = \"subst()\" >{ input.PageFooterHtml}</ body ></ html >", tempPath, tempFilesList) : (string) null;
        }
      }
      try
      {
        if (inputContent != null)
          pdfSettings.InputFiles = new HtmlToPdfConverter.WkHtmlInput[1]
          {
            new HtmlToPdfConverter.WkHtmlInput(this.CreateTempFile(inputContent, tempPath, tempFilesList))
          };
        if (outputStream != null)
          pdfSettings.OutputFile = this.CreateTempFile((string) null, tempPath, tempFilesList);
        if (this.batchMode)
          this.InvokeWkHtmlToPdfInBatch(pdfSettings);
        else
          this.InvokeWkHtmlToPdf(pdfSettings, (string) null, (Stream) null);
        if (outputStream == null)
          return;
        using (FileStream fileStream = new FileStream(pdfSettings.OutputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
          this.CopyStream((Stream) fileStream, outputStream, 65536);
      }
      catch (Exception ex)
      {
        if (!this.batchMode)
          this.EnsureWkHtmlProcessStopped();
        throw new Exception("Cannot generate PDF: " + ex.Message, ex);
      }
      finally
      {
        foreach (string filePath in tempFilesList)
          this.DeleteFileIfExists(filePath);
      }
    }

    private string GetTempPath()
    {
      if (!string.IsNullOrEmpty(this.TempFilesPath) && !Directory.Exists(this.TempFilesPath))
        Directory.CreateDirectory(this.TempFilesPath);
      return this.TempFilesPath ?? Path.GetTempPath();
    }

    private string GetToolExePath()
    {
      if (string.IsNullOrEmpty(this.PdfToolPath))
        throw new ArgumentException("PdfToolPath property is not initialized with path to wkhtmltopdf binaries");
      string path = Path.Combine(this.PdfToolPath, this.WkHtmlToPdfExeName);
      if (!File.Exists(path))
        throw new FileNotFoundException("Cannot find wkhtmltopdf executable: " + path);
      return path;
    }

    private HtmlToPdfConverter.WkHtmlInput[] GetWkHtmlInputFromFiles(string[] files)
    {
      HtmlToPdfConverter.WkHtmlInput[] wkHtmlInputArray = new HtmlToPdfConverter.WkHtmlInput[files.Length];
      for (int index = 0; index < wkHtmlInputArray.Length; ++index)
        wkHtmlInputArray[index] = new HtmlToPdfConverter.WkHtmlInput(files[index]);
      return wkHtmlInputArray;
    }

    private void InvokeWkHtmlToPdf(HtmlToPdfConverter.PdfSettings pdfSettings, string inputContent, Stream outputStream)
    {
      string lastErrorLine = string.Empty;
      DataReceivedEventHandler receivedEventHandler = (DataReceivedEventHandler) ((o, args) =>
      {
        if (args.Data == null)
          return;
        if (!string.IsNullOrEmpty(args.Data))
          lastErrorLine = args.Data;
        // ISSUE: reference to a compiler-generated field
        if (this.LogReceived != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.LogReceived((object) this, args);
        }
      });
      byte[] buffer = inputContent != null ? Encoding.UTF8.GetBytes(inputContent) : (byte[]) null;
      try
      {
        this.WkHtmlToPdfProcess = Process.Start(new ProcessStartInfo(this.GetToolExePath(), this.ComposeArgs(pdfSettings))
        {
          WindowStyle = ProcessWindowStyle.Hidden,
          CreateNoWindow = true,
          UseShellExecute = false,
          WorkingDirectory = Path.GetDirectoryName(this.PdfToolPath),
          RedirectStandardInput = buffer != null,
          RedirectStandardOutput = outputStream != null,
          RedirectStandardError = true
        });
        this.WkHtmlToPdfProcess.ErrorDataReceived += receivedEventHandler;
        this.WkHtmlToPdfProcess.BeginErrorReadLine();
        if (buffer != null)
        {
          this.WkHtmlToPdfProcess.StandardInput.BaseStream.Write(buffer, 0, buffer.Length);
          this.WkHtmlToPdfProcess.StandardInput.BaseStream.Flush();
          this.WkHtmlToPdfProcess.StandardInput.Close();
        }
        long num = 0;
        if (outputStream != null)
          num = (long) this.ReadStdOutToStream(this.WkHtmlToPdfProcess, outputStream);
        this.WaitWkHtmlProcessForExit();
        if (outputStream == null && File.Exists(pdfSettings.OutputFile))
          num = new FileInfo(pdfSettings.OutputFile).Length;
        this.CheckExitCode(this.WkHtmlToPdfProcess.ExitCode, lastErrorLine, num > 0L);
      }
      finally
      {
        this.EnsureWkHtmlProcessStopped();
      }
    }

    private void InvokeWkHtmlToPdfInBatch(HtmlToPdfConverter.PdfSettings pdfSettings)
    {
      string lastErrorLine = string.Empty;
      DataReceivedEventHandler receivedEventHandler = (DataReceivedEventHandler) ((o, args) =>
      {
        if (args.Data == null)
          return;
        if (!string.IsNullOrEmpty(args.Data))
          lastErrorLine = args.Data;
        // ISSUE: reference to a compiler-generated field
        if (this.LogReceived != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.LogReceived((object) this, args);
        }
      });
      if (this.WkHtmlToPdfProcess == null || this.WkHtmlToPdfProcess.HasExited)
      {
        this.WkHtmlToPdfProcess = Process.Start(new ProcessStartInfo(this.GetToolExePath(), "--read-args-from-stdin")
        {
          WindowStyle = ProcessWindowStyle.Hidden,
          CreateNoWindow = true,
          UseShellExecute = false,
          WorkingDirectory = Path.GetDirectoryName(this.PdfToolPath),
          RedirectStandardInput = true,
          RedirectStandardOutput = false,
          RedirectStandardError = true
        });
        this.WkHtmlToPdfProcess.BeginErrorReadLine();
      }
      this.WkHtmlToPdfProcess.ErrorDataReceived += receivedEventHandler;
      try
      {
        if (File.Exists(pdfSettings.OutputFile))
          File.Delete(pdfSettings.OutputFile);
        this.WkHtmlToPdfProcess.StandardInput.WriteLine(this.ComposeArgs(pdfSettings).Replace('\\', '/'));
        bool flag = true;
        while (flag)
        {
          Thread.Sleep(25);
          if (this.WkHtmlToPdfProcess.HasExited)
            flag = false;
          if (File.Exists(pdfSettings.OutputFile))
          {
            flag = false;
            this.WaitForFile(pdfSettings.OutputFile);
          }
        }
        if (!this.WkHtmlToPdfProcess.HasExited)
          return;
        this.CheckExitCode(this.WkHtmlToPdfProcess.ExitCode, lastErrorLine, File.Exists(pdfSettings.OutputFile));
      }
      finally
      {
        if (this.WkHtmlToPdfProcess != null && !this.WkHtmlToPdfProcess.HasExited)
          this.WkHtmlToPdfProcess.ErrorDataReceived -= receivedEventHandler;
        else
          this.EnsureWkHtmlProcessStopped();
      }
    }

    private int ReadStdOutToStream(Process proc, Stream outputStream)
    {
      byte[] buffer = new byte[32768];
      int num = 0;
      int count;
      while ((count = proc.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
      {
        outputStream.Write(buffer, 0, count);
        num += count;
      }
      return num;
    }

    private void WaitForFile(string fullPath)
    {
      double num1;
      if (this.ExecutionTimeout.HasValue)
      {
        TimeSpan? executionTimeout = this.ExecutionTimeout;
        if (executionTimeout.Value != TimeSpan.Zero)
        {
          executionTimeout = this.ExecutionTimeout;
          num1 = executionTimeout.Value.TotalMilliseconds;
          goto label_4;
        }
      }
      num1 = 60000.0;
label_4:
      double num2 = num1;
      int num3 = 0;
      while (num2 > 0.0)
      {
        ++num3;
        num2 -= 50.0;
        try
        {
          using (FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None, 100))
          {
            fileStream.ReadByte();
            break;
          }
        }
        catch (Exception ex)
        {
          Thread.Sleep(num3 < 10 ? 50 : 100);
        }
      }
      if (num2 != 0.0 || this.WkHtmlToPdfProcess == null || this.WkHtmlToPdfProcess.HasExited)
        return;
      this.WkHtmlToPdfProcess.StandardInput.Close();
      this.WkHtmlToPdfProcess.WaitForExit();
    }

    private void WaitWkHtmlProcessForExit()
    {
      if (this.ExecutionTimeout.HasValue)
      {
        if (!this.WkHtmlToPdfProcess.WaitForExit((int) this.ExecutionTimeout.Value.TotalMilliseconds))
        {
          this.EnsureWkHtmlProcessStopped();
          throw new Exception(string.Format("WkHtmlToPdf process exceeded execution timeout ({0}) and was aborted", (object) this.ExecutionTimeout));
        }
      }
      else
        this.WkHtmlToPdfProcess.WaitForExit();
    }

    public string CustomWkHtmlArgs { get; set; }

    public string CustomWkHtmlCoverArgs { get; set; }

    public string CustomWkHtmlPageArgs { get; set; }

    public string CustomWkHtmlTocArgs { get; set; }

    public TimeSpan? ExecutionTimeout { get; set; }

    public bool GenerateToc { get; set; }

    public bool Grayscale { get; set; }

    public bool LowQuality { get; set; }

    public HtmlToPdfConverter.PageOrientation Orientation { get; set; }

    public string PageFooterHtml { get; set; }

    public string PageHeaderHtml { get; set; }

    public float? PageHeight { get; set; }

    public float? PageWidth { get; set; }

    public string PdfToolPath { get; set; }

    public bool Quiet { get; set; }

    public HtmlToPdfConverter.PageSize Size { get; set; }

    public string TempFilesPath { get; set; }

    public string TocHeaderText { get; set; }

    public string WkHtmlToPdfExeName { get; set; }

    public float Zoom { get; set; }

    public class PdfSettings
    {
      public string CoverFilePath;
      public string FooterFilePath;
      public string HeaderFilePath;
      public HtmlToPdfConverter.WkHtmlInput[] InputFiles;
      public string OutputFile;
    }

    public class WkHtmlInput
    {
      public WkHtmlInput(string inputFileOrUrl)
      {
        this.Input = inputFileOrUrl;
      }

      public string CustomWkHtmlPageArgs { get; set; }

      internal string FooterFilePath { get; set; }

      internal string HeaderFilePath { get; set; }

      public string Input { get; set; }

      public string PageFooterHtml { get; set; }

      public string PageHeaderHtml { get; set; }
    }

    public enum PageOrientation
    {
      Default,
      Landscape,
      Portrait,
    }

    public enum PageSize
    {
      Default,
      A4,
      A3,
      Letter,
    }
  }
}
