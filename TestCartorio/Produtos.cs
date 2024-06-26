using AppCartorio.Clientes;
using AppCartorio.Produtos;
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

namespace TestCartorio
{
    public partial class frm_Produtos : Form
    {
        private readonly ISender _mediator;
        private readonly frmProdutoNovo _frm_Produto;
        public frm_Produtos(
            ISender mediator,
            frmProdutoNovo frm_Produto)
        {
            InitializeComponent();
            _mediator = mediator;
            _frm_Produto = frm_Produto;
        }

        private async void btn_prod_pesquisar_Click(object sender, EventArgs e)
        {
            lbl_error.ForeColor = Color.Black;
            lbl_error.Text = "Buscando dados ...";
            try
            {
                var queryProduto = new GetProdutoByNomeQuery(
                    Nome: txt_produto_pesquisar.Text
                    );


                var produtos = await _mediator.Send(queryProduto);

                gv_produto_pesquisar.DataSource = produtos;

                lbl_error.Text = "";
            }
            catch (Exception ex)
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = ex.Message;
            }
        }

        private void frm_Produtos_Load(object sender, EventArgs e)
        {
            lbl_error.Text = string.Empty;
            txt_produto_pesquisar.Text = string.Empty;
            txt_produto_pesquisar.Focus();


            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            {
                editButtonColumn.Name = "edit_column";
                editButtonColumn.HeaderText = "";
                editButtonColumn.Text = "Editar";
                editButtonColumn.UseColumnTextForButtonValue = true;
                editButtonColumn.Width = 50;
            };
            if (gv_produto_pesquisar.Columns["edit_column"] is null)
            {
                gv_produto_pesquisar.Columns.Insert(0, editButtonColumn);
            }

            DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
            {
                removeButtonColumn.Name = "remove_column";
                removeButtonColumn.HeaderText = "";
                removeButtonColumn.Text = "Remover";
                removeButtonColumn.UseColumnTextForButtonValue = true;
                removeButtonColumn.Width = 60;
            };
            if (gv_produto_pesquisar.Columns["remove_column"] is null)
            {
                gv_produto_pesquisar.Columns.Insert(1, removeButtonColumn);
            }
        }

        private async void gv_produto_pesquisar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0
                || !(e.ColumnIndex == gv_produto_pesquisar.Columns["edit_column"].Index
                    || e.ColumnIndex == gv_produto_pesquisar.Columns["remove_column"].Index)
               ) return;

            try
            {


                int ProdutoId = (int)gv_produto_pesquisar[2, e.RowIndex].Value;

                if (e.ColumnIndex == gv_produto_pesquisar.Columns["edit_column"].Index)
                {
                    _frm_Produto.ProdutoId = ProdutoId;
                    _frm_Produto.IsNew = false;
                    _frm_Produto.ShowDialog();
                    this.btn_prod_pesquisar_Click(sender, e);
                }
                else
                    if (e.ColumnIndex == gv_produto_pesquisar.Columns["remove_column"].Index)
                {
                    var confirmResult = MessageBox.Show("Seguro quer excluir o Produto??",
                                     "Confirmação excluir!!",
                                     MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.No) return;

                    lbl_error.ForeColor = Color.Black;
                    lbl_error.Text = "Gravando dados ...";

                    var cmdRemoveProduto = new RemoveProdutoCommand(
                            ProdutoId: ProdutoId
                        );
                    var produto = await _mediator.Send(cmdRemoveProduto);
                    this.btn_prod_pesquisar_Click(sender, e);

                    lbl_error.Text = "Dados gravados corretamente.";
                    await Task.Delay(1000);
                    lbl_error.Text = string.Empty;

                }


            }
            catch (Exception ex)
            {
                lbl_error.ForeColor = Color.Red;
                this.lbl_error.Text = ex.Message;
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
