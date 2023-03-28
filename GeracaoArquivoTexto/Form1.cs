using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeracaoArquivoTexto
{
    public partial class Form1 : Form
    {

        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
            this.dt.Columns.Add("Nome", typeof(string));
            this.dt.Columns.Add("Salário", typeof(double));
            dataGridView1.DataSource = this.dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numeroFuncionarios = Convert.ToInt16(textBox1.Text);
            if (numeroFuncionarios < 1) numeroFuncionarios = 1;
            int i = 0;

            do
            {
                //DataRow novaLinha = this.dt.NewRow();
                this.dt.Rows.Add("", 0);

                //var linhaTabela = new DataGridViewRow();
                //linhaTabela.Cells.Add(new DataGridViewTextBoxCell {Value = string.Empty});
                //linhaTabela.Cells.Add(new DataGridViewTextBoxCell { Value = 0 });
                //this.dt.Rows.Add(linhaTabela);
            } while (++i < numeroFuncionarios);
            textBox1.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = true;

            dataGridView1.DataSource = this.dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Criar um novo objeto SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Definir as propriedades do SaveFileDialog
            saveFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            saveFileDialog.Title = "Salvar Arquivo";
            saveFileDialog.FileName = "exemplo.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;

            // Exibir o SaveFileDialog e aguardar que o usuário faça uma seleção
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obter o caminho e o nome do arquivo selecionado pelo usuário
                string nomeArquivo = saveFileDialog.FileName;

                // Escrever algum conteúdo no arquivo
                using (StreamWriter sw = new StreamWriter(nomeArquivo))
                {
                    sw.WriteLine("Exemplo de conteúdo salvo em um arquivo usando SaveFileDialog");
                }

                // Exibir uma mensagem informando que o arquivo foi salvo com sucesso
                MessageBox.Show("Arquivo salvo com sucesso em " + nomeArquivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //foreach (DataRow linha in dt.Rows)
            //{
             //   Console.WriteLine(linha[0]);
              ///  Double valorAnterior = Double.Parse((String)linha[1], CultureInfo.InvariantCulture);

               // Console.WriteLine(valorAnterior);
           // }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("clicou aqui");
            this.dt.Rows.Clear();
            textBox1.Text = string.Empty;
            textBox1.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = false;
        }
    }
}
