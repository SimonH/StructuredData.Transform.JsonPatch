using System.ComponentModel.Composition;
using System.Dynamic;
using Marvin.JsonPatch.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using StructuredData.Transform.interfaces;

namespace StructuredData.Transform.JsonPatch
{
    [Export(typeof(ITransformStructuredData))]
    [ExportMetadata("MimeType", "application/json")]
    [ExportMetadata("Method", "jsonpatch")]
    public class JsonJsonPatchStructuredDataTransformer : ITransformStructuredData
    {
        public string Transform(string sourceData, string transformData)
        {
            var jpd = JsonConvert.DeserializeObject<JsonPatchDocument>(transformData);
            var converter = new ExpandoObjectConverter();
            dynamic jsonObject = JsonConvert.DeserializeObject<ExpandoObject>(sourceData, converter);
            jpd.ApplyTo(jsonObject);
            return JsonConvert.SerializeObject(jsonObject);
        }
    }
}