using System.Windows.Forms;

namespace market
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Cadastro = new System.Windows.Forms.Button();
            this.Produtos = new System.Windows.Forms.Button();
            this.Vendas = new System.Windows.Forms.Button();
            this.Estoque = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.FuncionarioMes = new System.Windows.Forms.Label();
            this.funcionarioRank1 = new System.Windows.Forms.Label();
            this.funcionarioRank10 = new System.Windows.Forms.Label();
            this.funcionarioRank9 = new System.Windows.Forms.Label();
            this.funcionarioRank8 = new System.Windows.Forms.Label();
            this.funcionarioRank7 = new System.Windows.Forms.Label();
            this.funcionarioRank6 = new System.Windows.Forms.Label();
            this.funcionarioRank5 = new System.Windows.Forms.Label();
            this.funcionarioRank3 = new System.Windows.Forms.Label();
            this.funcionarioRank4 = new System.Windows.Forms.Label();
            this.funcionarioRank2 = new System.Windows.Forms.Label();
            this.EstoqueProdutos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.produtos1 = new market.Produtos();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EstoqueProdutos)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Cadastro);
            this.panel1.Controls.Add(this.Produtos);
            this.panel1.Controls.Add(this.Vendas);
            this.panel1.Controls.Add(this.Estoque);
            this.panel1.Location = new System.Drawing.Point(306, -36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1391, 91);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(681, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Cadastro
            // 
            this.Cadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Cadastro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cadastro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cadastro.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cadastro.Location = new System.Drawing.Point(804, 46);
            this.Cadastro.Name = "Cadastro";
            this.Cadastro.Size = new System.Drawing.Size(112, 35);
            this.Cadastro.TabIndex = 10;
            this.Cadastro.Text = "Cadastro\r\n";
            this.Cadastro.UseVisualStyleBackColor = false;
            this.Cadastro.Click += new System.EventHandler(this.Cadastro_Click);
            // 
            // Produtos
            // 
            this.Produtos.BackColor = System.Drawing.Color.Transparent;
            this.Produtos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Produtos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Produtos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Produtos.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Produtos.ForeColor = System.Drawing.Color.White;
            this.Produtos.Location = new System.Drawing.Point(327, 46);
            this.Produtos.Name = "Produtos";
            this.Produtos.Size = new System.Drawing.Size(112, 35);
            this.Produtos.TabIndex = 9;
            this.Produtos.Text = "Produtos";
            this.Produtos.UseVisualStyleBackColor = false;
            // 
            // Vendas
            // 
            this.Vendas.BackColor = System.Drawing.Color.Transparent;
            this.Vendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Vendas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Vendas.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vendas.ForeColor = System.Drawing.Color.White;
            this.Vendas.Location = new System.Drawing.Point(445, 46);
            this.Vendas.Name = "Vendas";
            this.Vendas.Size = new System.Drawing.Size(112, 35);
            this.Vendas.TabIndex = 8;
            this.Vendas.Text = "Vendas";
            this.Vendas.UseVisualStyleBackColor = false;
            // 
            // Estoque
            // 
            this.Estoque.BackColor = System.Drawing.Color.Transparent;
            this.Estoque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Estoque.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Estoque.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Estoque.ForeColor = System.Drawing.Color.White;
            this.Estoque.Location = new System.Drawing.Point(563, 46);
            this.Estoque.Name = "Estoque";
            this.Estoque.Size = new System.Drawing.Size(112, 35);
            this.Estoque.TabIndex = 7;
            this.Estoque.Text = "Estoque";
            this.Estoque.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dashboard";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Location = new System.Drawing.Point(321, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(298, 22);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(793, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 204);
            this.panel2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Informações";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Sylfaen", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(27, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 36);
            this.label3.TabIndex = 7;
            this.label3.Text = "DeEDU Market.\r\n";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            this.chart2.Cursor = System.Windows.Forms.Cursors.Cross;
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(306, 84);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.LegendText = "Vendas";
            series1.MarkerBorderColor = System.Drawing.Color.White;
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(455, 204);
            this.chart2.TabIndex = 9;
            this.chart2.Text = "chart2";
            this.chart2.Click += new System.EventHandler(this.chart2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.FuncionarioMes);
            this.panel3.Controls.Add(this.funcionarioRank1);
            this.panel3.Controls.Add(this.funcionarioRank10);
            this.panel3.Controls.Add(this.funcionarioRank9);
            this.panel3.Controls.Add(this.funcionarioRank8);
            this.panel3.Controls.Add(this.funcionarioRank7);
            this.panel3.Controls.Add(this.funcionarioRank6);
            this.panel3.Controls.Add(this.funcionarioRank5);
            this.panel3.Controls.Add(this.funcionarioRank3);
            this.panel3.Controls.Add(this.funcionarioRank4);
            this.panel3.Controls.Add(this.funcionarioRank2);
            this.panel3.Location = new System.Drawing.Point(306, 328);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(455, 450);
            this.panel3.TabIndex = 10;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint_1);
            // 
            // FuncionarioMes
            // 
            this.FuncionarioMes.AutoSize = true;
            this.FuncionarioMes.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FuncionarioMes.Location = new System.Drawing.Point(151, 26);
            this.FuncionarioMes.Name = "FuncionarioMes";
            this.FuncionarioMes.Size = new System.Drawing.Size(173, 21);
            this.FuncionarioMes.TabIndex = 11;
            this.FuncionarioMes.Text = "Funcionario do Mes";
            this.FuncionarioMes.Click += new System.EventHandler(this.FuncionarioMes_Click);
            // 
            // funcionarioRank1
            // 
            this.funcionarioRank1.AutoSize = true;
            this.funcionarioRank1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionarioRank1.Location = new System.Drawing.Point(11, 65);
            this.funcionarioRank1.Name = "funcionarioRank1";
            this.funcionarioRank1.Size = new System.Drawing.Size(62, 20);
            this.funcionarioRank1.TabIndex = 20;
            this.funcionarioRank1.Text = "label13";
            // 
            // funcionarioRank10
            // 
            this.funcionarioRank10.AutoSize = true;
            this.funcionarioRank10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionarioRank10.Location = new System.Drawing.Point(11, 384);
            this.funcionarioRank10.Name = "funcionarioRank10";
            this.funcionarioRank10.Size = new System.Drawing.Size(62, 20);
            this.funcionarioRank10.TabIndex = 19;
            this.funcionarioRank10.Text = "label12";
            // 
            // funcionarioRank9
            // 
            this.funcionarioRank9.AutoSize = true;
            this.funcionarioRank9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionarioRank9.Location = new System.Drawing.Point(11, 349);
            this.funcionarioRank9.Name = "funcionarioRank9";
            this.funcionarioRank9.Size = new System.Drawing.Size(62, 20);
            this.funcionarioRank9.TabIndex = 18;
            this.funcionarioRank9.Text = "label11";
            // 
            // funcionarioRank8
            // 
            this.funcionarioRank8.AutoSize = true;
            this.funcionarioRank8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionarioRank8.Location = new System.Drawing.Point(11, 310);
            this.funcionarioRank8.Name = "funcionarioRank8";
            this.funcionarioRank8.Size = new System.Drawing.Size(62, 20);
            this.funcionarioRank8.TabIndex = 17;
            this.funcionarioRank8.Text = "label10";
            // 
            // funcionarioRank7
            // 
            this.funcionarioRank7.AutoSize = true;
            this.funcionarioRank7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionarioRank7.Location = new System.Drawing.Point(11, 273);
            this.funcionarioRank7.Name = "funcionarioRank7";
            this.funcionarioRank7.Size = new System.Drawing.Size(53, 20);
            this.funcionarioRank7.TabIndex = 16;
            this.funcionarioRank7.Text = "label9";
            // 
            // funcionarioRank6
            // 
            this.funcionarioRank6.AutoSize = true;
            this.funcionarioRank6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionarioRank6.Location = new System.Drawing.Point(11, 239);
            this.funcionarioRank6.Name = "funcionarioRank6";
            this.funcionarioRank6.Size = new System.Drawing.Size(53, 20);
            this.funcionarioRank6.TabIndex = 15;
            this.funcionarioRank6.Text = "label8";
            // 
            // funcionarioRank5
            // 
            this.funcionarioRank5.AutoSize = true;
            this.funcionarioRank5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionarioRank5.Location = new System.Drawing.Point(11, 205);
            this.funcionarioRank5.Name = "funcionarioRank5";
            this.funcionarioRank5.Size = new System.Drawing.Size(53, 20);
            this.funcionarioRank5.TabIndex = 14;
            this.funcionarioRank5.Text = "label7";
            // 
            // funcionarioRank3
            // 
            this.funcionarioRank3.AutoSize = true;
            this.funcionarioRank3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionarioRank3.Location = new System.Drawing.Point(11, 134);
            this.funcionarioRank3.Name = "funcionarioRank3";
            this.funcionarioRank3.Size = new System.Drawing.Size(53, 20);
            this.funcionarioRank3.TabIndex = 13;
            this.funcionarioRank3.Text = "label6";
            // 
            // funcionarioRank4
            // 
            this.funcionarioRank4.AutoSize = true;
            this.funcionarioRank4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionarioRank4.Location = new System.Drawing.Point(11, 171);
            this.funcionarioRank4.Name = "funcionarioRank4";
            this.funcionarioRank4.Size = new System.Drawing.Size(53, 20);
            this.funcionarioRank4.TabIndex = 12;
            this.funcionarioRank4.Text = "label5";
            // 
            // funcionarioRank2
            // 
            this.funcionarioRank2.AutoSize = true;
            this.funcionarioRank2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionarioRank2.Location = new System.Drawing.Point(11, 98);
            this.funcionarioRank2.Name = "funcionarioRank2";
            this.funcionarioRank2.Size = new System.Drawing.Size(53, 20);
            this.funcionarioRank2.TabIndex = 11;
            this.funcionarioRank2.Text = "label4";
            // 
            // EstoqueProdutos
            // 
            this.EstoqueProdutos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.EstoqueProdutos.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
            chartArea2.Name = "ChartArea1";
            this.EstoqueProdutos.ChartAreas.Add(chartArea2);
            this.EstoqueProdutos.Cursor = System.Windows.Forms.Cursors.Default;
            legend2.Name = "Legend1";
            this.EstoqueProdutos.Legends.Add(legend2);
            this.EstoqueProdutos.Location = new System.Drawing.Point(793, 328);
            this.EstoqueProdutos.Name = "EstoqueProdutos";
            this.EstoqueProdutos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series2.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.Color = System.Drawing.Color.MediumAquamarine;
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series2.Name = "Series1";
            series2.YValuesPerPoint = 2;
            this.EstoqueProdutos.Series.Add(series2);
            this.EstoqueProdutos.Size = new System.Drawing.Size(429, 450);
            this.EstoqueProdutos.TabIndex = 11;
            this.EstoqueProdutos.Text = "Estoque de Produtos";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.label14);
            this.panel4.Location = new System.Drawing.Point(12, 328);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(288, 120);
            this.panel4.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Informações";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel5.Controls.Add(this.label15);
            this.panel5.Location = new System.Drawing.Point(12, 499);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(288, 119);
            this.panel5.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Informações";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel6.Controls.Add(this.label16);
            this.panel6.Location = new System.Drawing.Point(12, 659);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(288, 119);
            this.panel6.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "Informações";
            // 
            // label17
            // 
            this.label17.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(33, 142);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 27);
            this.label17.TabIndex = 12;
            this.label17.Text = "Home";
            // 
            // produtos1
            // 
            this.produtos1.Location = new System.Drawing.Point(306, 51);
            this.produtos1.Name = "produtos1";
            this.produtos1.Size = new System.Drawing.Size(916, 727);
            this.produtos1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = global::market.Properties.Resources.Imagem_Verde;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 794);
            this.Controls.Add(this.produtos1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.EstoqueProdutos);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EstoqueProdutos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Estoque;
        private System.Windows.Forms.Button Produtos;
        private System.Windows.Forms.Button Vendas;
        private System.Windows.Forms.Button Cadastro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label funcionarioRank2;
        public System.Windows.Forms.Label funcionarioRank1;
        public System.Windows.Forms.Label funcionarioRank10;
        public System.Windows.Forms.Label funcionarioRank9;
        public System.Windows.Forms.Label funcionarioRank8;
        public System.Windows.Forms.Label funcionarioRank7;
        public System.Windows.Forms.Label funcionarioRank6;
        public System.Windows.Forms.Label funcionarioRank5;
        public System.Windows.Forms.Label funcionarioRank3;
        public System.Windows.Forms.Label funcionarioRank4;
        private System.Windows.Forms.Label FuncionarioMes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.DataVisualization.Charting.Chart EstoqueProdutos;
        public Produtos produtos1;
    }
}

