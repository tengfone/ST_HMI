using System.Linq;
using System.Security.Principal;
using System;

namespace ST_HMI.Services
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity _identity;

        public CustomIdentity Identity
        {
            get
            {
                if (_identity != null)
                    return _identity;
                else
                    return new AnonymousIdentity();
            }
            set { _identity = value; }
        }

        IIdentity IPrincipal.Identity
        {
            get { return this.Identity; }
        }

        public bool IsInRole(string role)
        {
            return _identity.Roles.Contains(role);
        }
    }
}
