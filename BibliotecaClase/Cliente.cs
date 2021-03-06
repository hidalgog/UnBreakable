﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClase
{
   
    public class Cliente
    {
        private String _rut;

        public String Rut
        {
            get { return _rut; }
            set
            {
                if (value != null && value.Length>=11 && value.Length<=12)
                {
                    _rut = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Rut no puede estar Vacío");
                }
            }
        }

        private String _razonSocial;

        public String RazonSocial
        {
            get { return _razonSocial; }
            set
            {
                if (value != null)
                {
                    _razonSocial = value;
                }
                else
                {
                    throw new ArgumentException("- Campo RazónSocial no puede estar Vacío");
                }

            }
        }

        private String _nombreContacto;

        public String NombreContacto
        {
            get { return _nombreContacto; }
            set
            {
                if (value != null)
                {
                    _nombreContacto = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Nombre Contrato no puede estar Vacío");
                }

            }
        }

        private String _mailContacto;

        public String Mail
        {
            get { return _mailContacto; }
            set
            {
                if (value != null)
                {
                    _mailContacto = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Email no puede estar Vacío");
                }
            }
        }

        private String _direccion;

        public String Direccion
        {
            get { return _direccion; }
            set
            {
                if (value != null)
                {
                    _direccion = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Dirección no puede estar Vacío");
                }
            }
        }

        private int _telefono;

        public int Telefono
        {
            get { return _telefono; }
            set
            {
                if (value != 0 && value>=111111111 && value<999999999)
                {
                    _telefono = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Teléfono no puede estar Vacío y debe tener un largo de 9 dígitos");
                }

            }
        }

        private TipoEmpresa _emp;

        public TipoEmpresa Empresa
        {
            get { return _emp; }
            set { _emp = value; }
        }

        private ActividadEmpresa _act;

        public ActividadEmpresa Actividad
        {
            get { return _act; }
            set { _act = value; }
        }

        public Cliente()
        {

        }

        public Cliente(string rut, string razonSocial, string nombreContacto, string mail, string direccion, int telefono)
        {
            Rut = rut;
            RazonSocial = razonSocial;
            NombreContacto = nombreContacto;
            Mail = mail;
            Direccion = direccion;
            Telefono = telefono;
           
        }


    }
}