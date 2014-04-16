#region Using Statemets
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Input;
using WaveEngine.Common.Math;
using WaveEngine.Components.Animation;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services; 
#endregion

namespace WaveEngineGame1Project
{
    public class PersonajeBehavior : Behavior
    {

        private const int SPEED = 5;
        private const int RIGHT = 1;
        private const int LEFT = -1;
        private const int NONE = 0;
        private const int BORDER_OFFSET = 25;


        [RequiredComponent]
        public RigidBody2D body;
        [RequiredComponent]
        public Transform2D trans2D;
        [RequiredComponent]
        public RectangleCollider collider;

        [RequiredComponent]
        public Animation2D anim2D;

        private enum AnimState { Idle, Right, Left };
        private AnimState currentState, lastState;

        private int direction;
        private KeyboardState lastKeyboardState;
        private TouchPanelState touchpanel;


        private Input input;
        private MyScene escena;


        public PersonajeBehavior(MyScene escena)
        {
            this.lastKeyboardState = new KeyboardState();
            input = WaveServices.Input;
            this.currentState = AnimState.Idle;
            this.escena = escena;
            

        }

        protected override void Update(TimeSpan gameTime)
        {
            
            if (trans2D.X < -37.5f || trans2D.X > WaveServices.Platform.ScreenWidth + 37.5f)
            {
                escena.EndGame();
            }

            currentState = AnimState.Idle;

            touchpanel = WaveServices.Input.TouchPanelState;
            if (touchpanel.Count > 0)
            {
                TouchLocation firstTouch = touchpanel[0];

                if (firstTouch.Position.X > WaveServices.Platform.ScreenWidth / 2)
                {
                    currentState = AnimState.Right;
                }
                else
                {
                    currentState = AnimState.Left;
                }
            }

            /*if (input.KeyboardState.D == ButtonState.Pressed)
            {
                currentState = AnimState.Right;
            }
            else if (input.KeyboardState.A == ButtonState.Pressed)
            {
                currentState = AnimState.Left;
            }*/

            if (currentState != lastState)
            {
                switch (currentState)
                {
                    case AnimState.Idle:
                        anim2D.CurrentAnimation = "Idle";
                        anim2D.Play(true);
                        direction = NONE;
                        break;
                    case AnimState.Right:
                        anim2D.CurrentAnimation = "Running";
                        trans2D.Effect = SpriteEffects.FlipHorizontally;
                        anim2D.Play(true);
                        direction = RIGHT;
                        break;
                    case AnimState.Left:
                        anim2D.CurrentAnimation = "Running";
                        trans2D.Effect = SpriteEffects.None;
                        anim2D.Play(true);
                        direction = LEFT;
                        break;
                }
            }

            lastState = currentState;

            if (direction == RIGHT)
            {
                body.ApplyLinearImpulse(new Vector2(0.1f, 0));
            }
            else if (direction == LEFT)
            {
                body.ApplyLinearImpulse(new Vector2(-0.1f, 0));
            }

        }
    }
}
