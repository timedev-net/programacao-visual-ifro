using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoReajusteFolhaPagamento
{
    public partial class Form1 : Form
    {
        DataTable dados;

        public Form1()
        {
            InitializeComponent();
        }

        private DataTable LerArquivoCSV(string caminhoArquivo)
        {
            DataTable dt = new DataTable();
            using (var reader = new StreamReader(caminhoArquivo))
            {
                string[] cabecalho = reader.ReadLine().Split(',');
                foreach (string coluna in cabecalho)
                {
                    dt.Columns.Add(coluna);
                }
                while (!reader.EndOfStream)
                {
                    string[] linha = reader.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < cabecalho.Length; i++)
                    {
                        dr[i] = linha[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = openFileDialog.FileName;
                this.dados = LerArquivoCSV(caminhoArquivo);
                ExibirDados(this.dados);
                // fazer algo com os dados lidos, como exibi-los em um controle DataGridView
            }
        }

        private void ExibirDados(DataTable dados)
        {
            dataGridView1.DataSource = this.dados;
        }

        private DataTable CalculaReajusteDados(DataTable dados)
        {
            DataTable dt = new DataTable();
            
            Double valorPosterior = 0;
            Double valorTotalAnterior = 0;
            Double valorTotalPosterior = 0;
            Double percentAcrecimo = 0;


            foreach (DataColumn coluna in dados.Columns)
            {
               // Console.WriteLine("teste1", coluna.ColumnName);
                dt.Columns.Add(coluna.ToString());
            }

            foreach (DataRow linha in dados.Rows)
            {
                DataRow dr = dt.NewRow();
                DataRow linha1 = linha;

                Console.WriteLine(linha[1]);
                Double valorAnterior = Double.Parse((String)linha[1], CultureInfo.InvariantCulture);
                dr[0] = linha[0];
                Console.WriteLine(valorAnterior);
                valorTotalAnterior += valorAnterior;
                if (valorAnterior < 1000)
                {
                    // o reajuste será de 15%
                    valorPosterior = valorAnterior + (valorAnterior * 0.15);
                }
                if (valorAnterior >= 1000 && valorAnterior <= 1500)
                {
                    // o reajuste será de 10%
                    valorPosterior = valorAnterior + (valorAnterior * 0.1);
                }
                if (valorAnterior > 1500)
                {
                    // o reajuste será de 5%
                    valorPosterior = valorAnterior + (valorAnterior * 0.05);
                }
                dr[1] = valorPosterior;
                valorTotalPosterior += valorPosterior;

                percentAcrecimo = ((valorTotalPosterior - valorTotalAnterior) / valorTotalAnterior) * 100;

                dt.Rows.Add(dr);
                // for (int i = 0; i < dados.Columns.Count; i++) {}
            }

            label1.Text = "O valor total antes do cálculo é: R$ " + valorTotalAnterior.ToString("F2");
            label2.Text = "O valor total calculado é: R$ " + valorTotalPosterior.ToString("F2");
            label3.Text = "O percentual de acréscimo total calculado é: " + percentAcrecimo.ToString("F2")+ "%";

            foreach (DataRow linha in dados.Rows)
            {
                
                
                // string valorColuna1 = linha["cod"].ToString();
                // Double valorColuna2 = Convert.ToDouble(linha["valor"]);
                // realizar outras operações com os dados
            }
            return dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable tabelaNova = CalculaReajusteDados(this.dados);
            dataGridView2.DataSource = tabelaNova;
        }
    }
}
