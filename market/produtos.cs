using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market
{
    public partial class Produtos : UserControl
    {
        private List<Produto> produtos = new List<Produto>();

        public Produtos()
        {
            InitializeComponent();
            // Associar o evento de clicar, do botão Cadastrar ao método btnCadastrar_Click
            btnCadastrar.Click += btnCadastrar_Click;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Recupera os dados do forms
            string nome = txtNome.Text;
            decimal preco;
            int quantidade;

            if (!decimal.TryParse(txtPreco.Text, out preco) || preco < 0)
            {
                MessageBox.Show("O preço digitado é inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtQuantidade.Text, out quantidade) || quantidade < 0)
            {
                MessageBox.Show("A quantidade digitada é inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cria um novo objeto Produto
            Produto novoProduto = new Produto
            {
                Nome = nome,
                Preco = preco,
                Quantidade = quantidade
            };

            // Adiciona ele ao novo produto à lista
            produtos.Add(novoProduto);

            // Atualiza o nosso DataGridView
            AtualizarDataGridView();

            // Por fim, ele limpa campos do formulário
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
        }

        private void AtualizarDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = produtos;
        }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
