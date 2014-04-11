#region Using Statements
using System;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Gestures;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;
#endregion

namespace WaveEngineGame1Project
{
    public class MyScene : Scene
    {
        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.CornflowerBlue;
            
            CrearEntidades();
            //Collider2D colliderpj = personaje.FindComponent<RectangleCollider>();
            //Collider2D colliderBola = bola.FindComponent<CircleCollider>();

            //colliderpj.Intersects(colliderBola);
        }

        private void CrearEntidades()
        {
            //Pintar Background
            Entity background = new Entity("background")
                .AddComponent(new Transform2D()
                {
                    DrawOrder = 1
                })
                .AddComponent(new Sprite("Content/fondo.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Opaque));
           

            Entity mountain = new Entity("mountain")
                .AddComponent(new Transform2D()
                {
                    DrawOrder = 1
                })
                .AddComponent(new Sprite("Content/mountain.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Opaque));



            //EntityManager.Add(mountain);
            EntityManager.Add(background);

            /*Entity barBot = new Entity("suelo")
                .AddComponent(new Transform2D()
                {
                    X = WaveServices.Platform.ScreenWidth/2,
                    Y = WaveServices.Platform.ScreenHeight
                })
                .AddComponent(new Sprite("Content/Texture/wall.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider())
                .AddComponent(new RigidBody2D() { IsKinematic = true });

            EntityManager.Add(barBot);

            Entity barTop = new Entity()
                .AddComponent(new Transform2D()
                {
                    XScale = 1.55f,
                    YScale = 2f,
                    X = WaveServices.Platform.ScreenWidth / 2,
                    Y = 0
                })
                .AddComponent(new Sprite("Content/Texture/wall.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider())
                .AddComponent(new RigidBody2D() { IsKinematic = true });

            EntityManager.Add(barTop);

            Entity rampa = new Entity()
                .AddComponent(new Transform2D()
                {
                    XScale = 1.6f,
                    YScale = 2f,
                    X = 700,
                    Y = 400,
                })
                .AddComponent(new Sprite("Content/Texture/wall.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Opaque))
                .AddComponent(new RectangleCollider())
                .AddComponent(new RigidBody2D() { IsKinematic = true });

            EntityManager.Add(rampa);

            rampa.FindComponent<RigidBody2D>().Rotation = MathHelper.ToRadians(-25);

            Entity baseEnemigo = new Entity()
                .AddComponent(new Transform2D()
                {
                    XScale = 1f,
                    YScale = 2f,
                    X = WaveServices.Platform.ScreenWidth + 125,
                    Y = 300,
                })
                .AddComponent(new Sprite("Content/Texture/wall.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Opaque))
                .AddComponent(new RectangleCollider())
                .AddComponent(new RigidBody2D() { IsKinematic = true });

            EntityManager.Add(baseEnemigo);



            Entity personaje = new Entity("personaje")
                .AddComponent(new Transform2D()
                {
                    X = 40,
                    Y = WaveServices.Platform.ScreenHeight - 70,

                })
                .AddComponent(new Sprite("Content/casillas.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Opaque))
                .AddComponent(new RectangleCollider())
                .AddComponent(new PersonajeBehavior())
                .AddComponent(new RigidBody2D());

            EntityManager.Add(personaje);

            Entity enemigo = new Entity()
                .AddComponent(new Transform2D()
                {
                    X = WaveServices.Platform.ScreenWidth - 40,
                    Y = 100,// WaveServices.Platform.ScreenHeight - 70,

                })
                .AddComponent(new Sprite("Content/Carlo.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Opaque))
                .AddComponent(new RectangleCollider())
                .AddComponent(new RigidBody2D());

            EntityManager.Add(enemigo);


            Entity bola = new Entity("bola")
                    .AddComponent(new Transform2D()
                    {
                        //XScale = 1.55f,
                        //YScale = 2f,
                        X = (WaveServices.Platform.ScreenWidth - 50) / 2,
                        Y = 300,// WaveServices.Platform.ScreenHeight - 70,

                    })

                    .AddComponent(new Sprite("Content/balon.wpk"))
                    .AddComponent(new SpriteRenderer(DefaultLayers.Opaque))
                    .AddComponent(new CircleCollider())
                    .AddComponent(new BolaBehavior())
                    .AddComponent(new RigidBody2D());

            EntityManager.Add(bola);*/

            for (int i = 0; i < 10; i++)
            {
                BallSpawn(i);
            }
        
        }


        
        

        private void BallSpawn(int it)
        {
            System.Random r = new System.Random(DateTime.Now.Millisecond);

            int xAleatoria = r.Next(3*WaveServices.Platform.ScreenWidth/4, WaveServices.Platform.ScreenWidth);
            int yAleatoria = r.Next(0, WaveServices.Platform.ScreenHeight/4);

            //Entity bolita = CreateBall(1f, 1f);
            //EntityManager.Add(bolita);
            Entity bolita = CreateBall((float)xAleatoria, (float)yAleatoria, it);
            EntityManager.Add(bolita);
        }

        private Entity CreateBall(float x,float y, int it)
        {
            //Coordenadas aleatorias dentro de un rango
            Entity bola = new Entity("bola"+it)
                                .AddComponent(new Transform2D()
                                {
                                    X = x,//(WaveServices.Platform.ScreenWidth - 50) / 2,
                                    Y = y//300
                                })
                                .AddComponent(new Sprite("Content/balon.wpk"))
                                .AddComponent(new SpriteRenderer(DefaultLayers.Opaque))
                                .AddComponent(new CircleCollider())
                                .AddComponent(new BolaBehavior())
                                .AddComponent(new RigidBody2D());
            return bola;
        }

    }
}
