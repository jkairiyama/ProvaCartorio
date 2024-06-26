using AppCartorio.Vendas;
using Domain.Data.Vendas;
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
    public partial class frm_Vendas : Form
    {
        private readonly ISender _mediator;
        private readonly frm_clientes _frm_clientes;
        private readonly frm_VendaNova _frm_VendaNova;
        private int _clienteId;
        private string _clienteNome;
        private DateTime _data;

        public frm_Vendas(
            ISender mediator,
            frm_clientes frm_clientes,
            frm_VendaNova frm_VendaNova)
        {
            InitializeComponent();
            _mediator = mediator;
            _frm_clientes = frm_clientes;
            _frm_VendaNova = frm_VendaNova;
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void btn_vendas_pesquisar_Click(object sender, EventArgs e)
        {
            if (rdb_vendas_por_cliente.Checked)
            {
                await BuscarVendasDoCliente();
            }
        }

        private async Task BuscarVendasDoCliente()
        {
            _frm_clientes.IsSelectionAction = true;
            _frm_clientes.ShowDialog();

            _clienteId = _frm_clientes.ClienteId;
            _clienteNome = _frm_clientes.ClienteNome;

            lbl_msg.Text = $"Pesquisa por cliente {_clienteNome}";

            var qryVendasCliente = new GetVendaByClienteQuery(ClienteId: _clienteId);
            var vendas = await _mediator.Send(qryVendasCliente);

            this.gv_vendas_pesquisar.DataSource = new BindingSource(vendas, null);
            _frm_clientes.IsSelectionAction = false;
        }

        private void frm_Vendas_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            {
                editButtonColumn.Name = "edit_column";
                editButtonColumn.HeaderText = "Editar";
                editButtonColumn.Text = "Editar";
                editButtonColumn.UseColumnTextForButtonValue = true;
                editButtonColumn.Width = 50;
            };
            if (gv_vendas_pesquisar.Columns["edit_column"] is null)
            {
                gv_vendas_pesquisar.Columns.Insert(0, editButtonColumn);
            }
        }

        private void gv_vendas_pesquisar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int vendaId = (int)gv_vendas_pesquisar[1, e.RowIndex].Value;
            if (e.ColumnIndex == gv_vendas_pesquisar.Columns["edit_column"].Index)
            {
                _frm_VendaNova.VendaId = vendaId;
                _frm_VendaNova.IsNewVenda = false;
                _frm_VendaNova.ShowDialog();                
                _frm_VendaNova.IsNewVenda = true;
            }
        }
    }
}
