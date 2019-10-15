using CRUDWFC_Sharp.Modelos;
using System;
using System.Windows.Forms;

namespace CRUDWFC_Sharp.Presentación
{
    public partial class formularioPersona : Form
    {
        public int? idPersona;
        Persona oPersona = null;

        public formularioPersona(int? IdPersona = null)
        {
            InitializeComponent();

            this.idPersona = IdPersona;
            if (IdPersona != null)
                SubirDatos();
        }

        private void SubirDatos()
        {
            using (CrudFinalEntities db = new CrudFinalEntities())
            {
                oPersona = db.Persona.Find(idPersona);
                oPersona.Cedula = int.Parse(txtCedula.Text);
                oPersona.Nombre = txtNombre.Text;
                oPersona.Apellido = txtApellido.Text;
                oPersona.Edad = int.Parse(txtEdad.Text);
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            using (CrudFinalEntities db = new CrudFinalEntities())
            {
                if (idPersona == null)
                    oPersona = new Persona();
                oPersona.Cedula = int.Parse(txtCedula.Text);
                oPersona.Nombre = txtNombre.Text;
                oPersona.Apellido = txtApellido.Text;
                oPersona.Edad = int.Parse(txtEdad.Text);


                if (idPersona == null)
                    db.Persona.Add(oPersona);
                else
                {
                    db.Entry(idPersona).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();

                this.Close();
            }
        }

        private void FormularioPersona_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();
        }

        private void Btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
