using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using market;

namespace market
{
    public class funcionalidades
    {
        public Form1 mainForm;

        public funcionalidades(Form1 form)
        {
            this.mainForm = form;
            Inicializador inicializador = new Inicializador(form);
            inicializador.LerArquivo();
        }


        public class Inicializador
        {
            private Form1 mainForm;

            public Inicializador(Form1 form)
            {
                this.mainForm = form;

                form.funcionarioRank2.Text = "Testei";
            }

            public void LerArquivo()
            {
                // criação do semáforo para controle de concorrência
                Semaphore semaforo = new Semaphore(1, 1);

                // variáveis para localização do arquivo
                string pastaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string pastaMarket = Path.Combine(pastaAppData, "market");
                string filePath = Path.Combine(pastaMarket, "dados.xlsx");

                try
                {
                    // requisita controle do semáforo
                    semaforo.WaitOne();

                    if (!File.Exists(filePath))
                    {
                        throw new FileNotFoundException("O arquivo dados.xlsx não foi encontrado.");
                    }

                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    using (var package = new ExcelPackage(new FileInfo(filePath)))
                    {
                        ExcelWorksheet funcionariosPlanilha = package.Workbook.Worksheets["Funcionarios"];

                        var funcionarios = funcionariosPlanilha.Cells[2, 2, 11, 2].ToList();

                        // Suponha que esses sejam os labels no seu Windows Forms:
                        var labels = new List<Label> {
                            mainForm.funcionarioRank1,
                            mainForm.funcionarioRank2,
                            mainForm.funcionarioRank3,
                            mainForm.funcionarioRank4,
                            mainForm.funcionarioRank5,
                            mainForm.funcionarioRank6,
                            mainForm.funcionarioRank7,
                            mainForm.funcionarioRank8,
                            mainForm.funcionarioRank9,
                            mainForm.funcionarioRank10
                        };

                        // Resto do código
                        for (int i = 0; i < funcionarios.Count; i++)
                        {
                            // Certifique-se de que há um rótulo correspondente para cada funcionário
                            if (i < labels.Count)
                            {
                                labels[i].Text = (i + 1) + "° - " + funcionarios[i].Value.ToString();
                            }
                        }
                    }
                }
                finally
                {
                    // libera o semáforo
                    semaforo.Release();
                }

            }


            public static void VerificarPastaEArquivos()
            {
                string pastaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string pastaMarket = Path.Combine(pastaAppData, "market");
                string filePath = Path.Combine(pastaMarket, "dados.xlsx");

                Directory.CreateDirectory(pastaMarket);

                if (!File.Exists(filePath))
                {
                    CriarArquivoExcel(filePath);
                }
            }

            private static void CriarArquivoExcel(string filePath)
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    PreencherDadosIniciais(package);

                    package.Save();
                }
            }

