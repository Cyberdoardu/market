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
using System.Windows.Forms.DataVisualization.Charting;

namespace market
{
    public class funcionalidades
    {
        public Form1 mainForm;



        public class Inicializador
        {
            private Form1 mainForm;

            public Inicializador(Form1 form)
            {
                this.mainForm = form;

            }

            public class FuncionarioException : Exception
            {
                public Label TargetLabel { get; private set; }

                public FuncionarioException(string message, Label targetLabel) : base(message)
                {
                    this.TargetLabel = targetLabel;
                }
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
                    // requisitar controle do semáforo
                    semaforo.WaitOne();

                    if (!File.Exists(filePath))
                    {
                        throw new FuncionarioException("O arquivo dados.xlsx não foi encontrado.", mainForm.funcionarioRank1);
                    }

                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    using (var package = new ExcelPackage(new FileInfo(filePath)))
                    {
                        ExcelWorksheet funcionariosPlanilha = package.Workbook.Worksheets["Funcionarios"];
                        funcionariosPlanilha.Calculate();

                        var funcionariosCells = funcionariosPlanilha.Cells[2, 2, 11, 2].ToList();
                        var funcionariosVendasCells = funcionariosPlanilha.Cells[2, 4, 11, 4].ToList();

                        // labels do Windows Forms:
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

                        // Criação do dicionário para associar os nomes dos funcionários às suas vendas
                        Dictionary<string, int> dicFuncionarios = new Dictionary<string, int>();
                        for (int i = 0; i < funcionariosCells.Count; i++)
                        {
                            try
                            {
                                dicFuncionarios.Add(funcionariosCells[i].Text, int.Parse(funcionariosVendasCells[i].Text));
                            }
                            catch (FormatException ex)
                            {
                                labels[i].Text = "Erro ao converter dados para int";
                            }
                        }

                        // Ordenação do dicionário com base nos valores (número de vendas)
                        var list = dicFuncionarios.ToList();
                        list.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));


                        // Criar listas para armazenar os dados dos funcionários e das vendas
                        List<string> funcionarios = new List<string>();
                        List<int> vendas = new List<int>();
                        List<int> indexes = new List<int>();
                        // Loop para preencher as listas com os dados da planilha
                        for (int i = 0; i < funcionariosCells.Count; i++)
                        {
                            // Tentar converter o valor das vendas para int
                            
                            if (!int.TryParse(funcionariosVendasCells[i].Value.ToString(), out int vendasFuncionario))
                            {
                                // Se a conversão falhar, lançar uma FuncionarioException
                                //throw new FuncionarioException($"Unable to parse '{funcionariosVendasCells[i].Value}'", labels[i]);

                                labels[i].Text = "Erro ao converter dados para int";
                                indexes.Add(i);
                            }

                            // Se a conversão for bem-sucedida, adicionar o nome do funcionário e o valor das vendas às listas
                            funcionarios.Add(funcionariosCells[i].Text);
                            vendas.Add(vendasFuncionario);

                            // Adicionar o nome dos funcionários aos labels
                            if (i < labels.Count)
                            {
                                if (indexes.Contains(i))
                                {
                                    labels[i].Text = (i + 1) + "° - Erro com os valores";
                                }
                                else
                                {
                                    int index = list.FindIndex(pair => pair.Key == funcionariosCells[i].Text);
                                    if (index != -1)
                                    {
                                        labels[i].Text = (i + 1) + "° - " + list[index].Key;
                                    }
                                }
                            }

                        }

                        // Adicionar os dados ao gráfico
                        // Certifique-se de que a série de dados no gráfico está vazia antes de adicionar novos pontos de dados
                        var chartArea = mainForm.EstoqueProdutos.ChartAreas[0];

                        // Forçar a exibição de todas as labels no eixo X
                        chartArea.AxisX.LabelStyle.Angle = -90;
                        chartArea.AxisX.Interval = 1;

                        var series = mainForm.EstoqueProdutos.Series[0];
                        series.Points.Clear();
                        series.Points.DataBindXY(funcionarios, vendas);



