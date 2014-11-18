using Com.EnjoyCodes.SharpSerializer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace XmlSerializerTest
{
    /// <summary>
    /// 序列化方法测试类
    /// </summary>
    public class TestClass
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public List<int> Values { get; set; }
        public List<float> Values2 { get; set; }
        public byte[] Values3 { get; set; }
        public Dictionary<string, int> Value4 { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TestClass t = new TestClass()
            {
                ID = Guid.NewGuid(),
                Name = "睡觉了快递费",
                Number = 123,
                Values = new List<int>() { 1, 2, 3, 4, 5 },
                Values2 = new List<float>() { 1, 2, 3, 4, 5 },
                Values3 = new byte[] { 1, 2, 3, 4, 5 },
                Value4 = new Dictionary<string, int>() { { "1", 1 }, { "2", 2 } }
            };

            SharpSerializer s = new SharpSerializer();
            string path = Path.Combine(Environment.CurrentDirectory, "test.xml");

            s.Serialize(t, path);

            var t1 = s.Deserialize(path);
        }
    }
}
