using DevelopmentChallenge.Data.enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica
    {

        private decimal _largo;

        private decimal _ancho;

        public Rectangulo(decimal largo, decimal ancho, string nombre)
        {
            this._largo = largo;
            this._ancho = ancho;
            this._nombre = nombre;
        }

        public override decimal CalcularArea()
        {
            return _largo * _ancho;
        }

        public override decimal CalcularPerimetro()
        {
            return _largo * 2 + _ancho * 2;
        }
    }
}
