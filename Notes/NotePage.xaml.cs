namespace Notes;

public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

	public NotePage()
	{
		InitializeComponent();
        if (File.Exists(_fileName))
            TextEditor.Text = File.ReadAllText(_fileName);
	}


    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, TextEditor.Text);
        await DisplayAlert(nameof(NotePage), "Arquivo criado com sucesso", "Acabou");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (!File.Exists(_fileName))
        {
            await DisplayAlert("Deletar arquivo", "Deletou o arquivo", "Beleza");
            File.Delete(_fileName);

            TextEditor.Text = String.Empty;

        }
    }
     


}

