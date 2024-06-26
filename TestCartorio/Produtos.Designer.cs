namespace TestCartorio
{
    partial class frm_Produtos
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
            btn_prod_novo = new Button();
            btn_fechar = new Button();
            lbl_error = new Label();
            gv_produto_pesquisar = new DataGridView();
            txt_produto_pesquisar = new TextBox();
            btn_prod_pesquisar = new Button();
            ((System.ComponentModel.ISupportInitialize)gv_produto_pesquisar).BeginInit();
            SuspendLayout();
            // 
            // btn_prod_novo
            // 
            btn_prod_novo.Location = new Point(535, 44);
            btn_prod_novo.Name = "btn_prod_novo";
            btn_prod_novo.Size = new Size(138, 23);
            btn_prod_novo.TabIndex = 11;
            btn_prod_novo.Text = "&Adicionar Produto";
            btn_prod_novo.UseVisualStyleBackColor = true;
            // 
            // btn_fechar
            // 
            btn_fechar.Location = new Point(589, 384);
            btn_fechar.Name = "btn_fechar";
            btn_fechar.Size = new Size(84, 23);
            btn_fechar.TabIndex = 10;
            btn_fechar.Text = "&Fechar";
            btn_fechar.UseVisualStyleBackColor = true;
            btn_fechar.Click += btn_fechar_Click;
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.Location = new Point(143, 70);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(0, 15);
            lbl_error.TabIndex = 9;
            // 
            // gv_produto_pesquisar
            // 
            gv_produto_pesquisar.AllowUserToAddRows = false;
            gv_produto_pesquisar.AllowUserToDeleteRows = false;
            gv_produto_pesquisar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gv_produto_pesquisar.Location = new Point(128, 91);
            gv_produto_pesquisar.Name = "gv_produto_pesquisar";
            gv_produto_pesquisar.ReadOnly = true;
            gv_produto_pesquisar.Size = new Size(530, 262);
            gv_produto_pesquisar.TabIndex = 8;
            gv_produto_pesquisar.CellContentClick += gv_produto_pesquisar_CellContentClick;
            // 
            // txt_produto_pesquisar
            // 
            txt_produto_pesquisar.Location = new Point(143, 44);
            txt_produto_pesquisar.Name = "txt_produto_pesquisar";
            txt_produto_pesquisar.Size = new Size(225, 23);
            txt_produto_pesquisar.TabIndex = 7;
            // 
            // btn_prod_pesquisar
            // 
            btn_prod_pesquisar.Location = new Point(381, 44);
            btn_prod_pesquisar.Name = "btn_prod_pesquisar";
            btn_prod_pesquisar.Size = new Size(138, 23);
            btn_prod_pesquisar.TabIndex = 6;
            btn_prod_pesquisar.Text = "&Pesquisar pelo Nome";
            btn_prod_pesquisar.UseVisualStyleBackColor = true;
            btn_prod_pesquisar.Click += btn_prod_pesquisar_Click;
            // 
            // frm_Produtos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_prod_novo);
            Controls.Add(btn_fechar);
            Controls.Add(lbl_error);
            Controls.Add(gv_produto_pesquisar);
            Controls.Add(txt_produto_pesquisar);
            Controls.Add(btn_prod_pesquisar);
            Name = "frm_Produtos";
            Text = "Produtos";
            Load += frm_Produtos_Load;
            ((System.ComponentModel.ISupportInitialize)gv_produto_pesquisar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_prod_novo;
        private Button btn_fechar;
        private Label lbl_error;
        private DataGridView gv_produto_pesquisar;
        private TextBox txt_produto_pesquisar;
        private Button btn_prod_pesquisar;
    }
}