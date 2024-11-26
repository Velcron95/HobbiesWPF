using Hobbies.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbies.VM
{
    public class HobbiesViewModel : ViewModelBase
    {
        private ObservableCollection<HobbyItemViewModel> hobbies = new();

        public ObservableCollection<HobbyItemViewModel> Hobbies
        {
            get { return hobbies; }
            set { hobbies = value; RaisePropertyChanged(); }
        }

        private HobbyItemViewModel selectedHobby;

        public HobbyItemViewModel SelectedHobby
        {
            get { return selectedHobby; }
            set
            {
                selectedHobby = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand AddCommand { get; }

        public Hobby NewHobby { get; set; } = new Hobby();

        public HobbiesViewModel()
        {
            AddCommand = new DelegateCommand(AddHobby);
            LoadAsync();
        }

        public async Task LoadAsync()
        {
            if (Hobbies.Any()) return;

            

            hobbies.Add(new HobbyItemViewModel(new Hobby() { Name = "Climbing", Description = "Climbing on the walls like Spiderman" }));
            hobbies.Add(new HobbyItemViewModel(new Hobby() { Name = "Gym", Description = "Lifting them weights" }));
            hobbies.Add(new HobbyItemViewModel(new Hobby() { Name = "Gaming", Description = "Playing video games" }));
        }

        private void AddHobby(object? parameter)
        {
            Hobby hobby = new Hobby() { Name = "New Hobby", Description = "Description for new hobby" };
            var hobbyVM = new HobbyItemViewModel(hobby);
            Hobbies.Add(hobbyVM);
            SelectedHobby = hobbyVM;
        }
    }
}
