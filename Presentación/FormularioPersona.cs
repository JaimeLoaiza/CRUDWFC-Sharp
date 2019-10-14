using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDWFC_Sharp.Modelos;

namespace CRUDWFC_Sharp.Presentación
{
    public partial class formularioPersona : Form
    {
        public int? idPersona;
        Persona oPersona = null;
        int Cedula;
        int Edad;

        public formularioPersona(int? IdPersona = null)
        {
            InitializeComponent();

            this.idPersona = idPersona;
            if (IdPersona != null)
                SubirDatos();
        }

        private void SubirDatos()
        {
            using (CrudFinalEntities db = new CrudFinalEntities())
            {
                oPersona = db.Persona.Find(idPersona);
                txtCedula.Text = Cedula;
                txtNombre.Text = oPersona.Nombre;
                txtApellido.Text = oPersona.Apellido;
                txtEdad.Text = oPersona.Edad;
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            using (CrudFinalEntities db = new CrudFinalEntities())
            {
                if(idPersona==null)
                       oPersona = new Persona();
                oPersona.idPersona = int.Parse(txtIdPersona.Text);
                oPersona.Cedula = int.Parse(txtCedula.Text);
                oPersona.Nombre = txtNombre.Text;
                oPersona.Apellido = txtApellido.Text;
                oPersona.Edad = int.Parse(txtEdad.Text);


                if(idPersona==null)
                    db.Persona.Add(oPersona);
                else
                {
                    db.Entry(oPersona).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();

                this.Close();
            }
        }

        private void FormularioPersona_Load(object sender, EventArgs e)
        {

        }
    }
}
