using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnakeGraphics
{
	public partial class Form2 : Form
	{
		private Device device = null;
		private VertexBuffer vertexBuffer;

		public Form2()
		{
			InitializeComponent();
		}

		public bool initializeDirectX()
		{
			try
			{
				PresentParameters presPars = new PresentParameters();
				presPars.Windowed = true;
				presPars.SwapEffect = SwapEffect.Discard;
				device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presPars);
				OnCreateDevice(device, null);

				return true;
			}
			catch (DirectXException e)
			{
				MessageBox.Show("Ошибка инициализации DirectX " + e.ErrorString);
				return false;
			}
		}

		public void rendering()
		{
			if (device == null) return;
			//очищает и заливает белым цветом устройство (форму)
			device.Clear(ClearFlags.Target, Color.Aqua, 1.0f, 0);
			//начинаем и заканчиваем сцену
			device.BeginScene();
			device.SetStreamSource(0, vertexBuffer, 0);
			device.VertexFormat = CustomVertex.TransformedColored.Format;
			device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
			device.EndScene();
			device.Present();
		}

		public void OnCreateDevice(object sender, EventArgs e)
		{

			//создаем буфер для вершин треугольника
			vertexBuffer = new VertexBuffer(typeof(CustomVertex.TransformedColored), 4, device, 0, CustomVertex.TransformedColored.Format, Pool.Default);
			vertexBuffer.Created += new System.EventHandler(this.OnCreateVertexBuffer);
			OnCreateVertexBuffer(vertexBuffer, null);
		}

		public void OnCreateVertexBuffer(object sender, EventArgs e)

		{
			GraphicsStream graphicsStream = vertexBuffer.Lock(0, 0, 0);
			CustomVertex.TransformedColored[] vertex = new CustomVertex.TransformedColored[3];
			//вершина 0

			vertex[0].X = 150;
			vertex[0].Y = 50;
			vertex[0].Z = 0.1f;

			vertex[0].Rhw = 1;
			vertex[0].Color = Color.Black.ToArgb();
			
			//вершина 1
			vertex[1].X = 250;
			vertex[1].Y = 70;
			vertex[1].Z = 0.5f;

			vertex[1].Rhw = 1;
			vertex[1].Color = Color.Black.ToArgb();

			//вершина 2
			vertex[2].X = 50;
			vertex[2].Y = 250;
			vertex[2].Z = 0.5f;

			vertex[2].Rhw = 1;
			vertex[2].Color = System.Drawing.Color.Black.ToArgb();

			//вывод графической фигуры
			graphicsStream.Write(vertex);
			vertexBuffer.Unlock();
		}
		private void Form2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((int)(byte)e.KeyChar == (int)System.Windows.Forms.Keys.Escape) this.Close();
		}
	}
}