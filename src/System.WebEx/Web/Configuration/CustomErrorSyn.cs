#region License
/*
The MIT License

Copyright (c) 2008 Sky Morey

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion
using System.Configuration;
using System.ComponentModel;
using System.Reflection;
namespace System.Web.Configuration
{
    /// <summary>
    /// CustomErrorSyn
    /// </summary>
    public class CustomErrorSyn : ConfigurationElementSyn<CustomError>
    {
        private static readonly ConfigurationPropertyCollection _properties = new ConfigurationPropertyCollection();
        private static readonly ConfigurationProperty _propUrlRoutingType = new ConfigurationProperty("urlRoutingType", typeof(Type), null, new TypeNameConverter(), null, ConfigurationPropertyOptions.None, "Enabled UrlRouting Custom Errors");

        static CustomErrorSyn()
        {
            _properties.Add(_propUrlRoutingType);
            // add to config
            var propertiesField = typeof(CustomErrorsSection).GetField("_properties", BindingFlags.NonPublic | BindingFlags.Static);
            var properties = (ConfigurationPropertyCollection)propertiesField.GetValue(null);
            foreach (var property in _properties)
                properties.Add((ConfigurationProperty)property);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomErrorSyn"/> class.
        /// </summary>
        /// <param name="syn">The syn.</param>
        public CustomErrorSyn(CustomError syn)
            : base(syn) { }

        /// <summary>
        /// Gets or sets the type of the URL routing.
        /// </summary>
        /// <value>
        /// The type of the URL routing.
        /// </value>
        [ConfigurationProperty("urlRoutingType")]
        [TypeConverter(typeof(TypeNameConverter))]
        public Type UrlRoutingType
        {
            get { return (Type)base[_propUrlRoutingType]; }
            set { base[_propUrlRoutingType] = value; }
        }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }

        /// <summary>
        /// Registers the by touch.
        /// </summary>
        public static void RegisterByTouch() { }
    }
}