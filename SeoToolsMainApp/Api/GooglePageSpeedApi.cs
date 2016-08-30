using System;
using Newtonsoft.Json;
using SeoToolsMainApp.Core;
using System.Text;
using SeoToolsMainApp.Interfaces;
using SeoToolsMainApp.Models;

namespace SeoToolsMainApp.Api
{
    public class GooglePageSpeedApi :AbstractApi, IGooglePageSpeed
    {
        public string TitleOfSite { set; get; }
        public string SpeedScore { set; get; }
        public string NumberOfHosts { set; get; }
        public string NumberStaticOfResources { set; get; }
        public string NumberJsResources { set; get; }
        public string NumberCssResources { set; get; }
        public string HtmlSize { set; get; }
        public string CssSize { set; get; }
        public string ImageSize { set; get; }
        public string JavaScriptSize { set; get; }
        public GooglePageSpeedApi(string url)
        {
            try
            {
                string json = HttpProtocol.TakeData($"https://www.googleapis.com/pagespeedonline/v2/runPagespeed?url={url}", "GET", Encoding.UTF8);
                var pageSpeed = JsonConvert.DeserializeObject<GooglePageSpeed>(json);
                TitleOfSite = pageSpeed.Title;
                SpeedScore = pageSpeed.RuleGroups.Speed.Score;
                NumberOfHosts = pageSpeed.PageStats.NumberHosts.ToString();
                NumberStaticOfResources = pageSpeed.PageStats.NumberResources.ToString();
                NumberJsResources = pageSpeed.PageStats.NumberJsResources.ToString();
                NumberCssResources = pageSpeed.PageStats.NumberCssResources.ToString();
                HtmlSize = ConvertToKiloBits(pageSpeed.PageStats.HtmlResponseBytes);
                CssSize = ConvertToKiloBits(pageSpeed.PageStats.CssResponseBytes);
                ImageSize = ConvertToKiloBits(pageSpeed.PageStats.ImageResponseBytes);
                JavaScriptSize = ConvertToKiloBits(pageSpeed.PageStats.JavascriptResponseBytes);
            }
            catch (Exception)
            {
                // ignored
            }
        }
        private string ConvertToKiloBits(int number)
        {
            return $"{number / 1024} килобайт";
        }

    }
    /// <summary>
    /// Модель получения данных от GooglePageSpeed Api
    /// </summary>
    class GooglePageSpeed
    {
        public string Kind { get; set; }
        public string Id { get; set; }
        public string ResponseCode { get; set; }
        public string Title { get; set; }
        public RuleGroups RuleGroups { get; set; }
        public PageStats PageStats { get; set; }
        public Version Version { get; set; }
    }
    class RuleGroups
    {
        public Speed Speed { get; set; }
    }
    class Speed
    {
        public string Score { get; set; }
    }
    class PageStats
    {
        public int NumberResources { get; set; }
        public int NumberHosts { get; set; }
        public int TotalRequestedBytes { get; set; }
        public int NumberStaticResources { get; set; }
        public int HtmlResponseBytes { get; set; }
        public int CssResponseBytes { get; set; }
        public int ImageResponseBytes { get; set; }
        public int JavascriptResponseBytes { get; set; }
        public int OtherResponseBytes { get; set; }
        public int NumberJsResources { get; set; }
        public int NumberCssResources { get; set; }
    }
    class FormattedResults
    {
        public string Locale { get; set; }
        public RuleResults RuleResults { get; set; }
    }
    class RuleResults
    {
        public AvoidLandingPageRedirects AvoidLandingPageRedirects { get; set; }
    }
    class AvoidLandingPageRedirects
    {
        public string LocalizedRuleName { get; set; }
        public int RuleImpact { get; set; }
        public string[] Groups { get; set; }
        public Summary Summary { get; set; }
    }
    class Summary
    {
        public string Format { get; set; }
        public Args[] Args { get; set; }
    }
    class Args
    {
        public string Type { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
    class EnableGzipCompression
    {
        public string LocalizedRuleName { get; set; }
        public float RuleImpact { get; set; }
        public string[] Groups { get; set; }
        public Summary[] Summary { get; set; }
        public UrlBlocks[] UrlBlocks { get; set; }
    }
    class UrlBlocks
    {
        public Header[] Header { get; set; }
        public Urls[] Urls { get; set; }
    }
    class Header
    {
        public string Format { get; set; }
        public Args[] Args { get; set; }
    }
    class Urls
    {
        public Header[] Result { get; set; }
    }
    class LeverageBrowserCaching
    {
        public string LocalizedRuleName { get; set; }
        public float RuleImpact { get; set; }
        public string[] Groups { get; set; }
        public Summary Summary { get; set; }
        public UrlBlocks[] UrlBlocks { set; get; }
    }
    class MainResourceServerResponseTime
    {
        public string LocalizedRuleName { get; set; }
        public int RuleImpact { get; set; }
        public string[] Groups { get; set; }
        public Summary Summary { get; set; }
    }
    class MinifyCss
    {
        public string LocalizedRuleName { get; set; }
        public int RuleImpact { get; set; }
        public string[] Groups { get; set; }
        public Summary[] Summary { get; set; }
    }
    class MinifyHtml
    {
        public string LocalizedRuleName { get; set; }
        public int RuleImpact { get; set; }
        public string[] Groups { get; set; }
        public Summary[] Summary { get; set; }
    }
    class MinifyJavaScript
    {
        public string LocalizedRuleName { get; set; }
        public int RuleImpact { get; set; }
        public string[] Groups { get; set; }
        public Summary Summary { get; set; }
        public UrlBlocks[] UrlBlocks { get; set; }
    }
    class MinimizeRenderBlockingResources
    {
        public string LocalizedRuleName { get; set; }
        public int RuleImpact { get; set; }
        public string[] Groups { get; set; }
        public Summary Summary { get; set; }
        public UrlBlocks[] UrlBlocks { get; set; }
    }
    class OptimizeImages
    {
        public string LocalizedRuleName { get; set; }
        public int RuleImpact { get; set; }
        public string[] Groups { get; set; }
        public Summary Summary { get; set; }
        public UrlBlocks[] UrlBlocks { get; set; }
    }
    class PrioritizeVisibleContent
    {
        public string LocalizedRuleName { get; set; }
        public int RuleImpact { get; set; }
        public string[] Groups { get; set; }
        public Summary Summary { get; set; }
    }
    class Version
    {
        public string Major { set; get; }
        public string Minor { set; get; }
    }
}