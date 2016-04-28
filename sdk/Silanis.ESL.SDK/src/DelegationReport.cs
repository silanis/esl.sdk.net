using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class DelegationReport
    {
        private IDictionary<string, IList<DelegationEventReport>> delegationEvents = new Dictionary<string, IList<DelegationEventReport>> ();

        public IDictionary<string, IList<DelegationEventReport>> DelegationEvents
        {
            get
            {
                return delegationEvents;
            }
            set{ delegationEvents = value;}
        }

        public Nullable<DateTime> From
        {
            get; set;
        }

        public Nullable<DateTime> To
        {
            get; set;
        }
    }
}

