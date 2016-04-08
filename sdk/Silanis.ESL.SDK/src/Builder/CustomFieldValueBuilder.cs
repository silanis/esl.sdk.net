using System;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK.Builder
{
    public class CustomFieldValueBuilder
    {
        private string id;
        private string value;

        ///
        /// Creates an user custom field builder with field id
        ///
        /// @param id of user custom field
        /// @return a user custom field builder with field id
        ///
        public static CustomFieldValueBuilder CustomFieldValueWithId(string id)
        {
            return new CustomFieldValueBuilder().WithId(id);
        }

        internal static CustomFieldValueBuilder CustomFieldValue(UserCustomField userCustomField)
        {
            return new CustomFieldValueBuilder().
                WithId(userCustomField.Id).
                WithValue(userCustomField.Value);
        }

        ///
        /// Sets id of user custom field
        ///
        /// @param id of user custom field
        /// @return the user custom field builder itself
        ///
        public CustomFieldValueBuilder WithId(string id)
        {
            this.id = id;
            return this;
        }

        ///
        /// Sets value of user custom field
        ///
        /// @param value of user custom field
        /// @return the user custom field builder itself
        ///
        public CustomFieldValueBuilder WithValue(string value)
        {
            this.value = value;
            return this;
        }

        ///
        /// Builds the user custom field
        ///
        /// @return the user custom field
        ///
        public CustomFieldValue build()
        {
            var result = new CustomFieldValue();
            result.Id = id;
            result.Value = value;

            return result;
        }

    }
}

