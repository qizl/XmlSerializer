using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XmlSerializerLibrary
{
    public class XmlSerialize
    {
        public XmlDocument Xml { get; protected set; }

        public XmlDocument Serialize(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", ""); // 去除默认命名空间

                XmlSerializer xs = new XmlSerializer(obj.GetType());
                xs.Serialize(ms, obj, ns);

                ms.Seek(0, SeekOrigin.Begin);

                this.Xml = new XmlDocument();
                this.Xml.Load(ms);
            }

            return this.Xml;
        }

        public T Deserialize<T>(XmlDocument xml) where T : class
        {
            object obj;
            using (MemoryStream ms = new MemoryStream())
            {
                xml.Save(ms);
                ms.Seek(0, SeekOrigin.Begin);
                using (XmlReader reader = XmlReader.Create(ms))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    obj = xs.Deserialize(reader);
                }
            }
            return obj as T;
        }
    }
}
