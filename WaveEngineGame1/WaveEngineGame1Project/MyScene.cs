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
            //RenderManager.DebugLines = true;
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
                .AddComponent(new Sprite("Content/mountain.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new Transform2D()
                {
                    DrawOrder = 0.7f,
                    //X = WaveServices.Platform.ScreenWidth/2,
                    //Y = WaveServices.Platform.ScreenHeight/2,
                });


            Entity personaje = new Entity("personaje")
                .AddComponent(new Transform2D()
                {
                    X = 100,
                    Y = 100

                })
                .AddComponent(new Sprite("Content/conejito.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new PerPixelCollider("Content/conejito.wpk", 0))
                .AddComponent(new PersonajeBehavior())
                .AddComponent(new RigidBody2D());

            Entity barra1 = new Entity()
               .AddComponent(new Transform2D()
               {
                   X = 259/2,
                   Y = WaveServices.Platform.ScreenHeight - 40
               })
               .AddComponent(new Sprite("Content/barra1.wpk"))
               .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
               .AddComponent(new PerPixelCollider("Content/barra1.wpk", 0))
               .AddComponent(new PersonajeBehavior())
               .AddComponent(new RigidBody2D() { IsKinematic = true });

            Entity barra2 = new Entity()
               .AddComponent(new Transform2D()
               {
                   X = 305,
                   Y = WaveServices.Platform.ScreenHeight - 100,
               })
               .AddComponent(new Sprite("Content/barra2.wpk"))
               .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
               .AddComponent(new PerPixelCollider("Content/barra2.wpk", 0))
               .AddComponent(new PersonajeBehavior())
               .AddComponent(new RigidBody2D() { IsKinematic = true,
                                                 Rotation = MathHelper.ToRadians(42)});

            Entity barra3 = new Entity()
               .AddComponent(new Transform2D()
               {
                   X = 435,
                   Y = WaveServices.Platform.ScreenHeight - 190,
               })
               .AddComponent(new Sprite("Content/barra2.wpk"))
               .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
               .AddComponent(new PerPixelCollider("Content/barra2.wpk", 0))
               .AddComponent(new PersonajeBehavior())
               .AddComponent(new RigidBody2D()
               {
                   IsKinematic = true,
                   Rotation = MathHelper.ToRadians(70)
               });

            Entity barra4 = new Entity()
               .AddComponent(new Transform2D()
               {
                   X = 550,
                   Y = WaveServices.Platform.ScreenHeight - 250,
               })
               .AddComponent(new Sprite("Content/barra2.wpk"))
               .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
               .AddComponent(new PerPixelCollider("Content/barra2.wpk", 0))
               .AddComponent(new PersonajeBehavior())
               .AddComponent(new RigidBody2D()
               {
                   IsKinematic = true,
                   Rotation = MathHelper.ToRadians(45)
               });

            Entity barra5 = new Entity()
               .AddComponent(new Transform2D()
               {
                   X = 650,
                   Y = WaveServices.Platform.ScreenHeight - 335,
               })
               .AddComponent(new Sprite("Content/barra2.wpk"))
               .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
               .AddComponent(new PerPixelCollider("Content/barra2.wpk", 0))
               .AddComponent(new PersonajeBehavior())
               .AddComponent(new RigidBody2D()
               {
                   IsKinematic = true,
                   Rotation = MathHelper.ToRadians(70)
               });

            EntityManager.Add(personaje);
            EntityManager.Add(barra1);
            EntityManager.Add(barra2);
            EntityManager.Add(barra3);
            EntityManager.Add(barra4);
            EntityManager.Add(barra5);
            EntityManager.Add(mountain);
            EntityManager.Add(background);
        }

        private void BallSpawn()
        {

        }

        private Entity CreateBall(float x,float y)
        {
            //Coordenadas aleatorias dentro de un rango
            Entity bola = new Entity("bola")
                                .AddComponent(new Transform2D()
                                {
                                    X = (WaveServices.Platform.ScreenWidth - 50) / 2,
                                    Y = 300
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
