using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication10
{   
    [Serializable]
    public class Texturas
    {

        int r;
        int g;
        int b;
        Color color;
        String tipo;//ropa o geografico
        String subtipo;

        public void guardar(int rr, int gg, int bb, Color c, String t, String st)
        {
            this.r = rr;
            this.g = gg;
            this.b = bb;
            this.color = c;
            this.tipo = t;
            this.subtipo = st;

        }
        public void mostrar()
        {
            Console.WriteLine(this.r + "  " + this.g + "  " + this.b);
        }

        public int getr()
        {
            return this.r;
        }
        public int getg()
        {
            return this.g;
        }
        public int getb()
        {
            return this.b;
        }
        public Color getColor()
        {
            return this.color;
        }
        public String getTipo()
        {
            return this.tipo;
        }
        public String getSubtipo()
        {
            return this.subtipo;
        }
    }
}
