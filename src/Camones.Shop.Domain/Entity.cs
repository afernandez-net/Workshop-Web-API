namespace Camones.Shop.Domain
{
    public class Entity<T>
    {
        public T Id { get; set; }

        public bool IsActive { get; set; }

        //Fecha creacion
        //Fecha de actulizacion
        //Usuario creacion
        //Usuario de actulizacion
    }
}