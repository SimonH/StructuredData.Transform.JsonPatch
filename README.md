# StructuredData.Transform.JsonPatch
Implementation of StructuredData.Transform that transforms json using JsonPatch 
{via [Json.NET](http://www.newtonsoft.com/json) and [Marvin.JsonPatch.Dynamic](https://github.com/KevinDockx/JsonPatch.Dynamic)}

Available as a package on [Nuget](https://www.nuget.org/packages/StructuredData.Transform.JsonPatch/)

##Usage

* Install the package and it's dependencies  
   > install-package StructuredData.Transform.JsonPatch
* Use one of the extension methods on StructuredDataTransform
   [E.g. "source json text".Transform("json patch data", "application/json", "jsonPatch")]
   

