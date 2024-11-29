using T2_T3VisorDeImagenes.Modelo;

namespace T2_T3VisorDeImagenes.Vista;

public partial class DescripcionAnimal : ContentPage
{
	public DescripcionAnimal(Animal a)
	{
		InitializeComponent();
		BindingContext = a;
	}
}