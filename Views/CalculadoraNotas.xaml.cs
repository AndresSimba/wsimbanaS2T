using System.Text.RegularExpressions;
namespace wsimbanaTS2.Resources.Views;

public partial class CalculadoraNotas : ContentPage
{
    public CalculadoraNotas(string usuario, string contrasena)
    {
        InitializeComponent();

        lblUsuario.Text = $"Usuario: {usuario}";
        lblContrasena.Text = $"Contraseña: {contrasena}";
    }

    private void txtNotaSeguimiento_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;
        string texto = entry.Text;

        ErrorLabel.IsVisible = false;

        if (double.TryParse(texto, out double valor))
        {
            int decimales = texto.Contains('.') ? texto.Split('.')[1].Length : 0;

            if (valor > 10)
            {
                ErrorLabel.Text = " No es una nota válida. Máximo 10.";
                ErrorLabel.IsVisible = true;
            }
            else if (decimales > 2)
            {
                ErrorLabel.Text = "Máximo 2 decimales permitidos.";
                ErrorLabel.IsVisible = true;
            }
        }
        else if (!string.IsNullOrEmpty(texto))
        {
            ErrorLabel.Text = "Solo se permiten números.";
            ErrorLabel.IsVisible = true;
        }

    }

    private void txtNotaExamen_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;
        string texto = entry.Text;

        ErrorLabelE.IsVisible = false;

        if (double.TryParse(texto, out double valor))
        {
            int decimales = texto.Contains('.') ? texto.Split('.')[1].Length : 0;

            if (valor > 10)
            {
                ErrorLabelE.Text = " No es una nota válida. Máximo 10.";
                ErrorLabelE.IsVisible = true;
            }
            else if (decimales > 2)
            {
                ErrorLabelE.Text = "Máximo 2 decimales permitidos.";
                ErrorLabelE.IsVisible = true;
            }
        }
        else if (!string.IsNullOrEmpty(texto))
        {
            ErrorLabelE.Text = "Solo se permiten números.";
            ErrorLabelE.IsVisible = true;
        }

    }

    private void txtNotaSeguimiento2_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void txtNotaExamen2_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private async void btnCalcularNotas_Clicked(object sender, EventArgs e)
    {
        bool notaSeguimientoValida = double.TryParse(txtNotaSeguimiento.Text, out double notaSeguimiento);
        bool notaExamenValida = double.TryParse(txtNotaExamen.Text, out double notaExamen);
        bool notaSeguimiento2Valida = double.TryParse(txtNotaSeguimiento2.Text, out double notaSeguimiento2);
        bool notaExamen2Valida = double.TryParse(txtNotaExamen2.Text, out double notaExamen2);
        string estudiantes = pkEstudiantes.Items[pkEstudiantes.SelectedIndex].ToString();

        if (!notaSeguimientoValida || !notaExamenValida || !notaSeguimiento2Valida || !notaExamen2Valida)
        {
            await DisplayAlert("Error", "Por favor, ingrese notas válidas antes de calcular.", "OK");
            return;
        }
        else { 
          double notaParcial1 = (notaSeguimiento * 0.3) + (notaExamen * 0.2);
            lblNotaParcial1.Text = $"{notaParcial1:F2}";

            double notaParcial2 = (notaSeguimiento2 * 0.3) + (notaExamen2 * 0.2);
            lblNotaParcial2.Text = $"{notaParcial2:F2}";

            double notaFinal = notaParcial1 + notaParcial2;
            lblNotaFinal.Text = $"{notaFinal:F2}";
            string estado = "";

            if (notaFinal < 5)
            {
                estado = lblEstado.Text = "Reprobado";
                lblEstado.TextColor = Colors.Red;
            }
            else if (notaFinal >= 5 && notaFinal < 7)
            {
                estado = lblEstado.Text = "Complementario";
                lblEstado.TextColor = Colors.Orange;
            }
            else
            {
                estado =  lblEstado.Text = "Aprobado";
                lblEstado.TextColor = Colors.Green;
            }

            string mensaje = $"Nombre: {estudiantes}\nNota final: {notaFinal:F2}\nEstado: {estado}";

            await DisplayAlert("Resultado", mensaje, "OK");

        }

        
    }
}