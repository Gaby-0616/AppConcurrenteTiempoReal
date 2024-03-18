using AppConcurrenteTiempoReal;
using System;
using System.Threading;
using static AppConcurrenteTiempoReal.Parque;



public class Program
{
    public static void Main(string[] args)
    {
        const int capacidadMaxima = 10;
        Parque parque = new Parque(capacidadMaxima);

        // Simular la llegada y salida de personas
        for (int i = 0; i < 10; i++)
        {
            int numeroPersona = i + 1;
            new Thread(() =>
            {
                Console.WriteLine("Persona {0} llegando al parque", numeroPersona);
                try
                {
                    parque.Entrar();
                }
                catch (ParqueCapacidadMaximaException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Thread.Sleep(1000);
                Console.WriteLine("Persona {0} saliendo del parque", numeroPersona);
                parque.Salir(numeroPersona);
            }).Start();
        }

        // Mostrar información del parque
        while (true)
        {
            Console.WriteLine("Capacidad disponible: {0}", parque.CapacidadDisponible());
            Console.WriteLine("Capacidad máxima: {0}", parque.CapacidadMaxima());
            Console.WriteLine("Estado del parque: {0}", parque.Estado());
            Thread.Sleep(1000);
        }
    }
}
