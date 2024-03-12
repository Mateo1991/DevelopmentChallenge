using System;
using DevelopmentChallenge.Data.enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        private decimal _lado;

        public TrianguloEquilatero(decimal lado, string nombre)
        {
            this._lado = lado;
            this._nombre = nombre;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }
    }
}
