using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotesApp.View
{
    /// <summary>
    /// NotesWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NotesWindow : Window
    {
        SpeechRecognitionEngine recognizer;
        bool isRecognizing = false;

        public NotesWindow()
        {
            InitializeComponent();

            //참조 --> 참조 추가 --> System.Speech
            //내 시스템 culture를 가져옴
            var currentCulture = (from r in SpeechRecognitionEngine.InstalledRecognizers()
                                 where r.Culture.Equals(Thread.CurrentThread.CurrentCulture)
                                 select r).FirstOrDefault();
            //내 시스템에서는 recognizer가 null이라서 오류 발생..
            if(recognizer != null)
            {
                recognizer = new SpeechRecognitionEngine(currentCulture);

                GrammarBuilder builder = new GrammarBuilder();
                builder.AppendDictation();
                Grammar grammar = new Grammar(builder);

                recognizer.LoadGrammar(grammar);
                recognizer.SetInputToDefaultAudioDevice();
                recognizer.SpeechRecognized += Recofnizer_SpeechRecognized;
            }
            
        }

        private void Recofnizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string recognizedText = e.Result.Text;

            contentRichTextBox.Document.Blocks.Add(new Paragraph(new Run(recognizedText)));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void contentRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int numOfCharacters = (new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd)).Text.Length;

            statusTextBox.Text = $"Document length: {numOfCharacters} characters";
        }

        private void boldButton_Click(object sender, RoutedEventArgs e)
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
        }

        private void speechButtonClick(object sender, RoutedEventArgs e)
        {
            if(!isRecognizing)
            {
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
                isRecognizing = true;
            }
            else
            {
                recognizer.RecognizeAsyncStop();
                isRecognizing = false;
            }
        }
    }
}
