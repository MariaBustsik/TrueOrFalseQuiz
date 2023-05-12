using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueOrFalseQuiz.Views;
using Xamarin.Forms;

namespace TrueOrFalseQuiz
{
    
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void StartQuiz(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuizPage()).ConfigureAwait(false);
        }
    }
}
