using FastNoise;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.IO;

namespace SurvMapViewer
{
    public partial class Form1 : Form
    {
        //configurable
        public static int WorldSeed = -617053759;
        
        public static int imgsize = 500;

        //MapControl
        public float ZoomFactor = 1f;
        public float ViewX = 0;
        public float ViewY = 0;
        //INGAME UNCHANGED VARS
        public float NoiseScale = 375f;
        public float ZMultiplier = 11500.0f;


        public Form1()
        {
            InitializeComponent();
        }

        //Noise Initialization
        FastNoise.FastNoise MainNoise = new FastNoise.FastNoise();
        FastNoise.FastNoise ErosionNoise = new FastNoise.FastNoise();
        FastNoise.FastNoise HillsNoise = new FastNoise.FastNoise();
        FastNoise.FastNoise PeaksNoise = new FastNoise.FastNoise();
        FastNoise.FastNoise OceanNoise = new FastNoise.FastNoise();

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupNoise();
            DrawMapAsync();
        }
        public Bitmap bmp = new Bitmap(imgsize, imgsize);
        public bool graphicsLock = false;
        private void DrawMapAsync()
        {
            /* Mult thread approach 1
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                for (int xit = 0; xit < imgsize; xit++)
                {
                    for (int yit = 0; yit < imgsize; yit++)
                    {
                        float nvalraw = GetNoise(xit * ZoomFactor, yit * ZoomFactor);
                        float nval = nvalraw / 5000000;
                        if (!graphicsLock)
                        {
                            bmp.SetPixel(xit, yit, GetMapColor(nval));
                        }
                    }
                }
                
            }).Start();
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(pictureBox1_Paint);
            */

            //Mult thread approach 2
            bgThread.RunWorkerAsync();
        }

