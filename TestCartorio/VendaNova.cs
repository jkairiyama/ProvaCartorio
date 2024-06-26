using AppCartorio.Vendas;
using Domain.Data.Produtos;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Contracts.ViewModels.Vendas;
using Domain.Data.Vendas;
using AppCartorio.Clientes;
using Domain.Data.Clientes;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Data.Vendas.Entities;

namespace TestCartorio
{
    public partial class frm_VendaNova : Form
    {

        private readonly ISender _mediator;
        private readonly frm_clientes _frm_clientes;
        private readonly frm_Produtos _frm_Produtos;
        private VendaVM? _venda;
        private int _produtoId;
        private decimal _preco;

        private bool _isNewVenda = true;
        private int _vendaId;

        public frm_VendaNova(frm_clientes frm_clientes, frm_Produtos frm_Produtos, ISender mediator)
        {
            InitializeComponent();
            _frm_clientes = frm_clientes;
            _frm_Produtos = frm_Produtos;
            _mediator = mediator;
        }

        public int VendaId
        {
            get { return _vendaId; }
            set { _vendaId = value; }
        }

        public bool IsNewVenda
        {
            get { return _isNewVenda; }
            set { _isNewVenda = value; }
        }

        private void btn_venda_sair_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void gv_venda_items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == gv_venda_items.Columns["remove_column"].Index)
            {
                int produtoId = (int)gv_venda_items[3, e.RowIndex].Value;
                var prod = this._venda?.Items.Where(itm => itm.ProdutoId == produtoId).FirstOrDefault();

                if (prod is not null)
                {
                    this._venda?.Items.Remove(prod);
                    this.gv_venda_items.DataSource = new BindingSource(this._venda?.Items, null);

                }
            }
        }

        private void btn_venda_clinete_pesquisar_Click(object sender, EventArgs e)
        {
            _frm_clientes.IsSelectionAction = true;
            _frm_clientes.ShowDialog();
            this._venda = new 
            (
                VendaId: 0,
                ClienteId: _frm_clientes.ClienteId,
                ClienteNome: _frm_clientes.ClienteNome,
                Data: DateTime.Now,
                Items: new List<ItemVendaVM>()
            );

            txt_venda_cliente.Text = _frm_clientes.ClienteNome;
            txt_venda_data.Text = this._venda.Data.ToString("dd/MM/yyyy");
            this.gv_venda_items.DataSource = null;
            _frm_clientes.IsSelectionAction = false;
        }

        private void btn_venda_produto_pesquisar_Click(object sender, EventArgs e)
        {

            _frm_Produtos.IsSelectionAction = true;
            _frm_Produtos.ShowDialog();
            _produtoId = _frm_Produtos.ProdutoId;
            txt_venda_produto.Text = _frm_Produtos.ProdutoNome;
            txt_venda_produto_qnt.Text = "1";
            _preco = _frm_Produtos.Preco;

            _frm_Produtos.IsSelectionAction = false;
        }

        private void btn_venda_produto_inserir_Click(object sender, EventArgs e)
        {

            if (this._venda is null)
            {
                lbl_error.ForeColor = Color.Black;
                lbl_error.Text = "Por favor escolha primeiro um Cliente.";
                return;
            }
            else
            {
                lbl_error.Text = string.Empty;
            }
            var prod = this._venda.Items.Where(itm => itm.ProdutoId == _produtoId).FirstOrDefault();

            if (prod is not null)
            {
                this._venda.Items.Remove(prod);

            }

            ItemVendaVM vendaItem = new(
                VendaItemId: default,
                VendaId: default,
                ProdutoId: _produtoId,
                ProdutoNome: txt_venda_produto.Text,
                Preco: _preco,
                Quantidade: int.Parse(txt_venda_produto_qnt.Text),
                Total: _preco * int.Parse(txt_venda_produto_qnt.Text)
            );


            this._venda.Items.Add(vendaItem);
            this.gv_venda_items.DataSource = new BindingSource(this._venda.Items, null);


        }

        private async void btn_venda_pagar_Click(object sender, EventArgs e)
        {
            if (this._venda is not null && this._venda.Items.Count > 0)
            {
                try
                {
                    lbl_error.ForeColor = Color.Black;
                    lbl_error.Text = "Gravando dados ...";

                    var cmd = this._venda.Adapt<CreateVendaCommand>();

                    await _mediator.Send(cmd);

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

        private async void frm_VendaNova_Load(object sender, EventArgs e)
        {
            AdicionaColunaEdit();

            await CarregarDados();
        }

        private async Task CarregarDados()
        {
            lbl_error.Text = "";
            txt_venda_cliente.Focus();
            if (IsNewVenda)
            {
                txt_venda_cliente.Text = string.Empty;
                txt_venda_data.Text = string.Empty;
                txt_venda_produto.Text = string.Empty;
                txt_venda_produto_qnt.Text = string.Empty;
                gv_venda_items.DataSource = null;
            }
            else
            {
                var vendaQuery = new GetVendaByIdQuery(VendaId: _vendaId);
                var vend = await _mediator.Send(vendaQuery);
                if (vend != null)
                {
                    txt_venda_cliente.Text = vend.Cliente?.Nome;
                    txt_venda_data.Text = vend.Data.ToString("dd/MM/yyyy");
                    txt_venda_produto.Text = string.Empty;
                    txt_venda_produto_qnt.Text = string.Empty;
                    //gv_venda_items.DataSource = null;
                }

                TypeAdapterConfig<Venda, VendaVM>.NewConfig()
                    .Map(dest => dest.ClienteNome, src => src.Cliente.Nome);

                TypeAdapterConfig<VendaItem, ItemVendaVM>.NewConfig()
                    .Map(dest => dest.ProdutoNome, src => src.Produto.Nome)
                    .Map(dest => dest.Total, src => src.Quantidade * src.Preco);

                this._venda = vend.Adapt<VendaVM>();

                gv_venda_items.DataSource = this._venda.Items;

            }
        }

        private void AdicionaColunaEdit()
        {
            DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
            {
                removeButtonColumn.Name = "remove_column";
                removeButtonColumn.HeaderText = "";
                removeButtonColumn.Text = "Remover";
                removeButtonColumn.UseColumnTextForButtonValue = true;
                removeButtonColumn.Width = 60;
            };
            if (gv_venda_items.Columns["remove_column"] is null)
            {
                gv_venda_items.Columns.Insert(0, removeButtonColumn);
            }
        }
    }
}