            private static void PreencherDadosIniciais(ExcelPackage package)
            {
                var nomesFuncionarios = new string[] { "Roberto", "Clara", "Eduardo", "Gisele", "Fábio", "Camila", "Ricardo", "Carolina", "Marcos", "Isabela" };
                var nomesClientes = new string[] { "João", "Maria", "Pedro", "Ana", "Luiz", "Fernanda", "Carlos", "Juliana", "Felipe", "Amanda" };
                var nomesProdutos = new string[] { "Arroz", "Feijão", "Macarrão", "Azeite", "Café", "Chá", "Açúcar", "Sal", "Leite", "Queijo" };

                var estoquePlanilha = package.Workbook.Worksheets.Add("Estoque");
                estoquePlanilha.Cells["A1:D1"].LoadFromArrays(new List<object[]>() {
            new object[] { "id", "produto", "quantidade", "validade" }
        });

                for (int i = 1; i <= 10; i++)
                {
                    estoquePlanilha.Cells[i + 1, 1].Value = i;
                    estoquePlanilha.Cells[i + 1, 2].Value = $"Produto {i}";
                    estoquePlanilha.Cells[i + 1, 3].Value = 100 + i;
                    estoquePlanilha.Cells[i + 1, 4].Value = DateTime.Now.AddDays(30 * i);
                }

                var clientesPlanilha = package.Workbook.Worksheets.Add("Clientes");
                clientesPlanilha.Cells["A1:E1"].LoadFromArrays(new List<object[]>() {
            new object[] { "id", "nome", "data de nascimento", "pontos", "quantidade de compras" }
        });

                for (int i = 1; i <= 10; i++)
                {
                    clientesPlanilha.Cells[i + 1, 1].Value = i;
                    clientesPlanilha.Cells[i + 1, 2].Value = nomesClientes[i - 1];
                    clientesPlanilha.Cells[i + 1, 3].Value = new DateTime(1980 + i, 1, 1);
                    clientesPlanilha.Cells[i + 1, 4].Value = i * 100;
                    clientesPlanilha.Cells[i + 1, 5].Value = i * 5;
                }

                var funcionariosPlanilha = package.Workbook.Worksheets.Add("Funcionarios");
                funcionariosPlanilha.Cells["A1:D1"].LoadFromArrays(new List<object[]>() {
            new object[] { "id", "nome", "data de nascimento", "vendas" }
        });

                for (int i = 1; i <= 10; i++)
                {
                    funcionariosPlanilha.Cells[i + 1, 1].Value = i;
                    funcionariosPlanilha.Cells[i + 1, 2].Value = nomesFuncionarios[i - 1];
                    funcionariosPlanilha.Cells[i + 1, 3].Value = new DateTime(1980 + i, 1, 1);
                    funcionariosPlanilha.Cells[i + 1, 4].Value = i * 1000;
                }

                var produtosPlanilha = package.Workbook.Worksheets.Add("Produtos");
                produtosPlanilha.Cells["A1:F1"].LoadFromArrays(new List<object[]>() {
            new object[] { "id", "nome", "preço", "marca", "categoria", "quantidade" }
        });

                for (int i = 1; i <= 10; i++)
                {
                    produtosPlanilha.Cells[i + 1, 1].Value = i;
                    produtosPlanilha.Cells[i + 1, 2].Value = nomesProdutos[i - 1];
                    produtosPlanilha.Cells[i + 1, 3].Value = i * 1.50 + 1.50;
                    produtosPlanilha.Cells[i + 1, 4].Value = $"Marca {i}";
                    produtosPlanilha.Cells[i + 1, 5].Value = $"Categoria {i % 3 + 1}";
                    produtosPlanilha.Cells[i + 1, 6].Value = i * 10 + 10;
                }

                var vendasPlanilha = package.Workbook.Worksheets.Add("Vendas");
                vendasPlanilha.Cells["A1:E1"].LoadFromArrays(new List<object[]>() {
            new object[] { "id", "id estoque", "quantidade", "funcionario", "cliente" }
        });

                for (int i = 1; i <= 10; i++)
                {
                    vendasPlanilha.Cells[i + 1, 1].Value = i;
                    vendasPlanilha.Cells[i + 1, 2].Value = i;
                    vendasPlanilha.Cells[i + 1, 3].Value = 1;
                    vendasPlanilha.Cells[i + 1, 4].Value = nomesFuncionarios[i % nomesFuncionarios.Length];
                    vendasPlanilha.Cells[i + 1, 5].Value = nomesClientes[i % nomesClientes.Length];
                }

                // Adicionando fórmulas
                estoquePlanilha.Cells["E2"].Formula = "SUM(C2:C11)"; // Total do estoque
                clientesPlanilha.Cells["F2"].Formula = "AVERAGE(D2:D11)"; // Média de pontos dos clientes
                funcionariosPlanilha.Cells["E2"].Formula = "MAX(D2:D11)"; // Maior valor em vendas
                produtosPlanilha.Cells["G2"].Formula = "MIN(C2:C11)"; // Menor preço de produto
                vendasPlanilha.Cells["F2"].Formula = "COUNTA(E2:E11)"; // Número total de clientes
            }


        }


        public class Estoque
        {
            private List<Produto> produtos;

            public Estoque()
            {
                produtos = new List<Produto>();
            }

            public void AdicionarProduto(Produto produto)
            {
                produtos.Add(produto);
            }

            public void RemoverProduto(Produto produto)
            {
                produtos.Remove(produto);
            }

            // ... Outras funcionalidades do estoque
        }

        public class Produto
        {
            public string Nome { get; set; }
            public double Preco { get; set; }
            public int Quantidade { get; set; }

            public Produto(string nome, double preco, int quantidade)
            {
                Nome = nome;
                Preco = preco;
                Quantidade = quantidade;
            }

            // ... Outras funcionalidades do produto
        }

        // ... As classes ProdutoPerecivel, ProdutoNaoPerecivel e Cliente


    }
}
