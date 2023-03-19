using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PesoIdeal
{
    public partial class Form1 : Form
    {
        RadioButton rbnSelecionado = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void SetPesoIdeal()
        {
            try
            {
                double altura = Convert.ToDouble(textBox1.Text);
                double pesoIdeal;

                if (rbnSelecionado == null)
                {
                    label3.Text = "Selecione o Sexo";
                } else
                {

                    if (rbnSelecionado.Text.Equals("Masculino"))
                    {
                        pesoIdeal = (72.7 * altura) - 58;
                        label3.Text = pesoIdeal.ToString("N");
                    }


                    if (rbnSelecionado.Text.Equals("Feminino"))
                    {
                        pesoIdeal = (62.1 * altura) - 44.7;
                        label3.Text = pesoIdeal.ToString("N");
                    }

                }


            }
            catch (Exception e)
            {
                MessageBox.Show("Selecione o sexo e informe a altura corretamente", "Atenção!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbn = (RadioButton)sender;
            if (radioButton1.Checked)
            {
                rbnSelecionado = rbn;
                SetPesoIdeal();
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbn = (RadioButton)sender;
            if (radioButton2.Checked)
            {
                rbnSelecionado = rbn;
                SetPesoIdeal();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SetPesoIdeal();
        }
    }
}
