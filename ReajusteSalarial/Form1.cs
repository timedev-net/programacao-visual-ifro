using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReajusteSalarial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double salario_min = Convert.ToDouble(textBox1.Text);
            double horas_trabalhadas = Convert.ToDouble(textBox2.Text);
            String categoria = "";
            String turno = "";
            double salario_bruto = 0.0;
            double salario_liquido = 0.0;
            
            if (radioButton3.Text.Equals("Matutino")) {
                turno = "Matutino";
                salario_bruto = salario_min + (salario_min * 0.01);
            }
            if (radioButton4.Text.Equals("Vespertino")) {
                turno = "Vespertino";
                salario_bruto = salario_min + (salario_min * 0.02);
            }
            if (radioButton5.Text.Equals("Noturno")) {
                turno = "Noturno";
                salario_bruto = salario_min + (salario_min * 0.03);
                if (horas_trabalhadas > 80) // gratificação
                {
                    salario_liquido += 50;
                } else
                {
                    salario_liquido += 30;
                }
            }

            if (radioButton1.Text.Equals("Calouro"))
            {
                categoria = "Calouro";
                if (salario_bruto < 300)
                {
                    // salario liquido recebe imposto de 1%
                } else
                {
                    // salario liquido recebe imposto de 2%
                }
                if (salario_bruto < salario_min/2) { // auxílio alimentação
                
                }
            }
            if (radioButton2.Text.Equals("Veterano")) { 
                categoria = "Veterano";
                if (salario_bruto < 400)
                {
                    // salario liquido recebe imposto de 3%
                }
                else
                {
                    // salario liquido recebe imposto de 4%
                }

            }



        }
    }
}
