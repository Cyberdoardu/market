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
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace market
{
    public partial class Cadastro : UserControl
    {
        private static Semaphore semaforo = new Semaphore(1, 1);

        public Cadastro()
        {
            InitializeComponent();

           

            CarregarDados();
        }

        private void CarregarDados()
        {
            dgvClientes.DataSource = null;
            dgvFuncionarios.DataSource = null;

            Thread t1 = new Thread(() => CarregarPlanilha("Clientes", dgvClientes));
            Thread t2 = new Thread(() => CarregarPlanilha("Funcionarios", dgvFuncionarios));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

        }

        private void CarregarPlanilha(string nomePlanilha, DataGridView dt)
        {

            /* Está com problema pq o DataGrid pode terminar a construção antes do resto da UI
             * 
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

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                List<string> columns = new List<string>();
                List<List<object>> rows = new List<List<object>>();

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet planilha = package.Workbook.Worksheets[nomePlanilha];

                    // Adiciona as colunas
                    for (int i = planilha.Dimension.Start.Column; i <= planilha.Dimension.End.Column; i++)
                    {
                        var cell = planilha.Cells[1, i];
                        if (cell.Value != null)
                        {
                            columns.Add(cell.Value.ToString());
                        }
                    }

                    // Adiciona as linhas
                    for (int i = planilha.Dimension.Start.Row + 1; i <= planilha.Dimension.End.Row; i++)
                    {
                        List<object> row = new List<object>();
                        for (int j = planilha.Dimension.Start.Column; j <= planilha.Dimension.End.Column; j++)
                        {
                            var cell = planilha.Cells[i, j];
                            if (cell.Value != null)
                            {
                                row.Add(cell.Value);
                            }
                        }
                        rows.Add(row);
                    }
                }

                // Invoke the operation in the UI thread
                dt.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    dt.Columns.Clear();

                    foreach (var column in columns)
                    {
                        dt.Columns.Add(column, column);
                    }

                    foreach (var row in rows)
                    {
                        dt.Rows.Add(row.ToArray());
                    }
                });
            }
            finally
            {
                semaforo.Release();
            }

            

            */
        }




        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(() => SalvarPlanilha("Clientes", dgvClientes));
            Thread t2 = new Thread(() => SalvarPlanilha("Funcionarios", dgvFuncionarios));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            MessageBox.Show("Dados salvos com sucesso!");
        }

        private void SalvarPlanilha(string nomePlanilha, DataGridView dt)
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

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet planilha = package.Workbook.Worksheets[nomePlanilha];

                    planilha.Cells.Clear();

                    // Preencher a planilha
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (i == 0)
                            {
                                planilha.Cells[1, j + 1].Value = dt.Columns[j].Name;
                            }
                            planilha.Cells[i + 2, j + 1].Value = dt.Rows[i].Cells[j].Value;
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
            t.Join();
            CarregarDados();
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

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

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

