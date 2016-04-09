using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class GroupBuilder
    {
        private GroupId id;
        private string name;
        private string email;
        private DateTime created;
        private DateTime updated;
        private bool emailMembers;
        private List<GroupMember> members;

        private GroupBuilder( string name )
        {
            this.name = name;
            members = new List<GroupMember>();
        }

        public static GroupBuilder NewGroup( string name ) {
            return new GroupBuilder(name);
        }

        public GroupBuilder WithEmail( string email ) {
            this.email = email;
            return this;
        }

        public GroupBuilder CreatedOn( DateTime created ) {
            this.created = created;
            return this;
        }

        public GroupBuilder UpdatedOn( DateTime updated ) {
            this.updated = updated;
            return this;
        }

        public GroupBuilder WithIndividualMemberEmailing() {
            emailMembers = true;
            return this;
        }

        public GroupBuilder WithoutIndividualMemberEmailing() {
            emailMembers = false;
            return this;
        }

        public GroupBuilder WithMember( GroupMemberBuilder builder ) {
            return WithMember(builder.Build());
        }

        public GroupBuilder WithMember( GroupMember groupMember ) {
            members.Add(groupMember);
            return this;
        }

        public GroupBuilder WithId( GroupId id ) {
            this.id = id;
            return this;
        }

        public Group Build() {
            var result = new Group();
            result.Id = id;
            result.Email = email;
            result.Created = created;
            result.Updated = updated;
            result.Name = name;
            result.EmailMembers = emailMembers;

            foreach( var groupMember in members ) {
                result.Members.Add( groupMember );
            }

            return result;
        }
    }
}

