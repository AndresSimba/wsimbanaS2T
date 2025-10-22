namespace wsimbanaTS2.Views;

public partial class vBienvenida : ContentPage
{
	public vBienvenida(string usuario, string contrasena)
	{
		InitializeComponent();

		lblUsuario.Text = $"Usuario: {usuario}";
		lblContrasena.Text = $"Contraseña: {contrasena}";

    }
}