using System;
using System.Security.Principal;


namespace ST_HMI.Services
{
    public class AnonymousIdentity : CustomIdentity
    {
        public AnonymousIdentity()
            : base(string.Empty, string.Empty, new string[] { }) { }
    }
}
