using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TrueOrFalseQuiz.Models;
using TrueOrFalseQuiz.Views;
using Xamarin.Forms;

namespace TrueOrFalseQuiz.ViewModels
{
    class QuizPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public List<Question> questions;

        private string _currentQuestionText;
        public string CurrentQuestionText {
            get
            {
                return _currentQuestionText;
            }

            set
            {
                _currentQuestionText = value;
                OnPropertyChanged();
            }
        }

        private bool _currentAnswerValue;
        public bool CurrentAnswerValue
        {
            get
            {
                return _currentAnswerValue;
            }

            set
            {
                _currentAnswerValue = value;
                OnPropertyChanged();
            }
        }

        private int _totalQuestions;
        public int TotalQuestions
        {
            get
            {
                return _totalQuestions;
            }

            set
            {
                _totalQuestions = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TitleText));
            }
        }

        private int _currentQuestionNumber;
        public int CurrentQuestionNumber
        {
            get
            {
                return _currentQuestionNumber;
            }

            set
            {
                _currentQuestionNumber = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TitleText));
            }
        }

        public string TitleText
        {
            get { return $"Вопрос {_currentQuestionNumber} из {_totalQuestions}"; }
        }
        
        private int score;

        private Random random;

        public Command AnsweredTrue { get; }
        public Command AnsweredFalse { get; }
        
        public QuizPageModel()
        {
            // запустить случайный порядок вопросов
            random = new Random();

            // заполнение списка вопросов
            questions = new List<Question>()
            {
                new Question() { QuestionText="Столица Франции - Париж", Answer=true },
                new Question() { QuestionText="Столица Латвии - Таллинн", Answer=false },
                new Question() { QuestionText="Столица Литвы - Вильнюс", Answer=true },
                new Question() { QuestionText="Столица Турции - Анталия", Answer=false },
                new Question() { QuestionText="Столица Италии - Рим", Answer=true },
                new Question() { QuestionText="Столица Германии - Берлин", Answer=true },
                new Question() { QuestionText="Столица Бельгии - Брюгге", Answer=false },
                new Question() { QuestionText="Столица России - Санкт-Петербург", Answer=false },
                new Question() { QuestionText="Столица Республики Беларусь - Минск", Answer=true },
                new Question() { QuestionText="Столица Швеции - Стокгольм", Answer=true }
            };

            // инициализация значений викторины
            TotalQuestions = questions.Count;
            CurrentQuestionNumber = 1;
            score = 0;

            // загрузить первый вопрос
            LoadQuestion();

            AnsweredTrue = new Command(async () =>
            {
                Debug.WriteLine("Нажата кнопка - Верно");
                
                // проверка правильности ответа
                if (_currentAnswerValue == true) score++;

                // загрузить следующий вопрос
                if (CurrentQuestionNumber < TotalQuestions)
                {
                    // увеличить счётчик вопросов
                    CurrentQuestionNumber++;
                    LoadQuestion();
                }
                else
                {
                    Debug.WriteLine("Конец викторины");
                    await ShowResults().ConfigureAwait(false);
                }
            });

            AnsweredFalse = new Command(async () =>
            {
                Debug.WriteLine("Нажата кнопка - Неверно");
                
                // проверка верного ответа
                if (_currentAnswerValue == false) score++;
                
                // загрузить следующий вопрос
                if (CurrentQuestionNumber < TotalQuestions)
                {
                    // увеличить счётчик вопросов
                    CurrentQuestionNumber++;
                    LoadQuestion();
                } 
                else
                {
                    Debug.WriteLine("Конец викторины");
                    await ShowResults().ConfigureAwait(false);
                }
            });
        }

        private void LoadQuestion()
        {
            var index = random.Next(questions.Count);
            CurrentQuestionText = questions[index].QuestionText;
            CurrentAnswerValue = questions[index].Answer;
            questions.RemoveAt(index);
        }

        private async Task ShowResults() => await Application.Current.MainPage.Navigation.PushAsync(new ResultsPage(score, _totalQuestions)).ConfigureAwait(false);
    }
}
