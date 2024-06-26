﻿using AppCartorio.Clientes;
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
    public partial class frm_clientes : Form
    {
        private readonly ISender _mediator;
        private readonly frm_ClienteNewUpdate _frm_Cliente;
        public frm_clientes(ISender mediator, frm_ClienteNewUpdate frm_Cliente)
        {
            InitializeComponent();
            _mediator = mediator;
            _frm_Cliente = frm_Cliente;
        }

        private async void btn_clie_pesquisar_Click(object sender, EventArgs e)
        {
            lbl_error.ForeColor = Color.Black;
            lbl_error.Text = "Buscando dados ...";
            try
            {
                var queryCliente = new GetClienteByNomeQuery(
                    Nome: txt_cliente_pesquisar.Text
                    );


                var clientes = await _mediator.Send(queryCliente);

                gv_cliente_pesquisar.DataSource = clientes;

                lbl_error.Text = "";
            }
            catch (Exception ex)
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = ex.Message;
            }
        }

        private void frm_clientes_Load(object sender, EventArgs e)
        {
            lbl_error.Text = string.Empty;
            txt_cliente_pesquisar.Text = string.Empty;
            txt_cliente_pesquisar.Focus();

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            {
                editButtonColumn.Name = "edit_column";
                editButtonColumn.HeaderText = "Editar";
                editButtonColumn.Text = "Editar";
                editButtonColumn.UseColumnTextForButtonValue = true;
                editButtonColumn.Width = 50;
            };
            if (gv_cliente_pesquisar.Columns["edit_column"] is null)
            {
                gv_cliente_pesquisar.Columns.Insert(0, editButtonColumn);
            }

            DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
            {
                removeButtonColumn.Name = "remove_column";
                removeButtonColumn.HeaderText = "Remover";
                removeButtonColumn.Text = "Remover";
                removeButtonColumn.UseColumnTextForButtonValue = true;
                removeButtonColumn.Width = 60;
            };
            if (gv_cliente_pesquisar.Columns["remove_column"] is null)
            {
                gv_cliente_pesquisar.Columns.Insert(1, removeButtonColumn);
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void gv_cliente_pesquisar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0
                || !(e.ColumnIndex == gv_cliente_pesquisar.Columns["edit_column"].Index
                    || e.ColumnIndex == gv_cliente_pesquisar.Columns["remove_column"].Index)
               ) return;

            try
            {


                int ClienteId = (int)gv_cliente_pesquisar[2, e.RowIndex].Value;

                if (e.ColumnIndex == gv_cliente_pesquisar.Columns["edit_column"].Index)
                {
                    _frm_Cliente.ClienteId = ClienteId;
                    _frm_Cliente.IsNew = false;
                    _frm_Cliente.ShowDialog();
                    this.btn_clie_pesquisar_Click(sender, e);
                }
                else
                    if (e.ColumnIndex == gv_cliente_pesquisar.Columns["remove_column"].Index)
                {
                    var confirmResult = MessageBox.Show("Seguro quer excluir o Cliente??",
                                     "Confirmação excluir!!",
                                     MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.No) return;

                    lbl_error.ForeColor = Color.Black;
                    lbl_error.Text = "Gravando dados ...";

                    var cmdRemoveCliente = new RemoveClienteCommand(
                            ClienteId: ClienteId
                        );
                    var cliente = await _mediator.Send(cmdRemoveCliente);
                    this.btn_clie_pesquisar_Click(sender, e);

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

        private void btn_clie_novo_Click(object sender, EventArgs e)
        {
            _frm_Cliente.ClienteId = 0;
            _frm_Cliente.IsNew = true;
            _frm_Cliente.ShowDialog();
            this.btn_clie_pesquisar_Click(sender, e);
        }
    }
}
