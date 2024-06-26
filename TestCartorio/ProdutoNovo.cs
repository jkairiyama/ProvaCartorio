using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCartorio.Clientes;
using AppCartorio.Produtos;

namespace TestCartorio
{

    public partial class frmProdutoNovo : Form
    {

        private readonly ISender _mediator;
        private bool _isNewProduto = true;
        private int _produtoId;
        
        public frmProdutoNovo(ISender mediator)
        {
            InitializeComponent();
            _mediator = mediator;
        }

        public bool IsNew
        {
            get { return _isNewProduto; }
            set { _isNewProduto = value; }
        }

        public int ProdutoId
        {
            get { return _produtoId; }
            set { _produtoId = value; }
        }

        private void btn_prod_sair_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void frmProdutoNovo_Load(object sender, EventArgs e)
        {
            lbl_error.Text = "";
            prod_nome.Focus();
            if (IsNew)
            {
                prod_nome.Text = string.Empty;
                prod_descricao.Text = string.Empty;
                prod_estoque.Text = string.Empty;
                prod_preco.Text = string.Empty;
            }
            else
            {
                var prodQuery = new GetProdutoByIdQuery(ProdutoId: this.ProdutoId);
                var prod = await _mediator.Send(prodQuery);

                if (prod is not null)
                {
                    prod_nome.Text = prod.Nome;
                    prod_descricao.Text = prod.Descricao;
                    prod_estoque.Text = prod.Estoque.ToString("#,##0");
                    prod_preco.Text = prod.Preco.ToString("#,##0.00");
                }

            }
        }

        private async void btn_prod_gravar_Click(object sender, EventArgs e)
        {
            lbl_error.ForeColor = Color.Black;
            lbl_error.Text = "Gravando dados ...";
            try
            {
                if (IsNew)
                {
                    var cmdNewProduto = new CreateProdutoCommand(
                        Nome: prod_nome.Text,
                        Descricao: prod_descricao.Text,
                        Estoque: Int32.Parse(prod_estoque.Text),
                        Preco: Decimal.Parse(prod_preco.Text));
                    var cliente = await _mediator.Send(cmdNewProduto);
                }
                else
                {
                    var cmdEditCliente = new UpdateProdutoCommand(
                            ProdutoId: this.ProdutoId,
                            Nome: prod_nome.Text,
                            Descricao: prod_descricao.Text,
                            Estoque: Int32.Parse(prod_estoque.Text),
                            Preco: Decimal.Parse(prod_preco.Text)
                        );
                    var cliente = await _mediator.Send(cmdEditCliente);
                }

                lbl_error.Text = "Dados gravados corretamente.";
                await Task.Delay(500);
                this.Hide();

            }
            catch (Exception ex)
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = ex.Message;
            }
        }
    }
}
