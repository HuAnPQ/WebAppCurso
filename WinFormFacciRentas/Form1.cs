using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormFacciRentas.Logica;

namespace WinFormFacciRentas
{
    public partial class Form1 : Form
    {
        GestionCliente gCliente;
        public Form1()
        {
            InitializeComponent();
            gCliente = new GestionCliente();
        }

        private void iniciarButton_Click(object sender, EventArgs e)
        {
            EncenderApagar();
        }

        private void EncenderApagar()
        {
            if (this.iniciarButton.Text == "LISTAR")
            {
                CargarLista();
                this.iniciarButton.BackColor = System.Drawing.Color.LimeGreen;
                this.iniciarButton.Text = "APAGAR";
            }
            else
            {
                this.iniciarButton.BackColor = System.Drawing.Color.Tomato;
                this.iniciarButton.Text = "LISTAR";
                VaciarLista();
            }
        }

        private void CargarLista()
        {
            clienteDataGridView.DataSource = gCliente.ListaSimulaciones();
        }

        private void VaciarLista()
        {
            clienteDataGridView.DataSource = null;
        }


    }
}
