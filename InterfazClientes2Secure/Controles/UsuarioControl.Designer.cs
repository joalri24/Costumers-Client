﻿namespace InterfazClientes2Secure.Controles
{
    partial class UsuarioControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUsuario = new System.Windows.Forms.Label();
            this.checkBoxAdmin = new System.Windows.Forms.CheckBox();
            this.checkBoxEmpleado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelUsuario
            // 
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.ForeColor = System.Drawing.Color.Brown;
            this.labelUsuario.Location = new System.Drawing.Point(-3, 0);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(194, 23);
            this.labelUsuario.TabIndex = 0;
            this.labelUsuario.Text = "Usuario@user.2secure.org";
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.AutoSize = true;
            this.checkBoxAdmin.Location = new System.Drawing.Point(257, 2);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAdmin.TabIndex = 1;
            this.checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmpleado
            // 
            this.checkBoxEmpleado.AutoSize = true;
            this.checkBoxEmpleado.Location = new System.Drawing.Point(330, 2);
            this.checkBoxEmpleado.Name = "checkBoxEmpleado";
            this.checkBoxEmpleado.Size = new System.Drawing.Size(15, 14);
            this.checkBoxEmpleado.TabIndex = 2;
            this.checkBoxEmpleado.UseVisualStyleBackColor = true;
            // 
            // UsuarioControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxEmpleado);
            this.Controls.Add(this.checkBoxAdmin);
            this.Controls.Add(this.labelUsuario);
            this.Name = "UsuarioControl";
            this.Size = new System.Drawing.Size(418, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.CheckBox checkBoxAdmin;
        private System.Windows.Forms.CheckBox checkBoxEmpleado;
    }
}