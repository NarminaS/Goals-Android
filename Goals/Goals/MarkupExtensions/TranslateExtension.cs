using Goals.Helpers;
using Goals.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Goals.MarkupExtensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private readonly CultureInfo ci;
        private const string ResourceNamespace = "Goals.Localization.Resource";

        public string Text { get; set; }    

        public TranslateExtension()
        {
            ci = new CultureInfo(ApplicationSettings.CurrentCulture);
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";
            ResourceManager resourceManager = new ResourceManager(ResourceNamespace, typeof(TranslateExtension).GetTypeInfo().Assembly);

            var translation = resourceManager.GetString(Text, ci);
            if (translation == null)
            {
                translation = Text;
            }
            return translation;
        }
    }
}
