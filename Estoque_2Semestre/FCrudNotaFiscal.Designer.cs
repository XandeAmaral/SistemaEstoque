namespace Estoque_2Semestre
{
    partial class FCrudNotaFiscal
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOperacao = new System.Windows.Forms.TextBox();
            this.txtNumNF = new System.Windows.Forms.TextBox();
            this.dtpNF = new System.Windows.Forms.DateTimePicker();
            this.lstNF = new System.Windows.Forms.ListView();
            this.btnImportarXML = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastrar Nota Fiscal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "N Nfe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Natureza da operacao";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data da emissao";
            // 
            // txtOperacao
            // 
            this.txtOperacao.Location = new System.Drawing.Point(151, 154);
            this.txtOperacao.Name = "txtOperacao";
            this.txtOperacao.ReadOnly = true;
            this.txtOperacao.Size = new System.Drawing.Size(208, 20);
            this.txtOperacao.TabIndex = 4;
            // 
            // txtNumNF
            // 
            this.txtNumNF.Location = new System.Drawing.Point(73, 105);
            this.txtNumNF.Name = "txtNumNF";
            this.txtNumNF.ReadOnly = true;
            this.txtNumNF.Size = new System.Drawing.Size(156, 20);
            this.txtNumNF.TabIndex = 5;
            // 
            // dtpNF
            // 
            this.dtpNF.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNF.Location = new System.Drawing.Point(365, 106);
            this.dtpNF.Name = "dtpNF";
            this.dtpNF.Size = new System.Drawing.Size(111, 20);
            this.dtpNF.TabIndex = 6;
            // 
            // lstNF
            // 
            this.lstNF.HideSelection = false;
            this.lstNF.Location = new System.Drawing.Point(35, 209);
            this.lstNF.Name = "lstNF";
            this.lstNF.Size = new System.Drawing.Size(530, 177);
            this.lstNF.TabIndex = 7;
            this.lstNF.UseCompatibleStateImageBehavior = false;
            // 
            // btnImportarXML
            // 
            this.btnImportarXML.Location = new System.Drawing.Point(410, 146);
            this.btnImportarXML.Name = "btnImportarXML";
            this.btnImportarXML.Size = new System.Drawing.Size(105, 35);
            this.btnImportarXML.TabIndex = 8;
            this.btnImportarXML.Text = "Importar XML NFe";
            this.btnImportarXML.UseVisualStyleBackColor = true;
            this.btnImportarXML.Click += new System.EventHandler(this.btnImportarXML_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(61, 468);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(10, 13);
            this.lblUsuario.TabIndex = 10;
            this.lblUsuario.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 468);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Usuario";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(265, 428);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(94, 35);
            this.btnCadastrar.TabIndex = 13;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(94, 392);
            this.txtValor.Name = "txtValor";
            this.txtValor.ReadOnly = true;
            this.txtValor.Size = new System.Drawing.Size(169, 20);
            this.txtValor.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Valor Total";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(550, 452);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 26);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FCrudNotaFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 490);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnImportarXML);
            this.Controls.Add(this.lstNF);
            this.Controls.Add(this.dtpNF);
            this.Controls.Add(this.txtNumNF);
            this.Controls.Add(this.txtOperacao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FCrudNotaFiscal";
            this.Text = "Controle Nota Fiscal";
            this.Load += new System.EventHandler(this.FCrudNotaFiscal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOperacao;
        private System.Windows.Forms.TextBox txtNumNF;
        private System.Windows.Forms.DateTimePicker dtpNF;
        private System.Windows.Forms.ListView lstNF;
        private System.Windows.Forms.Button btnImportarXML;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelar;
    }
}