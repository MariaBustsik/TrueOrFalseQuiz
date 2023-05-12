# TrueOrFalseQuiz
A simple True or False quiz built using Xamarin.Forms, serving as a learning exercise. This is a work in progress and is currently non-functional.

## Views
This project consists of three content pages:
1. MainPage
2. QuizPage
3. ResultsPage

Navigation between these pages is performed using the NavigationPage heirarchical navigation system.

## Models
This project currently contains one model:

```csharp
class Question
{
    public string QuestionText { get; set; }
    public bool Answer { get; set; }
}
```
