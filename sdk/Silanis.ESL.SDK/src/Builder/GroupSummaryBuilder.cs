using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class GroupSummaryBuilder
    {
        private IDictionary<string, object> data;
        private string email;
        private string id;
        private string name;

        private GroupSummaryBuilder( string email )
        {
            this.email = email;
        }

        public static GroupSummaryBuilder NewGroupSummary( string email ) 
        {
            return new GroupSummaryBuilder(email);
        }

        public GroupSummaryBuilder WithId( string id ) 
        {
            this.id = id;
            return this;
        }

        public GroupSummaryBuilder WithName( string name ) 
        {
            this.name = name;
            return this;
        }

        public GroupSummaryBuilder WithData( IDictionary<string, object> data ) 
        {
            this.data = data;
            return this;
        }

        public Silanis.ESL.SDK.GroupSummary Build() 
        {
            Silanis.ESL.SDK.GroupSummary result = new Silanis.ESL.SDK.GroupSummary();
            result.Email = email;
            result.Id = id;
            result.Name = name;
            result.Data = data;
            return result;
        }
    }
}

