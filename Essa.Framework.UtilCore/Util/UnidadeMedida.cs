using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essa.Framework.UtilCore.Util
{
    public class UnidadeMedida
    {

        public UnidadeMedidaPixel Pixel(int valor)
        {
            return new UnidadeMedidaPixel(valor);
        }
        public UnidadeMedidaCentimetro Centimetro(int valor)
        {
            return new UnidadeMedidaCentimetro(valor);
        }
    }

    public class UnidadeMedidaPixel
    {
        private int _valor;

        public UnidadeMedidaPixel(int valor)
        {
            _valor = valor;
        }

        public double ToPoint()
        {
            return _valor * 0.75;
        }

        public double ToCentimetro(int dpi = 300)
        {
            return (_valor / dpi) * 2.5;
        }
    }

    public class UnidadeMedidaCentimetro
    {
        private double _valor;

        public UnidadeMedidaCentimetro(double valor)
        {
            _valor = valor;
        }

        public double ToPixel(int dpi = 300)
        {
            return (_valor * dpi) / 2.5;
        }
    }
}
