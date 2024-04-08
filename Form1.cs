using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Laboratorio__8
{
    public partial class Form1 : Form
    {
        List<int> notasTemporales = new List<int>();
        List<NotasAlumno> listaNotas = new List<NotasAlumno>();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAgregarNota_Click(object sender, EventArgs e)
        {
            int nota = Convert.ToInt32(textBoxNota.Text);

            notasTemporales.Add(nota);
            textBoxNota.Clear();
        }

        private void Grabar()
        {
            //Se serializa (convierte) la lista en formato Json y se guarda en una variable de tipo string
            string json = JsonConvert.SerializeObject(listaNotas);

            //El nombre del archivo
            string archivo = "Datos.json";

            //Se escribe la variable que contiene el json al archivo en un solo paso
            //con WriteAllText se escribe todo de un solo
            System.IO.File.WriteAllText(archivo, json);
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            //Guarda a un alumno con  sus notas
            NotasAlumno notasAlumno = new NotasAlumno();

            notasAlumno.Nombre = textBoxNombre.Text;
            notasAlumno.Notas = notasTemporales.GetRange(0,notasTemporales.Count);

            //Guarda a ese alumno en el listado de notas de alumnos
            listaNotas.Add(notasAlumno);
            Grabar();
            //Borrar las nota temporales para el próximo alumno
            notasTemporales.Clear();
        }
    }
}
