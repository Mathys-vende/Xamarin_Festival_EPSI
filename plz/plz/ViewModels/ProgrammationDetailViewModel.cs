using plz.Models;
using plz.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace plz.ViewModels
{
    [QueryProperty(nameof(ProgrammationId), nameof(ProgrammationId))]
    public class ProgrammationDetailViewModel : BaseViewModel
    {
        IProgrammationStore<Programmation> progDataStore = new ApiProgrammation();
        private int programmationId;
        private DateTime? programmationDate;
        private Artiste artiste;
        private Scene scene;

        public int Id { get; set; }
        public DateTime? ProgrammationDate
        {
            get => programmationDate;
            set => SetProperty(ref programmationDate, value);
        }
        public Artiste Artiste
        {
            get => artiste;
            set => SetProperty(ref artiste, value);
        }
        public Scene Scene
        {
            get => scene;
            set => SetProperty(ref scene, value);
        }
        public int ProgrammationId
        {
            get
            {
                return programmationId;
            }
            set
            {
                programmationId = value;
                LoadProgrammationId(value);
            }
        }
        public async void LoadProgrammationId(int progId)
        {
            try
            {
                var programmation = await progDataStore.GetProgrammation(progId);
                Id = programmation.Id;
                ProgrammationDate = programmation.Heure;
                artiste = programmation.artiste;
                scene = programmation.Scene;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}