                        // Define a distância entre as marcas de escala e garante que um rótulo seja exibido para cada ponto de dados
                        mainForm.EstoqueProdutos.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
                        mainForm.EstoqueProdutos.ChartAreas[0].AxisY.Interval = 1;



                        // Deitar labels das barras
                        mainForm.EstoqueProdutos.ChartAreas[0].AxisX.LabelStyle.Angle = -45;



                        // definir o número de pontos de dados a serem exibidos de uma vez
                        int viewSize = 10;
                        mainForm.EstoqueProdutos.ChartAreas[0].AxisX.ScaleView.Size = viewSize;

                        // definir o tamanho mínimo da exibição para evitar o zoom
                        mainForm.EstoqueProdutos.ChartAreas[0].AxisX.ScaleView.MinSize = viewSize;

                    }
                } finally
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
            new object[] { "id transação", "id do produto", "nome produto", "quantidade", "validade" }
        });

                for (int i = 1; i <= 10; i++)
                {
                    estoquePlanilha.Cells[i + 1, 1].Value = i; //id transação
                    estoquePlanilha.Cells[i + 1, 2].Value = i*2; // id do produto
                    estoquePlanilha.Cells["C" + (i + 1).ToString()].Formula = "VLOOKUP(B" + (i + 1).ToString() + ",Produtos!A:B,2,FALSE)"; // Nome do produto
                    estoquePlanilha.Cells[i + 1, 4].Value = 100 + i*4; // quantidade 
                    estoquePlanilha.Cells[i + 1, 5].Value = DateTime.Now.AddDays(30 * i); // validade


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
                    clientesPlanilha.Cells["E" + (i + 1).ToString()].Formula = "(SUMIF(Vendas!E:E,Clientes!A" + (i + 1).ToString() + ",Vendas!E:E))/Clientes!A" + (i + 1).ToString(); // Fórmula de quantidade de compras
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
                    funcionariosPlanilha.Cells["D" + (i + 1).ToString()].Formula = "(SUMIF(Vendas!D:D, Funcionarios!A" + (i + 1).ToString() + ", Vendas!D:D)) / Funcionarios!A" + (i + 1).ToString(); // Fórmula de vendas do funcionario
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
                    vendasPlanilha.Cells[i + 1, 4].Value = i % 3;
                    vendasPlanilha.Cells[i + 1, 5].Value = i % 4;
                }

                // Adicionando fórmulas
                //estoquePlanilha.Cells["E2"].Formula = "SUM(C2:C11)"; // Total do estoque
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


        public class ProdutoPerecivel : Produto
        {
            public DateTime DataValidade { get; set; }

            public ProdutoPerecivel(string nome, double preco, int quantidade, DateTime dataValidade) : base(nome, preco, quantidade)
            {
                DataValidade = dataValidade;
            }
        }

        public class ProdutoNaoPerecivel : Produto
        {
            public ProdutoNaoPerecivel(string nome, double preco, int quantidade) : base(nome, preco, quantidade) { }
        }


        public class Pessoa
        {
            public string Nome { get; set; }
            public DateTime Nascimento { get; set; }
            public char Genero { get; set; }

            public Pessoa(string nome, DateTime nascimento, char genero)
            {
                Nome = nome;
                Nascimento = nascimento;
                Genero = genero;
            }
        }

        public class Funcionario : Pessoa
        {
            public DateTime Admissao { get; set; }
            public bool Ativo { get; set; }
            public float Salario { get; set; }

            public Funcionario(string nome, DateTime nascimento, char genero, DateTime admissao, bool ativo, float salario) : base(nome, nascimento, genero)
            {
                Admissao = admissao;
                Ativo = ativo;
                Salario = salario;

            }
        }

        public class Cliente : Pessoa
        {
            int Pontos { get; set; }
            public Cliente(string nome, DateTime nascimento, char genero, int pontos) : base(nome, nascimento, genero) {
                Pontos = pontos;
            }
        }

        // ... As classes ProdutoPerecivel, ProdutoNaoPerecivel e Cliente


    }
}
