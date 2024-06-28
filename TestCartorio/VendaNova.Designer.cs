namespace TestCartorio
{
    partial class frm_VendaNova
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
            label1 = new Label();
            txt_venda_cliente = new TextBox();
            btn_venda_clinete_pesquisar = new Button();
            label2 = new Label();
            txt_venda_data = new TextBox();
            label3 = new Label();
            txt_venda_produto = new TextBox();
            btn_venda_produto_pesquisar = new Button();
            txt_venda_produto_qnt = new TextBox();
            label4 = new Label();
            btn_venda_produto_inserir = new Button();
            gv_venda_items = new DataGridView();
            btn_venda_pagar = new Button();
            btn_venda_sair = new Button();
            lbl_error = new Label();
            ((System.ComponentModel.ISupportInitialize)gv_venda_items).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 57);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente";
            // 
            // txt_venda_cliente
            // 
            txt_venda_cliente.Enabled = false;
            txt_venda_cliente.Location = new Point(181, 56);
            txt_venda_cliente.MaxLength = 256;
            txt_venda_cliente.Name = "txt_venda_cliente";
            txt_venda_cliente.ReadOnly = true;
            txt_venda_cliente.Size = new Size(449, 23);
            txt_venda_cliente.TabIndex = 1;
            // 
            // btn_venda_clinete_pesquisar
            // 
            btn_venda_clinete_pesquisar.Location = new Point(636, 57);
            btn_venda_clinete_pesquisar.Name = "btn_venda_clinete_pesquisar";
            btn_venda_clinete_pesquisar.Size = new Size(25, 23);
            btn_venda_clinete_pesquisar.TabIndex = 2;
            btn_venda_clinete_pesquisar.Text = "...";
            btn_venda_clinete_pesquisar.UseVisualStyleBackColor = true;
            btn_venda_clinete_pesquisar.Click += btn_venda_clinete_pesquisar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(99, 105);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 3;
            label2.Text = "Data";
            // 
            // txt_venda_data
            // 
            txt_venda_data.Enabled = false;
            txt_venda_data.Location = new Point(181, 97);
            txt_venda_data.MaxLength = 256;
            txt_venda_data.Name = "txt_venda_data";
            txt_venda_data.ReadOnly = true;
            txt_venda_data.Size = new Size(151, 23);
            txt_venda_data.TabIndex = 4;
            txt_venda_data.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(100, 151);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 5;
            label3.Text = "Produto";
            // 
            // txt_venda_produto
            // 
            txt_venda_produto.Enabled = false;
            txt_venda_produto.Location = new Point(181, 143);
            txt_venda_produto.Name = "txt_venda_produto";
            txt_venda_produto.ReadOnly = true;
            txt_venda_produto.Size = new Size(449, 23);
            txt_venda_produto.TabIndex = 6;
            // 
            // btn_venda_produto_pesquisar
            // 
            btn_venda_produto_pesquisar.Location = new Point(636, 143);
            btn_venda_produto_pesquisar.Name = "btn_venda_produto_pesquisar";
            btn_venda_produto_pesquisar.Size = new Size(25, 23);
            btn_venda_produto_pesquisar.TabIndex = 7;
            btn_venda_produto_pesquisar.Text = "...";
            btn_venda_produto_pesquisar.UseVisualStyleBackColor = true;
            btn_venda_produto_pesquisar.Click += btn_venda_produto_pesquisar_Click;
            // 
            // txt_venda_produto_qnt
            // 
            txt_venda_produto_qnt.Location = new Point(780, 147);
            txt_venda_produto_qnt.Name = "txt_venda_produto_qnt";
            txt_venda_produto_qnt.Size = new Size(50, 23);
            txt_venda_produto_qnt.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(691, 151);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 9;
            label4.Text = "Quantidade";
            // 
            // btn_venda_produto_inserir
            // 
            btn_venda_produto_inserir.Location = new Point(858, 146);
            btn_venda_produto_inserir.Name = "btn_venda_produto_inserir";
            btn_venda_produto_inserir.Size = new Size(75, 23);
            btn_venda_produto_inserir.TabIndex = 10;
            btn_venda_produto_inserir.Text = "Incluir";
            btn_venda_produto_inserir.UseVisualStyleBackColor = true;
            btn_venda_produto_inserir.Click += btn_venda_produto_inserir_Click;
            // 
            // gv_venda_items
            // 
            gv_venda_items.AllowUserToAddRows = false;
            gv_venda_items.AllowUserToDeleteRows = false;
            gv_venda_items.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gv_venda_items.Location = new Point(100, 196);
            gv_venda_items.Name = "gv_venda_items";
            gv_venda_items.ReadOnly = true;
            gv_venda_items.Size = new Size(833, 262);
            gv_venda_items.TabIndex = 11;
            gv_venda_items.CellContentClick += gv_venda_items_CellContentClick;
            // 
            // btn_venda_pagar
            // 
            btn_venda_pagar.Location = new Point(609, 480);
            btn_venda_pagar.Name = "btn_venda_pagar";
            btn_venda_pagar.Size = new Size(75, 23);
            btn_venda_pagar.TabIndex = 12;
            btn_venda_pagar.Text = "Gravar Venda";
            btn_venda_pagar.UseVisualStyleBackColor = true;
            btn_venda_pagar.Click += btn_venda_pagar_Click;
            // 
            // btn_venda_sair
            // 
            btn_venda_sair.Location = new Point(713, 480);
            btn_venda_sair.Name = "btn_venda_sair";
            btn_venda_sair.Size = new Size(75, 23);
            btn_venda_sair.TabIndex = 13;
            btn_venda_sair.Text = "Sair";
            btn_venda_sair.UseVisualStyleBackColor = true;
            btn_venda_sair.Click += btn_venda_sair_Click;
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.Location = new Point(181, 24);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(0, 15);
            lbl_error.TabIndex = 14;
            // 
            // frm_VendaNova
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 525);
            Controls.Add(lbl_error);
            Controls.Add(btn_venda_sair);
            Controls.Add(btn_venda_pagar);
            Controls.Add(gv_venda_items);
            Controls.Add(btn_venda_produto_inserir);
            Controls.Add(label4);
            Controls.Add(txt_venda_produto_qnt);
            Controls.Add(btn_venda_produto_pesquisar);
            Controls.Add(txt_venda_produto);
            Controls.Add(label3);
            Controls.Add(txt_venda_data);
            Controls.Add(label2);
            Controls.Add(btn_venda_clinete_pesquisar);
            Controls.Add(txt_venda_cliente);
            Controls.Add(label1);
            Name = "frm_VendaNova";
            Text = "Venda Nova";
            Load += frm_VendaNova_Load;
            ((System.ComponentModel.ISupportInitialize)gv_venda_items).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_venda_cliente;
        private Button btn_venda_clinete_pesquisar;
        private Label label2;
        private TextBox txt_venda_data;
        private Label label3;
        private TextBox txt_venda_produto;
        private Button btn_venda_produto_pesquisar;
        private TextBox txt_venda_produto_qnt;
        private Label label4;
        private Button btn_venda_produto_inserir;
        private DataGridView gv_venda_items;
        private Button btn_venda_pagar;
        private Button btn_venda_sair;
        private Label lbl_error;
    }
}