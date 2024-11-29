using T2_T3VisorDeImagenes.Modelo;

namespace T2_T3VisorDeImagenes.Vista;

public partial class NuevoAnimal : ContentPage
{
	public NuevoAnimal()
	{
		InitializeComponent();
	}

    public event Action<Animal> Creacion;
    private string rutaImagen;

    private async void OnInsertarClicked(object sender, EventArgs e)
    {
        try
        {
            // Abre el selector de archivos
            var escogida = await FilePicker.PickAsync(PickOptions.Images);

            if (escogida != null && escogida.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
            escogida.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
            {
                    //using var stream = await escogida.OpenReadAsync();
                    //var imagenSeleccionada.Source = ImageSource.FromStream(() => stream);
                var imageStream = await escogida.OpenReadAsync();
                imagenSeleccionada.Source = ImageSource.FromStream(() => imageStream);
                rutaImagen = escogida.FullPath;
            }
            
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Algo salió mal: {ex.Message}\n{ex.StackTrace}", "OK");
        }

    }

    private void OnAniadirAnimalClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDescripcion.Text))
        {
            DisplayAlert("Error", "Por favor, ingrese un nombre y una descripción.", "OK");
            return;
        }

        // Verificamos si la imagen ha sido seleccionada
        if (string.IsNullOrEmpty(rutaImagen))
        {
            DisplayAlert("Error", "Por favor, seleccione una imagen.", "OK");
            return;
        }

        // Creamos el nuevo animal con los datos proporcionados
        Animal nuevoAnimal = new Animal
        {
            Nombre = txtNombre.Text,
            Descripcion = txtDescripcion.Text,
            Fecha = DateTime.Now,
            Imagen = rutaImagen  // Usamos la ruta de la imagen seleccionada
        };

        // Disparamos el evento de creación y pasamos el nuevo animal
        Creacion?.Invoke(nuevoAnimal);

        // Navegamos de vuelta a la página anterior (VisorImagenes)
        Navigation.PopAsync();
    }

}
