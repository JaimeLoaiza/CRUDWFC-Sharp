using CRUDWFC_Sharp.Modelos;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CRUDWFC_Sharp
{
    public partial class Form1_Crud : Form
    {
        public Form1_Crud()
        {
            InitializeComponent();
        }

        private void SplitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Form1_Crud_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        #region HELPER
        private void Refrescar()
        {
            using (CrudFinalEntities db = new CrudFinalEntities())
            {
                var lst = from d in db.Persona
                          select d;
                dataGridView1_Crud.DataSource = lst.ToList();
            }
        }

        private int? GetIdPersona()
        {
            try
            {
                return int.Parse(dataGridView1_Crud.Rows[dataGridView1_Crud.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private void Btnnuevo_Click(object sender, EventArgs e)
        {
            Presentación.formularioPersona oformularioPersona = new Presentación.formularioPersona();
            oformularioPersona.ShowDialog();

            Refrescar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            int? IdPersona = GetIdPersona();
            if (IdPersona != null)
            {
                Presentación.formularioPersona oformularioPersona = new Presentación.formularioPersona(IdPersona);
                oformularioPersona.ShowDialog();

                Refrescar();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int? IdPersona = GetIdPersona();
            if (IdPersona != null)
            {
                using (CrudFinalEntities db = new CrudFinalEntities())
                {
                    Persona oPersona = db.Persona.Find(IdPersona);
                    db.Persona.Remove(oPersona);

                    db.SaveChanges();
                }
                Refrescar();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
