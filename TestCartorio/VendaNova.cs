using AppCartorio.Vendas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestCartorio
{
    public partial class frm_VendaNova : Form
    {

        private readonly frm_clientes _frm_clientes;
        private readonly frm_Produtos _frm_Produtos;
        private CreateVendaCommand _createVendaCommand;
        public frm_VendaNova(frm_clientes frm_clientes, frm_Produtos frm_Produtos)
        {
            InitializeComponent();
            _frm_clientes = frm_clientes;
            _frm_Produtos = frm_Produtos;
        }

        public CreateVendaCommand VendaNovaCommand
        {
            get { return _createVendaCommand; }
            set { _createVendaCommand = value; }
        }

        private void btn_venda_sair_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void gv_venda_items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            {
                editButtonColumn.Name = "edit_column";
                editButtonColumn.HeaderText = "";
                editButtonColumn.Text = "Editar";
                editButtonColumn.UseColumnTextForButtonValue = true;
                editButtonColumn.Width = 50;
            };
            if (gv_venda_items.Columns["edit_column"] is null)
            {
                gv_venda_items.Columns.Insert(0, editButtonColumn);
            }

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
                gv_venda_items.Columns.Insert(1, removeButtonColumn);
            }
        }

        private void btn_venda_clinete_pesquisar_Click(object sender, EventArgs e)
        {
            _frm_clientes.IsSelectionAction = true;
            _frm_clientes.ShowDialog();
            this.VendaNovaCommand = new CreateVendaCommand
            (
                ClienteId: _frm_clientes.ClienteId,
                Data: DateTime.Now,
                Items: new List<CreateVendaItemCommand>()
            );
            txt_venda_cliente.Text = _frm_clientes.ClienteNome;
            txt_venda_data.Text = VendaNovaCommand.Data.ToString("dd/MM/yyyy");

            _frm_clientes.IsSelectionAction = false;
        }
    }
}
