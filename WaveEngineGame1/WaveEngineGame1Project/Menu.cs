using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Common.Graphics;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.UI;

namespace WaveEngineGame1Project
{
    class Menu : Scene
    {
        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.CornflowerBlue;
            RenderManager.DebugLines = false;
            CrearEntidades();
        }

        private void CrearEntidades()
        {
            Button button = new Button()
            {
                HorizontalAlignment = WaveEngine.Framework.UI.HorizontalAlignment.Center,
                VerticalAlignment = WaveEngine.Framework.UI.VerticalAlignment.Center,
                Text = string.Empty,
                IsBorder = false,
                BackgroundImage = "Content/play.wpk",
                PressedBackgroundImage = "Content/playPuls.wpk",
                DrawOrder = 0.0f
            };

            button.Click += Play;

            TextBlock bestscore = new TextBlock()
            {
                Text = "Best time: " + Game.best_score,
                Foreground = Color.Yellow,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                FontPath = "Content/OCR A Std_14.wpk"
                //Margin = new Thickness(0, 100, 0, 0)
            };

            /*Image title = new Image("Titulo", "Content/LOGORABBITRUN.wpk")
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
            };*/

            Image background = new Image("Fondo", "Content/portada.wpk")
            {
                DrawOrder = 0.5f
            };

            /*Image floor = new Image("Suelo", "Content/suelo2.wpk")
            {
                VerticalAlignment = VerticalAlignment.Bottom,
            };*/

            /*TextBlock title = new TextBlock()
            {
                Text = "RabbitRun",
                Foreground = Color.Yellow,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontPath = "Content/OCR A Std_14.wpk",
                  
                //Margin = new Thickness(0, 100, 0, 0)
                
            };*/

            //EntityManager.Add(title);
            EntityManager.Add(bestscore);
            EntityManager.Add(button);
            //EntityManager.Add(floor);
            EntityManager.Add(background);
        }

        private void Play(object sender, EventArgs e)
        {
            ScreenContext screenContext = new ScreenContext(new MyScene());
            WaveServices.ScreenContextManager.To(screenContext);
        }

    }
}
