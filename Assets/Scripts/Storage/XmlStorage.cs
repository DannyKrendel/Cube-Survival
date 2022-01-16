using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class XmlStorage : IStorage<LocalizationData>
{
    public LocalizationData Get(string path)
    {
        try
        {
#if UNITY_ANDROID
            var reader = new WWW(path);
            while(!reader.isDone) { }
            var stream = new MemoryStream(reader.bytes);
            var doc = XDocument.Load(stream);
            stream.Close();
#endif
            return new LocalizationData
            {
                languageName = doc.Element("localizationData")?.Attribute("languageName")?.Value,
                items = doc.Element("localizationData")?.Elements("item").Select(x => new LocalizationDataItem
                {
                    key = x.Attribute("key")?.Value,
                    value = x.Attribute("value")?.Value
                }).ToArray()
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Couldn't get object from '{path}'.", ex);
        }
    }
}