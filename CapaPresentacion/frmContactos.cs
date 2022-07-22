using Entidad;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmContactos : Form
    {
        string cModo = "Inicio";
        public frmContactos()
        {
            InitializeComponent();
        }

        private void frmContactos_Load(object sender, EventArgs e)
        {
            Inicir();
        }
        private void Inicir()
        {
            cboEstado.SelectedIndex = 0;
            cModo = "Inicio";
            Botones();
            DesHabilitar();
            Limpiar();
            LlenarGrid(0);



        }
        private void DesHabilitar()
        {
            txtApellido.Enabled = false;
            txtApellido.ReadOnly = true;

            txtCelular.Enabled = false;
            txtCelular.ReadOnly = true;

            txtDireccion.Enabled = false;
            txtDireccion.ReadOnly = true;

            txtEmail.Enabled = false;
            txtEmail.ReadOnly = true;

            txtNombre.Enabled = false;
            txtNombre.ReadOnly = true;

            txtTelefono.Enabled = false;
            txtTelefono.ReadOnly = true;

            rdoF.Enabled = false;
            rdoM.Enabled = false;
            cboEstado.Enabled = false;
        }

        private void Habilitar()
        {
            txtApellido.Enabled = true;
            txtApellido.ReadOnly = false;

            txtCelular.Enabled = true;
            txtCelular.ReadOnly = false;

            txtDireccion.Enabled = true;
            txtDireccion.ReadOnly = false;

            txtEmail.Enabled = true;
            txtEmail.ReadOnly = false;

            txtNombre.Enabled = true;
            txtNombre.ReadOnly = false;

            txtTelefono.Enabled = true;
            txtTelefono.ReadOnly = false;

            rdoF.Enabled = true;
            rdoM.Enabled = true;
            cboEstado.Enabled = true;
        }

        private void Limpiar()
        {
            txtIdContacto.Text = "";
            txtApellido.Text = "";
            txtCelular.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
           
        }

        public void Botones()
        {

            switch (cModo)
            {

                case "Inicio":
                    this.cmdBorrar.Enabled = false;
                    this.cmdGrabar.Enabled = false;
                    this.cmdNuevo.Enabled = true;
                    this.cmdSalir.Enabled = true;
                    this.cmdEditar.Enabled = true;
                    this.cmdCancelar.Enabled = false;
                    break;
                case "Nuevo":
                    this.cmdBorrar.Enabled = false;
                    this.cmdCancelar.Enabled = true;
                    this.cmdGrabar.Enabled = true;
                    this.cmdNuevo.Enabled = false;
                    this.cmdEditar.Enabled = false;
                    this.cmdSalir.Enabled = true;

                    break;

                case "Grabar":
                    this.cmdBorrar.Enabled = false;
                    this.cmdCancelar.Enabled = false;
                    this.cmdGrabar.Enabled = false;
                    this.cmdNuevo.Enabled = true;
                    this.cmdSalir.Enabled = true;
                    this.cmdEditar.Enabled = false;
                    break;

                case "Eliminar":
                    this.cmdBorrar.Enabled = false;
                    this.cmdCancelar.Enabled = false;
                    this.cmdGrabar.Enabled = false;
                    this.cmdNuevo.Enabled = true;
                    this.cmdSalir.Enabled = true;
                    break;

                case "Cancelar":
                    this.cmdBorrar.Enabled = false;
                    this.cmdCancelar.Enabled = false;
                    this.cmdGrabar.Enabled = false;
                    this.cmdNuevo.Enabled = true;
                    this.cmdSalir.Enabled = true;
                    break;

                case "Buscar":
                    this.cmdBorrar.Enabled = true;
                    this.cmdCancelar.Enabled = true;
                    this.cmdGrabar.Enabled = false;
                    this.cmdNuevo.Enabled = false;
                    this.cmdSalir.Enabled = true;
                    this.cmdEditar.Enabled = true;
                    break;

                case "Actualizar":
                    this.cmdBorrar.Enabled = true;
                    this.cmdCancelar.Enabled = true;
                    this.cmdGrabar.Enabled = true;
                    this.cmdNuevo.Enabled = false;
                    this.cmdSalir.Enabled = true;
                    this.cmdEditar.Enabled = false;
                    break;


                default:
                    this.cmdBorrar.Enabled = false;

                    this.cmdCancelar.Enabled = false;
                    this.cmdGrabar.Enabled = false;
                    this.cmdNuevo.Enabled = true;
                    this.cmdSalir.Enabled = true;
                    this.cmdEditar.Enabled = false;
                    break;
            }
        } // fin Botones
        private void LlenarGrid(int nId)
        {

            try
            {
                LNegocio oLogica = new LNegocio();

                DataTable dtDatos = oLogica.CargarDatos(nId);
                string cSexo = "";
                string cGenero = "";
                dgvAgenda.Rows.Clear();
                foreach (DataRow contacto in dtDatos.Rows)
                {
                    cSexo = Convert.ToString(contacto["Genero"]);
                    switch (cSexo)
                    {
                        case "M":
                            cGenero = "Masculino";
                            break;
                        case "F":
                            cGenero = "Femenino";
                            break;
                        default:
                            break;
                    }
                    dgvAgenda.Rows.Add(Convert.ToString(contacto["Nombre"]), Convert.ToString(contacto["Apellido"]), Convert.ToString(contacto["FechaNac"]), cGenero,
                        Convert.ToString(contacto["Telefono"]), Convert.ToString(contacto["Celular"]), Convert.ToString(contacto["Direccion"]), Convert.ToString(contacto["Email"]),
                        Convert.ToString(contacto["IdContacto"]));
                }
            }
            catch (Exception ex)
            {

                string cMensajeError = ex.Message + ", " + ((ex.InnerException != null) ? ex.InnerException.Message.Trim() : "").ToString();
                MessageBox.Show("Error Llenando Grid: " + cMensajeError, "", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
               
            }
          
        }
        private void BuscarContacto(int nId)
        {
            try
            {
                string cSexo = "";
                LNegocio oLogica = new LNegocio();

                DataTable dtDatos = oLogica.CargarDatos(nId);
                foreach (DataRow contacto in dtDatos.Rows)
                {
                    txtIdContacto.Text = contacto["IdContacto"].ToString();
                    txtNombre.Text = contacto["Nombre"].ToString();
                    txtApellido.Text = contacto["Apellido"].ToString();
                    txtDireccion.Text = contacto["Direccion"].ToString();
                    txtTelefono.Text = contacto["Telefono"].ToString();
                    txtCelular.Text = contacto["Celular"].ToString();
                    txtEmail.Text = contacto["Email"].ToString();
                    cboEstado.SelectedIndex = Convert.ToInt32(contacto["EstadoCivil"].ToString());
                    cSexo = contacto["Genero"].ToString();
                    switch (cSexo)
                    {
                        case "M":
                            rdoM.Checked = true;
                            rdoF.Checked = false;
                            break;
                        case "F":
                            rdoF.Checked = true;
                            rdoM.Checked = false;
                            break;
                        default:
                            break;
                    }
                }
                
            }
            catch (Exception ex)
            {

                string cMensajeError = ex.Message + ", " + ((ex.InnerException != null) ? ex.InnerException.Message.Trim() : "").ToString();
                MessageBox.Show("Error Buscando Contacto: " + cMensajeError, "", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
                
            }
        }

        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            cModo = "Nuevo";
            Botones();
            Habilitar();
            Limpiar();
            txtNombre.Focus();
        }

        private void cmdGrabar_Click(object sender, EventArgs e)
        {
            try
            {

                if (cModo == "Nuevo")
                {
                    string cSexo = "";
                    LNegocio oLogica = new LNegocio();
                    List<EContacto> oContactos = new List<EContacto>();
                    if (rdoF.Checked)
                    {
                        cSexo = "F";
                    }
                    if (rdoM.Checked)
                    {
                        cSexo = "M";
                    }
                    string cEstadoCivil = cboEstado.SelectedIndex.ToString();
                    EContacto oContacto = new EContacto
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        FechaNac = Convert.ToDateTime(dtFecha.Value.ToString("yyyy-MM-dd")),
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Celular = txtCelular.Text,
                        Email = txtEmail.Text,
                        EstadoCivil = Convert.ToChar(cEstadoCivil),
                        Genero = cSexo,
                    };
                    oLogica.InsertarContacto(oContacto);

                    MessageBox.Show("Contacto Insertado Correctamente!!!");
                    LlenarGrid(0);
                    Limpiar();
                    Inicir();
                }
                if (cModo == "Actualizar")
                {
                    string cSexo = "";
                    LNegocio oLogica = new LNegocio();
                    //List<EContacto> oContactos = new List<EContacto>();
                    if (rdoF.Checked)
                    {
                        cSexo = "F";
                    }
                    if (rdoM.Checked)
                    {
                        cSexo = "M";
                    }
                    string cEstadoCivil = cboEstado.SelectedIndex.ToString();
                    EContacto oContacto = new EContacto
                    {

                        IdContacto = Convert.ToInt32(txtIdContacto.Text),
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        FechaNac = Convert.ToDateTime(dtFecha.Value.ToString("yyyy-MM-dd")),
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Celular = txtCelular.Text,
                        Email = txtEmail.Text,
                        EstadoCivil = Convert.ToChar(cEstadoCivil),
                        Genero = cSexo,
                    };
                    oLogica.ActualizarContacto(oContacto);
                    MessageBox.Show("Contacto Actualizado Correctamente Correctamente!!!");
                    LlenarGrid(0);
                    Limpiar();
                    Inicir();
                }
            }
            catch (Exception ex)
            {
                string cMensajeError = ex.Message + ", " + ((ex.InnerException != null) ? ex.InnerException.Message.Trim() : "").ToString();
                MessageBox.Show("Error Llenando Grid: " + cMensajeError, "", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow IdCont = dgvAgenda.CurrentRow;
            int nId = Convert.ToInt32(IdCont.Cells["idcontacto"].Value);
            if (nId > 0)
            {
                cModo = "Actualizar";
                Botones();
                Limpiar();
                BuscarContacto(nId);
                Habilitar();
            }
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {

            if (cModo == "Actualizar")
            {
                LNegocio oLogica = new LNegocio();
                var oResponse = MessageBox.Show("Seguro que desea Eliminar Este Contacto??", "Borrar Contacto",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (oResponse == DialogResult.Yes)
                {
                    oLogica.BorrarContacto(Convert.ToInt32(txtIdContacto.Text));
                    MessageBox.Show("Contacto Eliminado Correctamente!!!");
                    LlenarGrid(0);
                    Limpiar();
                    Inicir();
                }
              
            }
           

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Inicir();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            var oResponse = MessageBox.Show("Seguro que desea Salir del Sistema??", "Salir del Sistema",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (oResponse == DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }
    }
}
