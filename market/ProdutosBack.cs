using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market
{
    public class ProdutosBack
    {
        public Produtos produtoForm;

        public class InicializadorProdutos
        {
            private Produtos produtosForm;

            public InicializadorProdutos(Produtos produtos)
            {
                this.produtosForm = produtos;
            }

            public static void start()
            {

                

            }

        }



            private void AtualizarDataGridView()
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = produtos;
            }

        public class Produto
        {
            public string Nome { get; set; }
            public decimal Preco { get; set; }
            public int Quantidade { get; set; }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //aqui recupera os dados do formulario
            string nome = txtNome.Text;
            decimal preco = decimal.Parse(txtPreco.Text);
            int quantidade = int.Parse(txtQuantidade.Text);

            //cria um novo objeto Produto
            Produto novoProduto = new Produto
            {
                Nome = nome,
                Preco = preco,
                Quantidade = quantidade
            };

            //adiciona o novo produto a lista
            produtos.Add(novoProduto);

            // Atualize o DataGridView
            AtualizarDataGridView();

            // limpa campo de formulario
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            AtualizarDataGridView();
        }

    }
}
