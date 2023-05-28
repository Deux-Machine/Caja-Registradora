using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Caja
{
    public partial class Form3 : Form
    {
        private List<Producto> listaProductos;
        private const string rutaArchivo = "C:\\Users\\JERSON\\Desktop\\Productos.txt";

        public Form3()
        {
            InitializeComponent();
            listaProductos = new List<Producto>();

            dataGridView.Columns.Add("Codigo", "Código");
            dataGridView.Columns.Add("Nombre", "Nombre");
            dataGridView.Columns.Add("Precio", "Precio");
            dataGridView.Columns.Add("Cantidad", "Cantidad");

            CargarDatosDesdeArchivo();

            btnCrear.Click += btnCrear_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void CargarDatosDesdeArchivo()
        {
            dataGridView.Rows.Clear();
            listaProductos.Clear();

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string[] campos = linea.Split(',');

                    if (campos.Length == 4)
                    {
                        string codigo = campos[0];
                        string nombre = campos[1];
                        decimal precio;
                        int cantidad;

                        if (decimal.TryParse(campos[2], out precio) && int.TryParse(campos[3], out cantidad))
                        {
                            dataGridView.Rows.Add(codigo, nombre, precio, cantidad);
                            listaProductos.Add(new Producto(codigo, nombre, precio, cantidad));
                        }
                        else
                        {
                            MessageBox.Show("Error en el formato de los datos en el archivo.");
                            return;
                        }
                    }
                }
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            decimal precio;
            int cantidad;

            if (!decimal.TryParse(txtPrecio.Text, out precio) || !int.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos en los campos Precio y Cantidad.");
                return;
            }

            if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(nombre) || precio <= 0 || cantidad <= 0)
            {
                MessageBox.Show("Por favor, ingrese valores válidos en los campos.");
                return;
            }

            Producto nuevoProducto = new Producto(codigo, nombre, precio, cantidad);
            listaProductos.Add(nuevoProducto);

            string datosNuevos = $"{codigo},{nombre},{precio},{cantidad}";
            File.AppendAllText(rutaArchivo, datosNuevos + Environment.NewLine);

            dataGridView.Rows.Add(codigo, nombre, precio, cantidad);

            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int indiceFila = dataGridView.CurrentRow.Index;

            string nuevoCodigo = txtCodigo.Text;
            string nuevoNombre = txtNombre.Text;
            decimal nuevoPrecio;
            int nuevaCantidad;

            if (!decimal.TryParse(txtPrecio.Text, out nuevoPrecio) || !int.TryParse(txtCantidad.Text, out nuevaCantidad))
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos en los campos Precio y Cantidad.");
                return;
            }

            if (string.IsNullOrEmpty(nuevoCodigo) || string.IsNullOrEmpty(nuevoNombre) || nuevoPrecio <= 0 || nuevaCantidad <= 0)
            {
                MessageBox.Show("Por favor, ingrese valores válidos en los campos.");
                return;
            }

            listaProductos[indiceFila].Codigo = nuevoCodigo;
            listaProductos[indiceFila].Nombre = nuevoNombre;
            listaProductos[indiceFila].Precio = nuevoPrecio;
            listaProductos[indiceFila].Cantidad = nuevaCantidad;

            dataGridView.Rows[indiceFila].Cells[0].Value = nuevoCodigo;
            dataGridView.Rows[indiceFila].Cells[1].Value = nuevoNombre;
            dataGridView.Rows[indiceFila].Cells[2].Value = nuevoPrecio;
            dataGridView.Rows[indiceFila].Cells[3].Value = nuevaCantidad;

            GuardarCambiosEnArchivo();

            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indiceFila = dataGridView.CurrentRow.Index;

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                listaProductos.RemoveAt(indiceFila);

                dataGridView.Rows.RemoveAt(indiceFila);

                GuardarCambiosEnArchivo();

                LimpiarCampos();
            }
        }

        private void GuardarCambiosEnArchivo()
        {
            File.WriteAllText(rutaArchivo, string.Empty);

            foreach (Producto producto in listaProductos)
            {
                string datosProducto = $"{producto.Codigo},{producto.Nombre},{producto.Precio},{producto.Cantidad}";
                File.AppendAllText(rutaArchivo, datosProducto + Environment.NewLine);
            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
        }

        private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int indiceFila = dataGridView.CurrentRow.Index;

            if (indiceFila >= 0 && indiceFila < listaProductos.Count)
            {
                txtCodigo.Text = listaProductos[indiceFila].Codigo;
                txtNombre.Text = listaProductos[indiceFila].Nombre;
                txtPrecio.Text = listaProductos[indiceFila].Precio.ToString();
                txtCantidad.Text = listaProductos[indiceFila].Cantidad.ToString();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

            Form2 Form2 = new Form2();
            Form2.Show();
        }
    }

    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public Producto(string codigo, string nombre, decimal precio, int cantidad)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}





