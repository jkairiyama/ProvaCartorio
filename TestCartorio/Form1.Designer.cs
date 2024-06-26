namespace TestCartorio
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            cartorioToolStripMenuItem = new ToolStripMenuItem();
            clienteToolStripMenuItem = new ToolStripMenuItem();
            novoClienteToolStripMenuItem = new ToolStripMenuItem();
            listadoToolStripMenuItem = new ToolStripMenuItem();
            produtosToolStripMenuItem = new ToolStripMenuItem();
            novoProdutoToolStripMenuItem = new ToolStripMenuItem();
            listadoToolStripMenuItem1 = new ToolStripMenuItem();
            vendasToolStripMenuItem = new ToolStripMenuItem();
            novaVendaToolStripMenuItem = new ToolStripMenuItem();
            listadoToolStripMenuItem2 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cartorioToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(982, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // cartorioToolStripMenuItem
            // 
            cartorioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clienteToolStripMenuItem, produtosToolStripMenuItem, vendasToolStripMenuItem });
            cartorioToolStripMenuItem.Name = "cartorioToolStripMenuItem";
            cartorioToolStripMenuItem.Size = new Size(62, 20);
            cartorioToolStripMenuItem.Text = "&Cartorio";
            // 
            // clienteToolStripMenuItem
            // 
            clienteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoClienteToolStripMenuItem, listadoToolStripMenuItem });
            clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            clienteToolStripMenuItem.Size = new Size(122, 22);
            clienteToolStripMenuItem.Text = "&Clientes";
            // 
            // novoClienteToolStripMenuItem
            // 
            novoClienteToolStripMenuItem.Name = "novoClienteToolStripMenuItem";
            novoClienteToolStripMenuItem.Size = new Size(143, 22);
            novoClienteToolStripMenuItem.Text = "&Novo Cliente";
            novoClienteToolStripMenuItem.Click += novoClienteToolStripMenuItem_Click;
            // 
            // listadoToolStripMenuItem
            // 
            listadoToolStripMenuItem.Name = "listadoToolStripMenuItem";
            listadoToolStripMenuItem.Size = new Size(143, 22);
            listadoToolStripMenuItem.Text = "&Listado";
            listadoToolStripMenuItem.Click += listadoToolStripMenuItem_Click;
            // 
            // produtosToolStripMenuItem
            // 
            produtosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoProdutoToolStripMenuItem, listadoToolStripMenuItem1 });
            produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            produtosToolStripMenuItem.Size = new Size(122, 22);
            produtosToolStripMenuItem.Text = "&Produtos";
            // 
            // novoProdutoToolStripMenuItem
            // 
            novoProdutoToolStripMenuItem.Name = "novoProdutoToolStripMenuItem";
            novoProdutoToolStripMenuItem.Size = new Size(149, 22);
            novoProdutoToolStripMenuItem.Text = "Novo P&roduto";
            novoProdutoToolStripMenuItem.Click += novoProdutoToolStripMenuItem_Click;
            // 
            // listadoToolStripMenuItem1
            // 
            listadoToolStripMenuItem1.Name = "listadoToolStripMenuItem1";
            listadoToolStripMenuItem1.Size = new Size(149, 22);
            listadoToolStripMenuItem1.Text = "Listado";
            listadoToolStripMenuItem1.Click += listadoToolStripMenuItem1_Click;
            // 
            // vendasToolStripMenuItem
            // 
            vendasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novaVendaToolStripMenuItem, listadoToolStripMenuItem2 });
            vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            vendasToolStripMenuItem.Size = new Size(122, 22);
            vendasToolStripMenuItem.Text = "Vendas";
            // 
            // novaVendaToolStripMenuItem
            // 
            novaVendaToolStripMenuItem.Name = "novaVendaToolStripMenuItem";
            novaVendaToolStripMenuItem.Size = new Size(137, 22);
            novaVendaToolStripMenuItem.Text = "Nova &Venda";
            novaVendaToolStripMenuItem.Click += novaVendaToolStripMenuItem_Click;
            // 
            // listadoToolStripMenuItem2
            // 
            listadoToolStripMenuItem2.Name = "listadoToolStripMenuItem2";
            listadoToolStripMenuItem2.Size = new Size(137, 22);
            listadoToolStripMenuItem2.Text = "Listad&o";
            listadoToolStripMenuItem2.Click += listadoToolStripMenuItem2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Cartorio (teste)";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem cartorioToolStripMenuItem;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem novoClienteToolStripMenuItem;
        private ToolStripMenuItem listadoToolStripMenuItem;
        private ToolStripMenuItem produtosToolStripMenuItem;
        private ToolStripMenuItem novoProdutoToolStripMenuItem;
        private ToolStripMenuItem listadoToolStripMenuItem1;
        private ToolStripMenuItem vendasToolStripMenuItem;
        private ToolStripMenuItem novaVendaToolStripMenuItem;
        private ToolStripMenuItem listadoToolStripMenuItem2;
    }
}
