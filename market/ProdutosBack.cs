using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market
{
    public partial class MarketForm : Form
    {
        private List<Produto> produtos = new List<Produto>();

        private DataGridView dataGridView1;
        private TextBox txtNome;
        private TextBox txtPreco;
        private TextBox txtQuantidade;
        private Button btnCadastrar;

        public MarketForm()
        {
            InitializeComponent();
            InicializarComponentes();
            AtualizarDataGridView();
        }

        private void InicializarComponentes()
        {
            // Inicializar e configurar os controles do formulário aqui

            dataGridView1 = new DataGridView();
            // Configurações do DataGridView

            txtNome = new TextBox();
            // Configurações do TextBox do nome

            txtPreco = new TextBox();
            // Configurações do TextBox do preço

            txtQuantidade = new TextBox();
            // Configurações do TextBox da quantidade

            btnCadastrar = new Button();
            // Configurações do botão Cadastrar

            // Adicione os controles ao formulário
            Controls.Add(dataGridView1);
            Controls.Add(txtNome);
            Controls.Add(txtPreco);
            Controls.Add(txtQuantidade);
            Controls.Add(btnCadastrar);

            

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

            // por fim,ele Limpa campos do formulário
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
