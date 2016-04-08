using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class FieldManipulationExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new FieldManipulationExample();
            example.Run();

            // Test if all signatures are added properly
            var fieldDictionary = ConvertListToMap(example.addedFields);

            Assert.IsTrue(fieldDictionary.ContainsKey(example.field1.Name));
            Assert.IsTrue(fieldDictionary.ContainsKey(example.field2.Name));
            Assert.IsTrue(fieldDictionary.ContainsKey(example.field3.Name));

            // Test if field1 is deleted properly
            fieldDictionary = ConvertListToMap(example.deletedFields);

            Assert.IsFalse(fieldDictionary.ContainsKey(example.field1.Name));
            Assert.IsTrue(fieldDictionary.ContainsKey(example.field2.Name));
            Assert.IsTrue(fieldDictionary.ContainsKey(example.field3.Name));

            // Test if field3 is updated properly
            fieldDictionary = ConvertListToMap(example.updatedFields);

            Assert.IsFalse(fieldDictionary.ContainsKey(example.field1.Name));
            Assert.IsTrue(fieldDictionary.ContainsKey(example.field2.Name));
            Assert.IsTrue(fieldDictionary.ContainsKey(example.updatedField.Name));
        }

        private Dictionary<string, Field> ConvertListToMap(List<Field> fieldList)
        {
            var fieldDictionary = new Dictionary<string,Field>();
            foreach(var field in fieldList)
            {
                fieldDictionary.Add(field.Name, field);
            }
            return fieldDictionary;
        }
    }
}

