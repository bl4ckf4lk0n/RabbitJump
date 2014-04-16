#region Using Statemets
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

        public enum AnimState { Idle, Right, Left, Dead };
        public AnimState currentState, lastState;

        private int direction;
        private TouchPanelState touchpanel;


        private Input input;
        private MyScene escena;

        private int lastMovement;


        public PersonajeBehavior(MyScene escena)
        {
            input = WaveServices.Input;
            this.currentState = AnimState.Idle;
            this.escena = escena;
            lastMovement = 0;
        }

        protected override void Update(TimeSpan gameTime)
        {
            if (lastState != AnimState.Dead)
            {
                if (trans2D.X < -37.5f || trans2D.X > WaveServices.Platform.ScreenWidth + 37.5f)
                {
                    escena.EndGame();
                }

                if (currentState != AnimState.Dead)
                {
                    currentState = AnimState.Idle;

                    if (!System.Diagnostics.Debugger.IsAttached)
                    {
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
                    }
                    else
                    {
                        if (input.KeyboardState.D == ButtonState.Pressed)
                        {
                            currentState = AnimState.Right;
                        }
                        else if (input.KeyboardState.A == ButtonState.Pressed)
                        {
                            currentState = AnimState.Left;
                        }
                    }
                }



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
                        case AnimState.Dead:
                            anim2D.CurrentAnimation = "Dead";
                            trans2D.Effect = SpriteEffects.None;
                            if(lastMovement == RIGHT)
                                trans2D.Effect = SpriteEffects.FlipHorizontally;
                            anim2D.Play(true);
                            direction = NONE;
                            WaveEngine.Framework.Services.Timer timer = WaveServices.TimerFactory.CreateTimer("Dead", TimeSpan.FromSeconds(1f),  () =>
                            {
                                escena.EndGame();
                            },false);
                            break;
                    }
                }

                lastState = currentState;

                if (direction == RIGHT)
                {
                    body.ApplyLinearImpulse(new Vector2(0.1f, 0));
                    lastMovement = RIGHT;
                }
                else if (direction == LEFT)
                {
                    body.ApplyLinearImpulse(new Vector2(-0.1f, 0));
                    lastMovement = LEFT;
                }
            }
        }
    }
}
