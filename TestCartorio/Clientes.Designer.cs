namespace TestCartorio
{
    partial class frm_clientes
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
            btn_clie_pesquisar = new Button();
            txt_cliente_pesquisar = new TextBox();
            gv_cliente_pesquisar = new DataGridView();
            lbl_error = new Label();
            btn_fechar = new Button();
            btn_clie_novo = new Button();
            ((System.ComponentModel.ISupportInitialize)gv_cliente_pesquisar).BeginInit();
            SuspendLayout();
            // 
            // btn_clie_pesquisar
            // 
            btn_clie_pesquisar.Location = new Point(381, 65);
            btn_clie_pesquisar.Name = "btn_clie_pesquisar";
            btn_clie_pesquisar.Size = new Size(138, 23);
            btn_clie_pesquisar.TabIndex = 0;
            btn_clie_pesquisar.Text = "&Pesquisar pelo Nome";
            btn_clie_pesquisar.UseVisualStyleBackColor = true;
            btn_clie_pesquisar.Click += btn_clie_pesquisar_Click;
            // 
            // txt_cliente_pesquisar
            // 
            txt_cliente_pesquisar.Location = new Point(143, 65);
            txt_cliente_pesquisar.Name = "txt_cliente_pesquisar";
            txt_cliente_pesquisar.Size = new Size(225, 23);
            txt_cliente_pesquisar.TabIndex = 1;
            // 
            // gv_cliente_pesquisar
            // 
            gv_cliente_pesquisar.AllowUserToAddRows = false;
            gv_cliente_pesquisar.AllowUserToDeleteRows = false;
            gv_cliente_pesquisar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gv_cliente_pesquisar.Location = new Point(128, 112);
            gv_cliente_pesquisar.Name = "gv_cliente_pesquisar";
            gv_cliente_pesquisar.ReadOnly = true;
            gv_cliente_pesquisar.Size = new Size(530, 262);
            gv_cliente_pesquisar.TabIndex = 2;
            gv_cliente_pesquisar.CellContentClick += gv_cliente_pesquisar_CellContentClick;
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.Location = new Point(143, 91);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(0, 15);
            lbl_error.TabIndex = 3;
            // 
            // btn_fechar
            // 
            btn_fechar.Location = new Point(589, 405);
            btn_fechar.Name = "btn_fechar";
            btn_fechar.Size = new Size(84, 23);
            btn_fechar.TabIndex = 4;
            btn_fechar.Text = "&Fechar";
            btn_fechar.UseVisualStyleBackColor = true;
            btn_fechar.Click += btn_fechar_Click;
            // 
            // btn_clie_novo
            // 
            btn_clie_novo.Location = new Point(535, 65);
            btn_clie_novo.Name = "btn_clie_novo";
            btn_clie_novo.Size = new Size(138, 23);
            btn_clie_novo.TabIndex = 5;
            btn_clie_novo.Text = "&Adicionar Cliente";
            btn_clie_novo.UseVisualStyleBackColor = true;
            btn_clie_novo.Click += btn_clie_novo_Click;
            // 
            // frm_clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_clie_novo);
            Controls.Add(btn_fechar);
            Controls.Add(lbl_error);
            Controls.Add(gv_cliente_pesquisar);
            Controls.Add(txt_cliente_pesquisar);
            Controls.Add(btn_clie_pesquisar);
            Name = "frm_clientes";
            Text = "Clientes";
            Load += frm_clientes_Load;
            ((System.ComponentModel.ISupportInitialize)gv_cliente_pesquisar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_clie_pesquisar;
        private TextBox txt_cliente_pesquisar;
        private DataGridView gv_cliente_pesquisar;
        private Label lbl_error;
        private Button btn_fechar;
        private Button btn_clie_novo;
    }
}