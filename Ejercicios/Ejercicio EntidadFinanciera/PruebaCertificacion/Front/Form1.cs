using Back;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace Front
{
    public partial class Form1 : Form
    {
        Principal principal = new Principal();
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1 = new DataGridView();
            using (var dbContext = new BaseDatos())
            {
                var ListaCuentas = dbContext.CuentasBancarias.ToList();
                dataGridView1.DataSource = ListaCuentas;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
            if (comboBox1.Text == "Cuenta Corriente") 
            {
                comboBox1.Text = "CC";
            }
            else 
            {
                comboBox1.Text = "CA";
            }
            
            string tipo = comboBox1.Text;
            int dni = int.Parse(textBox2.Text);

            MessageBox.Show(principal.AgregarCuentaBancaria(tipo, dni));

            BindingSource binding = new BindingSource();
            binding.DataSource = principal.baseDatos.CuentasBancarias.ToList();

        }


    }
}