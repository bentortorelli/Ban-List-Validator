using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace BanListGui
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private DeckRules DeckRules { get; set; }

		public MainWindow()
		{
			DeckRules = new DeckRules();
			InitializeComponent();
		}

		private void LoadRulesCick(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == true)
			{
				try
				{
					DeckRules.loadRules(openFileDialog.FileName);
					TextOutput.Text = File.ReadAllText(openFileDialog.FileName);
					RuleCounter.Content = DeckRules.Rules.Count.ToString();
				} catch
				{
					TextOutput.Text = "Unable to open file.";
				}		
			}		
		}

		private void LoadDeckCick(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == true)
			{
				try
				{
					DeckRules.loadDeck(openFileDialog.FileName);
					TextOutput.Text = File.ReadAllText(openFileDialog.FileName);
					CardCounter.Content = DeckRules.Deck.Count.ToString();
				}
				catch
				{
					TextOutput.Text = "Unable to open file.";
				}
			}
		}

		private void ValidateCick(object sender, RoutedEventArgs e)
		{
			DeckRules.validate();
			if(DeckRules.Results == null)
			{
				TextOutput.Text = "Load rules and deck lists before validating.";
				return;
			}

			string output = "";
			foreach (Tuple<bool, string> result in DeckRules.Results)
			{
				output += result.Item2 + "\n";
			}
			TextOutput.Text = output;
		}
	}
}