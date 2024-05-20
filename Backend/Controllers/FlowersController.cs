using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlowersController : ControllerBase
    {
        const string connectionString = "server=localhost;user=root;password=titok;database=viragbolt";

        //összes virág lekérdezése
        [HttpGet]
        public IActionResult GetViragok()
        {
            List<Aruk> listViragok = new List<Aruk>();   //lista létrehozása modell osztály alapján listViragok néven
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            //lekérdezés db-bõl:
            string query = "SELECT a.id, a.nev, a.kategoriaId, a.leiras, a.keszlet, a.ar, a.kepUrl, k.nev FROM aruk a INNER JOIN kategoriak k ON a.kategoriaId = k.id";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!
                                                                // Ha DELETE, UPDATE, INSERT -> ExecuteNonQuery !!!
            while (reader.Read())   // Amíg vannak sorok a resultban, beolvassa
            {
                int id = reader.GetInt32(0);
                string nev = reader.GetString(1);
                int kategoriaId = reader.GetInt32(2);
                string leiras = reader.GetString(3);
                int keszlet = reader.GetInt32(4);
                int ar = reader.GetInt32(5);
                string kepUrl = reader.GetString(6);
                string kategoriaNev = reader.GetString(7);
                //osztály neve:
                Aruk viragok = new Aruk()
                {
                    Id = id,
                    Nev = nev,
                    KategoriaId = kategoriaId,
                    Leiras = leiras,
                    Keszlet = keszlet,
                    Ar = ar,
                    KepUrl = kepUrl,
                    Kategoria = new Kategoriak()  //ez az osztály a Kategoria táblából az id és a nev paraméter
                    {
                        Id = kategoriaId,
                        Nev = kategoriaNev
                    }
                };
                listViragok.Add(viragok);
            }

            connection.Close();

            return Ok(listViragok);
        }

        //virág lekérdezése Id alapján
        [HttpGet("viragId")]
        public IActionResult GetViragokById(int viragId)
        {
            List<Aruk> listViragok = new List<Aruk>();   //lista létrehozása modell osztály alapján listViragok néven
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            //lekérdezés db-bõl:
            string query = "SELECT a.id, a.nev, a.kategoriaId, a.leiras, a.keszlet, a.ar, a.kepUrl, k.nev FROM aruk a INNER JOIN kategoriak k ON a.kategoriaId = k.id WHERE a.id = @id";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", viragId);

            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!
                                                                // Ha DELETE, UPDATE, INSERT -> ExecuteNonQuery !!!
            while (reader.Read())   // Amíg vannak sorok a resultban, beolvassa
            {
                int id = reader.GetInt32(0);
                string nev = reader.GetString(1);
                int kategoriaId = reader.GetInt32(2);
                string leiras = reader.GetString(3);
                int keszlet = reader.GetInt32(4);
                int ar = reader.GetInt32(5);
                string kepUrl = reader.GetString(6);
                string kategoriaNev = reader.GetString(7);
                //osztály neve:
                Aruk viragok = new Aruk()
                {
                    Id = id,
                    Nev = nev,
                    KategoriaId = kategoriaId,
                    Leiras = leiras,
                    Keszlet = keszlet,
                    Ar = ar,
                    KepUrl = kepUrl,
                    Kategoria = new Kategoriak()  //ez az osztály a Kategoria táblából az id és a nev paraméter
                    {
                        Id = kategoriaId,
                        Nev = kategoriaNev
                    }
                };
                listViragok.Add(viragok);
            }

            connection.Close();

            if (listViragok.Count() > 0)    // megnézzük, van-e az a virág
                return Ok(listViragok);

            return NotFound("error: A virág nem található");
        }

        //lekérdezi egy virág nevét és leírását db-bõl azonosító alapján
        [HttpGet("{viragId}/details")]
        public IActionResult GetViragNevLeiras(int viragId)
        {
            List<Virag> listVirag = new List<Virag>();   //lista létrehozása modell osztály alapján listVirag néven
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            //lekérdezés db-bõl:
            string query = "SELECT id, nev, leiras FROM aruk WHERE id = @id";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", viragId);    //itt csak egy lehet

            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!
                                                                // Ha DELETE, UPDATE, INSERT -> ExecuteNonQuery !!!
            while (reader.Read())   // Amíg vannak sorok a resultban, beolvassa
            {
                //osztály neve:
                Virag viragok = new Virag()
                {
                    Id = reader.GetInt32(0),
                    Nev = reader.GetString(1),
                    Leiras = reader.GetString(2)
                };
                listVirag.Add(viragok);
            }

            connection.Close();

            if (listVirag.Count() > 0)    // megnézzük, van-e az a virág
                return Ok(listVirag);

            return NotFound("error: A virág nem található");
        }


        //új virág hozzáadása adatbázishoz
        [HttpPost]
        public IActionResult CreateVirag([FromBody] Aruk virag)
        {
            // Ellenõrizzük a modell érvényességét
            if (virag == null ||
                virag.Nev == null ||
                virag.KategoriaId <= 0 ||
                virag.Leiras == null ||
                virag.Keszlet <= 0 ||
                virag.Ar <= 0 ||
                virag.KepUrl == null)
            {
                return BadRequest("Hiányos adatok");
            }

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = "INSERT INTO aruk (nev, kategoriaId, leiras, keszlet, ar, kepUrl) VALUES (@nev, @kategoriaId, @leiras, @keszlet, @ar, @kepUrl)";
            using MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@nev", virag.Nev);
            cmd.Parameters.AddWithValue("@kategoriaId", virag.KategoriaId);
            cmd.Parameters.AddWithValue("@leiras", virag.Leiras);
            cmd.Parameters.AddWithValue("@keszlet", virag.Keszlet);
            cmd.Parameters.AddWithValue("@ar", virag.Ar);
            cmd.Parameters.AddWithValue("@kepUrl", virag.KepUrl);


            cmd.ExecuteNonQuery();  //long típus szükséges a visszatért-hez
            long insertedViragId = cmd.LastInsertedId;  //LastInsertedId-el kérem vissza az id-t, amit AutoIncrement-el hoz létre

            connection.Close();

            return Created("id", insertedViragId);
        }

        // virág módosítása
        [HttpPut]
        public IActionResult UpdateVirag([FromBody] Aruk virag)            
        {
            // Ellenõrizzük a modell érvényességét
            if (virag == null ||
                virag.Id <= 0 ||
                virag.Nev == null ||
                virag.KategoriaId <= 0 ||
                virag.Leiras == null ||
                virag.Keszlet <= 0 ||
                virag.Ar <= 0 ||
                virag.KepUrl == null)
            {
                return BadRequest("Hiányos adatok");
            }

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = "UPDATE aruk SET nev = @nev, kategoriaId = @kategoriaId, leiras = @leiras, keszlet = @keszlet, ar = @ar, kepUrl = @kepUrl  WHERE id = @id";
            using MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@id", virag.Id);
            cmd.Parameters.AddWithValue("@nev", virag.Nev);
            cmd.Parameters.AddWithValue("@kategoriaId", virag.KategoriaId);
            cmd.Parameters.AddWithValue("@leiras", virag.Leiras);
            cmd.Parameters.AddWithValue("@keszlet", virag.Keszlet);
            cmd.Parameters.AddWithValue("@ar", virag.Ar);
            cmd.Parameters.AddWithValue("@kepUrl", virag.KepUrl);

            cmd.ExecuteNonQuery();

            connection.Close();

            return Ok();
        }

        //virág törlése
        [HttpDelete]
        public IActionResult DeleteVirag(int id)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string deleteQuery = "DELETE FROM aruk WHERE id = @id";
            using MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
            cmd.Parameters.AddWithValue("@id", id);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            if (result == 0)
                return NotFound(result);

            return Ok();
        }
    }
}