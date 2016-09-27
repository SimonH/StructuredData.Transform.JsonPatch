using System.Runtime.InteropServices;
using Marvin.JsonPatch.Dynamic;
using Newtonsoft.Json;
using NUnit.Framework;

namespace StructuredData.Transform.JsonPatch.Tests
{
    [TestFixture]
    public class JsonJsonPatchStructuredDataTransformerFixture
    {
        [Test]
        public void SimpleTransform()
        {
            var json = "{ \"Value\":\"Initial\" }";
            var jsonPatch = "[{\"op\": \"replace\", \"path\": \"/Value\", \"value\":\"Replaced\"}]";
            var expected = "{\"Value\":\"Replaced\"}";
            var candidate = new JsonJsonPatchStructuredDataTransformer().Transform(json, jsonPatch);
            Assert.That(candidate, Is.EqualTo(expected));
        }

        [Test]
        public void TransformArrayItems()
        {
            var json = @"{ ""Values"":[""one"",""two"",""three""]}";
            var jsonPatch = "[{\"op\": \"replace\", \"path\": \"/Values/1\", \"value\":\"four\"},{\"op\": \"add\", \"path\": \"/Values/-\", \"value\":\"five\"}]";
            var expected = @"{""Values"":[""one"",""four"",""three"",""five""]}";
            var candidate = new JsonJsonPatchStructuredDataTransformer().Transform(json, jsonPatch);
            Assert.That(candidate, Is.EqualTo(expected));
        }
    }
}