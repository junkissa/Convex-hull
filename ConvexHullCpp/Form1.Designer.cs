namespace Geometry
{
	partial class Form1
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.button1 = new System.Windows.Forms.Button();
			this.Ендрю_Джавірса = new System.Windows.Forms.Button();
			this.button_delete = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// AnT
			// 
			this.AnT.AccumBits = ((byte)(0));
			this.AnT.AutoCheckErrors = false;
			this.AnT.AutoFinish = false;
			this.AnT.AutoMakeCurrent = true;
			this.AnT.AutoSwapBuffers = true;
			this.AnT.BackColor = System.Drawing.Color.WhiteSmoke;
			this.AnT.ColorBits = ((byte)(32));
			this.AnT.DepthBits = ((byte)(16));
			this.AnT.Location = new System.Drawing.Point(-5, 1);
			this.AnT.Name = "AnT";
			this.AnT.Size = new System.Drawing.Size(493, 350);
			this.AnT.StencilBits = ((byte)(0));
			this.AnT.TabIndex = 0;
			this.AnT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AnT_MouseClick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(494, 34);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(124, 31);
			this.button1.TabIndex = 1;
			this.button1.Text = "Кейла-Кірпатрика";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Ендрю_Джавірса
			// 
			this.Ендрю_Джавірса.Location = new System.Drawing.Point(494, 71);
			this.Ендрю_Джавірса.Name = "Ендрю_Джавірса";
			this.Ендрю_Джавірса.Size = new System.Drawing.Size(124, 28);
			this.Ендрю_Джавірса.TabIndex = 2;
			this.Ендрю_Джавірса.Text = "Ендрю-Джавірса";
			this.Ендрю_Джавірса.UseVisualStyleBackColor = true;
			this.Ендрю_Джавірса.Click += new System.EventHandler(this.Ендрю_Джавірса_Click);
			// 
			// button_delete
			// 
			this.button_delete.Location = new System.Drawing.Point(494, 1);
			this.button_delete.Name = "button_delete";
			this.button_delete.Size = new System.Drawing.Size(119, 21);
			this.button_delete.TabIndex = 3;
			this.button_delete.Text = "Delete";
			this.button_delete.UseVisualStyleBackColor = true;
			this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(509, 300);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 41);
			this.label1.TabIndex = 4;
			this.label1.Text = " ";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(494, 105);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(124, 27);
			this.button2.TabIndex = 5;
			this.button2.Text = "Грехема";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(494, 138);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(124, 29);
			this.button3.TabIndex = 6;
			this.button3.Text = "Рекурсивний";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(495, 187);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(123, 31);
			this.button4.TabIndex = 7;
			this.button4.Text = "Вороного";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(625, 353);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button_delete);
			this.Controls.Add(this.Ендрю_Джавірса);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.AnT);
			this.Name = "Form1";
			this.Text = "Geometry";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private Tao.Platform.Windows.SimpleOpenGlControl AnT;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button Ендрю_Джавірса;
		private System.Windows.Forms.Button button_delete;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}

