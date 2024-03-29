﻿using DevelopmentChallenge.Data.enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        private decimal _lado;

        public Cuadrado(decimal lado, string nombre)
        {
            this._lado = lado;
            this._nombre = nombre;
        }

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }
    }
}
