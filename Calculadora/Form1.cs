using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String operacao_selecionada = (string)operacao.SelectedItem;

            switch (operacao_selecionada)
            {
                case "somar": result.Text = (n1.Value + n2.Value).ToString(); break;
                case "subtrair": result.Text = (n1.Value - n2.Value).ToString(); break;
                case "multiplicar": result.Text = (n1.Value * n2.Value).ToString(); break;
                case "dividir":
                    try { result.Text = (n1.Value / n2.Value).ToString(); }
                    catch (Exception ex)
                    {
                        // result.Text = ex.Message;
                        MessageBox.Show("Erro, não é possível realizar a operação: "+ex.Message, "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    
                    break;
                default:
                    MessageBox.Show("Preencha os campos corretamente!", "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    ); break;
            }

            
        }

       
    }
}
