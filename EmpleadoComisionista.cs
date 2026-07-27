using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa_Gestion_Empleados
{
    public class EmpleadoComisionista : Empleado
    {
        public decimal SueldoBase { get; set; }
        public decimal VentasRealizadas { get; set; }
        public decimal PorcentajeComision { get; set; }

        public EmpleadoComisionista(string nombre, string id, decimal sueldoBase, decimal ventasRealizadas, decimal porcentajeComision) : base(nombre, id)
        {
            SueldoBase = sueldoBase;
            VentasRealizadas = ventasRealizadas;
            PorcentajeComision = porcentajeComision;
        }
        public override decimal CalcularSalario()
        {
            return SueldoBase + (VentasRealizadas * PorcentajeComision);
        }
        public override string ToString()
        {
            return $"{base.ToString()} | Tipo: Comisionista | Salario: {CalcularSalario():C}";
        }
    }

    public class EmpleadoAsalariado : Empleado
    {
        public decimal SueldoMensualFijo { get; set; }
        public EmpleadoAsalariado(string nombre, string id, decimal sueldoMensualFijo) : base(nombre, id)
        {
            SueldoMensualFijo = sueldoMensualFijo;
        }
        public override decimal CalcularSalario()
        {
            return SueldoMensualFijo;
        }
        public override string ToString()
        {
            return $"{base.ToString()} | Tipo: Asalariado | Salario: {CalcularSalario():C}";
        }
    }
    public class EmpleadoPorHora : Empleado
    {
        public decimal SueldoPorHora { get; set; }
        public double HorasTrabajadas { get; set; }

        public EmpleadoPorHora(string nombre, string id, decimal sueldoPorHora, double horasTrabajadas) : base(nombre, id)
        {
            SueldoPorHora = sueldoPorHora;
            HorasTrabajadas = horasTrabajadas;
        }
        public override decimal CalcularSalario()
        {
            return SueldoPorHora * (decimal)HorasTrabajadas;
        }
        public override string ToString()
        {
            return $"{base.ToString()} | Tipo: Por Hora | Salario: {CalcularSalario():C}";
        }
    }
    public abstract class Empleado
    {
        //Atributos privados
        private string nombre;
        private string id;
        //propiedades públicas
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }
        public string Id
        {
            get => id;
            set => id = value;

        }

        //Constructor
        public Empleado(string nombre, string id)
        {
            Nombre = nombre;
            Id = id;

        }

        //metodo para calcular el salario
        public abstract decimal CalcularSalario();

        //metodo ToString
        public override string ToString()
        {
            return $"ID: {Id} | Nombre: {Nombre}";
        }
    }
    public class EmpleadoNoEncontradoException : Exception
    {
        public EmpleadoNoEncontradoException(string id)
            : base($"Error: No se encontró ningún empleado con el ID '{id}'.")
        {
        }
    }
}