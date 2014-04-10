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
            

            var background = new Entity()
                .AddComponent(new Transform2D(){
                    DrawOrder = 1
                })                
                .AddComponent(new Sprite("Content/cavernaperdida.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Opaque));
            EntityManager.Add(background);

            var barBot = new Entity("suelo")
                .AddComponent(new Transform2D()
                {
                    XScale = 1.55f,
                    YScale = 2f,
                    X = WaveServices.Platform.ScreenWidth / 2,
                    Y = WaveServices.Platform.ScreenHeight - 25
                })
                .AddComponent(new Sprite("Content/Texture/wall.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider())
                .AddComponent(new RigidBody2D() { IsKinematic = true });

            EntityManager.Add(barBot);

            var barTop = new Entity()
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

            var rampa = new Entity()
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

            rampa.FindComponent<RigidBody2D>().Rotation =  MathHelper.ToRadians(-25);

            var baseEnemigo = new Entity()
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

            
            
            var personaje = new Entity("personaje")
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

            var enemigo = new Entity()
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


            var bola = new Entity("bola")
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

            EntityManager.Add(bola);
                    
                
            


            //Collider2D colliderpj = personaje.FindComponent<RectangleCollider>();
            //Collider2D colliderBola = bola.FindComponent<CircleCollider>();

            //colliderpj.Intersects(colliderBola);
        }
    }
}
