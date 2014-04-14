#region Using Statemets
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Common.Input;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;
#endregion

namespace WaveEngineGame1Project
{
    class BolaBehavior : Behavior
    {
        [RequiredComponent]
        public RigidBody2D body;
        [RequiredComponent]
        public CircleCollider collider;

        private Vector2 pjPosition = Vector2.Zero;

        protected override void Update(TimeSpan gameTime)
        {

        }

    }
}
