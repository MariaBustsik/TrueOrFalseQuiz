using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrueOrFalseQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage(int score, int total)
        {
            InitializeComponent();

            ScoreText.Text = $"{score} из {total}";
        }

        private void BackToStart(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}