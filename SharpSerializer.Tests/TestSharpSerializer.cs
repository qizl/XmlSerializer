using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Com.EnjoyCodes.SharpSerializer;
using System.Diagnostics;

namespace SharpSerializerTests
{
    [TestClass]
    public class TestSharpSerializer
    {
        public class Test
        {
            public Guid ID { get; set; }
            public string Name { get; set; }
            public DateTime Time { get; set; }
        }

        [TestMethod]
        public void TestSerialize()
        {
            List<Test> datas = new List<Test>();
            for (int i = 0; i < 100; i++)
                datas.Add(new Test()
                {
                    ID = Guid.NewGuid(),
                    Name = "Test" + Guid.NewGuid(),
                    Time = DateTime.Now
                });
            SharpSerializer serializer = new SharpSerializer();
            string str = serializer.Serialize(datas);
            Debug.WriteLine(str);

            Assert.IsTrue(!string.IsNullOrEmpty(str));
        }
    }
}
