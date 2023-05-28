namespace Caja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string contrasena = txtContrasena.Text;


            if (nombreUsuario == "admin" && contrasena == "123456")
            {
                MessageBox.Show("Inicio de sesión exitoso.");

                Form2 Form2 = new Form2();
                Form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
               
            }
        }
    }
}