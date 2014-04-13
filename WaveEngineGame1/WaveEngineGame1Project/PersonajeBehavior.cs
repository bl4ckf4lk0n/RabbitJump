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
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services; 
#endregion

namespace WaveEngineGame1Project
{
    public class PersonajeBehavior : Behavior
    {
        [RequiredComponent]
        public RigidBody2D body;
        [RequiredComponent]
        public Transform2D transform;
        [RequiredComponent]
        public PerPixelCollider collider;

        private KeyboardState lastKeyboardState;


        private Input input;


        public PersonajeBehavior()
        {
            this.lastKeyboardState = new KeyboardState();
            input = WaveServices.Input;

        }

        protected override void Update(TimeSpan gameTime)
        {


            if (input.KeyboardState.D == ButtonState.Pressed)
            {
                body.ApplyLinearImpulse(new Vector2(0.2f, 0));
            }
            else if (input.KeyboardState.A == ButtonState.Pressed)
            {
                body.ApplyLinearImpulse(new Vector2(-0.2f, 0));
            }

            /*Input input = WaveServices.Input;

                if (input.KeyboardState.Space == ButtonState.Pressed &&
                    this.lastKeyboardState.Space == ButtonState.Release && intentos < 2)
                {
                    body.ApplyLinearImpulse(new Vector2(0, -2));
                    intentos++;
                }

            this.lastKeyboardState = input.KeyboardState;


            Entity pjProta = this.EntityManager.Find("personaje");
            Collider2D colPj = pjProta.FindComponent<PerPixelCollider>();

            Entity bola = this.EntityManager.Find("mountain");
            Collider2D collider = bola.FindComponent<PerPixelCollider>();

            Entity suelo = this.EntityManager.Find("suelo");
            Collider2D col_suelo = suelo.FindComponent<RectangleCollider>();

            if (transform.Y == WaveServices.Platform.ScreenHeight - 250)
            {
                 intentos = 0;
            }*/

            /*Entity pjProta = this.EntityManager.Find("personaje");
            Collider2D colPj = pjProta.FindComponent<PerPixelCollider>();

            Entity suelo = this.EntityManager.Find("floor");
            Collider2D colPj2 = suelo.FindComponent<RectangleCollider>();

            if (colPj.Intersects(colPj2))
            {
                body.ApplyLinearImpulse(new Vector2(0, -2));
            }*/
        }
    }
}
