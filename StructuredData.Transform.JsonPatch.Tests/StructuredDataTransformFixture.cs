using NUnit.Framework;

namespace StructuredData.Transform.JsonPatch.Tests
{
    [TestFixture]
    public class StructuredDataTransformFixture
    {
        [Test]
        public void SimpleTransform()
        {
            var json = "{ \"Value\":\"Initial\" }";
            var jsonPatch = "[{\"op\": \"replace\", \"path\": \"/Value\", \"value\":\"Replaced\"}]";
            var expected = "{\"Value\":\"Replaced\"}";
            var candidate = json.Transform(jsonPatch, "application/json", "jsonpatch");
            Assert.That(candidate, Is.EqualTo(expected));
        }
    }
}