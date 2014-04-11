#region Using Statemets
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class PersonajeBehavior : Behavior
    {
        [RequiredComponent]
        public RigidBody2D body;

        private KeyboardState lastKeyboardState;

        private EventLog myLog;

        public PersonajeBehavior()
        {
            this.lastKeyboardState = new KeyboardState();
        }

        protected override void Update(TimeSpan gameTime)
        {
            Input input = WaveServices.Input;
            int intentos = 0;

            if (input.KeyboardState.Space == ButtonState.Pressed &&
                this.lastKeyboardState.Space == ButtonState.Release && intentos < 2) 
            {
                body.ApplyLinearImpulse(new Vector2(0,-2));
                intentos++;
            }

            this.lastKeyboardState = input.KeyboardState;

            /*Entity pjProta = this.EntityManager.Find("personaje");
            Collider2D colPj = pjProta.FindComponent<PerPixelCollider>();

            Entity bola = this.EntityManager.Find("mountain");
            Collider2D collider = bola.FindComponent<PerPixelCollider>();

            if (collider.Intersects(colPj))
            {
                body.ApplyLinearImpulse(new Vector2(-3, -2));
            }*/
        }
    }
}
