using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueOrFalseQuiz.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrueOrFalseQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPage : ContentPage
    {
        public QuizPage()
        {
            InitializeComponent();

            BindingContext = new QuizPageModel();
        }
    }
}