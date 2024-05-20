

using Backend.Controllers;
using ClassLibrary;
using MySqlConnector;
using System.Text.Json;

string connectionString = @"server=localhost;user=root;password=titok;database=viragbolt";

List<Aruk> viragLista = new List<Aruk>();   //lista létrehozása
viragLista = LoadFromJson();    //itt töltődik fel

ViragListatKiir();

AdatbazisbaMent();


static List<Aruk> LoadFromJson() 
{
    string jsonContent = File.ReadAllText(@"..\..\..\viragbolt.json");  //teljes json fájl beolvasása
                                                                
    var options = new JsonSerializerOptions     //kis-nagybetű különbségek figyelmen kívül hagyása az osztály property-jei és a json változónevek között
    {
        PropertyNameCaseInsensitive = true
    };
    return JsonSerializer.Deserialize<List<Aruk>>(jsonContent, options);  //Aruk objektum listává alakítja a json text-et
}

void ViragListatKiir()
{
    foreach (var virag in viragLista)
    {
        Console.WriteLine(virag);
    }
}

void AdatbazisbaMent() //listából ment db-be
{
    FlowersController controller = new FlowersController();

    //akkor, ha még nincs backend, a kommentezett rész:
    //using MySqlConnection connection = new MySqlConnection(connectionString);
    //connection.Open();

    foreach (var virag in viragLista)
    {
        controller.CreateVirag(virag);
        //akkor, ha még nincs backend, a kommentezett rész:
        //string insertQuery = "INSERT INTO aruk (nev, kategoriaId, leiras, keszlet, ar, kepUrl) VALUES (@nev, @kategoriaId, @leiras, @keszlet, @ar, @kepUrl)";
        //using MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
        //cmd.Parameters.AddWithValue("@nev", virag.Nev);
        //cmd.Parameters.AddWithValue("@kategoriaId", virag.KategoriaId);
        //cmd.Parameters.AddWithValue("@leiras", virag.Leiras);
        //cmd.Parameters.AddWithValue("@keszlet", virag.Keszlet);
        //cmd.Parameters.AddWithValue("@ar", virag.Ar);
        //cmd.Parameters.AddWithValue("@kepUrl", virag.KepUrl);
        //cmd.ExecuteNonQuery();  //long típus szükséges a visszatért-hez
    }

    //connection.Close();
}
