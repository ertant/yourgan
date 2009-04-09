using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Parser
{
    public class EntityErrorEventArgs : EventArgs
    {
        public EntityErrorEventArgs(EntityErrorCode code, Entity entity)
        {
            this.code = code;
            this.entity = entity;
        }

        private EntityErrorCode code;

        public EntityErrorCode Code
        {
            get
            {
                return code;
            }
        }

        private Entity entity;

        public Entity Entity
        {
            get
            {
                return entity;
            }
        }
    }
}
