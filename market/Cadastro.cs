using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market
{
    public partial class Cadastro : UserControl
    {
        private static Semaphore semaforo = new Semaphore(1, 1);

        private DataTable dtClientes;
        private DataTable dtFuncionarios;

        public Cadastro()
        {
            InitializeComponent();

            dtClientes = new DataTable();
            dtFuncionarios = new DataTable();

            CarregarDados();
        }

        private void CarregarDados()
        {
            dtClientes.Clear();
            dtFuncionarios.Clear();

            Thread t1 = new Thread(() => CarregarPlanilha("Clientes", dtClientes));
            Thread t2 = new Thread(() => CarregarPlanilha("Funcionarios", dtFuncionarios));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            dgvClientes.DataSource = dtClientes;
            dgvFuncionarios.DataSource = dtFuncionarios;
        }

        private void CarregarPlanilha(string nomePlanilha, DataTable dt)
        {
            semaforo.WaitOne();

            string pastaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pastaMarket = Path.Combine(pastaAppData, "market");
            string filePath = Path.Combine(pastaMarket, "dados.xlsx");

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new Exception("O arquivo dados.xlsx não foi encontrado.");
                }

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet planilha = package.Workbook.Worksheets[nomePlanilha];

                    dt.Clear();
                    dt.Columns.Clear();

                    // Preencher o DataTable
                    for (int i = planilha.Dimension.Start.Row; i <= planilha.Dimension.End.Row; i++)
                    {
                        DataRow row = dt.NewRow();
                        for (int j = planilha.Dimension.Start.Column; j <= planilha.Dimension.End.Column; j++)
                        {
                            var cell = planilha.Cells[i, j];

                            if (cell.Value != null)
                            {
                                if (i == planilha.Dimension.Start.Row)
                                {
                                    dt.Columns.Add(cell.Value.ToString());
                                }
                                else if (j <= dt.Columns.Count) // Verificando se a coluna existe no DataRow
                                {
                                    row[j - 1] = cell.Value;
                                }
                            }

                        }

                        if (i != planilha.Dimension.Start.Row)
                        {
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
            finally
            {
                semaforo.Release();
            }
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(() => SalvarPlanilha("Clientes", dtClientes));
            Thread t2 = new Thread(() => SalvarPlanilha("Funcionarios", dtFuncionarios));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            MessageBox.Show("Dados salvos com sucesso!");
        }

        private void SalvarPlanilha(string nomePlanilha, DataTable dt)
        {
            semaforo.WaitOne();

            string pastaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pastaMarket = Path.Combine(pastaAppData, "market");
            string filePath = Path.Combine(pastaMarket, "dados.xlsx");

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new Exception("O arquivo dados.xlsx não foi encontrado.");
                }

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet planilha = package.Workbook.Worksheets[nomePlanilha];

                    // Limpar a planilha
                    planilha.Cells.Clear();

                    // Preencher a planilha com os dados do DataTable
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (i == 0)
                            {
                                planilha.Cells[i + 1, j + 1].Value = dt.Columns[j].ColumnName;
                            }
                            planilha.Cells[i + 2, j + 1].Value = dt.Rows[i][j];
                        }
                    }

                    package.Save();
                }
            }
            finally
            {
                semaforo.Release();
            }
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            DateTime dataNascimento = dtDataNascimento.Value;

            Pessoa pessoa = null;
            if (rdbCliente.Checked)
            {
                pessoa = new Cliente(nome, dataNascimento, 0, this);
            }
            else if (rdbFuncionario.Checked)
            {
                pessoa = new Funcionario(nome, dataNascimento, 0, "ativo", this);
            }

            if (pessoa == null)
            {
                throw new Exception("Nenhuma opção de cadastro selecionada");
            }

            Thread t = new Thread(pessoa.Cadastrar);
            t.Start();
        }



        public abstract class Pessoa
        {
            public string Nome { get; set; }
            public DateTime DataNascimento { get; set; }
            protected Cadastro Cadastro { get; set; }

            protected Pessoa(string nome, DateTime dataNascimento, Cadastro cadastro)
            {
                Nome = nome;
                DataNascimento = dataNascimento;
                Cadastro = cadastro;
            }

            public abstract void Cadastrar();
        }

        public class Cliente : Pessoa
        {
            public int Pontos { get; set; }

            public Cliente(string nome, DateTime dataNascimento, int pontos, Cadastro cadastro)
                : base(nome, dataNascimento, cadastro)
            {
                Pontos = pontos;
            }

            public override void Cadastrar()
            {
                Cadastro.AdicionarNaPlanilha("Clientes", new object[] { Nome, DataNascimento, Pontos, 0 });
            }
        }

        public class Funcionario : Pessoa
        {
            public int Vendas { get; set; }
            public string Estado { get; set; }

            public Funcionario(string nome, DateTime dataNascimento, int vendas, string estado, Cadastro cadastro)
                : base(nome, dataNascimento, cadastro)
            {
                Vendas = vendas;
                Estado = estado;
            }

            public override void Cadastrar()
            {
                Cadastro.AdicionarNaPlanilha("Funcionarios", new object[] { Nome, DataNascimento, Vendas, Estado });
            }
        }


        private void AdicionarNaPlanilha(string nomePlanilha, object[] dados)
        {
            string pastaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pastaMarket = Path.Combine(pastaAppData, "market");
            string filePath = Path.Combine(pastaMarket, "dados.xlsx");

            try
            {
                // Requisitar controle do semáforo
                semaforo.WaitOne();

                if (!File.Exists(filePath))
                {
                    throw new Exception("O arquivo dados.xlsx não foi encontrado.");
                }

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet planilha = package.Workbook.Worksheets[nomePlanilha];

                    // Encontrar a próxima linha vazia
                    int row = planilha.Dimension.End.Row + 1;

                    // Definir o ID para a próxima linha
                    planilha.Cells[row, 1].Value = row - 1;  // Supondo que a primeira linha seja para cabeçalho

                    // Gravar os outros dados na planilha
                    for (int i = 0; i < dados.Length; i++)
                    {
                        planilha.Cells[row, i + 2].Value = dados[i];
                    }

                    // Salvar as alterações
                    package.Save();
                }
            }
            finally
            {
                // Libera o semáforo
                semaforo.Release();
            }
        }
    }
}
