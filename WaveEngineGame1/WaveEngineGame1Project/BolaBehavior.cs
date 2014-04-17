#region Using Statemets
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Common.Input;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;
#endregion

namespace WaveEngineGame1Project
{
    class BolaBehavior : Behavior
    {
        [RequiredComponent]
        Transform2D transform;

        private int id;

        public BolaBehavior(int id)
        {
            this.id = id;
        }

        protected override void Update(TimeSpan gameTime)
        {
            if (transform.Y > Game.VMHeight)
            {
                Entity ball = EntityManager.Find("bola" + id);
                EntityManager.Remove(ball);
            }
        }

    }
}
