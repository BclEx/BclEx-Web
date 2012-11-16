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
#if EXPERIMENTAL
using System.Collections.Generic;
using Contoso.Abstract.Micro;
namespace Contoso.Practices.FatPipe
{
    [JsonSerializable]
    public class PageletData
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("cacheable")]
        public bool Cacheable { get; set; }

        [JsonProperty("cache_hit")]
        public bool CacheHit { get; set; }

        [JsonProperty("bootloadable")]
        public bool BootLoadable { get; set; }


        // MAP
        [JsonProperty("jscc_map")]
        public Dictionary<string, string> JsccMap { get; set; }

        [JsonProperty("resource_map")]
        public Dictionary<string, PageletResourceRef> ResourceMap { get; set; }


        // CONTENT
        [JsonProperty("append")]
        public string Append { get; set; }

        [JsonProperty("content")]
        public Dictionary<string, PageletContainerRef> Content { get; set; }

        [JsonProperty("has_inline_js")]
        public bool HasInlineJS { get; set; }


        // JS
        [JsonProperty("js")]
        public List<string> JS { get; set; }

        [JsonProperty("jsmods")]
        public object JSMods { get; set; }

        [JsonProperty("requires")]
        public List<string> JSRequires { get; set; }

        [JsonProperty("provides")]
        public List<string> JSProvides { get; set; }

        [JsonProperty("onload")]
        public string OnLoad { get; set; }

        [JsonProperty("onafterload")]
        public string OnAfterLoad { get; set; }

        [JsonProperty("ondisplay")]
        public string OnDisplay { get; set; }


        // CSS
        [JsonProperty("css")]
        public List<string> Css { get; set; }

        [JsonProperty("display_dependency")]
        public List<string> DisplayDependency { get; set; }


        // PRIVATE
        [JsonProperty("phase")]
        internal int Phase { get; set; }

        [JsonProperty("is_last")]
        internal bool IsLast { get; set; }

        [JsonProperty("the_end")]
        internal bool TheEnd { get; set; }

        [JsonProperty("tti_phase")]
        internal bool TtiPhase { get; set; }

        [JsonProperty("is_second_to_last_phase")]
        internal bool IsSecondToLastPhase { get; set; }
    }
}
#endif