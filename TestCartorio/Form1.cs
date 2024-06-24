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

        private async void button1_Click(object sender, EventArgs e)
        {
            //Update Venda, add item
            var vendQuery = new GetVendaByIdQuery(VendaId: 14);
            var venda = await _mediator.Send(vendQuery);

            //Modifica a venda e adiciona item novo
            var vendCmmd = new UpdateVendaCommand(
                VendaId: venda.VendaId,
                ClienteId: venda.ClienteId,
                Data: venda.Data,
                Items: [
                    new UpdateVendaItemCommand(
                            VendaItemId : default,
                            VendaId : venda.VendaId,
                            ProdutoId: 1,
                            Preco: 0.15M,
                            Quantidade : 1
                        )]
            );

            //Adiciona os items velhos
            foreach (var itm in venda.Items)
            {
                if (itm.VendaItemId != 20)
                {
                    vendCmmd.Items.Add(
                        new UpdateVendaItemCommand(
                                VendaItemId: itm.VendaItemId,
                                VendaId: itm.VendaId,
                                ProdutoId: itm.ProdutoId,
                                Preco: itm.Preco + 100M,
                                Quantidade: itm.Quantidade
                        )
                    );
                }
            }

            var v = _mediator.Send(vendCmmd);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //Update cliente
            var cli = await _clienteRepository.Get(101);
            if (cli is not null)
            {
                cli
                .SetNome("Javier Milei")
                .SetEndereco("balcarce 50")
                .SetTelefone("11 9911 111")
                .SetEmail("cm@gmail.com");

                _clienteRepository.Update(cli);
                await _clienteRepository.Save();
            }
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
            var newVenda = new CreateVendaCommand(
                ClienteId: 103,
                Data: DateTime.UtcNow,
                Items: new List<CreateVendaItemCommand>()
                {
                    new CreateVendaItemCommand(
                        ProdutoId: 5,
                        Preco: 35,
                        Quantidade:1
                    ),
                    new CreateVendaItemCommand(
                        ProdutoId: 3,
                        Preco: 34,
                        Quantidade:1
                    )
                }
            );

            var v = await _mediator.Send(newVenda);

        }

        private async void button5_Click(object sender, EventArgs e)
        {

            int vendaId = 13;
            var v = await _vendaRepository.Get(vendaId);

            v?.AddItem(3, 1, 34M);
            await _clienteRepository.Save();
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
