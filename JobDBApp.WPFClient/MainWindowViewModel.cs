using AKFAC0_HFT_2021222.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace JobDBApp.WPFClient
{
	public class MainWindowViewModel : ObservableRecipient
	{
		public RestCollection<Job> Jobs { get; set; }
		public RestCollection<Armor> Armors { get; set; }
		public RestCollection<Weapon> Weapons { get; set; }

		private Job selectedJob;

		public Job Selectedjob
		{
			get { return selectedJob; }
			set
			{
				SetProperty(ref selectedJob, value);
				(DeleteJobCommand as RelayCommand).NotifyCanExecuteChanged();
			}
		}

		private Armor selectedArmor;

		public Armor SelectedArmor
		{
			get { return selectedArmor; }
			set
			{
				SetProperty(ref selectedArmor, value);
				(DeleteArmorCommand as RelayCommand).NotifyCanExecuteChanged();
			}
		}

		private Weapon selectedWeapon;

		public Weapon SelectedWeapon
		{
			get { return selectedWeapon; }
			set
			{
				SetProperty(ref selectedWeapon, value);
				(DeleteWeaponCommand as RelayCommand).NotifyCanExecuteChanged();
			}
		}

		public ICommand CreateJobCommand { get; set; }
		public ICommand DeleteJobCommand { get; set; }
		public ICommand UpdateJobCommand { get; set; }


		public ICommand CreateArmorCommand { get; set; }
		public ICommand DeleteArmorCommand { get; set; }
		public ICommand UpdateArmorCommand { get; set; }

		public ICommand CreateWeaponCommand { get; set; }
		public ICommand DeleteWeaponCommand { get; set; }
		public ICommand UpdateWeaponCommand { get; set; }


		public static bool IsInDesignMode
		{
			get
			{
				var prop = DesignerProperties.IsInDesignModeProperty;
				return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
			}
		}

		public  void SetupCollections()
		{
			Jobs = new RestCollection<Job>("http://localhost:30703/", "job", "hub");
			Weapons = new RestCollection<Weapon>("http://localhost:30703/", "weapon", "hub");
			Armors = new RestCollection<Armor>("http://localhost:30703/", "armor", "hub");
		}

		public void SetupCommands()
		{
			CreateJobCommand = new RelayCommand(() =>
			{
				Jobs.Add(new Job()
				{
					Id = Jobs.Max(t => t.Id) + 1,
					Name = Selectedjob.Name,
					Role = "TANK",
				});
			});

			DeleteJobCommand = new RelayCommand(() =>
			{
				Jobs.Delete(Selectedjob.Id);
			},
			() =>
			{
				return Selectedjob != null;
			});

			UpdateJobCommand = new RelayCommand(() =>
			{

				Jobs.Update(Selectedjob);

			});

			// Armor

			CreateArmorCommand = new RelayCommand(() =>
			{
				Armors.Add(new Armor()
				{
					Id = Armors.Max(t => t.Id) + 1,
					Name = selectedArmor.Name,
				});
			});

			DeleteArmorCommand = new RelayCommand(() =>
			{
				Armors.Delete(SelectedArmor.Id);
			},
			() =>
			{
				return SelectedArmor != null;
			});

			UpdateArmorCommand = new RelayCommand(() =>
			{

				Armors.Update(SelectedArmor);

			});
			// Weapon

			CreateWeaponCommand = new RelayCommand(() =>
			{
				Weapons.Add(new Weapon()
				{
					Id = Weapons.Max(t => t.Id) + 1,
					Name = selectedWeapon.Name,
				});
			});

			DeleteWeaponCommand = new RelayCommand(() =>
			{
				Weapons.Delete(selectedWeapon.Id);
			},
			() =>
			{
				return selectedWeapon != null;
			});

			UpdateWeaponCommand = new RelayCommand(() =>
			{

				Weapons.Update(selectedWeapon);

			});
		}
		public MainWindowViewModel()
		{
			if (!IsInDesignMode)
			{
				SetupCollections();
				SetupCommands();
				Selectedjob = new Job();
				selectedArmor = new Armor();
			}
		}
	}
}
