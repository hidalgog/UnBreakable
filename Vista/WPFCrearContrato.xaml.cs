﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using BibliotecaNegocio;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para Crear_Contrato.xaml
    /// </summary>
    public partial class Crear_Contrato : MetroWindow
    {
      
        double uf = new Servicios.Service1().Uf();

        public Crear_Contrato()
        {

            InitializeComponent();
            lblNumero.Content =  DateTime.Now.ToString("yyyyMMddHHmm");
            lblUf.Content = "$" + uf;
            this.cboTipo.SelectedItem = null;
            btnTerminar.Visibility = Visibility.Hidden;
            btnModificar.Visibility = Visibility.Hidden;

            //LLENAR COMBO BOX TIPO EVENTO
            foreach (TipoEvento item in new TipoEvento().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id;
                cb.descripcion = item.Descripcion;
                cboTipo.Items.Add(cb);
            }
          
           

            //LLENAR CB MODALIDAD SERVICIO

            foreach (ModalidadServicio item in new ModalidadServicio().ReadAll())
            {
                comboBoxItem2 cb = new comboBoxItem2();
                cb.id = item.Id;
                cb.descripcion = item.Nombre;
                cbModalidad.Items.Add(cb);
            }
         

        }

        double valorc= 2;

        DateTime fechac = DateTime.Now;
        DateTime fechat = DateTime.Now;
        //CREAR CONTRATO
        private async void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (dpFechaInicio.SelectedDate <= dpFechaFinEvento.SelectedDate)
                {
                   
                    String numero = lblNumero.Content.ToString();
                    DateTime creacion = fechac;
                    bool realizado ;
                    DateTime termino;
                    if (rbSi.IsChecked == true)
                    {
                        realizado = false;
                        termino = dpFechaTermino.recuperarFecha();

                    }
                    else
                    {
                        realizado = true;
                        termino = dpFechaTermino.recuperarFecha();

                    }


                    //EVENTO

                    //inicio
                    DateTime fechaHoraInicio = dpFechaInicio1.recuperar();

                    DateTime fechaHoraTermino = dpFechaTermino.recuperar();
                 

                    //////
             
                    int asistentes = 0;
                    if (int.TryParse(txtNumeroAsistentes.Text, out asistentes))
                    {

                    }
                    else
                    {
                        await this.ShowMessageAsync("Mensaje:",
                          string.Format("Ingrese sólo números"));
                        txtNumeroAsistentes.Focus();
                        return;
                    }

                    int personalAdicional = 0;
                    if (int.TryParse(txtPersonalAdicional.Text, out personalAdicional))
                    {

                    }
                    else
                    {
                        await this.ShowMessageAsync("Mensaje:",
                          string.Format("Ingrese sólo números"));
                        txtPersonalAdicional.Focus();
                        return;
                    }

                    //CB
                    int evento = ((comboBoxItem)cboTipo.SelectedItem).id;
                    string idMod = ((comboBoxItem2)cbModalidad.SelectedItem).id;

                    String observaciones = txtObservaciones.Text;
                    String rutCliente = txtBuscarCliente.Text;

                    Contrato con = new Contrato()
                    {

                        Numero = numero,
                        Creacion = creacion,
                        Termino = termino,
                        RutCliente = rutCliente,
                        IdModalidad= idMod,
                        IdTipoEvento =evento,
                        FechaHoraInicio = fechaHoraInicio,
                        FechaHoraTermino = fechaHoraTermino,
                        Asistentes = asistentes,
                        PersonalAdicional = personalAdicional,
                        Realizado = realizado,
                        ValorTotalContrato=valorc,
                        Observaciones = observaciones,
                        
                    };

                    //METODO AGREGAR DEVUELVE BOOLEAN POR ESO SE CREA VARIABLE BOOLEANA resp
                    bool resp = con.Grabar();
                    await this.ShowMessageAsync("Mensaje:",
                          string.Format(resp ? "Guardado" : "No guardado"));
                    /*MessageBox.Show(resp ? "Guardado" : "No Guardado");*/
                    

                    btnModificar.Visibility=Visibility.Visible;
                }
               /* else
               / {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error: Fecha de Termino es menor a Fecha de Inicio"));
                }*/
            }
            catch (ArgumentException exa) //catch excepciones hechas por el usuario
            {
                await this.ShowMessageAsync("Mensaje:",string.Format((exa.Message)));
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                /*MessageBox.Show("Error de ingreso de datos");*/
                Logger.Mensaje(ex.Message);
            }

           


        }

       
        //limpiar
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {


            txtBuscarCliente.Clear();
            lblNombreCliente.Visibility = Visibility.Hidden;//desaparecer label
            txtNumero.Clear();
            lblNumero.Content = DateTime.Now.ToString("yyyyMMddHHmm");
            txtBuscarCliente.Clear();
            lblNombreCliente.Visibility = Visibility.Hidden;//no ver label


            //dpFechaInicio.SelectedDate = null;
            //dpFechaFinEvento.SelectedDate = null;
            //dpFechaInicio1.ClearValue(DatePicker);
           // dpFechaTermino.ClearValue(DatePicker);
            cboTipo.SelectedItem = 0;

            txtNumeroAsistentes.Clear();
            txtPersonalAdicional.Clear();

            txtObservaciones.Clear();
            txtBuscarCliente.Focus();
            rbSi.IsChecked = true;
            rbNo.IsChecked = false;

            ////DESBLOQUEAR EDITAR EL CONTRATO
            if (!txtBuscarCliente.IsEnabled)
            {
                txtNumero.IsEnabled = true;
                txtBuscarCliente.IsEnabled = true;
                txtNumero.IsEnabled = true;
                //Convert.ToDateTime(txtNumero).ToString("dd/MM/yyyy HH:mm")
                txtNumero.IsEnabled = true;
                txtBuscarCliente.IsEnabled = true;
                lblNumero.IsEnabled = true;
                //EVENTO
                //inicio
               // dpFechaInicio.IsEnabled = true;
               // txtHoraInicio.IsEnabled = true;
                //txtMinutoInicio.IsEnabled = true;
                //termino
                //dpFechaFinEvento.IsEnabled = true;
                //txtHoraTermino.IsEnabled = true;
                //txtMinutoTermino.IsEnabled = true;
                //////
                txtNumeroAsistentes.IsEnabled = true;
                txtPersonalAdicional.IsEnabled = true;
                cboTipo.IsEnabled = true;
                txtObservaciones.IsEnabled = true;
                txtBuscarCliente.IsEnabled = true;
            }




        }

        //listar numero contrato
        private void btnListadoNum_Click(object sender, RoutedEventArgs e)
        {
            ListarContrato con = new ListarContrato(this);
            con.Show();
            btnTerminar.Visibility = Visibility.Visible;

        }

        //listar cliente
        private void btnListadoCliente_Click(object sender, RoutedEventArgs e)
        {
            wpfListadoCliente cli = new wpfListadoCliente(this);
            cli.Show();

        }
        
        //salir
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ////DESBLOQUEAR EDITAR EL CONTRATO
            if (!txtBuscarCliente.IsEnabled)
            {
                txtNumero.IsEnabled = true;
                txtBuscarCliente.IsEnabled = true;
                txtNumero.IsEnabled = true;
                //Convert.ToDateTime(txtNumero).ToString("dd/MM/yyyy HH:mm")
                txtNumero.IsEnabled = true;
                txtBuscarCliente.IsEnabled = true;
                lblNumero.IsEnabled = true;
                //EVENTO
                //inicio
               // dpFechaInicio.IsEnabled = true;
               // txtHoraInicio.IsEnabled = true;
                //txtMinutoInicio.IsEnabled = true;
                //termino
                //dpFechaFinEvento.IsEnabled = true;
               // txtHoraTermino.IsEnabled = true;
                //txtMinutoTermino.IsEnabled = true;
                //////
       
                txtNumeroAsistentes.IsEnabled = true;
                txtPersonalAdicional.IsEnabled = true;
                cboTipo.IsEnabled = true;
                txtObservaciones.IsEnabled = true;
                txtBuscarCliente.IsEnabled = true;
            }
            this.Close();
        }


   
        //BUSCAR CONTRATO
        private async void btnBuscarContrato_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato c = new Contrato();
                c.Numero = txtNumero.Text;
                bool buscar = c.Buscar();
                if (buscar)
                {
                    
                    
                    txtBuscarCliente.Text = c.RutCliente;
                    //dpFechaInicio.Text = c.FechaHoraInicio.ToString();
                    //dpFechaFinEvento.Text = c.FechaHoraTermino.ToString();
                    txtNumeroAsistentes.Text = c.Asistentes.ToString();
                    txtPersonalAdicional.Text = c.PersonalAdicional.ToString();
                    cboTipo.Text = c.IdTipoEvento.ToString();
                    cbModalidad.Text = c.IdModalidad;
                    txtObservaciones.Text = c.Observaciones;
                    lblNumero.Content = txtNumero.Text; //IGUALAR CAMPOS 
                    btnModificar.Visibility = Visibility.Visible;
                    btnTerminar.Visibility = Visibility.Visible;
                    
                    
                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("Contrato no encontrado"));
                    /*MessageBox.Show("Contrato no Encontrado");*/
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al Buscar"));
                /*MessageBox.Show("Error al buscar");*/
                Logger.Mensaje(ex.Message);

            }

        }

        //MÉTODO BUSCAR CONTRATO

        public async void BuscarContrato()
        {
            try
            {
                Contrato c = new Contrato();
                c.Numero = txtNumero.Text;
                bool buscar = c.Buscar();
                if (buscar)
                {


                    txtBuscarCliente.Text = c.RutCliente;
                    //dpFechaInicio.Text = c.FechaHoraInicio.ToString();
                    //dpFechaFinEvento.Text = c.FechaHoraTermino.ToString();
                    //txtHoraInicio.Text = c.HoraInicio.ToString();
                    //txtMinutoInicio.Text = c.MinutoInicio.ToString();
                    //txtHoraTermino.Text = c.HoraTermino.ToString();
                    //txtMinutoTermino.Text = c.MinutoTermino.ToString();
                    txtNumeroAsistentes.Text = c.Asistentes.ToString();
                    txtPersonalAdicional.Text = c.PersonalAdicional.ToString();
                    cboTipo.Text = c.IdTipoEvento.ToString();
                    cbModalidad.Text = c.IdModalidad;
                    txtObservaciones.Text = c.Observaciones;
                    lblNumero.Content = txtNumero.Text; //IGUALAR CAMPOS 
                    btnModificar.Visibility = Visibility.Visible;
                    btnTerminar.Visibility = Visibility.Visible;
                    

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("Contrato no encontrado"));
                    /*MessageBox.Show("Contrato no Encontrado");*/
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al Buscar"));
                /*MessageBox.Show("Error al buscar");*/
                Logger.Mensaje(ex.Message);
            }

        }

        //BUSCAR CLIENTE
        private async void btnCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente c = new Cliente();
                c.RutCliente = txtBuscarCliente.Text;
                bool buscar = c.Buscar();
                if (buscar)
                {
                   
                    lblNombreCliente.Content = c.NombreContacto;

                    lblNombreCliente.Visibility = Visibility.Visible;//aparecer label

                    lblNombreCliente.Visibility = Visibility.Visible;//ver label

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                     string.Format("Cliente no encontrado"));
                    /*MessageBox.Show("Cliente no Encontrado");*/
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al Buscar"));
                /*MessageBox.Show("Error al buscar");*/
                Logger.Mensaje(ex.Message);

            }
        }

        public async void Buscar()
        {
            try
            {
                Cliente c = new Cliente();
                c.RutCliente = txtBuscarCliente.Text;
                bool buscar = c.Buscar();
                if (buscar)
                {
                    lblNombreCliente.Content = c.NombreContacto;
                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                     string.Format("Cliente no encontrado"));
                    /*MessageBox.Show("Cliente no Encontrado");*/
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al Buscar"));
                /*MessageBox.Show("Error al buscar");*/
                Logger.Mensaje(ex.Message);

            }
        }

        //MODIFICAR
        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

               // if (dpFechaInicio.SelectedDate <= dpFechaFinEvento.SelectedDate)
                {
                    String numero = lblNumero.Content.ToString();
                    DateTime creacion = fechac;
                    bool realizado;
                    DateTime termino;
                    if (rbSi.IsChecked == true)
                    {
                        realizado = false;
                        termino = dpFechaTermino.recuperarFecha();

                    }
                    else
                    {
                        realizado = true;
                        termino = dpFechaTermino.recuperarFecha();



                    }


                    //////

                    int asistentes = 0;
                    if (int.TryParse(txtNumeroAsistentes.Text, out asistentes))
                    {

                    }
                    else
                    {
                        await this.ShowMessageAsync("Mensaje:",
                          string.Format("Ingrese sólo números"));
                        txtNumeroAsistentes.Focus();
                        return;
                    }

                    int personalAdicional = 0;
                    if (int.TryParse(txtPersonalAdicional.Text, out personalAdicional))
                    {

                    }
                    else
                    {
                        await this.ShowMessageAsync("Mensaje:",
                          string.Format("Ingrese sólo números"));
                        txtPersonalAdicional.Focus();
                        return;
                    }

                    //CB
                    int evento = ((comboBoxItem)cboTipo.SelectedItem).id;
                    string idMod = ((comboBoxItem2)cbModalidad.SelectedItem).id;

                    String observaciones = txtObservaciones.Text;
                    String rutCliente = txtBuscarCliente.Text;

                    Contrato nuevo_con = new Contrato()
                    {

                        Numero = numero,
                        Creacion = creacion,
                        Termino = termino,
                        RutCliente = rutCliente,
                        IdModalidad =idMod,
                        IdTipoEvento = evento,
                        FechaHoraInicio = dpFechaInicio1.recuperar(),
                        FechaHoraTermino = dpFechaTermino.recuperar(),
                        Asistentes = asistentes,
                        PersonalAdicional = personalAdicional,
                        Realizado = realizado,
                        ValorTotalContrato =valorc,
                        Observaciones = observaciones,
                    };

                    //METODO AGREGAR DEVUELVE BOOLEAN POR ESO SE CREA VARIABLE BOOLEANA resp
                    bool resp = nuevo_con.Modificar();
                    await this.ShowMessageAsync("Mensaje:",
                          string.Format(resp ? "Contrato Modificado" : "Contrato No Modificado"));
                    /*MessageBox.Show(resp ? "Contrato Modificado" : "Contrato No Modificado");*/


                }
            }
            catch (ArgumentException exa) //catch excepciones hechas por el usuario
            {
                MessageBox.Show(exa.Message);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error"));
                /*MessageBox.Show("Error");*/
                Logger.Mensaje(ex.Message);
            }

        }

        //TERMINAR CONTRATO
        private async void btnTerminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var x =
             await this.ShowMessageAsync("Advertencia", "¿Desea Dar Término al Contrato?",
                     MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {

                    String numero = lblNumero.Content.ToString();
                    DateTime creacion = fechac;
                    bool realizado = true;
                    DateTime termino = fechat;
                    rbNo.IsChecked = true;
                    rbSi.IsChecked = false;

                    

                    //EVENTO

                    //inicio
                    DateTime fechaHoraInicio= dpFechaInicio1.recuperar();

                    //termino
                    DateTime fechaFinTermino = dpFechaTermino.recuperar();
                    

                    //////
                    int asistentes = int.Parse(txtNumeroAsistentes.Text);
                    int personalAdicional = int.Parse(txtPersonalAdicional.Text);

                    int evento = ((comboBoxItem)cboTipo.SelectedItem).id;
                    string idMod = ((comboBoxItem2)cbModalidad.SelectedItem).id;

                    String observaciones = txtObservaciones.Text;
                    String rutCliente = txtBuscarCliente.Text;

                    Contrato con_mod = new Contrato()
                    {


                        Numero = numero,
                        Creacion = creacion,
                        Termino = termino,
                        RutCliente = rutCliente,
                        IdModalidad = idMod,
                        IdTipoEvento = evento,
                        FechaHoraInicio = fechaHoraInicio,
                        FechaHoraTermino = fechaFinTermino,
                        Asistentes = asistentes,
                        PersonalAdicional = personalAdicional,
                        Realizado = realizado,
                       ValorTotalContrato =valorc,
                        Observaciones = observaciones,
                    };

                    //BLOQUEAR EDITAR EL CONTRATO
                    txtNumero.IsEnabled = false;
                    txtBuscarCliente.IsEnabled = false;
                    txtNumero.IsEnabled = false;
                    //Convert.ToDateTime(txtNumero).ToString("dd/MM/yyyy HH:mm")
                    txtNumero.IsEnabled = false;
                    txtBuscarCliente.IsEnabled = false;
                    lblNumero.IsEnabled = false;



                    /*EVENTO

                    //inicio
                    dpFechaInicio.IsEnabled = false;
                    txtHoraInicio.IsEnabled = false;
                    txtMinutoInicio.IsEnabled = false;
                    //termino
                    dpFechaFinEvento.IsEnabled = false;
                    txtHoraTermino.IsEnabled = false;
                    txtMinutoTermino.IsEnabled = false;

                    //////
                    txtNumeroAsistentes.IsEnabled = false;
                    txtPersonalAdicional.IsEnabled = false;
                    cboTipo.IsEnabled = false;
                    txtObservaciones.IsEnabled = false;
                    txtBuscarCliente.IsEnabled = false;
                    */


                    //METODO AGREGAR DEVUELVE BOOLEAN POR ESO SE CREA VARIABLE BOOLEANA resp
                    bool resp = con_mod.Modificar();

                    /*MessageBox.Show(resp ? "Contrato Terminado" : "Contrato No Terminado");*/
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Contrato Terminado" : "Contrato No Terminado"));
                    btnTerminar.Visibility = Visibility.Hidden;
                }

                }
                        catch (ArgumentException exa) //catch excepciones hechas por el usuario
                        {
                            MessageBox.Show(exa.Message);
                        }
                        catch (Exception ex)
                        {
                            await this.ShowMessageAsync("Mensaje:",
                                  string.Format("Guardado"));
                            MessageBox.Show("Error");
                            Logger.Mensaje(ex.Message);
                        }

                    }
        



        //valor evento base

        //Valor asistentes
        private async void txtNumeroAsistentes_TextChanged_1(object sender, TextChangedEventArgs e)
        {

            //try
            //{
            if (txtNumeroAsistentes.Text != null)
            {
                Servicios.Service1 WS = new Servicios.Service1();
                double uf = WS.Uf();

             
                int asi = 0;
                if (int.TryParse(txtNumeroAsistentes.Text, out asi))
                {

                }
                else
                {
                    
                    txtNumeroAsistentes.Focus();
                    return;
                }

                int n = 0;

                if (asi >= 1 && asi <= 20)
                {
                    n = 3;
                }
                if (asi >= 21 && asi <= 50)
                {
                    n = 5;
                }
                if (asi > 50)
                {
                    int c = asi - 50;
                    n = 5;
                    int r = (c / 20);
                    n = n + r;

                }
                int v = (int)(n * uf);
                lblAsistentes.Content = v.ToString();
            }
            else
            {
                txtNumeroAsistentes.Text = "0";
            }
            //}
            //catch (ArgumentException exa) //catch excepciones hechas por el usuario
            //{
            //    MessageBox.Show(exa.Message);
            //}
            //catch (Exception ex)
            //{
            //    await this.ShowMessageAsync("Mensaje:",
            //          string.Format("Error ingreso de datos"));
            //    MessageBox.Show("Error");
            //    Logger.Mensaje(ex.Message);
            //}
        }



        //valor personal adicional
        private async void txtPersonalAdicional_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (txtPersonalAdicional.Text != null)
            {
                
                int personal = 0;
                if (int.TryParse(txtPersonalAdicional.Text, out personal))
                {

                }
                else
                {
                    
                    txtPersonalAdicional.Focus();
                    return;
                }
                double cant_uf = 0;


                if (personal == 2)
                {
                    cant_uf = 2;
                }
                if (personal == 3)
                {
                    cant_uf = 3;
                }
                if (personal == 4)
                {
                    cant_uf = 3.5;
                }
                if (personal > 4)
                {
                    int cantidad = personal - 4;
                    cant_uf = 3.5;

                    double extra = (cantidad * 0.5);
                    cant_uf = cant_uf + extra;

                }

                int v = (int)(cant_uf * uf);
                lblPersonalAdicional.Content = v.ToString();
            }
            //else
            //{
            //    await this.ShowMessageAsync("Mensaje", "Debe crear un contrato");
            //}
        }

        private void cboTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnMasHoraInicio_Click(object sender, RoutedEventArgs e)
        {

        }


        //valor total
    }
}
