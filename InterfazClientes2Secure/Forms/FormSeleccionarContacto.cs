﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazClientes2Secure
{
    public partial class FormSeleccionarContacto : Form
    {
        // ------------------------------------------------------------------
        // Constantes
        // ------------------------------------------------------------------

        const string TODOS_LOS_CONTACTOS = "Todos los contactos: ";
        const string CONTACTOS_DEL_CLIENTE = "Contactos del cliente: ";


        // ------------------------------------------------------------------
        // Atributos
        // ------------------------------------------------------------------

        int IdCliente;

        // ------------------------------------------------------------------
        // Constructores
        // ------------------------------------------------------------------

        /// <summary>
        /// Crea un nuevo formulario para seleccionar contactos. Hace una lista con todos los contactos.
        /// </summary>
        /// <param name="idCliente"></param>
        public FormSeleccionarContacto()
        {
            InitializeComponent();
            buttonAceptar.Enabled = false;
            labelCliente.Text = TODOS_LOS_CONTACTOS;
            ObtenerTodosLosContactos();
            buttonAceptar.Enabled = false;
            buttonCambiarContactos.Enabled = false;
        }

        /// <summary>
        /// Crea un nuevo formulario para seleccionar contactos. Hace una lista con los contactos
        /// asociados al cliente identificado con el número pasado como parámetro.
        /// </summary>
        /// <param name="idCliente"></param>
        public FormSeleccionarContacto(int idCliente )
        {
            InitializeComponent();
            ObtenerContactosCliente(idCliente);
            buttonAceptar.Enabled = false;
            IdCliente = idCliente;
            labelCliente.Text = CONTACTOS_DEL_CLIENTE;
        }


        // ------------------------------------------------------------------
        // Métodos
        // ------------------------------------------------------------------

        /// <summary>
        /// Se ejecuta cuando cambia el elemento seleccionado en la lista.
        /// Activa el boton de aceptar si hay un elemento seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeleccionarContacto(object sender, EventArgs e)
        {
            buttonAceptar.Enabled = true;
        }

        /// <summary>
        /// Obtiene los contactos asociados con el cliente idnetificado por el id pasado
        /// como parámetro. Utiliza un query GET.
        /// </summary>
        /// <param name="idCliente"></param>
        private async void ObtenerContactosCliente(int idCliente)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Form1.DIRECCION_SERVIDOR);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));
                if (Form1.Sesion != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Form1.Sesion.access_token);

                HttpResponseMessage response = await httpClient.GetAsync(Form1.RUTA_CLIENTES + "/" + idCliente + Form1.RUTA_CONTACTOS_CLIENTE);
                if (response.IsSuccessStatusCode)
                {
                    Contact[] contactos = await response.Content.ReadAsAsync<Contact[]>();
                    listBoxContactos.Items.Clear();

                    foreach (var contacto in contactos)
                        listBoxContactos.Items.Add(contacto);
                }
            }
        }

        /// <summary>
        /// Obtiene todos los contactos. Utiliza un query GET
        /// </summary>
        private async void ObtenerTodosLosContactos()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Form1.DIRECCION_SERVIDOR);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Form1.APP_JSON));
                if (Form1.Sesion != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Form1.Sesion.access_token);

                HttpResponseMessage response = await httpClient.GetAsync(Form1.RUTA_CONTACTOS);
                if (response.IsSuccessStatusCode)
                {
                    Contact[] contactos = await response.Content.ReadAsAsync<Contact[]>();
                    listBoxContactos.Items.Clear();

                    foreach (var contacto in contactos)
                        listBoxContactos.Items.Add(contacto);
                }
            }
        }

        /// <summary>
        /// Alterna entre mostrar los contactos asociados al cliente y mostrar todos los clientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CambiarContactos(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton.Tag.ToString() == "Todos")
            {
                ObtenerTodosLosContactos();
                boton.Text = "Mostrar cliente...";
                boton.Tag = "Cliente";
                labelCliente.Text = TODOS_LOS_CONTACTOS;
            }
            else if (boton.Tag.ToString() == "Cliente")
            {
                ObtenerContactosCliente(IdCliente);
                boton.Text = "Mostrar todos...";
                boton.Tag = "Todos";
                labelCliente.Text = CONTACTOS_DEL_CLIENTE;
            }
        }

        /// <summary>
        /// Devuelve el contacto seleccionado.
        /// </summary>
        /// <returns></returns>
        public Contact DarContactoSeleccionado()
        {
            return listBoxContactos.SelectedItem as Contact;
        }

    }
}
