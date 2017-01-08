using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenPrimeraEvaluacion.Models
{
    public class Listado
    {
        public ObservableCollection<Carta> lista { get; set; }

        /// <summary>
        /// Creamos el listado de los personajes y sus armas
        /// </summary>
        public Listado()
        {
            lista = new ObservableCollection<Carta>();
            //Le ponemos a cada personaje el mismo indice que a su arma para saber cuando ha acertado
            lista.Add(new Carta(1,new Uri("/Assets/anonimo.jpg", UriKind.RelativeOrAbsolute),"AR-15" ));
            lista.Add(new Carta(1, new Uri("/Assets/anonimo.jpg", UriKind.RelativeOrAbsolute), "Sasha"));
            lista.Add(new Carta(2, new Uri("/Assets/anonimo.jpg", UriKind.RelativeOrAbsolute), "Ballesta"));
            lista.Add(new Carta(2, new Uri("/Assets/anonimo.jpg", UriKind.RelativeOrAbsolute), "Daryl"));
            lista.Add(new Carta(3, new Uri("/Assets/anonimo.jpg", UriKind.RelativeOrAbsolute), "Colt"));
            lista.Add(new Carta(3, new Uri("/Assets/anonimo.jpg", UriKind.RelativeOrAbsolute), "Rick"));    
            lista.Add(new Carta(4, new Uri("/Assets/anonimo.jpg", UriKind.RelativeOrAbsolute), "Katana"));
            lista.Add(new Carta(4, new Uri("/Assets/anonimo.jpg", UriKind.RelativeOrAbsolute), "Michonne"));
            lista.Add(new Carta(5, new Uri("/Assets/anonimo.jpg", UriKind.RelativeOrAbsolute), "Lucille"));
            lista.Add(new Carta(5, new Uri("/Assets/anonimo.jpg", UriKind.RelativeOrAbsolute), "Negan"));
            lista.Add(new Carta(6, new Uri("/Assets/anonimo.jpg", UriKind.RelativeOrAbsolute), "Martillo"));
            lista.Add(new Carta(6, new Uri("/Assets/anonimo.jpg", UriKind.RelativeOrAbsolute), "Tyreese"));

            //FALTA HACER EL ALEATORIO
        }
    }
}
