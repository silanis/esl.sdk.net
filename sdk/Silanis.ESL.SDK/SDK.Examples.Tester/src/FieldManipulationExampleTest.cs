using System;
using NUnit.Framework;
using System.Collections.Generic;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class FieldManipulationExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            FieldManipulationExample example = new FieldManipulationExample();
            example.Run();

            // Test if all signatures are added properly
            Dictionary<string,Field> fieldDictionary = ConvertListToMap(example.addedFields);

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
            Dictionary<string,Field> fieldDictionary = new Dictionary<string,Field>();
            foreach(Field field in fieldList)
            {
                fieldDictionary.Add(field.Name, field);
            }
            return fieldDictionary;
        }
    }
}

