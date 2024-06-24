using Domain.Data.Clientes;
using Domain.Data.Produtos;
using Domain.Data.Vendas;
using Domain.Logic.Clientes;
using Domain.Logic.Produtos;
using Domain.Logic.Vendas;
using MediatR;
using AppCartorio.Clientes;
using AppCartorio.Produtos;
using MapsterMapper;

//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestCartorio
{
    public partial class Form1 : Form
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IVendaRepository _vendaRepository;
        private readonly ISender _mediator;
        public Form1(
            IClienteRepository clienteRepository,
            IProdutoRepository produtoRepository,
            IVendaRepository vendaRepository,
            ISender mediator)
        {
            InitializeComponent();
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _vendaRepository = vendaRepository;
            _mediator = mediator;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var cli = new Cliente(nome: "Jorge", endereco : "Rua Joao Simoni 116", telefone : "11 99369 528", email : "jk@gmail.com" );
            //New cliente
            var cli = new Cliente(
                nome: "tia Jasmine",
                endereco: "Silva 130",
                telefone: "11 99369 888",
                email: "fridita@gmail.com"
            );

            var c = _clienteRepository.Create(cli);
            _clienteRepository.Save();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //Update cliente
            var cli = await _clienteRepository.Get(101);
            cli
                .SetNome("Cesar Milei")
                .SetEndereco("balcarce 50")
                .SetTelefone("11 9911 111")
                .SetEmail("cm@gmail.com");

            _clienteRepository.Update(cli);
            _clienteRepository.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //New Produto
            var prod = new Produto(
                nome: "Tenaza",
                descricao: "Tenaza comun larga",
                estoque: 15,
                preco: 40.00M

            );

            _produtoRepository.Create(prod);
            _produtoRepository.Save();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            //New venda
            int produtoId = 1;
            int clienteId = 2;
            var prod = await _produtoRepository.Get(produtoId);

            if (prod is null)
            {
                return;
            }
            var v = await _vendaRepository.Create(clienteId, DateTime.UtcNow);
            v.AddItem(produtoId: 2, qnty: 32, preco: 0.16M);
            v.AddItem(produtoId: 1, qnty: 15, preco: 0.20M);

            _vendaRepository.Save();
        }

        private async void button5_Click(object sender, EventArgs e)
        {

            int vendaId = 13;
            var v = await _vendaRepository.Get(vendaId);

            v?.AddItem(3, 1, 34M);
            _clienteRepository.Save();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var c = new CreateClienteCommand(Nome: "Lionel Messi", Endereco: "Blvd Sant Martin, 12", Telefone: "1 13254 789", Email: "goat@2022.com");

            var cli = await _mediator.Send(c);

            if (cli is not null)
            {
                label1.Text = cli.Nome;
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            var r = new RemoveClienteCommand(ClienteId: 2);

            await _mediator.Send(r);
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            var c = new GetClienteByNomeQuery(Nome: "Frid");

            var c_list = await _mediator.Send(c);

            dataGridView1.DataSource = c_list;

        }

        private async void button9_Click(object sender, EventArgs e)
        {
            var p = new CreateProdutoCommand(Nome: "Alicate", Descricao: "Tramontina Medium", Preco: 35.0M, Estoque: 8);

            var prod = await _mediator.Send(p);

            label1.Text = prod?.Nome ?? "Alicate";

        }
    }
}
