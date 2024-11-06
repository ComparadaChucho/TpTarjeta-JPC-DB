using System;

namespace TP
{
    public class Interurbano : Colectivo
    {
        public Interurbano(string linea) : base(linea)
        {
            tarifa = 2500;
        }
    }
}