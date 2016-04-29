using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace SDK.Examples
{
    [TestFixture]
    public class SDKSampleTest
    {
        public static void Main(string[] args) {
            new SDKSampleTest().test();
        }

        private Props properties = Props.GetInstance();

        public void runAllSamples(List<Exception> exceptionsThrown) {
        }

        private SDKSample instantiateSample( Type sampleType ) {
            ConstructorInfo constructorInfo = sampleType.GetConstructor(new[] { typeof(Props) } );
            return (SDKSample)constructorInfo.Invoke(new object[] { properties });
        }

        public void runAllSamples() {
            List<Type> sampleTypes = getSampleTypes();
            foreach (Type t in sampleTypes) {
            }
        }

        private List<Type> getSampleTypes() {
            List<Type> result = new List<Type>();
            Assembly a = Assembly.GetExecutingAssembly();
            {
                foreach (Type t in a.GetTypes())
                {
                    if (t.IsSubclassOf(typeof(SDKSample)))
                    {
                        result.Add(t);
                    }
                }
            }
            return result;
        }

        [Test]
        public void test() {
            List<Exception> exceptionsThrown = new List<Exception>();
            try {
                SDKSampleTest runner = new SDKSampleTest();
                runner.runAllSamples(exceptionsThrown);
            } catch (Exception e) {
                Assert.Fail("Unable to inspect packages and classes." + e);
            }
            Assert.AreEqual(exceptionsThrown.Count,0);
        }
    }
}

