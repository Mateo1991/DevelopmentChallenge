using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevelopmentChallenge.Data.enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {
        private decimal _ladoA;
        private decimal _ladoB;
        private decimal _ladoC;
        private decimal _ladoD;
        private decimal _altura;

        public Trapecio(decimal ladoA, decimal ladoB, decimal ladoC, decimal ladoD, decimal altura, string nombre)
        {
            this._ladoA = ladoA;
            this._ladoB = ladoB;
            this._ladoC = ladoC;
            this._ladoD = ladoD;
            this._altura = altura;
            this._nombre = nombre;
        }

        public override decimal CalcularArea()
        {
            return ((_ladoA + _ladoB) * _altura) / 2;
        }

        public override decimal CalcularPerimetro()
        {
            return _ladoA * _ladoB * _ladoC + _ladoD;
        }
    }
}

