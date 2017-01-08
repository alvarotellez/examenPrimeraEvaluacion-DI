using examenPrimeraEvaluacion.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace examenPrimeraEvaluacion.ViewModel
{
    public class MainPageVM : clsVMBase
    {

        private ObservableCollection<Carta> _lista;
        private Carta _cartaElegida1;
        private Carta _cartaElegida2;
        private int parejasEncontradas;
        private bool _haGanado;
        private bool _esClickeable;
        DispatcherTimer timer;
        public Stopwatch miTiempo = new Stopwatch();
        private Uri imgDefault = new Uri("../Assets/anonimo.jpg", UriKind.RelativeOrAbsolute);
        private String _textoReloj;

        public MainPageVM()
        {
            _lista = new Listado().lista;
            NotifyPropertyChanged("lista");
            parejasEncontradas = 0;
            _haGanado = false;
            _esClickeable = true;


            //Reloj del tiempo transcurrido
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();

            miTiempo.Start();
        }

       
        /// <summary>
        /// Comprueba si podemos seleccionar una carta
        /// </summary>
        public bool esClickeable
        {
            get
            {
                return this._esClickeable;
            }
            set
            {
                this._esClickeable = value;
                NotifyPropertyChanged("clickeable");
            }
        }

        public String textoreloj
        {
            get
            {
                return this._textoReloj;
            }
            set
            {
                this._textoReloj = value;
                NotifyPropertyChanged("textoreloj");
            }
        }

        /// <summary>
        /// Comprueba si la seleccion es la correcta 
        /// </summary>
        public Carta cartaSeleccionada
        {
            get
            {
                return this._cartaElegida1;
            }
            set
            {

                if (_cartaElegida1 == null || _cartaElegida1 != _cartaElegida2)
                {
                    this._cartaElegida1 = value;
                    if (_cartaElegida1.uri == imgDefault)
                    {



                        _cartaElegida1.uri = this.introducirFoto(cartaSeleccionada.nombre);



                        NotifyPropertyChanged("cartaElegida1");
                        _cartaElegida2 = _cartaElegida1;
                    }


                }

                else
                {
                    _cartaElegida1 = value;

                    if (!(_cartaElegida1 == _cartaElegida2) && _cartaElegida1.uri == imgDefault)
                    {
                        _cartaElegida1.uri = this.introducirFoto(cartaSeleccionada.nombre);

                        NotifyPropertyChanged("cartaElegida1");

                    }
                    this.retrasasegundo();
                }
            }
        }
        public bool haganado
        {
            get
            {
                return this._haGanado;
            }
            set
            {
                this._haGanado = value;
                NotifyPropertyChanged("haganado");
            }
        }
        public Carta cartaaux
        {
            get
            {
                return this._cartaElegida2;
            }
            set
            {
                this._cartaElegida2 = value;
            }
        }

        public ObservableCollection<Carta> lista
        {
            get
            {
                return this._lista;
            }
            set
            {
                this._lista = value;
                NotifyPropertyChanged("lista");
            }
        }
        
        /// <summary>
        /// Aignacion de la foto dependiendo del nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>

        public Uri introducirFoto(String nombre)
        {
            Uri uri = null;

            switch (nombre)
            {
                case "AR-15":
                    uri = new Uri("/Assets/AR-15.jpg", UriKind.RelativeOrAbsolute);
                    break;
                case "Ballesta":
                    uri = new Uri("/Assets/Ballesta.jpg", UriKind.RelativeOrAbsolute);
                    break;
                case "Colt":
                    uri = new Uri("/Assets/Colt.jpg", UriKind.RelativeOrAbsolute);
                    break;
                case "Daryl":
                    uri = new Uri("/Assets/Daryl.jpg", UriKind.RelativeOrAbsolute);
                    break;
                case "Katana":
                    uri = new Uri("/Assets/Katana.jpg", UriKind.RelativeOrAbsolute);
                    break;
                case "Lucille":
                    uri = new Uri("/Assets/Lucille.jpg", UriKind.RelativeOrAbsolute);
                    break;
                case "Martillo":
                    uri = new Uri("/Assets/Martillo.jpg", UriKind.RelativeOrAbsolute);
                    break;
                case "Michonne":
                    uri = new Uri("/Assets/Michonne.jpg", UriKind.RelativeOrAbsolute);
                    break;
                case "Negan":
                    uri = new Uri("/Assets/Negan.jpg", UriKind.RelativeOrAbsolute);
                    break;
                case "Rick":
                    uri = new Uri("/Assets/Rick.jpg", UriKind.RelativeOrAbsolute);
                    break;
                case "Sasha":
                    uri = new Uri("/Assets/Sasha.jpg", UriKind.RelativeOrAbsolute);
                    break;
                case "Tyreese":
                    uri = new Uri("/Assets/Tyreese.jpg", UriKind.RelativeOrAbsolute);
                    break;
            }

            return uri;
        }

        /// <summary>
        /// Metodo que va añadiendo segundos al tiempo dependiendo de los errores que cometa el usuario
        /// </summary>
        private async void retrasasegundo()
        {

            if (_cartaElegida2.id == _cartaElegida1.id)
            {
                parejasEncontradas++;
                _cartaElegida1 = null;
                _cartaElegida2 = null;
                NotifyPropertyChanged("cartaElegida1");
            }
            else
            {
                esClickeable = false;
                await Task.Delay(1000);
                esClickeable = true;
                _cartaElegida1.uri = imgDefault;

                NotifyPropertyChanged("cartaSeleccionada");


                _cartaElegida1 = _cartaElegida2;
                _cartaElegida1.uri = imgDefault;

                NotifyPropertyChanged("cartaSeleccionada");

                _cartaElegida1 = null;
                _cartaElegida2 = null;
                NotifyPropertyChanged("cartaSeleccionada");
            }

            if (parejasEncontradas == 6)
            {
                haganado = true;
                miTiempo.Stop();
            }
        }
    }
}
