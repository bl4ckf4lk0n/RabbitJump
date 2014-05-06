#region Using Statements
using System;
using System.IO;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;
#endregion

namespace WaveEngineGame1Project
{
    public class Game : WaveEngine.Framework.Game
    {
        public static String best_score;
        public static float VMWidth = 800;
        public static float VMHeight = 480;

        public override void Initialize(IApplication application)
        {
            base.Initialize(application);

            ViewportManager vm = WaveServices.GetService<ViewportManager>();
            vm.Activate(VMWidth, VMHeight, ViewportManager.StretchMode.Fill);

            ObtenerMejorPuntuacion();

            ScreenContext screenContext = new ScreenContext(new Menu());
            WaveServices.ScreenContextManager.To(screenContext);
         
        }

        public static void ObtenerMejorPuntuacion()
        {
            Stream stream = WaveServices.Storage.OpenStorageFile("best_score", WaveEngine.Common.IO.FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(stream);

            best_score = sr.ReadLine();
            if (best_score == null)
            {
                best_score = "00:00";
            }
            sr.Dispose();
            stream.Dispose();
            /*sr.Close();
            stream.Close();*/
        }

        public static void EscribirMejorPuntuacion(string tiempo)
        {
            Stream stream = WaveServices.Storage.OpenStorageFile("best_score", WaveEngine.Common.IO.FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine(tiempo);

            sw.Dispose();
            stream.Dispose();
            //sw.Close();
            //stream.Close();
        }
    }
}
