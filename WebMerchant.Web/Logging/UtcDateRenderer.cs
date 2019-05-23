using System.Globalization;
using System.Text;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace WebMerchant.Web.Logging
{
    [LayoutRenderer("utc_date")]
    public class UtcDateRenderer : LayoutRenderer
    {
        /// Initializes a new instance of the  class.
        public UtcDateRenderer()
        {
            Format = "G";
            Culture = CultureInfo.InvariantCulture;
        }

        /// Gets or sets the culture used for rendering.
        public CultureInfo Culture { get; set; }

        /// Gets or sets the date format. Can be any argument accepted by DateTime.ToString(format).
        [DefaultParameter]
        public string Format { get; set; }

        /// Renders the current date and appends it to the specified .
        /// <param name="builder">
        ///     The  to append the rendered data to.
        /// </param>
        /// <param name="logEvent">Logging event.</param>
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(logEvent.TimeStamp.ToUniversalTime()
                                   .ToString(Format, Culture));
        }
    }
}