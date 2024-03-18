using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AppConcurrenteTiempoReal
{
    public class Parque
    {
        private Semaphore _semaforo;
        private int _capacidadMaxima;

        public Parque(int capacidadMaxima)
        {
            if (capacidadMaxima < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacidadMaxima), "La capacidad máxima no puede ser negativa");
            }

            _semaforo = new Semaphore(capacidadMaxima, capacidadMaxima);
            _capacidadMaxima = capacidadMaxima;
        }

        public void Entrar()
        {
            try
            {
                _semaforo.WaitOne();
            }
            catch (SemaphoreFullException ex)
            {
                throw new ParqueCapacidadMaximaException("Capacidad máxima del parque alcanzada", ex);
            }
            Console.WriteLine("Persona ha entrado al parque");
        }

        public void Salir(int idPersona)
        {
            if (idPersona <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(idPersona), "El ID de la persona no puede ser negativo o cero");
            }

            if (_semaforo.Release() < 10)
            {
                _semaforo.Release();
            }

            Console.WriteLine("Persona ha salido del parque");
        }

        public int CapacidadDisponible()
        {
            int capacidadDisponible = ConsultarCapacidadDisponible();

            if (capacidadDisponible > 0)
            {
                _semaforo.Release();
            }
            else
            {
                Console.WriteLine("El parque está lleno. No se puede entrar");
            }

            return capacidadDisponible;
        }

        public int CapacidadMaxima()
        {
            return _capacidadMaxima;
        }

        public EstadoParque Estado()
        {
            if (_semaforo.Release() == _capacidadMaxima)
            {
                return EstadoParque.Abierto;
            }
            else
            {
                return EstadoParque.Cerrado;
            }
        }


        public int ConsultarCapacidadDisponible()
        {
            if (_semaforo.Release() < 10)
            {
                _semaforo.Release();
            }
            else
            {
                Console.WriteLine("El parque está lleno");
            }
            return _semaforo.Release();
        }


    }



    public enum EstadoParque
    {
        Abierto,
        Cerrado
    }

    public class ParqueCapacidadMaximaException : Exception
    {
        public ParqueCapacidadMaximaException()
        {
        }

        public ParqueCapacidadMaximaException(string message) : base(message)
        {
        }

        public ParqueCapacidadMaximaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }


}