        private void bgThread_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int xit = 0; xit < imgsize; xit++)
            {
                for (int yit = 0; yit < imgsize; yit++)
                {
                    float valraw = GetNoise(xit * ZoomFactor, yit * ZoomFactor);
                    float val = valraw / 5000000;
                    bmp.SetPixel(xit, yit, GetMapColor(val));
                }
            }
        }

        private void bgThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(pictureBox1_Paint);
            //so fresh and clean
            pictureBox1.Refresh();
        }

        /*
        private void DrawMap()
        {
            
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(pictureBox1_Paint);
            
            for (int xit = 0; xit < imgsize; xit++)
            {
                for (int yit = 0; yit < imgsize; yit++)
                {
                    float nvalraw = GetNoise(xit * ZoomFactor, yit * ZoomFactor);
                    float nval = nvalraw / 5000000;
                    bmp.SetPixel(xit, yit, GetMapColor(nval));
                }
            }
            pictureBox1.Refresh();
        }
        */

        private Color GetMapColor(float noiseValue)
        {
            //throw new Exception("NoiseValue is" + noiseValue.ToString());
            Color Sand = Color.Yellow;
            Color Grass = Color.FromArgb((int)noiseValue, 0, 255, 0);
            Color Water = Color.FromArgb((int)noiseValue, 0, 0, 255);

            if(noiseValue > 201)
            {
                return Grass;
            }
            else
            {
                return Water;
            }
        }
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            graphicsLock = true;
            Graphics g = e.Graphics;
            e.Graphics.DrawImage(bmp, 0, 0);
            graphicsLock = false;
        }

        private void SetupNoise()
        {
            //LAYER 1
            MainNoise.SetNoiseType(FastNoise.FastNoise.NoiseType.SimplexFractal);
            MainNoise.SetSeed(Util.TruncFloatToInt(WorldSeed - 23465 * 16.253735f));
            MainNoise.SetFrequency(0.0012f * (NoiseScale / 750));
            MainNoise.SetFractalOctaves(3);
            MainNoise.SetFractalLacunarity(1.85f);
            MainNoise.SetCellularJitter(0.35f);
            MainNoise.SetFractalGain(0.45f);
            MainNoise.SetInterp(FastNoise.FastNoise.Interp.Quintic);
            MainNoise.SetFractalType(FastNoise.FastNoise.FractalType.RigidMulti);
            MainNoise.SetCellularDistanceFunction(FastNoise.FastNoise.CellularDistanceFunction.Natural);

            //LAYER 2
            ErosionNoise.SetNoiseType(FastNoise.FastNoise.NoiseType.SimplexFractal);
            ErosionNoise.SetSeed(WorldSeed);
            ErosionNoise.SetFrequency(0.0012f * (NoiseScale / 750));
            ErosionNoise.SetFractalOctaves(9);
            ErosionNoise.SetFractalLacunarity(2f);
            ErosionNoise.SetCellularJitter(0.45f);
            ErosionNoise.SetFractalGain(0.65f);
            ErosionNoise.SetInterp(FastNoise.FastNoise.Interp.Quintic);
            ErosionNoise.SetFractalType(FastNoise.FastNoise.FractalType.FBM);
            ErosionNoise.SetCellularDistanceFunction(FastNoise.FastNoise.CellularDistanceFunction.Natural);

            //LAYER 3
            HillsNoise.SetNoiseType(FastNoise.FastNoise.NoiseType.ValueFractal);
            HillsNoise.SetSeed(Util.TruncFloatToInt(WorldSeed - 23465 * 16.253735f));
            HillsNoise.SetFrequency(0.01f * (NoiseScale / 750));
            HillsNoise.SetFractalOctaves(6);
            HillsNoise.SetFractalLacunarity(2f);
            HillsNoise.SetCellularJitter(0.45f);
            HillsNoise.SetFractalGain(0.5f);
            HillsNoise.SetInterp(FastNoise.FastNoise.Interp.Quintic);
            HillsNoise.SetFractalType(FastNoise.FastNoise.FractalType.FBM);
            HillsNoise.SetCellularDistanceFunction(FastNoise.FastNoise.CellularDistanceFunction.Natural);

            //LAYER 4
            PeaksNoise.SetNoiseType(FastNoise.FastNoise.NoiseType.Cubic);
            PeaksNoise.SetSeed(WorldSeed);
            PeaksNoise.SetFrequency(0.021f * (NoiseScale / 750));
            PeaksNoise.SetFractalOctaves(2);
            PeaksNoise.SetFractalLacunarity(2f);
            PeaksNoise.SetCellularJitter(1f);
            PeaksNoise.SetFractalGain(0.5f);
            PeaksNoise.SetInterp(FastNoise.FastNoise.Interp.Quintic);
            PeaksNoise.SetFractalType(FastNoise.FastNoise.FractalType.Billow);
            PeaksNoise.SetCellularDistanceFunction(FastNoise.FastNoise.CellularDistanceFunction.Natural);

            //LAYER 5
            OceanNoise.SetNoiseType(FastNoise.FastNoise.NoiseType.Perlin);
            OceanNoise.SetSeed(WorldSeed + 13214 / 4);
            OceanNoise.SetFrequency(0.0018f * (NoiseScale / 750));
            OceanNoise.SetFractalOctaves(2);
            OceanNoise.SetFractalLacunarity(2f);
            OceanNoise.SetCellularJitter(0.45f);
            OceanNoise.SetFractalGain(0.65f);
            OceanNoise.SetInterp(FastNoise.FastNoise.Interp.Quintic);
            OceanNoise.SetFractalType(FastNoise.FastNoise.FractalType.FBM);
            OceanNoise.SetCellularDistanceFunction(FastNoise.FastNoise.CellularDistanceFunction.Natural);
        }

        private float GetNoise(float x, float y)
        {
            float mn_height;
            float er_height;
            float hi_height;
            float pe_height;
            float oc_height;
            float finalheight;

            mn_height = MainNoise.GetNoise(x, y) * ZMultiplier;
            er_height = (ErosionNoise.GetNoise(x, y) * 1.5f) * 4000f;
            hi_height = Util.Clamp(HillsNoise.GetNoise(x, y) * ZMultiplier, 0, 999999999);
            pe_height = Util.Clamp(PeaksNoise.GetNoise(x, y), 0, 1) * Util.Clamp((11500 * 4 - (MainNoise.GetNoise(x, y) * 32)), 0, 99999999);
            oc_height = Util.Clamp(OceanNoise.GetNoise(x, y), 0, 0.5f);

            finalheight = ((er_height - mn_height) + hi_height + (pe_height * er_height / 1000) * oc_height);

            return finalheight;
        }

        private void ZoomUp_Click(object sender, EventArgs e)
        {
            ZoomFactor = ZoomFactor + 0.1f;
            DrawMapAsync();
        }

        private void ZoomDown_Click(object sender, EventArgs e)
        {
            ZoomFactor = ZoomFactor - 0.1f;
            DrawMapAsync();
        }


        //other shit classes for TYPE CONVERSION because fuck you
    }
    public class Util
    {
        public Util()
        {
            return;
        }

        public static int TruncFloatToInt(float f)
        {
            return (int)f;
        }

        public static int TruncDoubleToInt(double d)
        {
            return (int)d;
        }

        public static T Clamp<T>(T value, T max, T min)
        where T : System.IComparable<T>
        {
            T result = value;
            if (value.CompareTo(max) > 0)
                result = max;
            if (value.CompareTo(min) < 0)
                result = min;
            return result;
        }
    }

    public class baseConv
        {
            public static float baseIntFloat(int i)
             {
                return (float)i;
             }
         public static int baseFloatInt(int f)
            {
                return (int)f;
            }

        public static int baseDoubleInt(double d)
        {
            return (int)d;
        }
    }

    }
