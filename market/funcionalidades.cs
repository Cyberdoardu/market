using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market
{
    internal class funcionalidades
    {

        public static class Inicializador
        {
            private static string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\market";
            private static string[] Files = { "estoque.csv", "clientes.csv", "funcionarios.csv", "produtos.csv", "vendas.csv" };

            public static void Iniciar()
            {
                // Verificar se a pasta existe
                if (!Directory.Exists(AppDataPath))
                {
                    Directory.CreateDirectory(AppDataPath);
                }

                // Verificar se os arquivos existem
                foreach (var file in Files)
                {
                    var filePath = Path.Combine(AppDataPath, file);
                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath).Close();
                        PreencherDadosIniciais(filePath);
                    }
                }
            }

            private static void PreencherDadosIniciais(string filePath)
            {
                var sb = new StringBuilder();
                var nomesFuncionarios = new string[] { "Roberto", "Clara", "Eduardo", "Gisele", "Fábio", "Camila", "Ricardo", "Carolina", "Marcos", "Isabela" };
                var nomesClientes = new string[] { "João", "Maria", "Pedro", "Ana", "Luiz", "Fernanda", "Carlos", "Juliana", "Felipe", "Amanda" };



                switch (Path.GetFileName(filePath))
                {
                    case "estoque.csv":
                        sb.AppendLine("id,produto,quantidade,validade");
                        for (int i = 1; i <= 10; i++)
                        {
                            sb.AppendLine($"{i},Produto {i},{100 + i},{DateTime.Now.AddDays(30 * i).ToShortDateString()}");
                        }
                        break;
                    case "clientes.csv":
                        sb.AppendLine("id,nome,data de nascimento,pontos,quantidade de compras");
                        for (int i = 0; i < nomesClientes.Length; i++)
                        {
                            sb.AppendLine($"{i + 1},{nomesClientes[i]},{new DateTime(1980 + i, 1, 1).ToShortDateString()},{i * 100},{i * 5}");
                        }
                        break;
                    case "funcionarios.csv":
                        sb.AppendLine("id,nome,data de nascimento,vendas");
                        for (int i = 0; i < nomesFuncionarios.Length; i++)
                        {
                            sb.AppendLine($"{i + 1},{nomesFuncionarios[i]},{new DateTime(1980 + i, 1, 1).ToShortDateString()},{i * 1000}");
                        }
                        break;
                    case "produtos.csv":
                        sb.AppendLine("id,nome,preço,marca,categoria,quantidade");
                        var nomesProdutos = new string[] { "Arroz", "Feijão", "Macarrão", "Azeite", "Café", "Chá", "Açúcar", "Sal", "Leite", "Queijo" };
                        for (int i = 0; i < nomesProdutos.Length; i++)
                        {
                            sb.AppendLine($"{i + 1},{nomesProdutos[i]},{i * 1.50 + 1.50},Marca {i + 1},Categoria {i % 3 + 1},{i * 10 + 10}");
                        }
                        break;
                    case "vendas.csv":
                        sb.AppendLine("id,id estoque,quantidade,funcionario,cliente");
                        for (int i = 1; i <= 10; i++)
                        {
                            sb.AppendLine($"{i},{i},1,{nomesFuncionarios[i % nomesFuncionarios.Length]},{nomesClientes[i % nomesClientes.Length]}");
                        }
                        break;
                }

                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
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
