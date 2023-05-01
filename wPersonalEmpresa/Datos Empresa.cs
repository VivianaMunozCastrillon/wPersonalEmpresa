using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.IO;

namespace wPersonalEmpresa
{
    public partial class frmDatosEmpresa : Form
    {
        public frmDatosEmpresa()
        {
            InitializeComponent();
        }

        private Stream myStream; //Permite cargar informacion de mi archivo plano
        int count = 0; //Suma las lineas del archivo plano
        string line; //Esta sirve para que el datagridview cargue linea a linea

       

        private void btnCSV_Click(object sender, EventArgs e)
        {
            //Las matrices las vemos a través de arreglos
            string[] result;
            //Tamaño y cantidad de columnas.
            DataGridTextBoxColumn columnas = new DataGridTextBoxColumn();
            //columnas.HeaderText = "Columna1";
            columnas.Width = 200; //Ancho
            columnas.ReadOnly = true;//No escribir encima

            //Instancia el explorador de archivos
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            //Establece las extensiones para filtrar los archivos mediante el explorador de archivos.
            openFileDialog1.Filter = "Archivo(*.csv)| *.csv";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                          
                            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
                            //Realice las acciones dentro del while siempre y cuando las filas del archivo plano no esten vacias
                            while ((line = file.ReadLine()) != null)
                            {
                                result = line.Split(';');//split para datagridview, nos lea las lineas de las matrices 
                                //rows son las CELDAS Add adiciona las celdas 
                                dtgDatosEmpresa.Rows.Add(result[0], result[1], result[2], result[3], result[4], result[5], result[6]);
                                count++;
                            }
                            file.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    //Mensaje de salida en caso de error
                    MessageBox.Show("Error: No se puede encontrar el archivo, el formato no es compatible o tiene el archivo abierto" +
                        "en otra ventana");
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpia todas las filas del datagridview
            dtgDatosEmpresa.Rows.Clear();
        }

        private void btnLimpiarFila_Click(object sender, EventArgs e)
        {
            //Limpia las filas seleccionadas.
            //El try-catch evita que se detenga la ejecucion del programa si el usuario selecciona una fila sin datos.
            try
            {
                dtgDatosEmpresa.Rows.Remove(dtgDatosEmpresa.CurrentRow);
            }
            catch (Exception)
            {
                //Mensaje de salida en caso de error
                MessageBox.Show("Asegurese de estar seleccionando la fila que desea eliminar y tenga datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
