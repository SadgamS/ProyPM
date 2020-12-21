using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WindowsFormsApplication10
{
   [Serializable]
  public partial class Form1 : Form
    {
        // Variables Color
        int cR, cG, cB;
        int cmR, cmG, cmB;
        // Variables para guardar la cantidad de texturas
        double ntierra,nvegetacion, nnieve, nagua;

        double npantalon, nchompa, nzapato, npolera;

        double totalTex;

        List<Texturas> tex = new List<Texturas>();
        

        //imagen

        public Form1()
        {
            InitializeComponent();
            panel1.Visible=false;
            panel2.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imagenes JPG|*.jpg";
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
            ntierra = 0;
            nvegetacion = 0;
            nnieve = 0;
            nagua = 0;

            npantalon = 0;
            npolera = 0;
            nzapato = 0;
            nchompa = 0;

            ptierra.Text = "";
            pagua.Text = "";
            pvegetacion.Text = "";
            pnieve.Text = "";

            pchompa.Text = "";
            pzapato.Text = "";
            ppolera.Text = "";
            ppantalon.Text = "";

            panel2.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        // Click en Imagen para guardar
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(e.X, e.Y);
            cR = c.R;
            cG = c.G;
            cB = c.B;
            
            
            cmR = 0;
            cmG = 0;
            cmB = 0;
            for (int i = e.X; i < e.X + 5; i++)
                for (int j = e.Y; j < e.Y + 5; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cmR = cmR + c.R;
                    cmG = cmG + c.G;
                    cmB = cmB + c.B;
                }
            cmR = cmR / 25;
            cmG = cmG / 25;
            cmB = cmB / 25;
            textBox1.Text = cmR.ToString() + ", " + cmG.ToString() + ", " + cmB.ToString();
            label12.Text = textBox1.Text;
            label22.BackColor = Color.FromArgb(cmR,cmG,cmB);
            label22.ForeColor = Color.FromArgb(cmR, cmG, cmB);
            panel1.Visible = true;
           
        }

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //
            panel1.Visible = true;
            label12.Text = textBox1.Text;
        }
        // Boton guardar Textura
        private void button2_Click_2(object sender, EventArgs e)
        {
            Texturas t = new Texturas();
            t.guardar(cmR,cmG,cmB,lcolor2.BackColor,ltipo.Text,lcolor.Text);
            // guardamos en la lista
            tex.Add(t);
            ltipo.Text = "";
            lcolor.Text = "";
            lcolor2.BackColor = Color.White;
            lcolor2.ForeColor = Color.White;
            GuardarD(tex);
            panel1.Visible = false;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        // Boton Cancelar
        private void button5_Click_1(object sender, EventArgs e)
        {
            ltipo.Text = "";
            lcolor.Text = "";
            lcolor2.BackColor = Color.White;
            lcolor2.ForeColor = Color.White;
            panel1.Visible = false;

        }

        private void label5_Click(object sender, EventArgs e)
        {
            ltipo.Text = "Satelital";
            lcolor.Text = "Tierra";
            lcolor2.BackColor = Color.Chocolate;
            lcolor2.ForeColor = Color.Chocolate;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ltipo.Text = "Satelital";
            lcolor.Text = "Agua";
            lcolor2.BackColor = Color.Blue;
            lcolor2.ForeColor = Color.Blue;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ltipo.Text = "Satelital";
            lcolor.Text = "Vegetacion";
            lcolor2.BackColor = Color.Green;
            lcolor2.ForeColor = Color.Green;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ltipo.Text = "Satelital";
            lcolor.Text = "Nieve";
            lcolor2.BackColor = Color.DarkSlateGray;
            lcolor2.ForeColor = Color.DarkSlateGray;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            ltipo.Text = "Ropa";
            lcolor.Text = "Camisa";
            lcolor2.BackColor = Color.Red;
            lcolor2.ForeColor = Color.Red;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            ltipo.Text = "Ropa";
            lcolor.Text = "Chompa";
            lcolor2.BackColor = Color.Yellow;
            lcolor2.ForeColor = Color.Yellow;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            ltipo.Text = "Ropa";
            lcolor.Text = "Pantalon";
            lcolor2.BackColor = Color.Magenta;
            lcolor2.ForeColor = Color.Magenta;
        }

        private void label16_Click(object sender, EventArgs e)
        {
            ltipo.Text = "Ropa";
            lcolor.Text = "Zapatos";
            lcolor2.BackColor= Color.FromArgb(128, 255, 128);
            lcolor2.ForeColor = Color.FromArgb(128, 255, 128);
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        // Boton de Clasificar
        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            ptierra.Text = "";
            pagua.Text = "";
            pvegetacion.Text = "";
            pnieve.Text = "";
            pgeo.Text = "";

            pchompa.Text = "";
            pzapato.Text = "";
            ppolera.Text = "";
            ppantalon.Text = "";
            propa.Text = "";
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            ntierra = 0;
            nvegetacion = 0;
            nnieve = 0;
            nagua = 0;

            npantalon = 0;
            npolera = 0;
            nzapato = 0;
            nchompa = 0;
            if (existeArch())
            {
                tex = obtener();
            }
            foreach (Texturas obj in tex)
               bmp= pintar(obj.getr(), obj.getg(), obj.getb(), obj.getColor(),obj.getSubtipo(),bmp);

            //calculos
            ptierra.Text = ""+((ntierra/totalTex)*100).ToString("0.##")+"%";
            pvegetacion.Text = "" + ((nvegetacion/totalTex)*100).ToString("0.##") + "%";
            pagua.Text = "" + ((nagua / totalTex)*100).ToString("0.##") + "%";
            pnieve.Text = "" + ((nnieve / totalTex)*100).ToString("0.##") + "%";

            pchompa.Text = "" + ((nchompa / totalTex)*100).ToString("0.##") + "%";
            pzapato.Text = "" + ((nzapato / totalTex)*100).ToString("0.##") + "%";
            ppolera.Text = "" + ((npolera / totalTex)*100).ToString("0.##") + "%";
            ppantalon.Text = "" + ((npantalon / totalTex)*100).ToString("0.##") + "%";

            pgeo.Text = "" + (((ntierra + nnieve + nagua + nvegetacion) / totalTex)*100).ToString("0.##") + "%";
            propa.Text = "" + (((npantalon+npolera+nzapato+nchompa) / totalTex)*100).ToString("0.##") + "%";

            if (((ntierra + nnieve + nagua + nvegetacion) / totalTex)> ((npantalon + npolera + nzapato + nchompa) / totalTex))
            {
                decision.Text = "Imagen de tipo Satelital";
            }
            else
            {
                decision.Text = "Imagen de tipo Ropa";
            }

            panel2.Visible = true;
        }

        //Funcion para pintar
        private Bitmap pintar(int r,int g, int b,Color color,String st,Bitmap bmp)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            int ciR, ciG, ciB;
            totalTex = 0;
            for (int i = 0; i < bmp.Width -5; i = i + 5)
                for (int j = 0; j < bmp.Height-5 ; j = j + 5)
                {
                    totalTex++;

                    ciR = 0;
                    ciG = 0;
                    ciB = 0;
                    for (int x = i; x < i + 5; x++)
                        for (int y = j; y < j + 5; y++)
                        {
                            c = bmp.GetPixel(x, y);
                            ciR = ciR + c.R;
                            ciG = ciG + c.G;
                            ciB = ciB + c.B;
                        }
                    ciR = ciR / 25;
                    ciG = ciG / 25;
                    ciB = ciB / 25;
                    
                    if (((r - 15 < ciR) && (ciR < r + 15)) && ((g - 15 < ciG) && (ciG < g + 15)) && ((b - 15 < ciB) && (ciB < b + 15)))
                    {
                        //contar tipo de textura
                        if (st == "Agua")
                            nagua++;
                        if (st == "Tierra")
                            ntierra++;
                        if (st == "Nieve")
                            nnieve++;
                        if (st == "Vegetacion")
                            nvegetacion++;

                        if (st == "Chompa")
                            nchompa++;
                        if (st == "Camisa")
                            npolera++;
                        if (st == "Zapatos")
                            nzapato++;
                        if (st == "Pantalon")
                            npantalon++;
                        for (int x = i; x < i + 5; x++)
                            for (int y = j; y < j + 5; y++)
                            {
                                bmp2.SetPixel(x, y, color);
                            }
                    }
                    else
                    {

                        for (int x = i; x < i + 5; x++)
                            for (int y = j; y < j + 5; y++)
                            {
                                c = bmp.GetPixel(x, y);
                                bmp2.SetPixel(x, y, Color.FromArgb(c.R, c.G, c.B));
                            }

                    }

                }
            pictureBox1.Image = bmp2;
            bmp = new Bitmap(pictureBox1.Image);
            return bmp;
        }

        // Eliminar datos
        private void button3_Click_2(object sender, EventArgs e)
        {
            List<Texturas> g = new List<Texturas>();
            GuardarD(g);
            MessageBox.Show("  Datos eliminados  ");
         
        }

    
        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void titulo_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
        // Eliminar Objetos de tipo Ropa
        private void button6_Click_1(object sender, EventArgs e)
        {
            List<Texturas> aux = new List<Texturas>();
            foreach (Texturas i in tex)
            {
                if (i.getTipo() != "Satelital")
                    aux.Add(i);
            }
            this.tex = aux;
            GuardarD(tex);
        }
        // Eliminar Objetos de tipo Satelital
        private void button7_Click(object sender, EventArgs e)
        {
            List<Texturas> aux = new List<Texturas>();
            foreach (Texturas i in tex)
            {
                if (i.getTipo() != "Ropa")
                    aux.Add(i);
            }
            this.tex = aux;
            GuardarD(tex);
        }

        //Guardar en un archivo
        private static void GuardarD(List<Texturas> lista)
        {
            FileStream fs = new FileStream("datos.txt",FileMode.Create);
            BinaryFormatter fo = new BinaryFormatter();
            fo.Serialize(fs,lista);
            fs.Close();
        }
        // Sacar los datos del archivo
        private static List<Texturas> obtener()
        {
            FileStream fs = new FileStream("datos.txt",FileMode.Open);
            BinaryFormatter fo = new BinaryFormatter();
            List<Texturas> t = fo.Deserialize(fs) as List<Texturas>;
            fs.Close();
            return t;
        }
        // Preguntar Archivos
        private static bool existeArch()
        {
            try
            {
                FileStream fs = new FileStream("datos.txt", FileMode.Open);
                BinaryFormatter fo = new BinaryFormatter();
                List<Texturas> t = fo.Deserialize(fs) as List<Texturas>;
                fs.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }
    
    }
}
