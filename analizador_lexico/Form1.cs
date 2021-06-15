using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_calc
{
    public partial class Form1 : Form
    {
    
        static private List<Token> lis_toks;
        public Form1()
        {
            InitializeComponent();
          
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void b_correr_Click(object sender, EventArgs e)
        {
            //capturo el texto que posee el richtextbox y llamo la clase para analizarlo
            String texto;
            texto = richTextBox1.Text;
            Analizador analiz = new Analizador();
            analiz.Analizador_cadena(texto);

            analiz.generarLista();
            comen.Text = analiz.getRetorno();

            //Llamo mi clase lista en donde recorro los valores ya guardados
            lis_toks = new List<Token>();
            lis_toks = analiz.getListaTokens();

            //voy mostrando en pantalla
            for (int i = 0; i < lis_toks.Count; i++)
            {
                Token actual = lis_toks.ElementAt(i);
                
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

   

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        
        

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
   
        }

        private void analizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.b_correr_Click(sender, e );
        }
    }
}
