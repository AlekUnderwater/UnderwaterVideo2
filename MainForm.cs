using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCNLUI.Dialogs;

namespace UnderwaterVideo2
{    
    public partial class MainForm : Form
    {
        #region Invokers

        private void InvokeSetImage(PictureBox pBox, Bitmap image)
        {
            if (pBox.InvokeRequired)
                pBox.Invoke((MethodInvoker)delegate { pBox.Image = image; });
            else
                pBox.Image = image;
        }

        private void InvokeSetChecked(ToolStrip strip, ToolStripButton btn, bool isChecked)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate { btn.Checked = isChecked; });
            else
                btn.Checked = isChecked;

        }

        private void InvokeSetEnable(ToolStrip strip, ToolStripItem btn, bool isEnabled)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate { btn.Enabled = isEnabled; });
            else
                btn.Enabled = isEnabled;

        }
        
        #endregion


        #region Properties

        bool isRestart = false;

        Size outFrameSize = new Size(240, 240);

        volatile VideoCaptureDevice vDevice;
        FilterInfoCollection videoDevices;
        FiltersSequence framePostFilter;
        GammaCorrection gammaCorrector;
        ResizeBicubic resizer;

        bool receiverExists = false;        

        Size webCamDesiredFrameSize = new Size(160, 120);
        Size frameSize = new Size(120, 120);

        Transmitter transmitter;
        Encoder encoder;
        Receiver receiver;

        int receiverBufferMultiplier = 5;

        int sampleRate = 96000;

        double carrier = 24000;
        int chipSize = 1;

        int pSize = 960;

        int frameCnt = 0;
        string framesPath;
        bool isSaveFrames = false;


        #endregion


        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            framesPath = StrUtils.GetTimeDirTree(DateTime.Now, Application.ExecutablePath, "FRAMES", true);


            #region framePostFilter

            gammaCorrector = new GammaCorrection(1.5);
            resizer = new ResizeBicubic(outFrameSize.Width, outFrameSize.Height);

            framePostFilter = new FiltersSequence(new IFilter[]
            {
                Grayscale.CommonAlgorithms.RMY,
                gammaCorrector,
                resizer
            });           

            #endregion        

            #region encoder

            encoder = new Encoder(sampleRate, frameSize, chipSize);

            #endregion

            #region transmitter

            transmitter = new Transmitter(encoder, 2, 2, pSize);
            transmitter.CarrierHz = carrier;
            transmitter.FrameTransmitted += new EventHandler<NextFrameEventArgs>(transmitter_FrameTransmitted);
            transmitter.TransmissionStarted += new EventHandler(transmitter_TransmissionStarted);
            transmitter.TransmissionStopped += new EventHandler(transmitter_TransmissionStopped);

            #endregion

            #region receiver

            for (int n = 0; n < WaveIn.DeviceCount; n++)
            {
                audioInputDeviceCbx.Items.Add(WaveIn.GetCapabilities(n).ProductName);
            }

            if (audioInputDeviceCbx.Items.Count > 0)
            {
                receiverExists = true;
                audioInputDeviceCbx.SelectedIndex = 0;
                audioInputDeviceCbx_SelectedIndexChanged(audioInputDeviceCbx, new EventArgs());
            }

            //receiver.EmulInit();

            #endregion


            #region vDevice

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            for (int i = 0; i < videoDevices.Count; i++)
                videoCaptureDeviceCbx.Items.Add(videoDevices[i].Name);

            if (videoCaptureDeviceCbx.Items.Count > 0)
            {
                videoCaptureDeviceCbx.SelectedIndex = 0;
                videoCaptureDeviceCbx_SelectedIndexChanged(new object(), new EventArgs());
                videoCaptureBtn.Enabled = true;
            }

            #endregion

                
        }

        #endregion

        #region Handlers

        #region mainToolstrip

        private void videoCaptureBtn_Click(object sender, EventArgs e)
        {
            if (videoCaptureBtn.Checked)
            {
                if ((!transmitter.IsRunning) && (!receiver.IsRunning))
                {
                    vDevice.SignalToStop();
                    videoCaptureBtn.Checked = false;
                    txBtn.Enabled = false;
                    rxBtn.Enabled = receiverExists;
                    settingsBtn.Enabled = false;
                    settingsBtn.Enabled = !transmitter.IsRunning && ((receiver == null) || (!receiver.IsRunning));
                }
                else
                {
                    MessageBox.Show("Stop transmitter or/and receiver first", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                vDevice.Start();
                videoCaptureBtn.Checked = true;
                txBtn.Enabled = true;
                rxBtn.Enabled = receiverExists;
                settingsBtn.Enabled = false;
            }
        }

        private void txBtn_Click(object sender, EventArgs e)
        {
            if (!transmitter.IsRunning)
                transmitter.Start();
            else
                transmitter.Stop();
        }

        private void rxBtn_Click(object sender, EventArgs e)
        {
            if (!receiver.IsRunning)
                receiver.Start();
            else
                receiver.Stop();
        }

        private void videoCaptureDeviceCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool found = false;
            string vDeviceMoniker = "";

            for (int i = 0; (i < videoDevices.Count) && (!found); i++)
            {
                if (string.Compare(videoCaptureDeviceCbx.SelectedItem.ToString(), videoDevices[i].Name) == 0)
                {
                    found = true;
                    vDeviceMoniker = videoDevices[i].MonikerString;
                }
            }

            if (found)
            {
                vDevice = new VideoCaptureDevice(vDeviceMoniker);
                vDevice.DesiredFrameRate = 15;
                vDevice.DesiredFrameSize = new System.Drawing.Size(160, 120);
                vDevice.NewFrame += new NewFrameEventHandler(vDevice_NewFrame);
            }
        }

        private void audioInputDeviceCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (receiver != null)
            {
                receiver.FrameReceived = null;
                receiver.ReceivingStarted = null;
                receiver.ReceivingStopped = null;
                receiver = null;
            }

            receiver = new Receiver(encoder, audioInputDeviceCbx.SelectedIndex, receiverBufferMultiplier, carrier, chipSize);
            receiver.FrameReceived += new EventHandler<FrameReceivedEventArgs>(receiver_FrameReceived);
            receiver.ReceivingStarted += new EventHandler(receiver_ReceivingStarted);
            receiver.ReceivingStopped += new EventHandler(receiver_ReceivingStopped);

        }

        private void sampleRateCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            sampleRate = Convert.ToInt32(sampleRateCbx.SelectedItem.ToString());
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            using (AboutBox aBox = new AboutBox())
            {
                aBox.ApplyAssembly(Assembly.GetExecutingAssembly());
                aBox.Weblink = "www.unavlab.com";
                aBox.ShowDialog();
            }
        }

        #endregion

        #region vDevice

        private void vDevice_NewFrame(object sender, NewFrameEventArgs e)
        {
            if (transmitter.IsRunning)
                transmitter.ProcessNextFrame((Bitmap)e.Frame.Clone());

            InvokeSetImage(srcPbx, (Bitmap)e.Frame.Clone());
            e.Frame.Dispose();
            GC.SuppressFinalize(e.Frame);
        }

        #endregion

        #region receiver

        private void receiver_FrameReceived(object sender, FrameReceivedEventArgs e)
        {
            InvokeSetImage(rxPbx, framePostFilter.Apply(e.receivedFrame));

            if (isSaveFrames)
            {
                try
                {
                    e.receivedFrame.Save(Path.Combine(framesPath, string.Format("{0:0000}.png", frameCnt)));
                    frameCnt++;
                }
                catch (Exception ex)
                {
                    // 
                }
            }
        }

        private void receiver_ReceivingStarted(object sender, EventArgs e)
        {
            InvokeSetChecked(toolStrip, rxBtn, true);
            InvokeSetEnable(toolStrip, settingsBtn, false);
        }

        private void receiver_ReceivingStopped(object sender, EventArgs e)
        {
            InvokeSetChecked(toolStrip, rxBtn, false);
            bool settingsEnabled = !vDevice.IsRunning && !transmitter.IsRunning;
            InvokeSetEnable(toolStrip, settingsBtn, settingsEnabled);
        }

        #endregion


        #region transmitter

        private void transmitter_FrameTransmitted(object sender, NextFrameEventArgs e)
        {
            InvokeSetImage(txPbx, encoder.Decode(e.FrameSamples, transmitter.CarrierHz, pSize));
            //receiver.AddSamplesEmul(e.FrameSamples);          
        }

        private void transmitter_TransmissionStarted(object sender, EventArgs e)
        {
            InvokeSetChecked(toolStrip, txBtn, true);
            InvokeSetEnable(toolStrip, settingsBtn, false);
        }

        private void transmitter_TransmissionStopped(object sender, EventArgs e)
        {
            InvokeSetChecked(toolStrip, txBtn, false);

            bool settingsEnabled = !vDevice.IsRunning && ((receiver == null) || (!receiver.IsRunning));
            InvokeSetEnable(toolStrip, settingsBtn, settingsEnabled);
        }

        #endregion
        
        #region mainForm

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (!isRestart) && (MessageBox.Show("Close application?", "Question", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((vDevice != null) && (vDevice.IsRunning)) vDevice.SignalToStop();
        }

        #endregion

        private void syncTkb_Scroll(object sender, EventArgs e)
        {
            if (receiver != null)
                receiver.PSync = syncTkb.Value;
        }

        private void sensTkb_Scroll(object sender, EventArgs e)
        {
            if (receiver != null)
                receiver.Threshold = sensTkb.Value;
        }

        private void interframePauseTkb_Scroll(object sender, EventArgs e)
        {
            transmitter.InterframePauseMs = interframePauseTkb.Value;
        }

        private void isSaveSnapShotsBtn_Click(object sender, EventArgs e)
        {
            isSaveFrames = !isSaveFrames;
            isSaveFramesBtn.Checked = isSaveFrames;
        }

        #endregion               
    }
}
