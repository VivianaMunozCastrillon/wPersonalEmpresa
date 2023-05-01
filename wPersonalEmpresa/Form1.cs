using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// Nombres: Viviana Muñoz Castrillon, Laura Serena Rivera Mejía
/// Fecha: 30-04-2023
/// Descripcion: Este programa instancia formularios a través del MenuStrip y carga archivos 
/// con informacion en un dataGridView.
///


namespace wPersonalEmpresa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tmrHoraFecha_Tick(object sender, EventArgs e)
        {
            //Reemplaza los valores del label y establece la fecha y hora en tiempo real.
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Llama al formulario datos empresa mediante el formulario padre.
            frmDatosEmpresa FrmDatosEmpresa = new frmDatosEmpresa();
            FrmDatosEmpresa.MdiParent = this;
            FrmDatosEmpresa.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmDatosEmpresa = this.ActiveMdiChild;
            //Si la ventana hijo no existe cierre la ventana padre.
            if (frmDatosEmpresa != null)
            {
                frmDatosEmpresa.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Finaliza el programa
            this.Close();
        }
    }
}
