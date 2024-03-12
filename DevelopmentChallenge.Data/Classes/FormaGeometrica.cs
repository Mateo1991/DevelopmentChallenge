/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevelopmentChallenge.Data.enums;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        protected string _nombre;

        public string getNombre()
        {
            return _nombre;
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append(ObtenerReporteVacioString(idioma));
            }
            else
            {
                var gruposFigura = formas.GroupBy(f => f.getNombre());
                decimal totalArea = 0;
                decimal totalPerimetro = 0;

                foreach (var grupo in gruposFigura)
                {
                    decimal totalAreaGrupo = 0;
                    decimal totalPerimetroGrupo = 0;

                    foreach (var figura in grupo)
                    {
                        totalAreaGrupo += figura.CalcularArea();
                        totalPerimetroGrupo += figura.CalcularPerimetro();
                    }

                    sb.Append(ObtenerLinea(grupo.Count(), totalAreaGrupo, totalPerimetroGrupo, grupo.Key, idioma));
                    totalArea += totalAreaGrupo;
                    totalPerimetro += totalPerimetroGrupo;
                }

                ObtenerDatosReporte(idioma, ref sb, formas, totalArea, totalPerimetro);

            }

            return sb.ToString();
        }

        private static string ObtenerDatosReporte(int idioma, ref StringBuilder sb, List<FormaGeometrica> formas, decimal totalArea, decimal totalPerimetro)
        {
            switch (idioma)
            {
                case (int)Idioma.Castellano:
                    sb.Append("<h1>Reporte de Formas</h1>");
                    sb.Append("TOTAL:<br/>");
                    sb.Append(formas.Count() + " " + "formas" + " ");
                    sb.Append("Perimetro " + (totalPerimetro).ToString("#.##") + " ");
                    sb.Append("Area " + (totalArea).ToString("#.##"));
                    break;
                case (int)Idioma.Ingles:
                    sb.Append("<h1>Shapes report</h1>");
                    sb.Append("TOTAL:<br/>");
                    sb.Append(formas.Count() + " " + "shapes" + " ");
                    sb.Append("Perimeter " + (totalPerimetro).ToString("#.##") + " ");
                    sb.Append("Area " + (totalArea).ToString("#.##"));
                    break;
                case (int)Idioma.Italiano:
                    sb.Append("<h1>Rapporto sui moduli</h1>");
                    sb.Append("TOTALE:<br/>");
                    sb.Append(formas.Count() + " " + "forme" + " ");
                    sb.Append("Perimetro " + (totalPerimetro).ToString("#.##") + " ");
                    sb.Append("La zona " + (totalArea).ToString("#.##"));
                    break;
            }

            return string.Empty;
        }

        private static string ObtenerReporteVacioString(int idioma)
        {
            switch (idioma)
            {
                case (int)Idioma.Castellano:
                    return "<h1>Lista vacía de formas!</h1>";
                case (int)Idioma.Ingles:
                    return "<h1>Empty list of shapes!</h1>";
                case (int)Idioma.Italiano:
                    return "<h1>Elenco vuoto di forme!</h1>";
            }

            return string.Empty;
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, string tipo, int idioma)
        {
            if (cantidad > 0)
            {
                switch (idioma)
                {
                    case (int)Idioma.Castellano:
                        return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";
                    case (int)Idioma.Ingles:
                        return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
                    case (int)Idioma.Italiano:
                        return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | La zona {area:#.##} | Perimetro {perimetro:#.##} <br/>";
                }
            }

            return string.Empty;
        }

        public static string TraducirForma(string tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case "Cuadrado":
                    if (idioma == (int)Idioma.Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else if (idioma == (int)Idioma.Ingles) return cantidad == 1 ? "Square" : "Squares";
                    else return cantidad == 1 ? "Piazza" : "Piazze";
                case "Circulo":
                    if (idioma == (int)Idioma.Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
                    else if (idioma == (int)Idioma.Ingles) return cantidad == 1 ? "Circle" : "Circles";
                    else return cantidad == 1 ? "Cerchio" : "Cerchi";
                case "TrianguloEquilatero":
                    if (idioma == (int)Idioma.Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
                    else if (idioma == (int)Idioma.Ingles) return cantidad == 1 ? "Triangle" : "Triangles";
                    else return cantidad == 1 ? "Triangolo" : "Triangoli";
                case "Rectangulo":
                    if (idioma == (int)Idioma.Castellano) return cantidad == 1 ? "Rectángulo" : "Rectángulos";
                    else if (idioma == (int)Idioma.Ingles) return cantidad == 1 ? "Rectangle" : "Rectangles";
                    else return cantidad == 1 ? "Rettangolo" : "Rettangoli";
            }

            return string.Empty;
        }

        public abstract decimal CalcularArea();

        public abstract decimal CalcularPerimetro();
    }
}
