namespace MilleMiettes
{
    public partial class Backoffice : Form
    {
        public Backoffice()
        {
            Business me = new Business("COM-7777", "Aux Mille Miettes", "logo.png", new Special("PROD-7777", "Mille-feuille", "mf.png", 3.5));
            File.WriteAllText(@"C:\temp\COM-7777.json", System.Text.Json.JsonSerializer.Serialize(me));
            InitializeComponent();
        }
    }
}
