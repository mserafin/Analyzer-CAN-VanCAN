using Ets2SdkClient;
using System;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Symulator
{
    public enum MessageType
    {
        SPEED = 0x1F1,
        RPM = 0x316,
        GEARS = 0x18F
    }

    public partial class Form1 : Form
    {
        private readonly Ets2SdkTelemetry telemetry;
        private readonly FramesSenderService senderService;
        private readonly FramesSender sender;

        private SerialPort serialPort;
        private Timer timer;
        private bool isStartTimer;

        private ResponseSupport<byte> response;

        public Form1()
        {
            InitializeComponent();

            response = new ResponseSupport<byte>();

            telemetry = new Ets2SdkTelemetry();
            telemetry.Data += Telemetry_Data;
            telemetry.JobFinished += Telemetry_JobFinished; ;
            telemetry.JobStarted += Telemetry_JobStarted;

            sender = new FramesSender();
            sender.Append(MessageType.RPM);
            sender.Append(MessageType.SPEED);
            sender.Append(MessageType.GEARS, 1000);

            senderService = new FramesSenderService(sender.Iterator);
            senderService.SendData += (data) =>
            {
                Console.WriteLine("SendFrame: {0}", data.CanId);

                byte[] frame = Frame.Builder()
                .WithType(FrameType.FRAME_STANDARD)
                .WithCanId((int)data.CanId)
                .WithData(data.Data)
                .Build();

                sendByte(frame);
            };

            timer = new Timer();
            timer.Tick += Timer_Tick;
        }

        public const int REC_BUFFER_SIZE = 500;
        public const int READ_TIMEOUT = 500;
        public const int WRITE_TIMEOUT = 500;
        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort == null || !serialPort.IsOpen)
            {
                serialPort = new SerialPort(txtPortName.Text);
                serialPort.BaudRate = 115200;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                serialPort.DataBits = 8;
                serialPort.Handshake = Handshake.None;
                serialPort.RtsEnable = false;
                serialPort.DtrEnable = false;
                serialPort.ReadTimeout = READ_TIMEOUT;
                serialPort.WriteTimeout = WRITE_TIMEOUT;
                //serialPort.ReadBufferSize = REC_BUFFER_SIZE;
                serialPort.ReceivedBytesThreshold = 15;
                serialPort.DataReceived += SerialPort_DataReceived;

                serialPort.Open();

                serialPort.DiscardOutBuffer();
                serialPort.DiscardInBuffer();
            }
            else
            {
                serialPort.Close();
            }

             (sender as Button).Text = serialPort.IsOpen ? "Rozłącz" : "Połącz";
        }

        private void sendConfig()
        {
            int baudrate = 9600; //115200;

            byte[] configUart = Frame.Builder()
                .WithType(FrameType.CONFIG_UART)
                .WithData(baudrate)
                .Build();

            /// ----------------------------------------------

            byte mode = 0x03;
            byte protocol = 0x01;
            short speed = 0x10;

            byte[] configCan = Frame.Builder()
                .WithType(FrameType.CONFIG_CAN)
                .WithData(((mode & 0xF) << 28) | ((protocol & 0xF) << 24) | (speed & 0xFF))
                .Build();

            /// ----------------------------------------------

            int timestamp = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

            byte[] syncTime = Frame.Builder()
                .WithType(FrameType.SYNC_TIME)
                .WithData(timestamp)
                .Build();

            sendByte(configCan);
        }

        private void sendData()
        {
            var canId = Convert.ToInt32(txtCanId.Text.Trim(), 16); //0x7FF || 0x7FFF || 0x1FFFFFFF‬

            var canData = txtCanData.Text
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => Convert.ToByte(x))
                .ToArray<byte>();

            byte[] frame = Frame.Builder()
                .WithType(FrameType.FRAME_STANDARD)
                .WithCanId(canId)
                .WithData(canData)
                .Build();

            sendByte(frame);
        }

        private void sendByte(byte[] frame)
        {
            if (serialPort == null || !serialPort.IsOpen)
            {
                return;
            }

            serialPort.Write(frame, 0, frame.Length);
            serialPort.DiscardOutBuffer();

            this.Invoke(() => txtResData.AppendText($"-> {string.Join(", ", frame)}\n"));
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var sp = sender as SerialPort;
            if (!sp.IsOpen)
            {
                return;
            }

            System.Threading.Thread.Sleep(50);

            var bytes = sp.BytesToRead;
            var buffer = new byte[bytes];
            sp.Read(buffer, 0, bytes);

            //response.Append(buffer).SetTimeout((byte[] data) =>
            //{
            //    Console.WriteLine($"Index: {++index}, Ilość danych: {data.Length}");
            //}, 10);

            if (buffer.Length % 15 != 0)
            {
                Console.WriteLine("Ramka nie pełna");
            }

            txtResData.Invoke(() =>
            {
                for (int i = 0, l = buffer.Length; i < l; i += 15)
                {
                    var data = buffer.Skip(i).Take(15).ToArray();
                    var frame = Frame.Builder().With(data);

                    var a = frame.CanId;
                    var b = frame.Data;
                    var c = frame.Length;
                    var d = frame.Type;

                    txtResData.AppendText($"<- {string.Join(", ", data)}\n");
                    txtResData.AppendText($"<- {frame.Type}, {frame.CanId}, {frame.Length}, {string.Join(", ", frame.Data)}\n");

                    //txtResData.AppendText($"<- {Encoding.UTF8.GetString(frame, 0, frame.Length)}\n");
                }
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort != null && !serialPort.IsOpen)
            {
                return;
            }

            sendData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isStartTimer)
            {
                if (serialPort == null || !serialPort.IsOpen)
                {
                    return;
                }

                timer.Interval = Convert.ToInt32(txtInterval.Text);
                timer.Start();
            }
            else
            {
                timer.Stop();
            }

            isStartTimer = !isStartTimer;
            (sender as Button).Text = isStartTimer ? "Stop" : "Start";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var canId = Convert.ToInt32(txtCanId.Text, 16) + 1;
            if (canId > 0x7FFF)
            {
                canId = 0x00;
            }

            txtCanId.Text = $"0x{canId:X3}";
            sendData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtResData.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var canId = Convert.ToInt32(txtCanId.Text, 16) - 1;
            if (canId < 0x00)
            {
                canId = 0x7FF;
            }

            txtCanId.Text = $"0x{canId:X3}";
            sendData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var canId = Convert.ToInt32(txtCanId.Text, 16) + 1;
            if (canId > 0x7FF)
            {
                canId = 0x00;
            }

            txtCanId.Text = $"0x{canId:X3}";
            sendData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sendConfig();
        }


        private void Telemetry_Data(Ets2Telemetry data, bool newTimestamp)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new TelemetryData(Telemetry_Data), new object[2] { data, newTimestamp });
                    return;
                }

                sender.Update(MessageType.SPEED, data.Physics.SpeedKmh);
                sender.Update(MessageType.RPM, data.Drivetrain.EngineRpm);

                labTelemetry.Clear();
                labTelemetry.AppendText($"Speed: {data.Physics.SpeedKmh}\n");
                labTelemetry.AppendText($"RPM: {data.Drivetrain.EngineRpm}\n");
                labTelemetry.AppendText($"MotorBrake: {data.Drivetrain.MotorBrake}\n");
                labTelemetry.AppendText($"City: {data.Job.CityDestination}\n");
                labTelemetry.AppendText($"Company: {data.Job.CompanyDestination}\n");
                labTelemetry.AppendText($"CoordinateX: {data.Physics.CoordinateX}\n");
                labTelemetry.AppendText($"CoordinateY: {data.Physics.CoordinateY}\n");
                labTelemetry.AppendText($"CoordinateZ: {data.Physics.CoordinateZ}\n");
            }
            catch { }
        }

        private void Telemetry_JobStarted(object sender, EventArgs e)
        {

        }

        private void Telemetry_JobFinished(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (senderService.IsEnabled) senderService.Disabled(); else senderService.Enabled();
            (sender as Button).Text = senderService.IsEnabled ? "Wyłącz symulator" : "Włącz symulator";
        }
    }
}
