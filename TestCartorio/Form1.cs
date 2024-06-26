using Domain.Data.Clientes;
using Domain.Data.Produtos;
using Domain.Data.Vendas;
using Domain.Repositories.Clientes;
using Domain.Repositories.Produtos;
using Domain.Repositories.Vendas;
using MediatR;
using AppCartorio.Clientes;
using AppCartorio.Produtos;
using MapsterMapper;
using AppCartorio.Vendas;

//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestCartorio
{
    public partial class Form1 : Form
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IVendaRepository _vendaRepository;
        private readonly ISender _mediator;
        private readonly frm_ClienteNewUpdate _frm_Cliente;
        private readonly frm_clientes _frm_clientes;
        private readonly frmProdutoNovo _frm_produtoNewUpdate;
        private readonly frm_Produtos _frm_produtos;
        private readonly frm_VendaNova _frm_VendaNova;
        private readonly frm_Vendas _frm_Vendas;

        public Form1(
            IClienteRepository clienteRepository,
            IProdutoRepository produtoRepository,
            IVendaRepository vendaRepository,
            ISender mediator,
            frm_ClienteNewUpdate frm_Cliente,
            frm_clientes frm_clientes,
            frmProdutoNovo frm_produtoNewUpdate,
            frm_Produtos frm_produtos,
            frm_VendaNova frm_VendaNova,
            frm_Vendas frm_Vendas)
        {
            InitializeComponent();
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _vendaRepository = vendaRepository;
            _mediator = mediator;
            _frm_Cliente = frm_Cliente;
            _frm_clientes = frm_clientes;
            _frm_produtoNewUpdate = frm_produtoNewUpdate;
            _frm_produtos = frm_produtos;
            _frm_VendaNova = frm_VendaNova;
            _frm_Vendas = frm_Vendas;
        }




        private void novoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_ClienteNewUpdate fmrCli = new frm_ClienteNewUpdate
            //{
            //    isNew = true
            //};
            _frm_Cliente.IsNew = true;
            _frm_Cliente.ShowDialog();
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _frm_clientes.ShowDialog();
        }

        private void novoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _frm_produtoNewUpdate.IsNew = true;
            _frm_produtoNewUpdate.ShowDialog();
        }

        private void listadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _frm_produtos.ShowDialog();
        }

        private void novaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _frm_VendaNova.ShowDialog();
        }

        private void listadoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _frm_Vendas.ShowDialog();
        }
    }
}
