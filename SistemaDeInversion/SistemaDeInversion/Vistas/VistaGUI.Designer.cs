namespace SistemaDeInversion.Vistas
{
    partial class VistaGUI
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
            this.buttonInversion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxMonto = new System.Windows.Forms.TextBox();
            this.comboBoxInversion = new System.Windows.Forms.ComboBox();
            this.numericUpDownPlazo = new System.Windows.Forms.NumericUpDown();
            this.comboBoxMoneda = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxApellido1 = new System.Windows.Forms.TextBox();
            this.textBoxApellido2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlazo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonInversion
            // 
            this.buttonInversion.Location = new System.Drawing.Point(435, 365);
            this.buttonInversion.Name = "buttonInversion";
            this.buttonInversion.Size = new System.Drawing.Size(121, 23);
            this.buttonInversion.TabIndex = 0;
            this.buttonInversion.Text = "Realizar Inversión";
            this.buttonInversion.UseVisualStyleBackColor = true;
            this.buttonInversion.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese su nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione el tipo de ahorro e inversión:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ingrese el monto de inversión:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Seleccione el plazo en días:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Seleccione el tipo de moneda:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(403, 62);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(153, 20);
            this.textBoxNombre.TabIndex = 6;
            // 
            // textBoxMonto
            // 
            this.textBoxMonto.Location = new System.Drawing.Point(403, 206);
            this.textBoxMonto.Name = "textBoxMonto";
            this.textBoxMonto.Size = new System.Drawing.Size(153, 20);
            this.textBoxMonto.TabIndex = 8;
            // 
            // comboBoxInversion
            // 
            this.comboBoxInversion.FormattingEnabled = true;
            this.comboBoxInversion.Location = new System.Drawing.Point(403, 167);
            this.comboBoxInversion.Name = "comboBoxInversion";
            this.comboBoxInversion.Size = new System.Drawing.Size(153, 21);
            this.comboBoxInversion.TabIndex = 9;
            // 
            // numericUpDownPlazo
            // 
            this.numericUpDownPlazo.Location = new System.Drawing.Point(404, 248);
            this.numericUpDownPlazo.Name = "numericUpDownPlazo";
            this.numericUpDownPlazo.Size = new System.Drawing.Size(152, 20);
            this.numericUpDownPlazo.TabIndex = 10;
            // 
            // comboBoxMoneda
            // 
            this.comboBoxMoneda.FormattingEnabled = true;
            this.comboBoxMoneda.Location = new System.Drawing.Point(404, 288);
            this.comboBoxMoneda.Name = "comboBoxMoneda";
            this.comboBoxMoneda.Size = new System.Drawing.Size(153, 21);
            this.comboBoxMoneda.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ingrese su primer apellido:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(48, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ingrese su segundo apellido:";
            // 
            // textBoxApellido1
            // 
            this.textBoxApellido1.Location = new System.Drawing.Point(404, 96);
            this.textBoxApellido1.Name = "textBoxApellido1";
            this.textBoxApellido1.Size = new System.Drawing.Size(153, 20);
            this.textBoxApellido1.TabIndex = 14;
            // 
            // textBoxApellido2
            // 
            this.textBoxApellido2.Location = new System.Drawing.Point(403, 128);
            this.textBoxApellido2.Name = "textBoxApellido2";
            this.textBoxApellido2.Size = new System.Drawing.Size(153, 20);
            this.textBoxApellido2.TabIndex = 15;
            // 
            // VistaGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 423);
            this.Controls.Add(this.textBoxApellido2);
            this.Controls.Add(this.textBoxApellido1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxMoneda);
            this.Controls.Add(this.numericUpDownPlazo);
            this.Controls.Add(this.comboBoxInversion);
            this.Controls.Add(this.textBoxMonto);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonInversion);
            this.Name = "VistaGUI";
            this.Text = "Realizar inversión";
            this.Load += new System.EventHandler(this.VistaGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlazo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInversion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxMonto;
        private System.Windows.Forms.ComboBox comboBoxInversion;
        private System.Windows.Forms.NumericUpDown numericUpDownPlazo;
        private System.Windows.Forms.ComboBox comboBoxMoneda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxApellido1;
        private System.Windows.Forms.TextBox textBoxApellido2;
    }
}