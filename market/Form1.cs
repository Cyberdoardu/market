using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using market;
namespace market

{
    public partial class Form1 : Form
    {
        public funcionalidades Funcionalidades { get; set; }

        public Form1()
        {
            InitializeComponent();
            funcionalidades.Inicializador inicializador = new funcionalidades.Inicializador(this);
            inicializador.LerArquivo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Cadastro_Click(object sender, EventArgs e)
        {
            this.produtos1.SendToBack();
            this.vendas1.SendToBack();
            this.cadastro1.BringToFront();
            this.estoque1.SendToBack();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void FuncionarioMes_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void Vendas_Click(object sender, EventArgs e)
        {
            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click_1(object sender, EventArgs e)
        {
            this.produtos1.SendToBack();
            this.vendas1.SendToBack();
            this.cadastro1.SendToBack();
            this.estoque1.SendToBack();
        }

        private void Produtos_Click(object sender, EventArgs e)
        {
            this.produtos1.BringToFront();
            this.vendas1.SendToBack();
            this.cadastro1.SendToBack();
            this.estoque1.SendToBack();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.produtos1.SendToBack();
        }

        private void Vendas_Click_1(object sender, EventArgs e)
        {
            this.produtos1.SendToBack();
            this.vendas1.BringToFront();
            this.cadastro1.SendToBack();
            this.estoque1.SendToBack();
        }

        private void Estoque_Click(object sender, EventArgs e)
        {
            this.produtos1.SendToBack();
            this.vendas1.SendToBack();
            this.cadastro1.SendToBack();
            this.estoque1.BringToFront();
        }
    }
}
