namespace Notes
{
    public partial class MainPage : ContentPage
    {
        string caminho = Path.Combine(FileSystem.AppDataDirectory, "nota.txt");
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

   /*     private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        } */

        private void SaveContent(object? sender, EventArgs e)
        {
            string conteudo = EditorNotas.Text;
            File.WriteAllText(caminho, conteudo);
            
        }
        private void LoadContent(object? sender, EventArgs e)
        {
            try
            {
                string conteudo = File.ReadAllText(caminho);
                CaixaTexto.Text = conteudo;
                DisplayAlert("Aviso", "Arquivo de texto carregado com sucesso!", "OK");

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }
        }
        private void DeleteContent(object? sender, EventArgs e)
        {
            if (File.Exists(caminho))
            {
                File.Delete(caminho);
                CaixaTexto.Text = "";
                DisplayAlert("Aviso", "Arquivo de texto deletado com sucesso!", "OK");

            }
        }

    }
}
