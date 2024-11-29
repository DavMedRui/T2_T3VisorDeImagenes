using T2_T3VisorDeImagenes.Modelo;
using System.Collections.ObjectModel;



namespace T2_T3VisorDeImagenes.Vista;

public partial class VisorImagenes : ContentPage
{
    public ObservableCollection<Animal> Animales { get; set; }

    Animal seleccionado;
    public VisorImagenes()
	{
		InitializeComponent();
        

        //Creamos los animales para ponerlos en la lista
        Animal tigre = new Animal
        {
            Nombre = "Tigre",
            Descripcion = "Es un animal solitario y territorial que generalmente suele habitar bosques densos, pero también áreas abiertas, como sabanas.",
            Imagen = "animal1.jpg",
            Fecha = DateTime.Now,
        };

        Animal leon = new Animal
        {
            Nombre = "León",
            Descripcion = "El león (Panthera leo) es un mamífero carnívoro de la familia de los félidos y una de las cinco especies del género Panthera.",
            Imagen = "animal2.jpg",
            Fecha = DateTime.Now
        };

        Animal panda = new Animal
        {
            Nombre = "Panda",
            Descripcion = "El panda, oso panda o panda gigante (Ailuropoda melanoleuca) es una especie de mamífero del orden de los carnívoros.",
            Imagen = "animal3.jpg",
            Fecha = DateTime.Now
        };

        Animal lince = new Animal
        {
            Nombre = "Lince Ibérico",
            Descripcion = "El lince ibérico (Lynx pardinus) es una especie de mamífero carnívoro de la familia Felidae, endémico de la península ibérica, conocido internacionalmente4​ por su recuperación tras haber estado en peligro crítico de extinción a principios del siglo XXI.",
            Imagen = "animal4.jpg",
            Fecha = DateTime.Now
        };

        Animal cebra = new Animal
        {
            Nombre = "Cebra",
            Descripcion = "Se conocen como cebra​ a tres especies del género Equus propias de África —Equus quagga (cebra común; con cinco subspecies),2​ Equus zebra (cebra de montaña; dos subespecies)​ y Equus grevyi (cebra de Grevy)​— cuya característica más distintiva es su coloración a base de rayas blancas sobre un fondo negro.",
            Imagen = "animal5.jpg",
            Fecha = DateTime.Now
        };

        Animal buitre = new Animal
        {
            Nombre = "Buitre",
            Descripcion = "Los buitres son aves rapaces del orden Accipitriformes que suelen alimentarse especialmente de animales muertos, aunque, a falta de estos, son capaces de cazar presas vivas.",
            Imagen = "animal6.jpg",
            Fecha = DateTime.Now
        };

        Animales = new ObservableCollection<Animal>()
        {
            tigre,leon,panda,lince,cebra, buitre
        };

        BindingContext = this;

        lista.ItemsSource = Animales; //Asignamos a la lista que vamos a mostrar, la que hemos creado con los animales



    }

    private async void OnSeleccionadoTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Animal animal)
        {
            await Navigation.PushAsync(new DescripcionAnimal(animal));
        }
    }

    private async void OnAniadirClicked(object sender, EventArgs e)
    {
        
        var recibido = new NuevoAnimal();
        recibido.Creacion += (nuevo) =>
        {
            Animales.Add(nuevo);
            BindingContext = null;
            BindingContext = this;
        };
        await Navigation.PushAsync(recibido);
    }
}