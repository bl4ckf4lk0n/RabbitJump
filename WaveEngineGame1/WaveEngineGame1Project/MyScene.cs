#region Using Statements
using System;
using System.IO;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Animation;
using WaveEngine.Components.Gestures;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.UI;
#endregion

namespace WaveEngineGame1Project
{
    public class MyScene : Scene
    {

        private int cont = 0;
        private float altura = 50f;
        private DateTime startTime;
        private TextBlock score;
        private TextBlock bestscore;

        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.CornflowerBlue;
            RenderManager.DebugLines = false;
            startTime = DateTime.Now;
            CrearEntidades();
        }

        private void CrearEntidades()
        {
            //Pintar Background
            Entity background = new Entity("background")
                .AddComponent(new Transform2D()
                {
                    DrawOrder = 1
                })
                .AddComponent(new Sprite("Content/fondo1.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Opaque));



            Entity floor = new Entity("floor")
                .AddComponent(new Transform2D()
                {
                    X = WaveServices.Platform.ScreenWidth/2,
                    Y = WaveServices.Platform.ScreenHeight - 17.5f
                })
                .AddComponent(new Sprite("Content/suelo2.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider())
                .AddComponent(new RigidBody2D() { IsKinematic = true, Restitution = 0, CollisionCategories = Physic2DCategory.Cat1});


            Entity personaje = new Entity("personaje")
                .AddComponent(new Transform2D()
                {
                    X = 100,
                    Y = 100

                })
                .AddComponent(new Sprite("Content/conejo_spritesheet.wpk"))
                .AddComponent(Animation2D.Create<TexturePackerGenericXml>("Content/conejo_spritesheet.xml")
                    .Add("Idle", new SpriteSheetAnimationSequence() { First = 1, Length = 1 })
                    .Add("Running", new SpriteSheetAnimationSequence() { First = 1, Length = 5 }))
                .AddComponent(new AnimatedSpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider())
                .AddComponent(new PersonajeBehavior(this))
                .AddComponent(new RigidBody2D() { Restitution = 0, CollisionCategories = Physic2DCategory.Cat2 });

            score = new TextBlock()
            {
                Text = "00:00",
                Foreground = Color.Yellow,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right,
                FontPath = "Content/OCR A Std_14.wpk"
                //Margin = new Thickness(0, 100, 0, 0)
            };

            bestscore = new TextBlock()
            {
                Text = "Best time: " + Game.best_score,
                Foreground = Color.Yellow,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontPath = "Content/OCR A Std_14.wpk"
                //Margin = new Thickness(0, 100, 0, 0)
            };

            EntityManager.Add(bestscore);
            EntityManager.Add(score);
            EntityManager.Add(personaje);
            EntityManager.Add(floor);
            EntityManager.Add(background);

 
            Timer timer = WaveServices.TimerFactory.CreateTimer("Init", TimeSpan.FromSeconds(1f), () =>
            {
                    BallSpawn();
                    DateTime currentTime = DateTime.Now;
                    TimeSpan timespan = currentTime - startTime;
                    score.Text = timespan.ToString(@"mm\:ss");
            });



        }

        private void BoxRigidBody_OnPhysic2DCollision(object sender, Physic2DCollisionEventArgs args)
        {
            EndGame();
        }

        public void EndGame()
        {
            if (isBestScore())
            {
                Game.best_score = score.Text;
                Game.EscribirMejorPuntuacion(score.Text);
            }

            ScreenContext screenContext = new ScreenContext(new Menu());
            WaveServices.ScreenContextManager.To(screenContext);
        }

        private bool isBestScore()
        {
            String[] split1 = score.Text.Split(':');
            String[] split2 = Game.best_score.Split(':');

            if (Convert.ToInt32(split1[0]) > Convert.ToInt32(split2[0]))
            {
                return true;
            }
            else if (Convert.ToInt32(split1[0]) == Convert.ToInt32(split2[0]))
            {
                if (Convert.ToInt32(split1[1]) > Convert.ToInt32(split2[1]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void BallSpawn()
        {
            System.Threading.Thread.Sleep(10);
            //Rango1 = 0 - 260
            //Rango2 = 261 - 525
            //Rango3 = 526 - 775
            System.Random r = new System.Random(DateTime.Now.Millisecond);

            int xAleatoria1 = r.Next(0, 260);
            int xAleatoria2 = r.Next(261, 525);
            int xAleatoria3 = r.Next(526, 775);
            //int yAleatoria = r.Next(0, WaveServices.Platform.ScreenHeight/4);

            //Entity bolita = CreateBall(1f, 1f);
            //EntityManager.Add(bolita);
            Entity bolita1 = CreateBall((float)xAleatoria1, altura, cont);
            EntityManager.Add(bolita1);
            cont++;

            Entity bolita2 = CreateBall((float)xAleatoria2, altura, cont);
            EntityManager.Add(bolita2);
            cont++;

            Entity bolita3 = CreateBall((float)xAleatoria3, altura, cont);
            EntityManager.Add(bolita3);
            cont++;

        }

        private Entity CreateBall(float x,float y, int it)
        {
            //Coordenadas aleatorias dentro de un rango
            Entity bola = new Entity("bola" +it)
                .AddComponent(new Transform2D()
                {
                    X = x,
                    Y = y

                })
                .AddComponent(new Sprite("Content/roca75.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new CircleCollider())
                .AddComponent(new BolaBehavior(it))
                .AddComponent(new RigidBody2D() { CollidesWith = Physic2DCategory.Cat2 });

            RigidBody2D boxRigidBody = bola.FindComponentOfType<RigidBody2D>();
            if (boxRigidBody != null)
            {
                boxRigidBody.OnPhysic2DCollision += BoxRigidBody_OnPhysic2DCollision;
            }

            return bola;
        }

    }
}
