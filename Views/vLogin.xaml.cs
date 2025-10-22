using wsimbanaTS2.Views;

namespace wsimbanaTS2.Resources.Views;

public partial class vLogin : ContentPage
{

    string[] usuarios = { "Carlos", "Ana", "Jose" };
    string[] contrasenas = { "carlos123", "ana123", "jose123" };


    public vLogin()
	{
		InitializeComponent();
	}

    private async void btnIngresar_Clicked(object sender, EventArgs e)
    {

		try
		{
			string usuario = txtUsuario.Text;
			string contrasena = txtContrasena.Text;
			bool encontrado = false;

			for (int i = 0; i < usuarios.Length; i++)
			{
				if(usuario == usuarios[i] && contrasena == contrasenas[i])
				{
					encontrado = true;
                    break;
                }
				
            }

            
            if (encontrado)
            {
               await Navigation.PushAsync(new vBienvenida(usuario, contrasena));
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            }
        }
		catch (Exception ex)
		{

			Console.WriteLine(ex.Message);
		}

    }
}