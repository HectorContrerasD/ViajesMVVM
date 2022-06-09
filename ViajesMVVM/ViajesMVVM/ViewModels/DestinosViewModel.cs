using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using ViajesMVVM.Models;
using Xamarin.Forms;
using ViajesMVVM.Views;

namespace ViajesMVVM.ViewModels
{
    public class DestinosViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Destinos> Viajes { get; set; } = new ObservableCollection<Destinos>();
        public Destinos DestinoViaje { get; set; }
        public string Error { get; set; }
        public ICommand CambiarVistaCommand { get; set; }
        public ICommand AgregarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand DetallesCommand { get; set; }
        public ICommand EditarCommand { get; set; }
        public ICommand GuardarCommand { get; set; }

        public DestinosViewModel()
        {
            CambiarVistaCommand = new Command<string>(CambiarVista);
            AgregarCommand = new Command(Agregar);
            EliminarCommand = new Command<Destinos>(Eliminar);
            DetallesCommand = new Command<Destinos>(MostrarDetalles);
            EditarCommand = new Command<Destinos>(Editar);
            GuardarCommand = new Command(GuardarDatos);
        }

        AgregarDestinoView agregarDestino;
        DetallesViajeView detallesViaje;
        EditarDestinoView editarDestino;

        int indice;
        private void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(DestinoViaje.NombreLugar))
            {
                Error = "Escriba el nombre del lugar";
            }
            if (string.IsNullOrWhiteSpace(DestinoViaje.Descripcion))
            {
                Error = "Agregue una descripción de su destino";
            }
            if (string.IsNullOrWhiteSpace(DestinoViaje.Ciudad))
            {
                Error = "Agregue la ciudad de su destino";
            }
            if (string.IsNullOrWhiteSpace(DestinoViaje.Pais))
            {
                Error = "Agregue el país de su destino";
            }
            if (DestinoViaje.PresupuestoRequerido < 0)
            {
                Error = "El presupuesto requerido no puede ser menor a $0.00";
            }
            if (string.IsNullOrWhiteSpace(DestinoViaje.ImagenLugar))
            {
                Error = "Agregue el URL de su imágen";
            }
            if (!Uri.TryCreate(DestinoViaje.ImagenLugar, UriKind.Absolute, out var uri))
            {
                Error = "Agregue una URL válida";
            }
        }
        private void GuardarDatos(object obj)
        {
            if (DestinoViaje != null)
            {
                Error = "";
                ValidarDatos();
                if (string.IsNullOrWhiteSpace(Error))
                {
                    Viajes[indice] = DestinoViaje;
                    App.Current.MainPage.Navigation.PopToRootAsync();
                }
                PropertyChange();
            }
        }

        private void Editar(Destinos obj)
        {
            throw new NotImplementedException();
        }

        private void MostrarDetalles(Destinos obj)
        {
            throw new NotImplementedException();
        }


        private void Eliminar(Destinos obj)
        {
            throw new NotImplementedException();
        }

        private void Agregar(object obj)
        {
            if (DestinoViaje != null)
            {
                Error = "";
                ValidarDatos();
                if (string.IsNullOrWhiteSpace(Error))
                {
                    Viajes.Add(DestinoViaje);
                    CambiarVista("Ver");
                }
            }
            PropertyChange();
        }

        private void CambiarVista(string vista)
        {
          if(vista =="Agregar")
            {
                Error = "";
                DestinoViaje = new Destinos();
            }
        }
        private void PropertyChange()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
