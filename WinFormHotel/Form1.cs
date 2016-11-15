using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormHotel.Logica;

namespace WinFormHotel
{
    public partial class Form1 : Form
    {
        GestionCliente gCliente;
        public Form1()
        {
            InitializeComponent();
            gCliente = new GestionCliente();
        }

        private void VaciarControles()
        {
            idTextBox.Text = "0";
            rucTextBox.Text = string.Empty;
            nombreTextBox.Text = string.Empty;
            descuentoTextBox.Text = "0";
            tipoComboBox.SelectedIndex = -1;
            rucTextBox.Focus();
        }

        private void CargarValores(int idCliente)
        {
            Cliente cliente = gCliente.ClientexId(idCliente);
            if (!string.IsNullOrEmpty(cliente.Ruc))
            {
                idTextBox.Text = cliente.Id.ToString();
                rucTextBox.Text = cliente.Ruc;
                nombreTextBox.Text = cliente.Nombre;
                descuentoTextBox.Text = cliente.Descuento.ToString();
                tipoComboBox.SelectedItem = cliente.Tipo;
            }
            else
                MessageBox.Show("Por favor seleccione otro registro, ocurrio un problema al cargar los datos del registro seleccionado.");
        }

        private void iniciarButton_Click(object sender, EventArgs e)
        {
            try
            {
                EncenderApagar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor verifique que este conectado al Api Rest. " + ex.Message);
            }
        }

        private void EncenderApagar()
        {
            if (this.iniciarButton.Text == "INICIAR")
            {
                CargarLista();
                this.iniciarButton.BackColor = System.Drawing.Color.LimeGreen;
                this.iniciarButton.Text = "APAGAR";
            }
            else
            {
                this.iniciarButton.BackColor = System.Drawing.Color.Tomato;
                this.iniciarButton.Text = "INICIAR";
                VaciarControles();
                VaciarLista();
            }
        }

        private void clienteDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idCliente = 0;
            if (clienteDataGridView.CurrentCell != null)
            {
                idCliente = Convert.ToInt16(clienteDataGridView.CurrentRow.Cells["Id"].Value.ToString());
                if (!string.IsNullOrEmpty(idCliente.ToString())) CargarValores(idCliente);
            }
            else
                MessageBox.Show("Por favor seleccione otro registro, ocurrio un problema al cargar los datos.");

        }

        private void nuevoButton_Click(object sender, EventArgs e)
        {
            VaciarControles();
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "0")
                MessageBox.Show("Por favor seleccione primero un registro con doble click, en la celda del Listado de Clientes.");
            try
            {
                gCliente.EliminarCliente(idTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor intente de nuevo mas tarde, ocurrio un problema." + ex.Message);
            }
            VaciarControles();
            CargarLista();

        }

        private void CargarLista()
        {
            clienteDataGridView.DataSource = gCliente.ListaClientes();
        }

        private void VaciarLista()
        {
            clienteDataGridView.DataSource = null;
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarDatosIngresados();
                if (idTextBox.Text == "0")
                    InsertarNuevoCliente();
                else
                    ModificarCliente();
                CargarLista();
                VaciarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas al guardar los cambios." + ex.Message);
            }
        }

        private void ValidarDatosIngresados()
        {
            string errores = string.Empty;
            if (string.IsNullOrEmpty(rucTextBox.Text))
                errores += "Inserte la cedula, por favor." + Environment.NewLine;
            if (string.IsNullOrEmpty(nombreTextBox.Text))
                errores += "Inserte el nombre, por favor." + Environment.NewLine;
            if (string.IsNullOrEmpty(tipoComboBox.Text))
                errores += "Inserte el tipo de cliente, por favor." + Environment.NewLine;
            if (string.IsNullOrEmpty(descuentoTextBox.Text))
                errores += "Inserte el descuento, por favor." + Environment.NewLine;
            if (!string.IsNullOrEmpty(errores))
                throw new Exception(errores);
        }

        private Cliente CargarCliente_Interfaz()
        {
            Cliente client = new Logica.Cliente();
            client.Id = int.Parse(idTextBox.Text);
            client.Ruc = rucTextBox.Text;
            client.Nombre = nombreTextBox.Text.ToUpper();
            client.Tipo = tipoComboBox.Text;
            client.Descuento = int.Parse(descuentoTextBox.Text);
            return client;
        }

        private void InsertarNuevoCliente()
        {
            Cliente client = CargarCliente_Interfaz();
            gCliente.InsertarCliente(client);
        }

        private void ModificarCliente()
        {
            Cliente client = CargarCliente_Interfaz();
            gCliente.ModificarCliente(client);
        }

        private void tipoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipoComboBox.Text == "PREMIUM")
                descuentoTextBox.Text = "3";
            if (tipoComboBox.Text == "REGULARES")
                descuentoTextBox.Text = "8";
        }
    }
}
