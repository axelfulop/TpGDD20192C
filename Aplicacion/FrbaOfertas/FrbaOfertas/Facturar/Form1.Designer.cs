﻿namespace FrbaOfertas.Facturar
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.fechaInicio = new System.Windows.Forms.DateTimePicker();
            this.FechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cuit = new System.Windows.Forms.TextBox();
            this.razonSocial = new System.Windows.Forms.TextBox();
            this.facturarBtn = new System.Windows.Forms.Button();
            this.cantComprasMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(396, 585);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(496, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(189, 44);
            this.button2.TabIndex = 22;
            this.button2.Text = "Ver ofertas compradas\r\n";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(633, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 22);
            this.label3.TabIndex = 20;
            this.label3.Text = "Fecha fin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(633, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 22);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fecha inicio";
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(12, 233);
            this.grid.Name = "grid";
            this.grid.RowTemplate.Height = 28;
            this.grid.Size = new System.Drawing.Size(1154, 346);
            this.grid.TabIndex = 17;
            // 
            // fechaInicio
            // 
            this.fechaInicio.Location = new System.Drawing.Point(764, 90);
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.Size = new System.Drawing.Size(336, 26);
            this.fechaInicio.TabIndex = 24;
            // 
            // FechaFin
            // 
            this.FechaFin.Location = new System.Drawing.Point(764, 141);
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.Size = new System.Drawing.Size(336, 26);
            this.FechaFin.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(617, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Seleccione el intervalo de facturación";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Seleccione el proveedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(89, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 22);
            this.label5.TabIndex = 29;
            this.label5.Text = "Razón social";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(89, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 22);
            this.label6.TabIndex = 28;
            this.label6.Text = "CUIT";
            // 
            // cuit
            // 
            this.cuit.Location = new System.Drawing.Point(237, 91);
            this.cuit.Name = "cuit";
            this.cuit.Size = new System.Drawing.Size(299, 26);
            this.cuit.TabIndex = 30;
            // 
            // razonSocial
            // 
            this.razonSocial.Location = new System.Drawing.Point(237, 142);
            this.razonSocial.Name = "razonSocial";
            this.razonSocial.Size = new System.Drawing.Size(299, 26);
            this.razonSocial.TabIndex = 31;
            // 
            // facturarBtn
            // 
            this.facturarBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.facturarBtn.Enabled = false;
            this.facturarBtn.Location = new System.Drawing.Point(601, 585);
            this.facturarBtn.Name = "facturarBtn";
            this.facturarBtn.Size = new System.Drawing.Size(174, 47);
            this.facturarBtn.TabIndex = 41;
            this.facturarBtn.Text = "Facturar";
            this.facturarBtn.UseVisualStyleBackColor = false;
            this.facturarBtn.Click += new System.EventHandler(this.facturarBtn_Click);
            // 
            // cantComprasMsg
            // 
            this.cantComprasMsg.AutoSize = true;
            this.cantComprasMsg.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cantComprasMsg.Location = new System.Drawing.Point(13, 199);
            this.cantComprasMsg.Name = "cantComprasMsg";
            this.cantComprasMsg.Size = new System.Drawing.Size(0, 20);
            this.cantComprasMsg.TabIndex = 42;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 644);
            this.Controls.Add(this.cantComprasMsg);
            this.Controls.Add(this.facturarBtn);
            this.Controls.Add(this.razonSocial);
            this.Controls.Add(this.cuit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FechaFin);
            this.Controls.Add(this.fechaInicio);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación a proveedor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DateTimePicker fechaInicio;
        private System.Windows.Forms.DateTimePicker FechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cuit;
        private System.Windows.Forms.TextBox razonSocial;
        private System.Windows.Forms.Button facturarBtn;
        private System.Windows.Forms.Label cantComprasMsg;
    }
}