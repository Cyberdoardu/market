using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void SalvarProduto(Produto produto)
        {
            string pastaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pastaMarket = Path.Combine(pastaAppData, "market");
            string filePath = Path.Combine(pastaMarket, "dados.xlsx");

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet planilha = package.Workbook.Worksheets["Produtos"];

                // Determina a primeira linha vazia
                int linha = planilha.Dimension?.Rows + 1 ?? 1;

                // Adiciona os dados
                planilha.Cells[linha, 1].Value = produto.Nome;
                planilha.Cells[linha, 2].Value = produto.Preco;
                planilha.Cells[linha, 3].Value = produto.Quantidade;

                package.Save(); // Salva as alterações no arquivo
            }
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

            // Salva o produto na planilha
            SalvarProduto(novoProduto);

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
