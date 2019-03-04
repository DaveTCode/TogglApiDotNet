using System;

namespace TogglApi.Client.Reports.Models.Response
{
    /// <inheritdoc />
    /// <summary>
    /// Used to mark objects that need to be mapped to specific url values.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal class ToggleApiUrlValueAttribute : Attribute
    {
        internal string UrlValue { get; }

        public ToggleApiUrlValueAttribute(string urlValue)
        {
            UrlValue = urlValue;
        }
    }
}