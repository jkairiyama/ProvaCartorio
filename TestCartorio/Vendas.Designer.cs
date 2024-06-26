namespace TestCartorio
{
    partial class frm_Vendas
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
            btn_fechar = new Button();
            lbl_msg = new Label();
            gv_vendas_pesquisar = new DataGridView();
            btn_vendas_pesquisar = new Button();
            rdb_vendas_por_data = new RadioButton();
            rdb_vendas_por_cliente = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)gv_vendas_pesquisar).BeginInit();
            SuspendLayout();
            // 
            // btn_fechar
            // 
            btn_fechar.Location = new Point(589, 384);
            btn_fechar.Name = "btn_fechar";
            btn_fechar.Size = new Size(84, 23);
            btn_fechar.TabIndex = 16;
            btn_fechar.Text = "&Fechar";
            btn_fechar.UseVisualStyleBackColor = true;
            btn_fechar.Click += btn_fechar_Click;
            // 
            // lbl_msg
            // 
            lbl_msg.AutoSize = true;
            lbl_msg.Location = new Point(143, 70);
            lbl_msg.Name = "lbl_msg";
            lbl_msg.Size = new Size(0, 15);
            lbl_msg.TabIndex = 15;
            // 
            // gv_vendas_pesquisar
            // 
            gv_vendas_pesquisar.AllowUserToAddRows = false;
            gv_vendas_pesquisar.AllowUserToDeleteRows = false;
            gv_vendas_pesquisar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gv_vendas_pesquisar.Location = new Point(127, 101);
            gv_vendas_pesquisar.Name = "gv_vendas_pesquisar";
            gv_vendas_pesquisar.ReadOnly = true;
            gv_vendas_pesquisar.Size = new Size(530, 262);
            gv_vendas_pesquisar.TabIndex = 14;
            gv_vendas_pesquisar.CellContentClick += gv_vendas_pesquisar_CellContentClick;
            // 
            // btn_vendas_pesquisar
            // 
            btn_vendas_pesquisar.Location = new Point(127, 44);
            btn_vendas_pesquisar.Name = "btn_vendas_pesquisar";
            btn_vendas_pesquisar.Size = new Size(138, 23);
            btn_vendas_pesquisar.TabIndex = 12;
            btn_vendas_pesquisar.Text = "&Pesquisar por";
            btn_vendas_pesquisar.UseVisualStyleBackColor = true;
            btn_vendas_pesquisar.Click += btn_vendas_pesquisar_Click;
            // 
            // rdb_vendas_por_data
            // 
            rdb_vendas_por_data.AutoSize = true;
            rdb_vendas_por_data.Location = new Point(370, 48);
            rdb_vendas_por_data.Name = "rdb_vendas_por_data";
            rdb_vendas_por_data.Size = new Size(49, 19);
            rdb_vendas_por_data.TabIndex = 18;
            rdb_vendas_por_data.Text = "Data";
            rdb_vendas_por_data.UseVisualStyleBackColor = true;
            // 
            // rdb_vendas_por_cliente
            // 
            rdb_vendas_por_cliente.AutoSize = true;
            rdb_vendas_por_cliente.Checked = true;
            rdb_vendas_por_cliente.Location = new Point(296, 48);
            rdb_vendas_por_cliente.Name = "rdb_vendas_por_cliente";
            rdb_vendas_por_cliente.Size = new Size(62, 19);
            rdb_vendas_por_cliente.TabIndex = 19;
            rdb_vendas_por_cliente.TabStop = true;
            rdb_vendas_por_cliente.Text = "Cliente";
            rdb_vendas_por_cliente.UseVisualStyleBackColor = true;
            // 
            // frm_Vendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rdb_vendas_por_cliente);
            Controls.Add(rdb_vendas_por_data);
            Controls.Add(btn_fechar);
            Controls.Add(lbl_msg);
            Controls.Add(gv_vendas_pesquisar);
            Controls.Add(btn_vendas_pesquisar);
            Name = "frm_Vendas";
            Text = "Vendas";
            Load += frm_Vendas_Load;
            ((System.ComponentModel.ISupportInitialize)gv_vendas_pesquisar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_fechar;
        private Label lbl_msg;
        private DataGridView gv_vendas_pesquisar;
        private TextBox txt_vendas_pesquisar;
        private Button btn_vendas_pesquisar;        
        private RadioButton rdb_vendas_por_data;
        private RadioButton rdb_vendas_por_cliente;
    }
}