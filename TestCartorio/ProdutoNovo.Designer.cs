namespace TestCartorio
{
    partial class frmProdutoNovo
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
            lbl_error = new Label();
            prod_preco = new TextBox();
            label4 = new Label();
            prod_estoque = new TextBox();
            label3 = new Label();
            prod_descricao = new TextBox();
            label2 = new Label();
            prod_nome = new TextBox();
            label1 = new Label();
            btn_prod_sair = new Button();
            btn_prod_gravar = new Button();
            SuspendLayout();
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.ForeColor = Color.Red;
            lbl_error.Location = new Point(129, 172);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(0, 15);
            lbl_error.TabIndex = 21;
            // 
            // prod_preco
            // 
            prod_preco.Location = new Point(129, 123);
            prod_preco.MaxLength = 10;
            prod_preco.Name = "prod_preco";
            prod_preco.Size = new Size(168, 23);
            prod_preco.TabIndex = 20;
            prod_preco.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 126);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 19;
            label4.Text = "Preço";
            // 
            // prod_estoque
            // 
            prod_estoque.Location = new Point(129, 92);
            prod_estoque.MaxLength = 6;
            prod_estoque.Name = "prod_estoque";
            prod_estoque.Size = new Size(168, 23);
            prod_estoque.TabIndex = 18;
            prod_estoque.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 97);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 17;
            label3.Text = "Estoque";
            // 
            // prod_descricao
            // 
            prod_descricao.Location = new Point(129, 63);
            prod_descricao.Name = "prod_descricao";
            prod_descricao.Size = new Size(350, 23);
            prod_descricao.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 68);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 15;
            label2.Text = "Descrição";
            // 
            // prod_nome
            // 
            prod_nome.Location = new Point(129, 34);
            prod_nome.Name = "prod_nome";
            prod_nome.Size = new Size(350, 23);
            prod_nome.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 39);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 13;
            label1.Text = "Nome";
            // 
            // btn_prod_sair
            // 
            btn_prod_sair.Location = new Point(311, 222);
            btn_prod_sair.Name = "btn_prod_sair";
            btn_prod_sair.Size = new Size(75, 23);
            btn_prod_sair.TabIndex = 12;
            btn_prod_sair.Text = "&Fechar";
            btn_prod_sair.UseVisualStyleBackColor = true;
            btn_prod_sair.Click += btn_prod_sair_Click;
            // 
            // btn_prod_gravar
            // 
            btn_prod_gravar.Location = new Point(205, 222);
            btn_prod_gravar.Name = "btn_prod_gravar";
            btn_prod_gravar.Size = new Size(75, 23);
            btn_prod_gravar.TabIndex = 11;
            btn_prod_gravar.Text = "&Gravar";
            btn_prod_gravar.UseVisualStyleBackColor = true;
            btn_prod_gravar.Click += btn_prod_gravar_Click;
            // 
            // frmProdutoNovo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 278);
            Controls.Add(lbl_error);
            Controls.Add(prod_preco);
            Controls.Add(label4);
            Controls.Add(prod_estoque);
            Controls.Add(label3);
            Controls.Add(prod_descricao);
            Controls.Add(label2);
            Controls.Add(prod_nome);
            Controls.Add(label1);
            Controls.Add(btn_prod_sair);
            Controls.Add(btn_prod_gravar);
            Name = "frmProdutoNovo";
            Text = "Produto";
            Load += frmProdutoNovo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_error;
        private TextBox prod_preco;
        private Label label4;
        private TextBox prod_estoque;
        private Label label3;
        private TextBox prod_descricao;
        private Label label2;
        private TextBox prod_nome;
        private Label label1;
        private Button btn_prod_sair;
        private Button btn_prod_gravar;
    }
}