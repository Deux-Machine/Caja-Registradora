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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Codigo";
            dataGridView1.Columns[1].Name = "Nombre";
            dataGridView1.Columns[2].Name = "Precio";
            dataGridView1.Columns[3].Name = "Cantidad";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.Show();

            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string codigoProducto = txtCodigo.Text.Trim();
            string nombreProducto = txtNombre.Text.Trim();
            string precioProducto = txtPrecio.Text.Trim();
            string cantidadProducto = txtCantidad.Text.Trim();

            if (string.IsNullOrEmpty(codigoProducto) || string.IsNullOrEmpty(nombreProducto) || string.IsNullOrEmpty(precioProducto) || string.IsNullOrEmpty(cantidadProducto))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error");
                return;
            }

            decimal precio;
            int cantidad;

            if (!decimal.TryParse(precioProducto, out precio) || !int.TryParse(cantidadProducto, out cantidad))
            {
                MessageBox.Show("El precio y la cantidad deben ser valores numéricos.", "Error");
                return;
            }

            dataGridView1.Rows.Add(codigoProducto, nombreProducto, precio, cantidad);

            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            string codigoProducto = txtCodigo.Text.Trim();

            string[] lineas = File.ReadAllLines("C:\\Users\\JERSON\\Desktop\\Productos.txt");

            foreach (string linea in lineas)
            {
                string[] campos = linea.Split(',');

                if (campos.Length >= 3 && campos[0] == codigoProducto)
                {
                    string nombreProducto = campos[1];
                    string precioProducto = campos[2];

                    txtNombre.Text = nombreProducto;
                    txtPrecio.Text = precioProducto;

                    break; 
                }
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {       
            if (dataGridView1.Rows.Count > 0)
            {
                List<string> codigos = new List<string>();
                List<string> nombres = new List<string>();
                List<decimal> precios = new List<decimal>();
                List<int> cantidades = new List<int>();

                decimal totalPagar = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCell codigoCell = row.Cells["Codigo"];
                    DataGridViewCell nombreCell = row.Cells["Nombre"];
                    DataGridViewCell precioCell = row.Cells["Precio"];
                    DataGridViewCell cantidadCell = row.Cells["Cantidad"];

                    if (codigoCell.Value != null && nombreCell.Value != null && precioCell.Value != null && cantidadCell.Value != null)
                    {
                        string codigo = codigoCell.Value.ToString();
                        string nombre = nombreCell.Value.ToString();
                        decimal precio = Convert.ToDecimal(precioCell.Value);
                        int cantidad = Convert.ToInt32(cantidadCell.Value);

                        codigos.Add(codigo);
                        nombres.Add(nombre);
                        precios.Add(precio);
                        cantidades.Add(cantidad);

                        decimal subtotal = precio * cantidad;
                        totalPagar += subtotal;
                    }
                }

                StringBuilder factura = new StringBuilder();
                factura.AppendLine("FACTURA");
                factura.AppendLine("----------------------------------------");
                factura.AppendLine("CODIGO | NOMBRE | PRECIO | CANTIDAD | SUBTOTAL");
                factura.AppendLine("----------------------------------------");

                for (int i = 0; i < codigos.Count; i++)
                {
                    factura.AppendLine($"{codigos[i]} | {nombres[i]} | {precios[i]} | {cantidades[i]} | {precios[i] * cantidades[i]}");

                    string[] lineas = File.ReadAllLines("C:\\Users\\JERSON\\Desktop\\Productos.txt");

                    for (int j = 0; j < lineas.Length; j++)
                    {
                        string[] campos = lineas[j].Split(',');

                        if (campos.Length >= 3 && campos[0] == codigos[i])
                        {
                            int unidadesDisponibles = Convert.ToInt32(campos[3]);
                            unidadesDisponibles -= cantidades[i];
                            campos[3] = unidadesDisponibles.ToString();
                            lineas[j] = string.Join(",", campos);
                            break; 
                        }
                    }

                    File.WriteAllLines("C:\\Users\\JERSON\\Desktop\\Productos.txt", lineas);
                }

                factura.AppendLine("----------------------------------------");
                factura.AppendLine($"TOTAL A PAGAR: {totalPagar}");

                MessageBox.Show(factura.ToString(), "Factura");

                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("No hay productos para facturar.", "Factura");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
