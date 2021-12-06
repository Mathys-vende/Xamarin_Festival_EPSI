using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using plz.Models;
using plz.Services;

using Xamarin.Forms;

namespace plz.ViewModels
{
    public class ProgrammationViewModel : BaseViewModel
    {

        IProgrammationStore<Programmation> progDataStore = new ApiProgrammation(); 

        private Programmation _selectedProgrammation;
        public ObservableCollection<Programmation> Programmations { get; }
        public Command LoadProgrammationsCommand { get; }
        public Command AddProgrammationsCommand { get; }
        public Command<Programmation> ProgrammationTapped { get; }

        public ProgrammationViewModel()
        {
            Title = "Test";
            
            Programmations = new ObservableCollection<Programmation>();
            LoadProgrammationsCommand = new Command(async () => await ExecuteLoadProgrammationCommand());
            ProgrammationTapped = new Command<Programmation>(OnProgrammationSelected);
            AddProgrammationsCommand = new Command(OnAddProgrammation);
        }
        async Task ExecuteLoadProgrammationCommand()
        {
            IsBusy = true;
            try
            {
                Programmations.Clear();
                var programmations = await progDataStore.GetProgrammations();
                foreach (var programmation in programmations)
                {
                    Programmations.Add(programmation);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }
        public async void OnAppearing()
        {
            IsBusy = true;
            SelectedProgrammation = null;
        }

        public Programmation SelectedProgrammation
        {
            get => _selectedProgrammation;
            set
            {
                SetProperty(ref _selectedProgrammation, value);
                OnProgrammationSelected(value);
            }
        }
        private async void OnAddProgrammation(object obj)
        {
           // await Shell.Current.GoToAsync(nameof(NewItemPage));
        }
        async void OnProgrammationSelected(Programmation programmation)
        {
            if (programmation == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ProgrammationDetailViewModel)}?{nameof(ProgrammationDetailViewModel.ProgrammationId)}={programmation.Id}");
        }
    }
}