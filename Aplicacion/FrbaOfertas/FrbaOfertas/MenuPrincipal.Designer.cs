﻿namespace FrbaOfertas
{
    partial class MenuPrincipal
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
            this.listadoMenu = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.msg_sin_rol = new System.Windows.Forms.Label();
            this.msg_rol_malo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(663, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Mi perfil";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listadoMenu
            // 
            this.listadoMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listadoMenu.FormattingEnabled = true;
            this.listadoMenu.ItemHeight = 25;
            this.listadoMenu.Location = new System.Drawing.Point(193, 113);
            this.listadoMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listadoMenu.Name = "listadoMenu";
            this.listadoMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listadoMenu.Size = new System.Drawing.Size(409, 204);
            this.listadoMenu.Sorted = true;
            this.listadoMenu.TabIndex = 2;
            this.listadoMenu.SelectedIndexChanged += new System.EventHandler(this.listadoMenu_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccione acción";
            // 
            // msg_sin_rol
            // 
            this.msg_sin_rol.AutoSize = true;
            this.msg_sin_rol.BackColor = System.Drawing.Color.Transparent;
            this.msg_sin_rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msg_sin_rol.ForeColor = System.Drawing.Color.OrangeRed;
            this.msg_sin_rol.Location = new System.Drawing.Point(269, 341);
            this.msg_sin_rol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.msg_sin_rol.Name = "msg_sin_rol";
            this.msg_sin_rol.Size = new System.Drawing.Size(259, 40);
            this.msg_sin_rol.TabIndex = 4;
            this.msg_sin_rol.Text = "   Usted no tiene un rol asignado!\r\nNo tiene acceso a ninguna acción...";
            this.msg_sin_rol.Visible = false;
            // 
            // msg_rol_malo
            // 
            this.msg_rol_malo.AutoSize = true;
            this.msg_rol_malo.BackColor = System.Drawing.Color.Transparent;
            this.msg_rol_malo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msg_rol_malo.ForeColor = System.Drawing.Color.OrangeRed;
            this.msg_rol_malo.Location = new System.Drawing.Point(249, 350);
            this.msg_rol_malo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.msg_rol_malo.Name = "msg_rol_malo";
            this.msg_rol_malo.Size = new System.Drawing.Size(304, 20);
            this.msg_rol_malo.TabIndex = 5;
            this.msg_rol_malo.Text = "No tiene ninguna acción para su rol actual";
            this.msg_rol_malo.Visible = false;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 430);
            this.Controls.Add(this.msg_rol_malo);
            this.Controls.Add(this.msg_sin_rol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listadoMenu);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(805, 469);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(687, 469);
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listadoMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label msg_sin_rol;
        private System.Windows.Forms.Label msg_rol_malo;
    }
}