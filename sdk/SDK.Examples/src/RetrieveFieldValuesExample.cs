using System;
using System.IO;
using System.Collections.Generic;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    /// <summary>
    /// Retrieves the values found in the fields of each of the documents in a package.
    /// </summary>
    public class RetrieveFieldValuesExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new RetrieveFieldValuesExample().Run();
        }

        override public void Execute()
        {
            var packageId = new PackageId("");

            IList<FieldSummary> fieldSummaries = eslClient.FieldSummaryService.GetFieldSummary(packageId);

            Console.WriteLine("SignerId,\t DocumentId, \tFieldId \tFieldName \tValue");
            foreach (var fieldSummary in fieldSummaries)
            {
                Console.WriteLine(fieldSummary.SignerId + ", \t" +
                    fieldSummary.DocumentId + ", \t" +
                    fieldSummary.FieldId + ", \t" +
                    fieldSummary.FieldName + ", \t" +
                    fieldSummary.FieldValue + "\n");
            }
        }
    }
}

 