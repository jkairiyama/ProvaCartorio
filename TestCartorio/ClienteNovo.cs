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

namespace TestCartorio
{
    public partial class frm_ClienteNewUpdate : Form
    {
        private readonly ISender _mediator;
        private bool _isNewCliente = true;
        private int _clienteId;
        public frm_ClienteNewUpdate(ISender mediator)
        {
            InitializeComponent();
            _mediator = mediator;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void ClienteNovo_Load(object sender, EventArgs e)
        {
            lbl_error.Text = "";
            clie_nome.Focus();
            if (IsNew)
            {
                clie_nome.Text = string.Empty;
                clie_endereco.Text = string.Empty;
                clie_telefone.Text = string.Empty;
                clie_email.Text = string.Empty;
            }
            else
            {
                var clieQuery = new GetClienteByIdQuery(ClienteId: this.ClienteId);
                var cli = await _mediator.Send(clieQuery);

                if (cli != null) 
                {
                    clie_nome.Text = cli.Nome ;
                    clie_endereco.Text = cli.Endereco;
                    clie_telefone.Text = cli.Telefone;
                    clie_email.Text = cli.Email;
                }

            }
        }

        private void btn_clie_sair_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void btn_clie_gravar_Click(object sender, EventArgs e)
        {
            lbl_error.ForeColor = Color.Black;
            lbl_error.Text = "Gravando dados ...";
            try
            {
                if (IsNew)
                {
                    var cmdNewCliente = new CreateClienteCommand(
                        Nome: clie_nome.Text,
                        Endereco: clie_endereco.Text,
                        Telefone: clie_telefone.Text,
                        Email: clie_email.Text);
                        var cliente = await _mediator.Send(cmdNewCliente);
                }
                else
                {
                    var cmdEditCliente = new UpdateClienteCommand( 
                            ClienteId: this.ClienteId,
                            Nome: clie_nome.Text,
                            Endereco: clie_endereco.Text,
                            Telefone: clie_telefone.Text,
                            Email: clie_email.Text
                        );
                    var cliente = await _mediator.Send(cmdEditCliente);
                }

                lbl_error.Text = "Dados gravados corretamente.";
                await Task.Delay(500);
                this.Hide();

            } catch (Exception ex)
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = ex.Message;
            }
        }

        public bool IsNew
        {
            get { return _isNewCliente; }
            set { _isNewCliente = value; }
        }

        public int ClienteId
        {
            get { return _clienteId; }
            set { _clienteId = value; }
        }
    }
}
