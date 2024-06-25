namespace TestCartorio
{
    partial class frm_ClienteNewUpdate
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
            btn_clie_gravar = new Button();
            btn_clie_sair = new Button();
            label1 = new Label();
            clie_nome = new TextBox();
            clie_endereco = new TextBox();
            label2 = new Label();
            clie_telefone = new TextBox();
            label3 = new Label();
            clie_email = new TextBox();
            label4 = new Label();
            lbl_error = new Label();
            SuspendLayout();
            // 
            // btn_clie_gravar
            // 
            btn_clie_gravar.Location = new Point(236, 229);
            btn_clie_gravar.Name = "btn_clie_gravar";
            btn_clie_gravar.Size = new Size(75, 23);
            btn_clie_gravar.TabIndex = 0;
            btn_clie_gravar.Text = "&Gravar";
            btn_clie_gravar.UseVisualStyleBackColor = true;
            btn_clie_gravar.Click += btn_clie_gravar_Click;
            // 
            // btn_clie_sair
            // 
            btn_clie_sair.Location = new Point(342, 229);
            btn_clie_sair.Name = "btn_clie_sair";
            btn_clie_sair.Size = new Size(75, 23);
            btn_clie_sair.TabIndex = 1;
            btn_clie_sair.Text = "&Fechar";
            btn_clie_sair.UseVisualStyleBackColor = true;
            btn_clie_sair.Click += btn_clie_sair_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 46);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 2;
            label1.Text = "Nome";
            label1.Click += label1_Click;
            // 
            // clie_nome
            // 
            clie_nome.Location = new Point(160, 41);
            clie_nome.Name = "clie_nome";
            clie_nome.Size = new Size(350, 23);
            clie_nome.TabIndex = 3;
            // 
            // clie_endereco
            // 
            clie_endereco.Location = new Point(160, 70);
            clie_endereco.Name = "clie_endereco";
            clie_endereco.Size = new Size(350, 23);
            clie_endereco.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 75);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 4;
            label2.Text = "Endereço";
            // 
            // clie_telefone
            // 
            clie_telefone.Location = new Point(160, 99);
            clie_telefone.Name = "clie_telefone";
            clie_telefone.Size = new Size(350, 23);
            clie_telefone.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 104);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 6;
            label3.Text = "Telefone";
            // 
            // clie_email
            // 
            clie_email.Location = new Point(160, 128);
            clie_email.Name = "clie_email";
            clie_email.Size = new Size(350, 23);
            clie_email.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 133);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 8;
            label4.Text = "Email";
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.ForeColor = Color.Red;
            lbl_error.Location = new Point(160, 179);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(0, 15);
            lbl_error.TabIndex = 10;
            // 
            // frm_ClienteNewUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 303);
            Controls.Add(lbl_error);
            Controls.Add(clie_email);
            Controls.Add(label4);
            Controls.Add(clie_telefone);
            Controls.Add(label3);
            Controls.Add(clie_endereco);
            Controls.Add(label2);
            Controls.Add(clie_nome);
            Controls.Add(label1);
            Controls.Add(btn_clie_sair);
            Controls.Add(btn_clie_gravar);
            Name = "frm_ClienteNewUpdate";
            Text = "ClienteNovo";
            Load += ClienteNovo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_clie_gravar;
        private Button btn_clie_sair;
        private Label label1;
        private TextBox clie_nome;
        private TextBox clie_endereco;
        private Label label2;
        private TextBox clie_telefone;
        private Label label3;
        private TextBox clie_email;
        private Label label4;
        private Label lbl_error;
    }
}