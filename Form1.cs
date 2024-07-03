using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;


namespace SurvMapViewer
{
    public partial class Form1 : Form
    {
        //runtime configurable
        public static int WorldSeed = -64;
        public static int imgsize = 500;
        public static int QualityLevel = 2;
        public static float scaledimgsize = imgsize / QualityLevel;
        public bool mousedown;
        //MapControl also runtime
        public float ZoomFactor = 1f;
        public float ViewX = 0;
        public float ViewY = 0;
        public float ViewSpd = 5;
        public float SeaLevel = 201.5f;

        //Game vars
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
            StartMouseTimer();
        }

        public Bitmap bmp = new Bitmap((int)scaledimgsize, (int)scaledimgsize);
        public bool graphicsLock = false;
        private void DrawMapAsync()
        {
            //im a fucking genius
            bgThread.RunWorkerAsync();
        }

        private void bgThread_DoWork(object sender, DoWorkEventArgs e)
        {
            float frozenViewX = ViewX;
            float frozenViewY = ViewY;
            for (int xit = 0; xit < scaledimgsize; xit++)
            {
                for (int yit = 0; yit < scaledimgsize; yit++)
                {
                    float valraw = GetNoise((xit * ZoomFactor) + frozenViewX, (yit * ZoomFactor) + frozenViewY);
                    float val = valraw / 5000000;
                    bmp.SetPixel(xit, yit, GetMapColor(val, (xit * ZoomFactor) + frozenViewX, (yit * ZoomFactor) + frozenViewY));
                }
            }
        }

        private void bgThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(pictureBox1_Paint);
            pictureBox1.Refresh();
            UpdateUIShit();
        }

        public static void StartMouseTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Start();
            timer.Elapsed += MouseTimerUpdate;
            
        }

        private static void MouseTimerUpdate(object sender, ElapsedEventArgs e)
        {
            var f = new Form1();
            f.MousePosLabel.Text = "X: " + Cursor.Position.X.ToString() + "\n" + "Y: " + Cursor.Position.Y.ToString();
        }

        private void UpdateUIShit()
        {
            xposLabel.Text = "X: " + ViewX.ToString();
            yposLabel.Text = "Y: " + ViewY.ToString();
            zoomLabel.Text = "Zoom: " + ZoomFactor.ToString();
            wseedbox.Text = WorldSeed.ToString();
        }

        private void ChangeSeed(int newseed)
        {
            WorldSeed = newseed;
            SetupNoise();
            DrawMapAsync();
        }

        private Color GetMapColor(float noiseValue, float x, float y)
        {
            //throw new Exception("NoiseValue is" + noiseValue.ToString());
            Color Grass = Color.FromArgb(255, 0, (int)noiseValue, 0);
            Color Water = Color.FromArgb(255, 0, 0, (int)noiseValue);

            if(x == 0 && y == 0)
            {
                return Color.Red;
            }

            if (noiseValue > SeaLevel)
            {
                return Grass;
            }
            else
            {
                return Water;
            }
        }

        private void MoveCam(float HorInput, float VerInput)
        {
            ViewX += HorInput;
            ViewY += VerInput;
        }

        //this is grabagwe
        public bool appliedTransform = false;
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            graphicsLock = true;
            Graphics g = e.Graphics;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            Bitmap scalebmp = new Bitmap(bmp, new Size(bmp.Width * QualityLevel, bmp.Height * QualityLevel));
            e.Graphics.DrawImage(scalebmp, 0, 0);
            graphicsLock = false;
        }

        //im a fucking genius

        //noise
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

        //button click shit
        private void ZoomUp_Click(object sender, EventArgs e)
        {
            if(!bgThread.IsBusy)
            {
                ZoomFactor = ZoomFactor - 1f * ZoomFactor / 2;
                DrawMapAsync();
            }
        }

        private void ZoomDown_Click(object sender, EventArgs e)
        {
            if (!bgThread.IsBusy)
            {
                ZoomFactor = ZoomFactor + 1f * ZoomFactor / 2;
                DrawMapAsync();
            }
        }

        private void camspdchangerthing_Scroll(object sender, EventArgs e)
        {
            ViewSpd = camspdchangerthing.Value;
            rndlabel1.Text = "Camera Speed: " + ViewSpd.ToString();
        }

        private void movup_Click(object sender, EventArgs e)
        {
            MoveCam(0, -ViewSpd);
            if (!bgThread.IsBusy)
            {
                DrawMapAsync();
            }
        }

        private void movdown_Click(object sender, EventArgs e)
        {
            MoveCam(0, ViewSpd);
            if (!bgThread.IsBusy)
            {
                DrawMapAsync();
            }
        }

        private void movL_Click(object sender, EventArgs e)
        {
            MoveCam(-ViewSpd, 0);
            if (!bgThread.IsBusy)
            {
                DrawMapAsync();
            }
           
        }

        private void movR_Click(object sender, EventArgs e)
        {
            MoveCam(ViewSpd, 0);
            if (!bgThread.IsBusy)
            {
                DrawMapAsync();
            }
        }

        private void applyseed_Click(object sender, EventArgs e)
        {
            ChangeSeed(Int32.Parse(wseedbox.Text));
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
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
